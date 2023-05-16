using System.Windows.Forms;
using System.Drawing;
namespace UntitledMonkeyGame
{
    internal class Tree : PictureBox
    {
        public Tree ()
     { 
        this.Tag = "Obstacle";
        this.Height = 100;
        this.Width = 50;
        
        this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Image = Properties.Resources.ground1;

        }

   }
}