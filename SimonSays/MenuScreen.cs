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
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            Form1.downtime = 500;
            //TODO: remove this screen and start the GameScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            GameScreen gs = new GameScreen();

            f.Controls.Add(gs);

            gs.Location = new Point((this.Width - gs.Width) / 2, (this.Height - gs.Height) / 2);
        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            //TODO: end the application
            Application.Exit();
        }

        private void hardModeButton_Click(object sender, EventArgs e)
        {
            Form1.downtime = 100;
            Form f = this.FindForm();
            f.Controls.Remove(this);

            GameScreen gs = new GameScreen();

            f.Controls.Add(gs);

            gs.Location = new Point((this.Width - gs.Width) / 2, (this.Height - gs.Height) / 2);
        }

        private void ultraHardMode_Click(object sender, EventArgs e)
        {
            Form1.downtime = 100;
            Form1.ultraHardMode = true;
            Form f = this.FindForm();
            f.Controls.Remove(this);

            GameScreen gs = new GameScreen();

            f.Controls.Add(gs);

            gs.Location = new Point((this.Width - gs.Width) / 2, (this.Height - gs.Height) / 2);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            hellMode.Visible = true;
        }

        private void hellMode_Click(object sender, EventArgs e)
        {
            Form1.hellMode = true;
            Form1.downtime = 100;
            Form f = this.FindForm();
            f.Controls.Remove(this);

            GameScreen gs = new GameScreen();

            f.Controls.Add(gs);

            gs.Location = new Point((this.Width - gs.Width) / 2, (this.Height - gs.Height) / 2);
        }
    }
}
