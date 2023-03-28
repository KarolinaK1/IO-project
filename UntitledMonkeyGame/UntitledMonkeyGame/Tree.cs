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
    }

   }
}