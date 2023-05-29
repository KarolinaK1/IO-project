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
            this.Tag = "Monkey";
            Jumping = false;
            IsAirborne = false;
            JumpSpeed = 0;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
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

        public bool Falling { get; set; }
        public int FallSpeed { get; internal set; }
    }
}