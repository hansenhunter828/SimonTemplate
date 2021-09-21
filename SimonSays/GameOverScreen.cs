using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            //TODO: show the length of the pattern
            patternLabel.Text += $"{Form1.pattern.Count}";
            if (Form1.pattern.Count < 5)
            {
                patternLabel.Text += "\n\nYou a gold fish";
            }
            else if (Form1.pattern.Count > 6 && Form1.pattern.Count < 10)
            {
                patternLabel.Text += "\n\nNot to bad";
            }
            else if (Form1.pattern.Count > 11 && Form1.pattern.Count < 15)
            {
                patternLabel.Text += "\n\nYour starting to impress me";
            }
            else if (Form1.pattern.Count > 16 && Form1.pattern.Count < 20)
            {
                patternLabel.Text += "\n\nIm proud of you";
            }
            else if (Form1.pattern.Count < 21)
            {
                patternLabel.Text += "\n\nCome join me in the god realm";
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //TODO: close this screen and open the MenuScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            MenuScreen ms = new MenuScreen();

            f.Controls.Add(ms);

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }
    }
}
