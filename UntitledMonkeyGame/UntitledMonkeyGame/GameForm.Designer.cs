
namespace UntitledMonkeyGame
{
    partial class restartImage
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
            this.components = new System.ComponentModel.Container();
            this.timergame = new System.Windows.Forms.Timer(this.components);
            this.scoreText = new System.Windows.Forms.Label();
            this.retryImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.retryImage)).BeginInit();
            this.SuspendLayout();
            // 
            // timergame
            // 
            this.timergame.Interval = 30;
            this.timergame.Tick += new System.EventHandler(this.GameTimer);
            // 
            // scoreText
            // 
            this.scoreText.AutoSize = true;
            this.scoreText.BackColor = System.Drawing.Color.LightSkyBlue;
            this.scoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreText.ForeColor = System.Drawing.Color.Black;
            this.scoreText.Location = new System.Drawing.Point(28, 55);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(144, 37);
            this.scoreText.TabIndex = 0;
            this.scoreText.Text = "Score: 0";
            this.scoreText.Click += new System.EventHandler(this.label1_Click);
            // 
            // retryImage
            // 
            this.retryImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.retryImage.Image = global::UntitledMonkeyGame.Properties.Resources.retry;
            this.retryImage.Location = new System.Drawing.Point(201, 153);
            this.retryImage.Name = "retryImage";
            this.retryImage.Size = new System.Drawing.Size(256, 95);
            this.retryImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.retryImage.TabIndex = 1;
            this.retryImage.TabStop = false;
            this.retryImage.Click += new System.EventHandler(this.RestartClickEvent);
            // 
            // restartImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.retryImage);
            this.Controls.Add(this.scoreText);
            this.Name = "restartImage";
            this.Text = "MonkeyTheGame";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.Click += new System.EventHandler(this.RestartClickEvent);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            ((System.ComponentModel.ISupportInitialize)(this.retryImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timergame;
        private System.Windows.Forms.Label scoreText;
        private System.Windows.Forms.PictureBox retryImage;
    }
}