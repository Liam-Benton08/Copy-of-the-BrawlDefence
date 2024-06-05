namespace Copy_of_the_BrawlDefence
{
    partial class Form1
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
            this.easyButton = new System.Windows.Forms.Button();
            this.hardButton = new System.Windows.Forms.Button();
            this.mediumButton = new System.Windows.Forms.Button();
            this.insaneButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.livesLabel = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.dragEdgar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // easyButton
            // 
            this.easyButton.Location = new System.Drawing.Point(241, 249);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(75, 23);
            this.easyButton.TabIndex = 0;
            this.easyButton.Text = "Easy";
            this.easyButton.UseVisualStyleBackColor = true;
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click_1);
            this.easyButton.MouseLeave += new System.EventHandler(this.easyButton_MouseLeave);
            this.easyButton.MouseHover += new System.EventHandler(this.easyButton_MouseHover);
            // 
            // hardButton
            // 
            this.hardButton.Location = new System.Drawing.Point(479, 249);
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(75, 23);
            this.hardButton.TabIndex = 1;
            this.hardButton.Text = "Hard";
            this.hardButton.UseVisualStyleBackColor = true;
            this.hardButton.Click += new System.EventHandler(this.hardButton_Click_1);
            this.hardButton.MouseLeave += new System.EventHandler(this.hardButton_MouseLeave);
            this.hardButton.MouseHover += new System.EventHandler(this.hardButton_MouseHover);
            // 
            // mediumButton
            // 
            this.mediumButton.Location = new System.Drawing.Point(363, 249);
            this.mediumButton.Name = "mediumButton";
            this.mediumButton.Size = new System.Drawing.Size(75, 23);
            this.mediumButton.TabIndex = 2;
            this.mediumButton.Text = "Medium";
            this.mediumButton.UseVisualStyleBackColor = true;
            this.mediumButton.Click += new System.EventHandler(this.mediumButton_Click_1);
            this.mediumButton.MouseLeave += new System.EventHandler(this.mediumButton_MouseLeave);
            this.mediumButton.MouseHover += new System.EventHandler(this.mediumButton_MouseHover);
            // 
            // insaneButton
            // 
            this.insaneButton.Location = new System.Drawing.Point(363, 349);
            this.insaneButton.Name = "insaneButton";
            this.insaneButton.Size = new System.Drawing.Size(75, 23);
            this.insaneButton.TabIndex = 3;
            this.insaneButton.Text = "Insane";
            this.insaneButton.UseVisualStyleBackColor = true;
            this.insaneButton.Click += new System.EventHandler(this.insaneButton_Click_1);
            this.insaneButton.MouseLeave += new System.EventHandler(this.insaneButton_MouseLeave);
            this.insaneButton.MouseHover += new System.EventHandler(this.insaneButton_MouseHover);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(653, 35);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.MouseLeave += new System.EventHandler(this.exitButton_MouseLeave);
            this.exitButton.MouseHover += new System.EventHandler(this.exitButton_MouseHover);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(396, 146);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(0, 13);
            this.titleLabel.TabIndex = 5;
            // 
            // livesLabel
            // 
            this.livesLabel.AutoSize = true;
            this.livesLabel.Location = new System.Drawing.Point(126, 19);
            this.livesLabel.Name = "livesLabel";
            this.livesLabel.Size = new System.Drawing.Size(32, 13);
            this.livesLabel.TabIndex = 6;
            this.livesLabel.Text = "Lives";
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Location = new System.Drawing.Point(37, 19);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(39, 13);
            this.moneyLabel.TabIndex = 7;
            this.moneyLabel.Text = "Money";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick_1);
            // 
            // dragEdgar
            // 
            this.dragEdgar.BackColor = System.Drawing.Color.Transparent;
            this.dragEdgar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dragEdgar.Location = new System.Drawing.Point(12, 108);
            this.dragEdgar.Name = "dragEdgar";
            this.dragEdgar.Size = new System.Drawing.Size(64, 51);
            this.dragEdgar.TabIndex = 8;
            this.dragEdgar.Text = "Drag button";
            this.dragEdgar.UseVisualStyleBackColor = false;
            this.dragEdgar.DragOver += new System.Windows.Forms.DragEventHandler(this.dragEdgar_DragOver);
            this.dragEdgar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragEdgar_MouseDown);
            this.dragEdgar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dragEdgar_MouseMove);
            this.dragEdgar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dragEdgar_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 466);
            this.Controls.Add(this.dragEdgar);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.livesLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.insaneButton);
            this.Controls.Add(this.mediumButton);
            this.Controls.Add(this.hardButton);
            this.Controls.Add(this.easyButton);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button easyButton;
        private System.Windows.Forms.Button hardButton;
        private System.Windows.Forms.Button mediumButton;
        private System.Windows.Forms.Button insaneButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label livesLabel;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button dragEdgar;
    }
}

