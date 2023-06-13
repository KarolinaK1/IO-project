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



namespace UntitledMonkeyGame
{
    public partial class GameMenu : Form
    {

        System.Media.SoundPlayer wplayer = new System.Media.SoundPlayer();
        public GameMenu()
        {
            InitializeComponent();
            wplayer.SoundLocation = "music.wav";
        }


        private void StartButton_Click(object sender, EventArgs e)
        {
            restartImage GF = new restartImage();
            GF.Show();
            wplayer.Play();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public struct HighScoreEntry
        {

            public string PlayerName { get; set; }
            public int Score { get; set; }
        }



        public static List<HighScoreEntry> highScores = new List<HighScoreEntry>();
        public static List<HighScoreEntry> SetHighScores(string playerName, int score)
        {




            highScores.Add(new HighScoreEntry { PlayerName = playerName, Score = score });

            return highScores;
        }
        public static List<HighScoreEntry> GetHighScores()
        {


            return highScores;
        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<HighScoreEntry> highScores = GetHighScores();


            Form highScoreDialog = new Form();
            highScoreDialog.Text = "High Score List";
            highScoreDialog.Size = new Size(400, 300);



            ListView highScoreListView = new ListView();
            highScoreListView.Dock = DockStyle.Fill;
            highScoreListView.View = View.Details;
            highScoreListView.Columns.Add("Nickname:", 150);
            highScoreListView.Columns.Add("Score:", 150);


            foreach (HighScoreEntry entry in highScores)
            {
                ListViewItem item = new ListViewItem(entry.PlayerName);
                item.SubItems.Add(entry.Score.ToString());
                highScoreListView.Items.Add(item);
            }



            highScoreDialog.Controls.Add(highScoreListView);


            highScoreDialog.ShowDialog();
        }
    }

}

