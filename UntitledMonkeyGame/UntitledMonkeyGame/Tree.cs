using System.Windows.Forms;
using System.Drawing;
namespace UntitledMonkeyGame
{
    internal class Tree : PictureBox
    {
        public Tree ()
     { 
        this.Tag = "obstacle";
        this.Height = 100;
        this.Width = 50;
        this.BackColor = Color.BurlyWood;
        this.SizeMode = PictureBoxSizeMode.StretchImage;
        this.Image = Properties.Resources.obstacle3;
            
        }

   }
}