namespace SudokuGUI
{
    partial class GameScreen
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
            this.mistakeText = new RichTextBox();
            SuspendLayout();
            // 
            // mistakeText
            // 
            this.mistakeText.Anchor = AnchorStyles.Top;
            this.mistakeText.BackColor = SystemColors.Window;
            this.mistakeText.BorderStyle = BorderStyle.None;
            this.mistakeText.Enabled = false;
            this.mistakeText.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            this.mistakeText.Location = new Point(297, 94);
            this.mistakeText.Name = "mistakeText";
            this.mistakeText.ReadOnly = true;
            this.mistakeText.Size = new Size(220, 48);
            this.mistakeText.TabIndex = 5;
            this.mistakeText.Text = "Mistakes: 0/4";
            // 
            // GameScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(this.mistakeText);
            Name = "GameScreen";
            Text = "GameScreen";
            WindowState = FormWindowState.Maximized;
            FormClosed += OnFormClose;
            Load += OnLoad;
            KeyDown += GameScreen_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox mistakeText;
    }
}