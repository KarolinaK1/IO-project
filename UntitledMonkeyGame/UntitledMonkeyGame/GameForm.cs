
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UntitledMonkeyGame.GameMenu;

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


        System.Media.SoundPlayer wplayer = new System.Media.SoundPlayer();

        System.Media.SoundPlayer eplayer = new System.Media.SoundPlayer();

        private HighScoreList highScoreList;


        private TextBox nameInput;
        private Button saveButton;
        private Label scoreLabel;
        private Label nameLabel;




        public restartImage()
        {
            InitializeComponent();
            InitializeDialogControls();
            GameReset();
            lbl_value.Text = Properties.Settings.Default.h_score;
            wplayer.SoundLocation = "music.wav";
            eplayer.SoundLocation = "negative.wav";
            highScoreList = new HighScoreList();
            nameInput.Hide();
            saveButton.Hide();
            nameLabel.Hide();
            scoreLabel.Hide();






        }

        private void InitializeDialogControls()

        {
            scoreLabel = new Label();
            scoreLabel.Text = "You made it into our High Score List!!";
            scoreLabel.Location = new System.Drawing.Point(20, 50);
            scoreLabel.Width = 320;
            scoreLabel.Font = new Font("Arial", 13, FontStyle.Regular);





            Controls.Add(scoreLabel);

            nameLabel = new Label();
            nameLabel.Text = "Enter your nickname below:";
            nameLabel.Location = new System.Drawing.Point(20, 80);
            Controls.Add(nameLabel);
            nameLabel.Width = 250;
            nameLabel.Font = new Font("Arial", 12, FontStyle.Regular);




            nameInput = new TextBox();

            nameInput.Size = new Size(180, 180);
            nameInput.Location = new System.Drawing.Point(20, 110);
            Controls.Add(nameInput);



            saveButton = new Button();
            saveButton.Text = "Add to High Score List";
            saveButton.Location = new System.Drawing.Point(20, 140);
            saveButton.Width = 180;
            saveButton.Click += SaveButton_Click;
            Controls.Add(saveButton);
            saveButton.BackColor = Color.LightGreen;
            saveButton.Font = new Font("Arial", 8, FontStyle.Regular);



        }


        private void GameReset()
        {
            foreach (Control ctr in this.Controls)
            {

                if (ctr.Focused)
                {
                    System.Console.WriteLine(ctr.ToString());
                    nameInput.Text = ctr.Focused.ToString();

                }
            }
            GameScore = 0;
            timergame.Stop();
            myGame = new GamePanel();
            myGame.Location = new Point(0, 0);
            this.Controls.Add(myGame);

            this.Width = 1000;
            this.Height = 500;
            myGame.Dock = DockStyle.Fill;

            //myGame.BackgroundImage = Properties.Resources.grass1;
            this.BackColor = Color.LightSkyBlue;

            this.player = new Monkey();
            player.Location = new Point(200, myGame.Height - player.Height);
            myGame.Controls.Add(player);

            GameScore = 0;
            scoreText.Text = "Score: " + GameScore;
            scoreText2.Text = "Score: " + GameScore;
            retryImage.Enabled = false;
            retryImage.Visible = false;


            obstacleSpeed = 10;

            gameLevel = 0;
            obstacleTimer.Interval = 2000;
            obstacleTimer.Tick += ObstacleTimer_Tick;
            obstacleTimer.Start();


            timergame.Interval = 30;
            timergame.Start();

            lbl_over.Hide();
            scoreText.Hide();
            high_score.Hide();
            lbl_value.Hide();
            scoreText2.Show();





        }




        private void GameTimer(object sender, EventArgs e)
        {


            scoreText.Text = "Score: " + GameScore;
            scoreText2.Text = "Score: " + GameScore;

            if (gameLevel == 0 && GameScore == 10)
            {
                obstacleTimer.Interval = 1500;

                obstacleSpeed++;
                gameLevel = 1;
            }
            if (gameLevel == 1 && obstacleSpeed < 15)
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
                        if ((string)t.Tag == "Bullet")
                        {

                            t.Left -= obstacleSpeed;
                           // t.Top += obstacleSpeed;
                        }
                        if (t.Name == "Falling" && t.Bottom < myGame.Height) t.Top += obstacleSpeed / 3;
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
                        eplayer.Play();

                    }


                    if ((string)t.Tag == "Obstacle" || (string)t.Tag == "Platform")
                    {
                        if (player.Bottom + player.FallSpeed > t.Top && player.Right >= t.Left && player.Left <= t.Right && player.Bottom < t.Top)
                        {
                            player.FallSpeed = t.Top - player.Bottom;
                        }
                        if (player.Bottom == t.Top && player.Right >= t.Left && player.Left <= t.Right && player.Falling == true)
                        {
                            player.Falling = false;
                        }
                        if (player.Bottom == t.Top && player.Falling == false && player.Left > t.Right)
                        {
                            player.Falling = true;
                            player.FallSpeed = 0;
                        }
                    }
                }
            }
            if (ObjectToDelete is PictureBox) myGame.Controls.Remove(ObjectToDelete);


        }




        private void ObstacleTimer_Tick(object sender, EventArgs e)
        {


            Random rnd = new Random();
            int probability = rnd.Next(120);
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
                    platform2.Location = new Point(myGame.Width + platform.Width * 2, myGame.Height - platform2.Height - 2 * myGame.Height / 5);
                    myGame.Controls.Add(platform2);
                    toskip += 1;

                    Platform platform3 = new Platform();
                    platform3.Width = platform.Width;
                    platform3.Height = platform.Height;
                    platform3.Location = new Point(myGame.Width + platform2.Width * 4, myGame.Height - platform3.Height - 3 * myGame.Height / 5);
                    myGame.Controls.Add(platform3);
                    toskip += 1;

                    Banany banan = new Banany();
                    banan.Location = new Point(platform3.Left + 2 * platform3.Width, platform3.Top - banan.Height * 2);
                    myGame.Controls.Add(banan);
                }
                else if (probability < 70)
                {
                    Platform platform = new Platform();
                    platform.Width = 100;
                    platform.Height = 20;
                    platform.Location = new Point(myGame.Width, myGame.Height - 4 * myGame.Height / 5);
                    myGame.Controls.Add(platform);



                }
                else if (probability < 80)
                {
                    Platform platform = new Platform();
                    platform.Width = 100;
                    platform.Height = 20;
                    platform.Location = new Point(myGame.Width, 2 * myGame.Height / 3);
                    myGame.Controls.Add(platform);


                }
                else if (probability < 90)
                {
                    if (probability < 100 && !myGame.Controls.ContainsKey("Enemy"))
                    {
                        
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
                    banan.Location = new Point(myGame.Width + rnd.Next(0, 100), 0);
                    myGame.Controls.Add(banan);

                }
                else if (probability < 110)
                {

                    Platform platform = new Platform();
                    platform.Width = 100;
                    platform.Height = 20;
                    platform.Location = new Point(myGame.Width, myGame.Height - platform.Height - myGame.Height / 5);
                    myGame.Controls.Add(platform);


                    Platform platform2 = new Platform();
                    platform2.Width = platform.Width;
                    platform2.Height = platform.Height;
                    platform2.Location = new Point(myGame.Width + platform.Width * 2, myGame.Height - platform2.Height - 2 * myGame.Height / 5);
                    myGame.Controls.Add(platform2);
                    toskip += 1;

                    Platform platform3 = new Platform();
                    platform3.Width = platform.Width;
                    platform3.Height = platform.Height;
                    platform3.Location = new Point(myGame.Width + platform2.Width * 4, myGame.Height - platform3.Height - myGame.Height / 5);
                    myGame.Controls.Add(platform3);
                    toskip += 1;



                    Banany banan = new Banany();
                    banan.Name = "Falling";
                    banan.Location = new Point(myGame.Width + rnd.Next(0, 100), 0);
                    myGame.Controls.Add(banan);

                    Banany banan2 = new Banany();
                    banan2.Location = new Point(platform3.Left + 2 * platform3.Width, platform3.Top - banan.Height * 2);
                    myGame.Controls.Add(banan2);

                    Enemy enemy = new Enemy();
                    enemy.Name = "Enemy";
                    enemy.Location = new Point(myGame.Width + platform.Width * 2, myGame.Height - enemy.Height);
                    myGame.Controls.Add(enemy);


                    myGame.Controls.Add(enemy);


                }
                else if (probability < 120)
                {


                    Platform platform = new Platform();
                    platform.Width = 175;
                    platform.Height = 20;
                    platform.Location = new Point(myGame.Width, myGame.Height - platform.Height - myGame.Height / 5);
                    myGame.Controls.Add(platform);

                    Spike kolce = new Spike();
                    kolce.Width = 20;
                    kolce.Height = 20;
                    kolce.Location = new Point(myGame.Width + rnd.Next(platform.Width - kolce.Width), platform.Top - kolce.Height);
                    myGame.Controls.Add(kolce);

                    Banany banan = new Banany();
                    banan.Location = new Point(myGame.Width, myGame.Height - platform.Height - 2 * myGame.Height / 5);
                    myGame.Controls.Add(banan);
                }
            }
            else 
            {
                
                toskip--; 
            }

            if (myGame.Controls.ContainsKey("Enemy") && !myGame.Controls.ContainsKey("Bullet"))
            {
                List<PictureBox> enemiesToShoot = new List<PictureBox>();
                foreach (Control control in myGame.Controls)
                {
                    if (control is PictureBox enemy && enemy.Name == "Enemy")
                    {
                        enemiesToShoot.Add(enemy);
                    }
                }

                foreach (PictureBox enemyToShoot in enemiesToShoot)
                {
                    PictureBox bullet = new PictureBox();
                    bullet.Width = player.Width / 2;
                    bullet.Tag = "Bullet";
                    bullet.Height = player.Height / 2;
                    bullet.BackColor = Color.Red;
                    bullet.Visible = true;
                    bullet.Location = enemyToShoot.Location;
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
            GameScore = 0;
            this.myGame.Dispose();
            GameReset();
            wplayer.Play();
            nameInput.Hide();
            saveButton.Hide();
            nameLabel.Hide();
            scoreLabel.Hide();


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


            wplayer.Stop();
            timergame.Stop();
            obstacleTimer.Stop();



            if (GameScore > highScoreList.GetPlayerScore())
            {


                highScoreList.AddScore(GameScore);
                Properties.Settings.Default.h_score = GameScore.ToString();
                Properties.Settings.Default.Save();
                lbl_value.Text = GameScore.ToString();
                nameInput.Show();
                saveButton.Show();
                nameLabel.Show();
                scoreLabel.Show();


            }


            lbl_over.Show();
            scoreText.Show();
            scoreText2.Hide();
            high_score.Show();
            lbl_value.Show();
            retryImage.Enabled = true;
            retryImage.Visible = true;




        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            string playerName = nameInput.Text;

            UntitledMonkeyGame.GameMenu.SetHighScores(playerName, highScoreList.GetPlayerScore());

            this.ActiveControl = null;


        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void scoreText2_Click(object sender, EventArgs e)
        {

        }


    }
    public class HighScoreList
    {
        private List<int> scores;

        public HighScoreList()
        {
            scores = new List<int>();
        }

        public void AddScore(int score)
        {
            scores.Add(score);
        }

        public int GetPlayerScore()
        {
            return scores.OrderByDescending(s => s).FirstOrDefault();
        }
    }
}
