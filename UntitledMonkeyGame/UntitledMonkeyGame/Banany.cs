using System;
using System.Drawing;
using System.Windows.Forms;

namespace UntitledMonkeyGame
{
    internal class Banany : PictureBox
    {
        public Banany()
        {
            this.Tag = "Powerup";
            this.BackColor = Color.Yellow;
            this.Height = 40;
            this.Width = 40;

        }

    }
}