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
    }

}
