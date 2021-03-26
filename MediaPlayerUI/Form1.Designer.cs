
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
            this.Start_Button = new System.Windows.Forms.Button();
            this.Pause_Button = new System.Windows.Forms.Button();
            this.Next_Button = new System.Windows.Forms.Button();
            this.Back_Button = new System.Windows.Forms.Button();
            this.Songname_Label = new System.Windows.Forms.TextBox();
            this.Volume_TrackBar = new System.Windows.Forms.TrackBar();
            this.Volume_Label = new System.Windows.Forms.Label();
            this.Watermark_LBL = new System.Windows.Forms.Label();
            this.Repeat_Button = new System.Windows.Forms.CheckBox();
            this.Shuffle_Button = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Volume_TrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Start_Button
            // 
            this.Start_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Start_Button.BackColor = System.Drawing.SystemColors.Control;
            this.Start_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Start_Button.CausesValidation = false;
            this.Start_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start_Button.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Start_Button.Location = new System.Drawing.Point(111, 158);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(167, 23);
            this.Start_Button.TabIndex = 0;
            this.Start_Button.TabStop = false;
            this.Start_Button.Text = "▶";
            this.Start_Button.UseMnemonic = false;
            this.Start_Button.UseVisualStyleBackColor = false;
            this.Start_Button.Click += new System.EventHandler(this.Start_BTN_Click);
            // 
            // Pause_Button
            // 
            this.Pause_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pause_Button.CausesValidation = false;
            this.Pause_Button.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuText;
            this.Pause_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pause_Button.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Pause_Button.Location = new System.Drawing.Point(284, 158);
            this.Pause_Button.Name = "Pause_Button";
            this.Pause_Button.Size = new System.Drawing.Size(88, 23);
            this.Pause_Button.TabIndex = 1;
            this.Pause_Button.TabStop = false;
            this.Pause_Button.Text = "❙❙";
            this.Pause_Button.UseVisualStyleBackColor = true;
            this.Pause_Button.Click += new System.EventHandler(this.Stop_BTN_Click);
            // 
            // Next_Button
            // 
            this.Next_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Next_Button.CausesValidation = false;
            this.Next_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Next_Button.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Next_Button.Location = new System.Drawing.Point(374, 158);
            this.Next_Button.Name = "Next_Button";
            this.Next_Button.Size = new System.Drawing.Size(93, 23);
            this.Next_Button.TabIndex = 2;
            this.Next_Button.TabStop = false;
            this.Next_Button.Text = "↪";
            this.Next_Button.UseVisualStyleBackColor = true;
            this.Next_Button.Click += new System.EventHandler(this.Next_BTN_Click);
            // 
            // Back_Button
            // 
            this.Back_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Back_Button.CausesValidation = false;
            this.Back_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back_Button.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Back_Button.Location = new System.Drawing.Point(12, 158);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(93, 23);
            this.Back_Button.TabIndex = 3;
            this.Back_Button.TabStop = false;
            this.Back_Button.Text = "↩";
            this.Back_Button.UseVisualStyleBackColor = true;
            this.Back_Button.Click += new System.EventHandler(this.Back_BTN_Click);
            // 
            // Songname_Label
            // 
            this.Songname_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Songname_Label.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Songname_Label.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Songname_Label.CausesValidation = false;
            this.Songname_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.Songname_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Songname_Label.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Songname_Label.HideSelection = false;
            this.Songname_Label.Location = new System.Drawing.Point(12, 12);
            this.Songname_Label.Name = "Songname_Label";
            this.Songname_Label.ReadOnly = true;
            this.Songname_Label.Size = new System.Drawing.Size(454, 23);
            this.Songname_Label.TabIndex = 5;
            this.Songname_Label.TabStop = false;
            this.Songname_Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Volume_TrackBar
            // 
            this.Volume_TrackBar.BackColor = System.Drawing.SystemColors.Control;
            this.Volume_TrackBar.CausesValidation = false;
            this.Volume_TrackBar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Volume_TrackBar.LargeChange = 20;
            this.Volume_TrackBar.Location = new System.Drawing.Point(12, 38);
            this.Volume_TrackBar.Maximum = 100;
            this.Volume_TrackBar.Minimum = 1;
            this.Volume_TrackBar.Name = "Volume_TrackBar";
            this.Volume_TrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Volume_TrackBar.Size = new System.Drawing.Size(45, 104);
            this.Volume_TrackBar.TabIndex = 6;
            this.Volume_TrackBar.TabStop = false;
            this.Volume_TrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Volume_TrackBar.Value = 50;
            this.Volume_TrackBar.Scroll += new System.EventHandler(this.Volume_Scroll);
            // 
            // Volume_Label
            // 
            this.Volume_Label.AutoSize = true;
            this.Volume_Label.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Volume_Label.Location = new System.Drawing.Point(44, 85);
            this.Volume_Label.Name = "Volume_Label";
            this.Volume_Label.Size = new System.Drawing.Size(13, 13);
            this.Volume_Label.TabIndex = 7;
            this.Volume_Label.Text = "0";
            // 
            // Watermark_LBL
            // 
            this.Watermark_LBL.AutoSize = true;
            this.Watermark_LBL.CausesValidation = false;
            this.Watermark_LBL.Location = new System.Drawing.Point(12, 142);
            this.Watermark_LBL.Name = "Watermark_LBL";
            this.Watermark_LBL.Size = new System.Drawing.Size(87, 13);
            this.Watermark_LBL.TabIndex = 8;
            this.Watermark_LBL.Text = "Made by Anequit";
            // 
            // Repeat_Button
            // 
            this.Repeat_Button.Appearance = System.Windows.Forms.Appearance.Button;
            this.Repeat_Button.CausesValidation = false;
            this.Repeat_Button.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Repeat_Button.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuText;
            this.Repeat_Button.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.Repeat_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Repeat_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Repeat_Button.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Repeat_Button.Location = new System.Drawing.Point(284, 133);
            this.Repeat_Button.Name = "Repeat_Button";
            this.Repeat_Button.Size = new System.Drawing.Size(88, 23);
            this.Repeat_Button.TabIndex = 9;
            this.Repeat_Button.TabStop = false;
            this.Repeat_Button.Text = "Repeat Track";
            this.Repeat_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Repeat_Button.UseVisualStyleBackColor = true;
            this.Repeat_Button.CheckedChanged += new System.EventHandler(this.Repeat_BTN_CheckedChanged);
            // 
            // Shuffle_Button
            // 
            this.Shuffle_Button.Appearance = System.Windows.Forms.Appearance.Button;
            this.Shuffle_Button.CausesValidation = false;
            this.Shuffle_Button.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Shuffle_Button.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuText;
            this.Shuffle_Button.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.Shuffle_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Shuffle_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shuffle_Button.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Shuffle_Button.Location = new System.Drawing.Point(374, 133);
            this.Shuffle_Button.Name = "Shuffle_Button";
            this.Shuffle_Button.Size = new System.Drawing.Size(93, 23);
            this.Shuffle_Button.TabIndex = 10;
            this.Shuffle_Button.TabStop = false;
            this.Shuffle_Button.Text = "Shuffle";
            this.Shuffle_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Shuffle_Button.UseVisualStyleBackColor = true;
            this.Shuffle_Button.CheckedChanged += new System.EventHandler(this.Shuffle_BTN_CheckedChanged);
            // 
            // MediaPlayerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(474, 189);
            this.Controls.Add(this.Shuffle_Button);
            this.Controls.Add(this.Repeat_Button);
            this.Controls.Add(this.Watermark_LBL);
            this.Controls.Add(this.Volume_Label);
            this.Controls.Add(this.Volume_TrackBar);
            this.Controls.Add(this.Songname_Label);
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.Next_Button);
            this.Controls.Add(this.Pause_Button);
            this.Controls.Add(this.Start_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(490, 228);
            this.MinimumSize = new System.Drawing.Size(490, 228);
            this.Name = "MediaPlayerForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lightweight MP3";
            ((System.ComponentModel.ISupportInitialize)(this.Volume_TrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.Button Pause_Button;
        private System.Windows.Forms.Button Next_Button;
        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.TextBox Songname_Label;
        private System.Windows.Forms.TrackBar Volume_TrackBar;
        private System.Windows.Forms.Label Volume_Label;
        private System.Windows.Forms.Label Watermark_LBL;
        private System.Windows.Forms.CheckBox Repeat_Button;
        private System.Windows.Forms.CheckBox Shuffle_Button;
    }
}

