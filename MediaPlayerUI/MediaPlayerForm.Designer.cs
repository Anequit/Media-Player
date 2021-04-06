
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
            System.Windows.Forms.Button Start_Button;
            System.Windows.Forms.Button Pause_Button;
            System.Windows.Forms.Button Next_Button;
            System.Windows.Forms.Button Back_Button;
            System.Windows.Forms.CheckBox Repeat_Button;
            System.Windows.Forms.CheckBox Shuffle_Button;
            this.Songname_Label = new System.Windows.Forms.TextBox();
            this.Volume_TrackBar = new System.Windows.Forms.TrackBar();
            this.Watermark_LBL = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Volume_Label = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            Start_Button = new System.Windows.Forms.Button();
            Pause_Button = new System.Windows.Forms.Button();
            Next_Button = new System.Windows.Forms.Button();
            Back_Button = new System.Windows.Forms.Button();
            Repeat_Button = new System.Windows.Forms.CheckBox();
            Shuffle_Button = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Volume_TrackBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start_Button
            // 
            Start_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            Start_Button.BackColor = System.Drawing.SystemColors.Control;
            Start_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            Start_Button.CausesValidation = false;
            Start_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Start_Button.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            Start_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Start_Button.ForeColor = System.Drawing.SystemColors.MenuText;
            Start_Button.Location = new System.Drawing.Point(102, 30);
            Start_Button.Name = "Start_Button";
            Start_Button.Size = new System.Drawing.Size(171, 23);
            Start_Button.TabIndex = 0;
            Start_Button.TabStop = false;
            Start_Button.Text = "▶";
            Start_Button.UseMnemonic = false;
            Start_Button.UseVisualStyleBackColor = false;
            Start_Button.Click += new System.EventHandler(this.Start_BTN_Click);
            // 
            // Pause_Button
            // 
            Pause_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            Pause_Button.BackColor = System.Drawing.SystemColors.Control;
            Pause_Button.CausesValidation = false;
            Pause_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Pause_Button.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            Pause_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Pause_Button.ForeColor = System.Drawing.SystemColors.MenuText;
            Pause_Button.Location = new System.Drawing.Point(279, 30);
            Pause_Button.Name = "Pause_Button";
            Pause_Button.Size = new System.Drawing.Size(93, 23);
            Pause_Button.TabIndex = 1;
            Pause_Button.TabStop = false;
            Pause_Button.Text = "❙❙";
            Pause_Button.UseMnemonic = false;
            Pause_Button.UseVisualStyleBackColor = false;
            Pause_Button.Click += new System.EventHandler(this.Stop_BTN_Click);
            // 
            // Next_Button
            // 
            Next_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            Next_Button.BackColor = System.Drawing.SystemColors.Control;
            Next_Button.CausesValidation = false;
            Next_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Next_Button.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            Next_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Next_Button.ForeColor = System.Drawing.SystemColors.MenuText;
            Next_Button.Location = new System.Drawing.Point(378, 30);
            Next_Button.Name = "Next_Button";
            Next_Button.Size = new System.Drawing.Size(93, 23);
            Next_Button.TabIndex = 2;
            Next_Button.TabStop = false;
            Next_Button.Text = "↪";
            Next_Button.UseMnemonic = false;
            Next_Button.UseVisualStyleBackColor = false;
            Next_Button.Click += new System.EventHandler(this.Next_BTN_Click);
            // 
            // Back_Button
            // 
            Back_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            Back_Button.BackColor = System.Drawing.SystemColors.Control;
            Back_Button.CausesValidation = false;
            Back_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Back_Button.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            Back_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Back_Button.ForeColor = System.Drawing.SystemColors.MenuText;
            Back_Button.Location = new System.Drawing.Point(3, 30);
            Back_Button.Name = "Back_Button";
            Back_Button.Size = new System.Drawing.Size(93, 23);
            Back_Button.TabIndex = 3;
            Back_Button.TabStop = false;
            Back_Button.Text = "↩";
            Back_Button.UseMnemonic = false;
            Back_Button.UseVisualStyleBackColor = false;
            Back_Button.Click += new System.EventHandler(this.Back_BTN_Click);
            // 
            // Repeat_Button
            // 
            Repeat_Button.Appearance = System.Windows.Forms.Appearance.Button;
            Repeat_Button.BackColor = System.Drawing.SystemColors.Control;
            Repeat_Button.CausesValidation = false;
            Repeat_Button.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            Repeat_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Repeat_Button.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ScrollBar;
            Repeat_Button.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            Repeat_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Repeat_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Repeat_Button.ForeColor = System.Drawing.SystemColors.MenuText;
            Repeat_Button.Location = new System.Drawing.Point(279, 4);
            Repeat_Button.Name = "Repeat_Button";
            Repeat_Button.Size = new System.Drawing.Size(93, 23);
            Repeat_Button.TabIndex = 9;
            Repeat_Button.TabStop = false;
            Repeat_Button.Text = "Repeat Track";
            Repeat_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Repeat_Button.UseMnemonic = false;
            Repeat_Button.UseVisualStyleBackColor = false;
            Repeat_Button.CheckedChanged += new System.EventHandler(this.Repeat_BTN_CheckedChanged);
            // 
            // Shuffle_Button
            // 
            Shuffle_Button.Appearance = System.Windows.Forms.Appearance.Button;
            Shuffle_Button.BackColor = System.Drawing.SystemColors.Control;
            Shuffle_Button.CausesValidation = false;
            Shuffle_Button.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            Shuffle_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            Shuffle_Button.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ScrollBar;
            Shuffle_Button.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            Shuffle_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Shuffle_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Shuffle_Button.ForeColor = System.Drawing.SystemColors.MenuText;
            Shuffle_Button.Location = new System.Drawing.Point(378, 4);
            Shuffle_Button.Name = "Shuffle_Button";
            Shuffle_Button.Size = new System.Drawing.Size(93, 23);
            Shuffle_Button.TabIndex = 10;
            Shuffle_Button.TabStop = false;
            Shuffle_Button.Text = "Shuffle";
            Shuffle_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Shuffle_Button.UseMnemonic = false;
            Shuffle_Button.UseVisualStyleBackColor = false;
            Shuffle_Button.CheckedChanged += new System.EventHandler(this.Shuffle_BTN_CheckedChanged);
            // 
            // Songname_Label
            // 
            this.Songname_Label.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Songname_Label.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Songname_Label.CausesValidation = false;
            this.Songname_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.Songname_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.Songname_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Songname_Label.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Songname_Label.Location = new System.Drawing.Point(0, 0);
            this.Songname_Label.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.Songname_Label.Multiline = true;
            this.Songname_Label.Name = "Songname_Label";
            this.Songname_Label.ReadOnly = true;
            this.Songname_Label.Size = new System.Drawing.Size(474, 28);
            this.Songname_Label.TabIndex = 5;
            this.Songname_Label.TabStop = false;
            this.Songname_Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Songname_Label.WordWrap = false;
            // 
            // Volume_TrackBar
            // 
            this.Volume_TrackBar.BackColor = System.Drawing.SystemColors.Control;
            this.Volume_TrackBar.CausesValidation = false;
            this.Volume_TrackBar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Volume_TrackBar.LargeChange = 25;
            this.Volume_TrackBar.Location = new System.Drawing.Point(13, 16);
            this.Volume_TrackBar.Maximum = 100;
            this.Volume_TrackBar.Name = "Volume_TrackBar";
            this.Volume_TrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Volume_TrackBar.Size = new System.Drawing.Size(45, 97);
            this.Volume_TrackBar.TabIndex = 6;
            this.Volume_TrackBar.TabStop = false;
            this.Volume_TrackBar.TickFrequency = 25;
            this.Volume_TrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.Volume_TrackBar.Value = 50;
            this.Volume_TrackBar.Scroll += new System.EventHandler(this.Volume_TrackBar_Scroll);
            // 
            // Watermark_LBL
            // 
            this.Watermark_LBL.AutoSize = true;
            this.Watermark_LBL.CausesValidation = false;
            this.Watermark_LBL.Location = new System.Drawing.Point(3, 14);
            this.Watermark_LBL.Name = "Watermark_LBL";
            this.Watermark_LBL.Size = new System.Drawing.Size(87, 13);
            this.Watermark_LBL.TabIndex = 8;
            this.Watermark_LBL.Text = "Made by Anequit";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Songname_Label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 28);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(Repeat_Button);
            this.panel3.Controls.Add(Shuffle_Button);
            this.panel3.Controls.Add(Next_Button);
            this.panel3.Controls.Add(Back_Button);
            this.panel3.Controls.Add(Pause_Button);
            this.panel3.Controls.Add(this.Watermark_LBL);
            this.panel3.Controls.Add(Start_Button);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 133);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(474, 56);
            this.panel3.TabIndex = 13;
            // 
            // Volume_Label
            // 
            this.Volume_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.Volume_Label.Location = new System.Drawing.Point(0, 0);
            this.Volume_Label.Name = "Volume_Label";
            this.Volume_Label.Size = new System.Drawing.Size(69, 16);
            this.Volume_Label.TabIndex = 14;
            this.Volume_Label.Text = "Volume: 50";
            this.Volume_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Volume_TrackBar);
            this.panel4.Controls.Add(this.Volume_Label);
            this.panel4.Location = new System.Drawing.Point(3, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(69, 113);
            this.panel4.TabIndex = 15;
            // 
            // MediaPlayerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(474, 189);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(490, 228);
            this.MinimumSize = new System.Drawing.Size(490, 228);
            this.Name = "MediaPlayerForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MP3 Player";
            ((System.ComponentModel.ISupportInitialize)(this.Volume_TrackBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox Songname_Label;
        private System.Windows.Forms.TrackBar Volume_TrackBar;
        private System.Windows.Forms.Label Watermark_LBL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Volume_Label;
    }
}

