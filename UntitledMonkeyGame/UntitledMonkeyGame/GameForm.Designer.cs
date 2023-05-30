
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
            this.high_score = new System.Windows.Forms.Label();
            this.lbl_over = new System.Windows.Forms.Label();
            this.lbl_value = new System.Windows.Forms.Label();
            this.scoreText2 = new System.Windows.Forms.Label();
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
            this.scoreText.BackColor = System.Drawing.Color.Transparent;
            this.scoreText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreText.ForeColor = System.Drawing.Color.Black;
            this.scoreText.Location = new System.Drawing.Point(354, 40);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(146, 39);
            this.scoreText.TabIndex = 0;
            this.scoreText.Text = "Score: 0";
            this.scoreText.Click += new System.EventHandler(this.label1_Click);
            // 
            // retryImage
            // 
            this.retryImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.retryImage.Image = global::UntitledMonkeyGame.Properties.Resources.retry;
            this.retryImage.Location = new System.Drawing.Point(308, 244);
            this.retryImage.Name = "retryImage";
            this.retryImage.Size = new System.Drawing.Size(248, 82);
            this.retryImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.retryImage.TabIndex = 1;
            this.retryImage.TabStop = false;
            this.retryImage.Click += new System.EventHandler(this.RestartClickEvent);
            // 
            // high_score
            // 
            this.high_score.AutoSize = true;
            this.high_score.BackColor = System.Drawing.Color.Transparent;
            this.high_score.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.high_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.high_score.ForeColor = System.Drawing.Color.Black;
            this.high_score.Location = new System.Drawing.Point(317, 100);
            this.high_score.Name = "high_score";
            this.high_score.Size = new System.Drawing.Size(193, 39);
            this.high_score.TabIndex = 2;
            this.high_score.Text = "High-score:";
            // 
            // lbl_over
            // 
            this.lbl_over.AutoSize = true;
            this.lbl_over.BackColor = System.Drawing.Color.Transparent;
            this.lbl_over.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_over.ForeColor = System.Drawing.Color.Red;
            this.lbl_over.Location = new System.Drawing.Point(298, 160);
            this.lbl_over.Name = "lbl_over";
            this.lbl_over.Size = new System.Drawing.Size(271, 55);
            this.lbl_over.TabIndex = 4;
            this.lbl_over.Text = "Game over";
            this.lbl_over.Click += new System.EventHandler(this.label3_Click);
            // 
            // lbl_value
            // 
            this.lbl_value.AutoSize = true;
            this.lbl_value.BackColor = System.Drawing.Color.Transparent;
            this.lbl_value.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_value.Location = new System.Drawing.Point(507, 100);
            this.lbl_value.Name = "lbl_value";
            this.lbl_value.Size = new System.Drawing.Size(38, 39);
            this.lbl_value.TabIndex = 5;
            this.lbl_value.Text = "0";
            // 
            // scoreText2
            // 
            this.scoreText2.AutoSize = true;
            this.scoreText2.BackColor = System.Drawing.Color.Transparent;
            this.scoreText2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scoreText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreText2.ForeColor = System.Drawing.Color.Black;
            this.scoreText2.Location = new System.Drawing.Point(12, 20);
            this.scoreText2.Name = "scoreText2";
            this.scoreText2.Size = new System.Drawing.Size(146, 39);
            this.scoreText2.TabIndex = 6;
            this.scoreText2.Text = "Score: 0";
            this.scoreText2.Click += new System.EventHandler(this.scoreText2_Click);
            // 
            // restartImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scoreText2);
            this.Controls.Add(this.lbl_value);
            this.Controls.Add(this.lbl_over);
            this.Controls.Add(this.high_score);
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
        private System.Windows.Forms.Label high_score;
        private System.Windows.Forms.Label lbl_over;
        private System.Windows.Forms.Label lbl_value;
        private System.Windows.Forms.Label scoreText2;
    }
}