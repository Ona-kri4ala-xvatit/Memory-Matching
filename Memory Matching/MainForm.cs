using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Matching
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        private void AssignIconsToSquares()
        {
            foreach(Control control in tableLayoutPanel1.Controls) 
            {
                Label iconLable = control as Label; //преобразование контрола в лэйбл

                if(iconLable != null) //если преобразование удалось
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
            Label clickedLabel = sender as Label; //преобразование объекта в лэйбл

            if(clickedLabel != null) //если не удалось преобразовать, код ниже не будет выполнен
            {
                if(clickedLabel.ForeColor == Color.Black) //если цвет лэйбла черный значит иконка выбрана
                {
                    return;
                }
                clickedLabel.ForeColor = Color.Black; //значок не был выбран, поэтому меняем цвет лэйбла на черный
            }
        }
    }
}
