using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Threading.Tasks;

namespace Memory_Matching
{
    public partial class MainForm : Form
    {
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        Label firstClicked = null;
        Label secondClicked = null;

        //SoundPlayer backgroundSound;
        SoundPlayer clickSound;
        SoundPlayer matchingCard;

        public MainForm()
        {
            InitializeComponent();
            //backgroundSound = new SoundPlayer("web-design-technology-background.wav");
            //backgroundSound.Play();
            
            clickSound = new SoundPlayer("click.wav");
            matchingCard = new SoundPlayer("matching card.wav");
            AssignIconsToSquares();
        }

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLable = control as Label; //преобразование контрола в лэйбл

                if (iconLable != null) //если преобразование удалось
                {
                    int randomNumber = random.Next(icons.Count); //выбирается рандомая "иконка"
                    iconLable.Text = icons[randomNumber]; //присваивается каждому лэйблу
                    iconLable.ForeColor = iconLable.BackColor; //скрываем иконку
                    icons.RemoveAt(randomNumber); //удаляем из списка иконку (чтобы не повторялись много раз)
                }
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            

            if (timer1.Enabled)
            {
                return;
            }

            Label clickedLabel = sender as Label; //преобразование объекта в лэйбл

            if (clickedLabel != null) //если не удалось преобразовать, код ниже не будет выполнен
            {
                clickSound.Play();
                if (clickedLabel.ForeColor == Color.Black) //если цвет лэйбла черный значит иконка выбрана
                {                
                    return;
                }

                if (firstClicked == null) //иконка еще не выбрана
                {
                    
                    firstClicked = clickedLabel; //есть первое нажатие
                    firstClicked.ForeColor = Color.Black; //меняем цвет на черный
                    return;
                }
                
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                
                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {                
                    matchingCard.Play();
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                    {
                        return;
                    }
                }
            }

            MessageBox.Show("You matched all the icons!", "Congratulations!");
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            


        }
    }
}
