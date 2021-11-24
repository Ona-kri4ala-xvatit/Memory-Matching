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
                    //iconLable.ForeColor = iconLable.BackColor; //скрываем иконку
                    icons.RemoveAt(randomNumber); //удаляем из списка иконку (чтобы не повторялись много раз)
                }
            }
        }
    }
}
