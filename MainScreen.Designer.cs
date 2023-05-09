using System.Windows.Forms;

namespace SudokuGUI
{
    partial class MainScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            EasyButton = new Button();
            MediumButton = new Button();
            HardButton = new Button();
            EvilButton = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // EasyButton
            // 
            EasyButton.Anchor = AnchorStyles.None;
            EasyButton.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            EasyButton.Location = new Point(298, 206);
            EasyButton.Name = "EasyButton";
            EasyButton.Size = new Size(800, 150);
            EasyButton.TabIndex = 0;
            EasyButton.Text = "Easy";
            EasyButton.UseVisualStyleBackColor = true;
            EasyButton.Click += EasyButton_Click;
            // 
            // MediumButton
            // 
            MediumButton.Anchor = AnchorStyles.None;
            MediumButton.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            MediumButton.Location = new Point(298, 362);
            MediumButton.Name = "MediumButton";
            MediumButton.Size = new Size(800, 150);
            MediumButton.TabIndex = 1;
            MediumButton.Text = "Medium";
            MediumButton.UseVisualStyleBackColor = true;
            MediumButton.Click += MediumButton_Click;
            // 
            // HardButton
            // 
            HardButton.Anchor = AnchorStyles.None;
            HardButton.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            HardButton.Location = new Point(298, 518);
            HardButton.Name = "HardButton";
            HardButton.Size = new Size(800, 150);
            HardButton.TabIndex = 2;
            HardButton.Text = "Hard";
            HardButton.UseVisualStyleBackColor = true;
            HardButton.Click += HardButton_Click;
            // 
            // EvilButton
            // 
            EvilButton.Anchor = AnchorStyles.None;
            EvilButton.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            EvilButton.Location = new Point(298, 674);
            EvilButton.Name = "EvilButton";
            EvilButton.Size = new Size(800, 150);
            EvilButton.TabIndex = 3;
            EvilButton.Text = "Evil";
            EvilButton.UseVisualStyleBackColor = true;
            EvilButton.Click += EvilButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top;
            richTextBox1.BackColor = SystemColors.Window;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Enabled = false;
            richTextBox1.Font = new Font("Segoe UI", 80F, FontStyle.Bold, GraphicsUnit.Point);
            richTextBox1.Location = new Point(311, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(487, 188);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "Sudoku";
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1401, 836);
            Controls.Add(richTextBox1);
            Controls.Add(EvilButton);
            Controls.Add(HardButton);
            Controls.Add(MediumButton);
            Controls.Add(EasyButton);
            Name = "MainScreen";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private Button EasyButton;
        private Button MediumButton;
        private Button HardButton;
        private Button EvilButton;
        private RichTextBox richTextBox1;
    }
}