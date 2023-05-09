using SudokuGUI.Code;

namespace SudokuGUI
{
    public partial class MainScreen : Form
    {
        private Size formOriginalSize;
        private Rectangle easyBtn;
        private Rectangle mediumBtn;
        private Rectangle hardBtn;
        private Rectangle evilBtn;

        public MainScreen()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            formOriginalSize = Size;

            richTextBox1.Location = new Point((formOriginalSize.Width / 2) - (richTextBox1.Width / 2), richTextBox1.Location.Y);
            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

            easyBtn = new Rectangle(EasyButton.Location, EasyButton.Size);
            mediumBtn = new Rectangle(MediumButton.Location, MediumButton.Size);
            hardBtn = new Rectangle(HardButton.Location, HardButton.Size);
            evilBtn = new Rectangle(EvilButton.Location, EvilButton.Size);

            resize_Control(EasyButton, easyBtn);
            resize_Control(MediumButton, mediumBtn);
            resize_Control(HardButton, hardBtn);
            resize_Control(EvilButton, evilBtn);
        }

        private void resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);

        }

        private void EasyButton_Click(object sender, EventArgs e)
        {
            StartGame("Easy");
        }

        private void MediumButton_Click(object sender, EventArgs e)
        {
            StartGame("Medium");
        }

        private void HardButton_Click(object sender, EventArgs e)
        {
            StartGame("Hard");
        }

        private void EvilButton_Click(object sender, EventArgs e)
        {
            StartGame("Evil");
        }

        private void StartGame(string difficulty)
        {
            new GameScreen(difficulty, this).Show();
            Hide();
        }
    }
}