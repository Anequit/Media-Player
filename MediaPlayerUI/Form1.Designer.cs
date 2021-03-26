
namespace MediaPlayerUI
{
    partial class MediaPlayerForm
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
            this.Volume = new System.Windows.Forms.TrackBar();
            this.volume_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Repeat_BTN = new System.Windows.Forms.CheckBox();
            this.Shuffle_BTN = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Volume)).BeginInit();
            this.SuspendLayout();
            // 
            // Start_BTN
            // 
            this.Start_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Start_BTN.BackColor = System.Drawing.SystemColors.Control;
            this.Start_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Start_BTN.CausesValidation = false;
            this.Start_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start_BTN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Start_BTN.Location = new System.Drawing.Point(111, 158);
            this.Start_BTN.Name = "Start_BTN";
            this.Start_BTN.Size = new System.Drawing.Size(167, 23);
            this.Start_BTN.TabIndex = 0;
            this.Start_BTN.TabStop = false;
            this.Start_BTN.Text = "▶";
            this.Start_BTN.UseMnemonic = false;
            this.Start_BTN.UseVisualStyleBackColor = false;
            this.Start_BTN.Click += new System.EventHandler(this.Start_BTN_Click);
            // 
            // Stop_BTN
            // 
            this.Stop_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Stop_BTN.CausesValidation = false;
            this.Stop_BTN.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuText;
            this.Stop_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stop_BTN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Stop_BTN.Location = new System.Drawing.Point(284, 158);
            this.Stop_BTN.Name = "Stop_BTN";
            this.Stop_BTN.Size = new System.Drawing.Size(88, 23);
            this.Stop_BTN.TabIndex = 1;
            this.Stop_BTN.TabStop = false;
            this.Stop_BTN.Text = "❙❙";
            this.Stop_BTN.UseVisualStyleBackColor = true;
            this.Stop_BTN.Click += new System.EventHandler(this.Stop_BTN_Click);
            // 
            // Next_BTN
            // 
            this.Next_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Next_BTN.CausesValidation = false;
            this.Next_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Next_BTN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Next_BTN.Location = new System.Drawing.Point(374, 158);
            this.Next_BTN.Name = "Next_BTN";
            this.Next_BTN.Size = new System.Drawing.Size(93, 23);
            this.Next_BTN.TabIndex = 2;
            this.Next_BTN.TabStop = false;
            this.Next_BTN.Text = "↪";
            this.Next_BTN.UseVisualStyleBackColor = true;
            this.Next_BTN.Click += new System.EventHandler(this.Next_BTN_Click);
            // 
            // Back_BTN
            // 
            this.Back_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Back_BTN.CausesValidation = false;
            this.Back_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back_BTN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Back_BTN.Location = new System.Drawing.Point(12, 158);
            this.Back_BTN.Name = "Back_BTN";
            this.Back_BTN.Size = new System.Drawing.Size(93, 23);
            this.Back_BTN.TabIndex = 3;
            this.Back_BTN.TabStop = false;
            this.Back_BTN.Text = "↩";
            this.Back_BTN.UseVisualStyleBackColor = true;
            this.Back_BTN.Click += new System.EventHandler(this.Back_BTN_Click);
            // 
            // Songname_LBL
            // 
            this.Songname_LBL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Songname_LBL.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Songname_LBL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Songname_LBL.CausesValidation = false;
            this.Songname_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.Songname_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Songname_LBL.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Songname_LBL.HideSelection = false;
            this.Songname_LBL.Location = new System.Drawing.Point(12, 12);
            this.Songname_LBL.Name = "Songname_LBL";
            this.Songname_LBL.ReadOnly = true;
            this.Songname_LBL.Size = new System.Drawing.Size(454, 23);
            this.Songname_LBL.TabIndex = 5;
            this.Songname_LBL.TabStop = false;
            this.Songname_LBL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Volume
            // 
            this.Volume.BackColor = System.Drawing.SystemColors.Control;
            this.Volume.CausesValidation = false;
            this.Volume.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Volume.LargeChange = 20;
            this.Volume.Location = new System.Drawing.Point(12, 38);
            this.Volume.Maximum = 100;
            this.Volume.Minimum = 1;
            this.Volume.Name = "Volume";
            this.Volume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Volume.Size = new System.Drawing.Size(45, 104);
            this.Volume.TabIndex = 6;
            this.Volume.TabStop = false;
            this.Volume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Volume.Value = 50;
            this.Volume.Scroll += new System.EventHandler(this.Volume_Scroll);
            // 
            // volume_lbl
            // 
            this.volume_lbl.AutoSize = true;
            this.volume_lbl.ForeColor = System.Drawing.SystemColors.MenuText;
            this.volume_lbl.Location = new System.Drawing.Point(44, 85);
            this.volume_lbl.Name = "volume_lbl";
            this.volume_lbl.Size = new System.Drawing.Size(13, 13);
            this.volume_lbl.TabIndex = 7;
            this.volume_lbl.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(12, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Made by Anequit";
            // 
            // Repeat_BTN
            // 
            this.Repeat_BTN.Appearance = System.Windows.Forms.Appearance.Button;
            this.Repeat_BTN.CausesValidation = false;
            this.Repeat_BTN.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Repeat_BTN.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuText;
            this.Repeat_BTN.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.Repeat_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Repeat_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Repeat_BTN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Repeat_BTN.Location = new System.Drawing.Point(284, 133);
            this.Repeat_BTN.Name = "Repeat_BTN";
            this.Repeat_BTN.Size = new System.Drawing.Size(88, 23);
            this.Repeat_BTN.TabIndex = 9;
            this.Repeat_BTN.TabStop = false;
            this.Repeat_BTN.Text = "Repeat Track";
            this.Repeat_BTN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Repeat_BTN.UseVisualStyleBackColor = true;
            this.Repeat_BTN.CheckedChanged += new System.EventHandler(this.Repeat_BTN_CheckedChanged);
            // 
            // Shuffle_BTN
            // 
            this.Shuffle_BTN.Appearance = System.Windows.Forms.Appearance.Button;
            this.Shuffle_BTN.CausesValidation = false;
            this.Shuffle_BTN.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Shuffle_BTN.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuText;
            this.Shuffle_BTN.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.Shuffle_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Shuffle_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shuffle_BTN.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Shuffle_BTN.Location = new System.Drawing.Point(374, 133);
            this.Shuffle_BTN.Name = "Shuffle_BTN";
            this.Shuffle_BTN.Size = new System.Drawing.Size(93, 23);
            this.Shuffle_BTN.TabIndex = 10;
            this.Shuffle_BTN.TabStop = false;
            this.Shuffle_BTN.Text = "Shuffle";
            this.Shuffle_BTN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Shuffle_BTN.UseVisualStyleBackColor = true;
            this.Shuffle_BTN.CheckedChanged += new System.EventHandler(this.Shuffle_BTN_CheckedChanged);
            // 
            // MediaPlayerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(474, 189);
            this.Controls.Add(this.Shuffle_BTN);
            this.Controls.Add(this.Repeat_BTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.volume_lbl);
            this.Controls.Add(this.Volume);
            this.Controls.Add(this.Songname_LBL);
            this.Controls.Add(this.Back_BTN);
            this.Controls.Add(this.Next_BTN);
            this.Controls.Add(this.Stop_BTN);
            this.Controls.Add(this.Start_BTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(490, 228);
            this.MinimumSize = new System.Drawing.Size(490, 228);
            this.Name = "MediaPlayerForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lightweight MP3";
            ((System.ComponentModel.ISupportInitialize)(this.Volume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start_BTN;
        private System.Windows.Forms.Button Stop_BTN;
        private System.Windows.Forms.Button Next_BTN;
        private System.Windows.Forms.Button Back_BTN;
        private System.Windows.Forms.TextBox Songname_LBL;
        private System.Windows.Forms.TrackBar Volume;
        private System.Windows.Forms.Label volume_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Repeat_BTN;
        private System.Windows.Forms.CheckBox Shuffle_BTN;
    }
}

