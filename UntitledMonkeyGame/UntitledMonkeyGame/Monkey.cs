using System;
using System.Drawing;
using System.Windows.Forms;

namespace UntitledMonkeyGame
{
    internal class Monkey : PictureBox
    {
        private bool jumping;
        private bool isAirborne;
        private int jumpSpeed;


        public Monkey()
        {
            this.Image = Properties.Resources.monkey;
            this.Height = 39;
            this.Width = 50;
            Jumping = false;
            IsAirborne = false;
            JumpSpeed = 0;
        }
        public bool Jumping
        {
            get => jumping;
            set
            {
                jumping = value;
            }
        }

        public int JumpSpeed
        {
            get => jumpSpeed;
            set
            {
                jumpSpeed = value;
            }
        }
        public bool IsAirborne
        {
            get => isAirborne;
            set
            {
                isAirborne = value;
            }
        }

    }
}