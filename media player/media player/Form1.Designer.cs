namespace media_player
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
            this.Start_BTN = new System.Windows.Forms.Button();
            this.Stop_BTN = new System.Windows.Forms.Button();
            this.Next_BTN = new System.Windows.Forms.Button();
            this.Back_BTN = new System.Windows.Forms.Button();
            this.Songname_LBL = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Start_BTN
            // 
            this.Start_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Start_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start_BTN.Location = new System.Drawing.Point(106, 154);
            this.Start_BTN.Name = "Start_BTN";
            this.Start_BTN.Size = new System.Drawing.Size(173, 23);
            this.Start_BTN.TabIndex = 0;
            this.Start_BTN.Text = "▶";
            this.Start_BTN.UseVisualStyleBackColor = true;
            this.Start_BTN.Click += new System.EventHandler(this.Start_BTN_Click);
            // 
            // Stop_BTN
            // 
            this.Stop_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Stop_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stop_BTN.Location = new System.Drawing.Point(284, 154);
            this.Stop_BTN.Name = "Stop_BTN";
            this.Stop_BTN.Size = new System.Drawing.Size(84, 23);
            this.Stop_BTN.TabIndex = 1;
            this.Stop_BTN.Text = "❙❙";
            this.Stop_BTN.UseVisualStyleBackColor = true;
            this.Stop_BTN.Click += new System.EventHandler(this.Stop_BTN_Click);
            // 
            // Next_BTN
            // 
            this.Next_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Next_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Next_BTN.Location = new System.Drawing.Point(373, 154);
            this.Next_BTN.Name = "Next_BTN";
            this.Next_BTN.Size = new System.Drawing.Size(89, 23);
            this.Next_BTN.TabIndex = 2;
            this.Next_BTN.Text = "↪";
            this.Next_BTN.UseVisualStyleBackColor = true;
            this.Next_BTN.Click += new System.EventHandler(this.Next_BTN_Click);
            // 
            // Back_BTN
            // 
            this.Back_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Back_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back_BTN.Location = new System.Drawing.Point(12, 154);
            this.Back_BTN.Name = "Back_BTN";
            this.Back_BTN.Size = new System.Drawing.Size(89, 23);
            this.Back_BTN.TabIndex = 3;
            this.Back_BTN.Text = "↩";
            this.Back_BTN.UseVisualStyleBackColor = true;
            this.Back_BTN.Click += new System.EventHandler(this.Back_BTN_Click);
            // 
            // Songname_LBL
            // 
            this.Songname_LBL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Songname_LBL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Songname_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.Songname_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Songname_LBL.Location = new System.Drawing.Point(12, 12);
            this.Songname_LBL.Name = "Songname_LBL";
            this.Songname_LBL.ReadOnly = true;
            this.Songname_LBL.Size = new System.Drawing.Size(450, 23);
            this.Songname_LBL.TabIndex = 5;
            this.Songname_LBL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(474, 189);
            this.Controls.Add(this.Songname_LBL);
            this.Controls.Add(this.Back_BTN);
            this.Controls.Add(this.Next_BTN);
            this.Controls.Add(this.Stop_BTN);
            this.Controls.Add(this.Start_BTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MP3 PLAYER";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start_BTN;
        private System.Windows.Forms.Button Stop_BTN;
        private System.Windows.Forms.Button Next_BTN;
        private System.Windows.Forms.Button Back_BTN;
        private System.Windows.Forms.TextBox Songname_LBL;
    }
}

