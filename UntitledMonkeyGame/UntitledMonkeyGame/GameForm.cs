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
            this.Text = "Score: " + GameScore;
            jakistimer += 1;
            if (jakistimer % 35 == 0)
            { 

                Random rnd = new Random();
                int dice = rnd.Next(1, 8);
                if (dice > 0)
                {
                    Tree przeszkoda = new Tree();
                    przeszkoda.Width = 200;
                    przeszkoda.Height = 90;
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
                player.Top -= player.JumpSpeed;
                player.JumpSpeed -= 6;
                if (player.JumpSpeed <= 0)
                {
                    player.Jumping = false;
                    player.Falling = true;
                    player.FallSpeed = 0;
                }
            }
            if (player.Falling)
            {
                player.Top += player.FallSpeed;
                player.FallSpeed += 6;
                if (player.Bottom >= myGame.Height) player.Falling = false;
            }

            if (player.Bottom + player.FallSpeed > myGame.Height)
            {
                player.FallSpeed = myGame.Height - player.Bottom;
            }

            foreach (Control t in myGame.Controls)
            {
                if (t is PictureBox && ( (string)t.Tag == "obstacle" || (string)t.Tag == "Powerup"))
                {

                    if(t.Left > -t.Width)
                    {
                        t.Left -= 15;
                    }
                    if (t.Left <= -t.Width)
                    {
                        myGame.Controls.Remove(t);
                    }
                    if (player.Bounds.IntersectsWith(t.Bounds) && (string)t.Tag == "Powerup")
                    {
                        GameScore ++;
                        myGame.Controls.Remove(t);
                    }
                    if (player.Bounds.IntersectsWith(t.Bounds) && (string)t.Tag == "obstacle")
                    {
                        timergame.Stop();
                        MessageBox.Show("Game Over");
                    }
                    if((string)t.Tag == "obstacle")
                    {
                        if( player.Bottom + player.FallSpeed > t.Top && player.Right > t.Left && player.Left < t.Right)
                        {
                            player.FallSpeed = t.Top - player.Bottom;
                        }
                        if (player.Bottom  == t.Top && player.Right > t.Left && player.Left < t.Right && player.Falling == true)
                        {
                            player.Falling = false;
                        }
                        if (player.Bottom == t.Top &&  player.Falling == false && player.Left > t.Right )
                        {
                            player.Falling = true;
                            player.FallSpeed = 0;
                        }


                    }
                    
                    

                }
            }

            
            
            


        }


        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && player.Jumping == false && !player.Falling)
            {
                player.JumpSpeed = 40;
                player.Jumping = true;


            }
        }
    }
}
