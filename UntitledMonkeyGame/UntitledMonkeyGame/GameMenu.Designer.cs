
namespace UntitledMonkeyGame
{
    partial class GameMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PLAY = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PLAY
            // 
            this.PLAY.BackColor = System.Drawing.Color.LightCyan;
            this.PLAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PLAY.Location = new System.Drawing.Point(238, 213);
            this.PLAY.Name = "PLAY";
            this.PLAY.Size = new System.Drawing.Size(129, 67);
            this.PLAY.TabIndex = 0;
            this.PLAY.Text = "PLAY";
            this.PLAY.UseVisualStyleBackColor = false;
            this.PLAY.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(528, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // GameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.BackgroundImage = global::UntitledMonkeyGame.Properties.Resources.monkeyplay;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(608, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PLAY);
            this.DoubleBuffered = true;
            this.Name = "GameMenu";
            this.Text = "UntitledMonkeyGame";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PLAY;
        private System.Windows.Forms.Button button1;
    }
}

