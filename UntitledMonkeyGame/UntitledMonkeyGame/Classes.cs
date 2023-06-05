using System.Windows.Forms;
using System.Drawing;
namespace UntitledMonkeyGame
{
    internal class Classes : PictureBox
    {
        public Classes ()
     { 
        this.Tag = "Obstacle";
        this.Height = 100;
        this.Width = 50;
        this.SizeMode = PictureBoxSizeMode.StretchImage;
        this.Image = Properties.Resources.ground1;
        }

    }

    internal class Spike : PictureBox
    {
        public Spike()
        {
           // this.Image = Properties.Resources.spike;
            this.Tag = "Spike";
            this.Height = 100;
            this.Width = 50;
            this.BackColor = Color.Red;

        }
    }


    internal class Platform : PictureBox
    {
        public Platform()
        {
            this.Tag = "Platform";
            this.Height = 100;
            this.Width = 50;
            this.BackColor = Color.Green;
        }
    }

    internal class Enemy : PictureBox
    {
        public Enemy()
        {
            this.Tag = "Enemy";
            this.Height = 50;
            this.Width = 50;
            this.BackColor = Color.Purple;
        }
    }

}