using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //TODO: create guess variable to track what part of the pattern the user is at
        int tracker = 0;
        Random Random = new Random();

        SoundPlayer blueSound = new SoundPlayer(Properties.Resources.blue);
        SoundPlayer redSound = new SoundPlayer(Properties.Resources.red);
        SoundPlayer greenSound = new SoundPlayer(Properties.Resources.green);
        SoundPlayer yellowSound = new SoundPlayer(Properties.Resources.yellow);
        SoundPlayer mistakeSound = new SoundPlayer(Properties.Resources.mistake);
        SoundPlayer hellModeMistake = new SoundPlayer(Properties.Resources.altMistake);

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //TODO: clear the pattern list from form1, refresh, pause for a bit, and run ComputerTurn()
            Form1.pattern.Clear();
            Refresh();
            Thread.Sleep(1000);
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list
            int random = Random.Next(0, 4);
            Form1.pattern.Add(random);

            if (Form1.ultraHardMode == true)
            {
                int random2 = Random.Next(0, 4);
                Form1.pattern.Add(random2);
            }

            if(Form1.hellMode == true)
            {
                for(int i = 0; i < 10; i++)
                {
                    int hellRandom = Random.Next(0, 4);
                    Form1.pattern.Add(hellRandom);
                }
            }
            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            for(int i = 0; i < Form1.pattern.Count; i++)
            {
                if(Form1.pattern[i] == 0)
                {
                    greenButton.BackColor = Color.LimeGreen;
                    Refresh();
                    greenSound.Play();
                    Thread.Sleep(Form1.downtime);
                    greenButton.BackColor = Color.ForestGreen;
                    Refresh();
                    Thread.Sleep(Form1.downtime);
                }
                else if(Form1.pattern[i] == 1)
                {
                    redButton.BackColor = Color.Red;
                    Refresh();
                    redSound.Play();
                    Thread.Sleep(Form1.downtime);
                    redButton.BackColor = Color.DarkRed;
                    Refresh();
                    Thread.Sleep(Form1.downtime);
                }
                else if(Form1.pattern[i] == 2)
                {
                    blueButton.BackColor = Color.Blue;
                    Refresh();
                    blueSound.Play();
                    Thread.Sleep(Form1.downtime);
                    blueButton.BackColor = Color.DarkBlue;
                    Refresh();
                    Thread.Sleep(Form1.downtime);
                }
                else
                {
                    yellowButton.BackColor = Color.Yellow;
                    Refresh();
                    yellowSound.Play();
                    Thread.Sleep(Form1.downtime);
                    yellowButton.BackColor = Color.Goldenrod;
                    Refresh();
                    Thread.Sleep(Form1.downtime);
                }
            }
            //TODO: get guess index value back to 0
            tracker = 0;
        }

        public void GameOver()
        {
            if(Form1.hellMode == true)
            {
                hellModeMistake.Play();
                Thread.Sleep(3000);
                Application.Exit();
            }
            mistakeSound.Play();
            //TODO: Play a game over sound
            Form f = this.FindForm();
            f.Controls.Remove(this);

            GameOverScreen go = new GameOverScreen();

            f.Controls.Add(go);

            go.Location = new Point((this.Width - go.Width) / 2, (this.Height - go.Height) / 2);
            //TODO: close this screen and open the GameOverScreen

        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            //TODO: is the value at current guess index equal to a green. If so:
                // light up button, play sound, and pause
                // set button colour back to original
                // add one to the guess index
                // check to see if we are at the end of the pattern. If so:
                    // call ComputerTurn() method
                // else call GameOver method
            if(Form1.pattern[tracker] == 0)
            {
                greenButton.BackColor = Color.LimeGreen;
                Refresh();
                greenSound.Play();
                Thread.Sleep(Form1.downtime);
                greenButton.BackColor = Color.ForestGreen;
                Refresh();
                Thread.Sleep(Form1.downtime);
                tracker++;
                if (tracker == Form1.pattern.Count) ComputerTurn();
            }
            else GameOver();
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[tracker] == 1)
            {
                redButton.BackColor = Color.Red;
                Refresh();
                redSound.Play();
                Thread.Sleep(Form1.downtime);
                redButton.BackColor = Color.DarkRed;
                Refresh();
                Thread.Sleep(Form1.downtime);
                tracker++;
                if (tracker == Form1.pattern.Count) ComputerTurn();
            }
            else GameOver();
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[tracker] == 3)
            {
                yellowButton.BackColor = Color.Yellow;
                Refresh();
                yellowSound.Play();
                Thread.Sleep(Form1.downtime);
                yellowButton.BackColor = Color.Goldenrod;
                Refresh();
                Thread.Sleep(Form1.downtime);
                tracker++;
                if (tracker == Form1.pattern.Count) ComputerTurn();
            }
            else GameOver();
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[tracker] == 2)
            {
                blueButton.BackColor = Color.Blue;
                Refresh();
                blueSound.Play();
                Thread.Sleep(Form1.downtime);
                blueButton.BackColor = Color.DarkBlue;
                Refresh();
                Thread.Sleep(Form1.downtime);
                tracker++;
                if (tracker == Form1.pattern.Count) ComputerTurn();
            }
            else GameOver();
        }
    }
}