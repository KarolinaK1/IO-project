using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UntitledMonkeyGame
{
    public partial class GameForm : Form
    {
        private Monkey player;
        private GamePanel myGame;
        private int jakistimer;
        private int GameScore;
        Random rand = new Random();
        public GameForm()
        {
            InitializeComponent();
            GameReset();
        }

        private void GameReset()
        {
            myGame = new GamePanel();
            myGame.Location = new Point(0, 0);
            this.Controls.Add(myGame);

            this.Width = 1000;
            this.Height = 500;
            myGame.Dock = DockStyle.Fill;

            var backgroundColor = System.Drawing.Color.FromArgb(8, 99, 5);
            this.BackColor = backgroundColor;

            this.player = new Monkey();
            player.Location = new Point(200, myGame.Height - player.Height);
            myGame.Controls.Add(player);
            
            timergame.Start();
        }

        private void GameTimer(object sender, EventArgs e)
        {
            GameScore = 0;
            jakistimer += 1;
            this.Text = "Score: " + GameScore;
            if (jakistimer % 25 == 0)
            { 

                Random rnd = new Random();
                int dice = rnd.Next(1, 7);
                if (dice > 2)
                {
                    Tree przeszkoda = new Tree();
                    przeszkoda.Location = new Point(myGame.Width, myGame.Height - przeszkoda.Height);
                    myGame.Controls.Add(przeszkoda);

                }
                else
                {
                    Banany banan = new Banany();
                    banan.Location = new Point(myGame.Width, myGame.Height - banan.Height);
                    myGame.Controls.Add(banan);
                }
                
            }

            if (player.Jumping)
            {
                if (!player.IsAirborne)
                {
                    player.JumpSpeed = 40;
                    player.IsAirborne = true;
                }
                if (player.IsAirborne)
                {
                    player.Top -= player.JumpSpeed;
                    if (player.JumpSpeed > -(2 * 40)) player.JumpSpeed-=4;
                }

            }
            
            if (player.Top == Height-(2*player.Height) && player.IsAirborne == true)
            {
                player.IsAirborne = false;
                player.Jumping = false;
            }

            foreach(Control t in myGame.Controls)
            {
                if (t is PictureBox && ( (string)t.Tag == "obstacle" || (string)t.Tag == "Powerup"))
                {

                    if(t.Left > 0)
                    {
                        t.Left -= 15;
                    }
                    if (t.Left <= 0)
                    {
                        myGame.Controls.Remove(t);
                        t.Name = null;
                    }
                    if (player.Bounds.IntersectsWith(t.Bounds) && (string)t.Tag == "Powerup")
                    {
                        GameScore += 2;
                        
                        myGame.Controls.Remove(t);
                        t.Name = null;
                    }
                    if (player.Bounds.IntersectsWith(t.Bounds) && (string)t.Tag == "obstacle")
                    {
                        timergame.Stop();
                        MessageBox.Show("Game Over");
                    }
                }
            }

            
            
            


        }


        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && player.Jumping == false)
            {
                player.Jumping = true;


            }
        }
    }
}
