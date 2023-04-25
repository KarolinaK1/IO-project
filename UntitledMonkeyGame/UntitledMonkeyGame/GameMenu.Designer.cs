
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
            this.SuspendLayout();
            // 
            // PLAY
            // 
            this.PLAY.BackColor = System.Drawing.Color.Khaki;
            this.PLAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PLAY.Location = new System.Drawing.Point(244, 289);
            this.PLAY.Name = "PLAY";
            this.PLAY.Size = new System.Drawing.Size(118, 54);
            this.PLAY.TabIndex = 0;
            this.PLAY.Text = "PLAY";
            this.PLAY.UseVisualStyleBackColor = false;
            this.PLAY.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // GameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.BackgroundImage = global::UntitledMonkeyGame.Properties.Resources.monkeyjump;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(608, 450);
            this.Controls.Add(this.PLAY);
            this.DoubleBuffered = true;
            this.Name = "GameMenu";
            this.Text = "UntitledMonkeyGame";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PLAY;
    }
}

