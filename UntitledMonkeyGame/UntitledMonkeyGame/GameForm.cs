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
        private Tree przeszkoda;
        private Banany banan;
        private GamePanel myGame;


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

            this.przeszkoda = new Tree();
            przeszkoda.Location = new Point(600, myGame.Height -  przeszkoda.Height);
            
            this.banan = new Banany();
            banan.Location = new Point(400, myGame.Height -banan.Height);

            myGame.Controls.Add(banan);
            myGame.Controls.Add(player);
            myGame.Controls.Add(przeszkoda);
            timergame.Start();
        }

        private void GameTimer(object sender, EventArgs e)
        {

            if (player.Jumping)
            {
                if (!player.IsAirborne)
                {
                    player.JumpSpeed = 30;
                    player.IsAirborne = true;
                }
                if (player.IsAirborne)
                {
                    player.Top -= player.JumpSpeed;
                    if (player.JumpSpeed > -(2 * 30)) player.JumpSpeed-=5;
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
                        t.Left -= 20;
                    }
                    else if (t.Left <= 0)
                    {
                        t.Left += 1000;
                    }

                }
            }

            if(player.Bounds.IntersectsWith(przeszkoda.Bounds))
                {
                    timergame.Stop();
                    MessageBox.Show("Game Over");
                }
            if (player.Bounds.IntersectsWith(banan.Bounds))
            {
                //this.Text += "1";
                //this.Controls.Remove(banan);
                
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
