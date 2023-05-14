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
    public partial class restartImage : Form
    {
        private Monkey player;
        private GamePanel myGame;
        private int jakistimer;
        private int GameScore = 0;
        private int gameLevel = 0;
        Random rand = new Random();
        Timer obstacleTimer = new Timer();
        private int obstacleSpeed;
        public restartImage()
        {
            InitializeComponent();
            GameReset();
        }

        private void GameReset()
        {
            timergame.Stop();
            myGame = new GamePanel();
            myGame.Location = new Point(0, 0);
            this.Controls.Add(myGame);

            this.Width = 1000;
            this.Height = 500;
            myGame.Dock = DockStyle.Fill;

            //myGame.BackgroundImage = Properties.Resources.grass1;
            this.BackColor = Color.SkyBlue;
            
            this.player = new Monkey();
            player.Location = new Point(200, myGame.Height - player.Height);
            myGame.Controls.Add(player);

            GameScore = 0;
            scoreText.Text = "Score: 0";
            retryImage.Enabled = false;
            retryImage.Visible = false;

            obstacleSpeed = 10;

            gameLevel = 0;
            obstacleTimer.Start();
            obstacleTimer.Interval = 2000;
            obstacleTimer.Tick += ObstacleTimer_Tick;

            timergame.Interval = 30;
            timergame.Start();
        }

        private void GameTimer(object sender, EventArgs e)
        {

            
            scoreText.Text = "Score: " + GameScore;

            if(gameLevel==0 && GameScore == 10)
            {
                obstacleTimer.Interval = 1500;

                obstacleSpeed++;
                gameLevel = 1;
            }
            if(gameLevel==1 && obstacleSpeed < 15)
            {

                obstacleSpeed++;
            }
            
            if (player.Jumping)
            {
                player.Top -= player.JumpSpeed;
                player.JumpSpeed -= 4;
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
                player.FallSpeed += 4;
                if (player.Bottom >= myGame.Height) player.Falling = false;
            }

            if (player.Bottom + player.FallSpeed > myGame.Height)
            {
                player.FallSpeed = myGame.Height - player.Bottom;
            }


            Control ObjectToDelete = new Control();
            foreach (Control t in myGame.Controls)
            {
                if (t is PictureBox && ( (string)t.Tag == "obstacle" || (string)t.Tag == "Powerup"))
                {
                    if (t.Left > -t.Width)
                    {
                        t.Left -= obstacleSpeed;
                    }
                    if (t.Left <= -t.Width)
                    {
                        ObjectToDelete = t;
                        GameScore = GameScore + 1;
                    }
                    if (player.Bounds.IntersectsWith(t.Bounds) && (string)t.Tag == "Powerup")
                    {
                        ObjectToDelete = t;
                    }
                    if (player.Bounds.IntersectsWith(t.Bounds) && (string)t.Tag == "obstacle")
                    {
                        
                        Endgame();
                    }
                    
                    if ((string)t.Tag == "obstacle")
                    {
                        if( player.Bottom + player.FallSpeed > t.Top && player.Right >= t.Left && player.Left <= t.Right)
                        {
                            player.FallSpeed = t.Top - player.Bottom;
                        }
                        if (player.Bottom  == t.Top && player.Right >= t.Left && player.Left <= t.Right && player.Falling == true)
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
            if(ObjectToDelete is Tree || ObjectToDelete is Banany)myGame.Controls.Remove(ObjectToDelete);


        }

        private void ObstacleTimer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();

            int probability = rnd.Next(100);
            if (probability < 20)
            {
                Tree przeszkoda = new Tree();
                przeszkoda.Width = rnd.Next(40, 150);
                przeszkoda.Height = rnd.Next(50, 80);
                przeszkoda.Location = new Point(myGame.Width, myGame.Height - przeszkoda.Height - 60);
                myGame.Controls.Add(przeszkoda);
                Banany banan = new Banany();
                banan.Location = new Point(myGame.Width+rnd.Next(przeszkoda.Width-banan.Width), przeszkoda.Top - banan.Height);
                myGame.Controls.Add(banan);
            }
            else if (probability < 40)
            {
                Tree przeszkoda = new Tree();
                przeszkoda.Width = rnd.Next(40, 150);
                przeszkoda.Height = rnd.Next(50, 80);
                przeszkoda.Location = new Point(myGame.Width, myGame.Height - przeszkoda.Height);
                myGame.Controls.Add(przeszkoda);
                Banany banan = new Banany();
                banan.Location = new Point(myGame.Width + rnd.Next(przeszkoda.Width - banan.Width), przeszkoda.Top - banan.Height);
                myGame.Controls.Add(banan);
            }
            else if (probability < 60)
            {
                Tree przeszkoda = new Tree();
                przeszkoda.Width = rnd.Next(40, 150);
                przeszkoda.Height = rnd.Next(50, 80);
                przeszkoda.Location = new Point(myGame.Width, myGame.Height - przeszkoda.Height);
                myGame.Controls.Add(przeszkoda);
            }
            else if (probability < 80)
            {
                Tree przeszkoda = new Tree();
                przeszkoda.Width = rnd.Next(40, 150);
                przeszkoda.Height = rnd.Next(50, 80);
                przeszkoda.Location = new Point(myGame.Width, myGame.Height - przeszkoda.Height - 60);
                myGame.Controls.Add(przeszkoda);
            }

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && player.Jumping == false && !player.Falling)
            {
                player.JumpSpeed = 35;
                player.Jumping = true;
            }

        }


        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

       
        private void RestartClickEvent(object sender, EventArgs e)
        {
            this.myGame.Dispose();
            GameReset();
        }

        private void Endgame()
        {
            
            timergame.Stop();
            obstacleTimer.Stop();
            scoreText.Text += " Game over!!!";
            retryImage.Enabled = true;
            retryImage.Visible = true;
        }
    }
}
