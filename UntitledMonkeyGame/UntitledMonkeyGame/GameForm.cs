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
        //fajne grafiki do przejrzenia
        //https://pixeljoint.com/forum/forum_posts.asp?TID=20453&PN=2
        private Monkey player;
        private GamePanel myGame;
        private int GameScore = 0;
        private int gameLevel = 0;
        private int toskip = 0;
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
            //this.BackColor = Color.SkyBlue;
            
            this.player = new Monkey();
            player.Location = new Point(200, myGame.Height - player.Height);
            myGame.Controls.Add(player);

            GameScore = 0;
            scoreText.Text = "Score: 0";
            retryImage.Enabled = false;
            retryImage.Visible = false;

            obstacleSpeed = 10;

            gameLevel = 0;
            obstacleTimer.Interval = 2000;
            obstacleTimer.Tick += ObstacleTimer_Tick;
            obstacleTimer.Start();
            

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
                //if (t is PictureBox && ( (string)t.Tag == "Obstacle" || (string)t.Tag == "Point" || (string)t.Tag == "Spike" || (string)t.Tag == "Platform" || (string)t.Tag == "Bullet"))
                if (t is PictureBox && (string)t.Tag != "Monkey")
                {

                    if (t.Left > -t.Width)
                    {
                        if((string)t.Tag == "Bullet")
                        {
                            t.Left -= obstacleSpeed;
                            t.Top += obstacleSpeed;
                        }
                        if(t.Name == "Falling" && t.Bottom<myGame.Height) t.Top += obstacleSpeed/3;
                        t.Left -= obstacleSpeed;
                    }
                    if (t.Left <= -t.Width || t.Bottom > myGame.Height)
                    {
                        ObjectToDelete = t;
                        
                    }
                    if (player.Bounds.IntersectsWith(t.Bounds) && (string)t.Tag == "Point")
                    {
                        GameScore = GameScore + 1;
                        ObjectToDelete = t;
                    }
                    if (player.Bounds.IntersectsWith(t.Bounds) && ((string)t.Tag == "Obstacle" || (string)t.Tag == "Spike" || (string)t.Tag == "Bullet"))
                    {
                        Endgame();
                    }
                    

                    if ((string)t.Tag == "Obstacle" || (string)t.Tag == "Platform")
                    {
                        if( player.Bottom + player.FallSpeed > t.Top && player.Right >= t.Left && player.Left <= t.Right && player.Bottom < t.Top)
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
            if(ObjectToDelete is PictureBox)myGame.Controls.Remove(ObjectToDelete);


        }

        private void ObstacleTimer_Tick(object sender, EventArgs e)
        {
            
            
            Random rnd = new Random();
            int probability = rnd.Next(100);
            if(toskip == 0)
            {
                if (probability < 10)
                {
                    Classes przeszkoda = new Classes();
                    przeszkoda.Width = rnd.Next(40, 150);
                    przeszkoda.Height = rnd.Next(50, 80);
                    przeszkoda.Location = new Point(myGame.Width, myGame.Height - przeszkoda.Height - 60);
                    myGame.Controls.Add(przeszkoda);
                    Banany banan = new Banany();
                    banan.Location = new Point(myGame.Width + rnd.Next(przeszkoda.Width - banan.Width), przeszkoda.Top - banan.Height);
                    myGame.Controls.Add(banan);

                }
                else if (probability < 20)
                {
                    Classes przeszkoda = new Classes();
                    przeszkoda.Width = rnd.Next(40, 150);
                    przeszkoda.Height = rnd.Next(50, 80);
                    przeszkoda.Location = new Point(myGame.Width, myGame.Height - przeszkoda.Height);
                    myGame.Controls.Add(przeszkoda);
                    Banany banan = new Banany();
                    banan.Location = new Point(myGame.Width + rnd.Next(przeszkoda.Width - banan.Width), przeszkoda.Top - banan.Height);
                    myGame.Controls.Add(banan);

                }
                else if (probability < 30)
                {
                    Classes przeszkoda = new Classes();
                    przeszkoda.Width = rnd.Next(40, 150);
                    przeszkoda.Height = rnd.Next(50, 80);
                    przeszkoda.Location = new Point(myGame.Width, myGame.Height - przeszkoda.Height);
                    myGame.Controls.Add(przeszkoda);
                }
                else if (probability < 40)
                {
                    Classes przeszkoda = new Classes();
                    przeszkoda.Width = rnd.Next(40, 150);
                    przeszkoda.Height = rnd.Next(50, 80);
                    przeszkoda.Location = new Point(myGame.Width, myGame.Height - przeszkoda.Height - 60);
                    myGame.Controls.Add(przeszkoda);
                }
                else if (probability < 50)
                {
                    Spike kolce = new Spike();
                    kolce.Width = rnd.Next(20, 50);
                    kolce.Height = rnd.Next(20, 40);
                    kolce.Location = new Point(myGame.Width, myGame.Height - kolce.Height);
                    myGame.Controls.Add(kolce);
                }
                else if (probability < 60)
                {
                    Platform platform = new Platform();
                    platform.Width = 100;
                    platform.Height = 20;
                    platform.Location = new Point(myGame.Width, myGame.Height - platform.Height - myGame.Height / 5);
                    myGame.Controls.Add(platform);


                    Platform platform2 = new Platform();
                    platform2.Width = platform.Width;
                    platform2.Height = platform.Height;
                    platform2.Location = new Point(myGame.Width + platform.Width*2, myGame.Height - platform2.Height - 2*myGame.Height / 5);
                    myGame.Controls.Add(platform2);
                    toskip += 1;

                    Platform platform3 = new Platform();
                    platform3.Width = platform.Width;
                    platform3.Height = platform.Height;
                    platform3.Location = new Point(myGame.Width + platform2.Width*4, myGame.Height - platform3.Height - 3*myGame.Height / 5);
                    myGame.Controls.Add(platform3);
                    toskip += 1;

                    Banany banan = new Banany();
                    banan.Location = new Point(platform3.Left + 2*platform3.Width, platform3.Top - banan.Height*2);
                    myGame.Controls.Add(banan);
                }
                else if (probability < 70)
                {
                    Platform platform = new Platform();
                    platform.Width = 100;
                    platform.Height = 20;
                    platform.Location = new Point(myGame.Width, myGame.Height - 4* myGame.Height / 5);
                    myGame.Controls.Add(platform);


                }
                else if (probability < 80)
                {
                    Platform platform = new Platform();
                    platform.Width = 100;
                    platform.Height = 20;
                    platform.Location = new Point(myGame.Width, 2*myGame.Height /3);
                    myGame.Controls.Add(platform);


                }
                else if (probability < 90)
                {
                    if (probability < 100 && !myGame.Controls.ContainsKey("Enemy"))
                    {
                        this.Text = "SADFG";
                        Enemy enemy = new Enemy();
                        enemy.Name = "Enemy";
                        enemy.Location = new Point(myGame.Width + rnd.Next(150, 300), 0);
                        myGame.Controls.Add(enemy);
                    }

                }
                else if (probability < 100)
                {
                    Banany banan = new Banany();
                    banan.Name = "Falling";
                    banan.Location = new Point(myGame.Width+ rnd.Next(0, 100), 0);
                    myGame.Controls.Add(banan);

                }
            }
            else 
            {
                
                toskip--; 
            }

            if (myGame.Controls.ContainsKey("Enemy") && !myGame.Controls.ContainsKey("Bullet"))
            {
                if (GetControlByName("Enemy") != null)
                {
                    PictureBox bullet = new PictureBox();
                    bullet.Width = player.Width/2;
                    bullet.Tag = "Bullet";
                    bullet.Height = player.Height / 2;
                    bullet.BackColor = Color.Red;
                    bullet.Visible = true;
                    bullet.Location = GetControlByName("Enemy").Location;
                    myGame.Controls.Add(bullet);
                }
                
            }


            //foreach (Control en in myGame.Controls)
            //{
            //    if ((string)en.Tag == "Enemy")
            //    {
            //        PictureBox bullet = new PictureBox();
            //        bullet.Width = 40;
            //        bullet.Tag = "Bullet";
            //        bullet.Height = 40;
            //        bullet.BackColor = Color.Red;
            //        bullet.Visible = true;
            //        bullet.Location = en.Location;
            //        myGame.Controls.Add(bullet);
            //    }
            //}
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
        Control GetControlByName(string Name)
        {
            foreach (Control c in myGame.Controls)
                if (c.Name == Name)
                    return c;

            return null;
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
