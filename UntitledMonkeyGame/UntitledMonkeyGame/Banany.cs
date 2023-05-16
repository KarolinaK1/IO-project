using System;
using System.Drawing;
using System.Windows.Forms;

namespace UntitledMonkeyGame
{
    internal class Banany : PictureBox
    {
        public Banany()
        {
            this.Tag = "Point";
            
            this.Height = 40;
            this.Width = 40;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Image = Properties.Resources.banan;

        }

    }
}