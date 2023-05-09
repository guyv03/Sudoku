using Microsoft.VisualBasic.ApplicationServices;
using Sudoku;
using SudokuGUI.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuGUI
{
    public partial class GameScreen : Form
    {
        const int BOARD_SIZE = 9, EMPTY_SLOT = 0, BTN_SIZE = 60, BACK_SIZE = 566, NUM_ZERO = 48, NUM_NINE = 57,
            NUMPAD_ZERO = 96, NUMPAD_NINE = 105, LEFT_ARROW = 37, UP_ARROW = 38, RIGHT_ARROW = 39, DOWN_ARROW = 40,
            BACKSPACE = 8, DELETE = 46;

        private static Color BACKGROUND_COLOR = Color.Gray, BACK_BACKGROUND_COLOR = Color.Black, SELECTED_COLOR = Color.DarkGray,
            STARTING_DIGIT_COLOR = Color.Cyan, MISTAKE_COLOR = Color.Red, NORMAL_DIGIT_COLOR = Color.Black;

        private static Board frontBoard = new Board(), backBoard = new Board();
        private static Label? currSelection;
        private static MainScreen? mainScreen;
        private static string? difficulty;
        private static int mistakes = 0, emptySpots = 0;

        public GameScreen(string difficultyReference, MainScreen mainScreenReference)
        {
            InitializeComponent();
            mainScreen = mainScreenReference;
            difficulty = difficultyReference;

            mistakeText.SelectAll();
            mistakeText.SelectionColor = Color.Black;
            mistakeText.Location = new Point((Width / 2) - (mistakeText.Width / 2), 1);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            string dirPath = "..\\..\\..\\ReadyBoards\\" + difficulty;
            DirectoryInfo myDir = new DirectoryInfo(dirPath);
            int count = myDir.GetFiles().Length;
            Random rnd = new Random();
            int boardNum = rnd.Next(count) + 1;
            string boardPath = dirPath + "\\" + difficulty + "Board" + boardNum;

            mistakes = 0;
            emptySpots = 80;

            if (File.Exists(boardPath))
            {
                ParseBoard(boardPath);
            }
            else
            {
                Console.WriteLine("Couldn't find file!!\nBoard Path: " + boardPath);
            }

            AddBoardToScreen();
        }

        void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            int val = e.KeyValue, index = int.Parse(currSelection.Name), pressedNumber = 0;

            if (val >= LEFT_ARROW && val <= DOWN_ARROW)
            {
                currSelection.BackColor = BACKGROUND_COLOR;

                switch (val)
                {
                    case LEFT_ARROW:
                        if (index % 9 != 0)
                        {
                            currSelection = Controls[(index - 1).ToString()] as Label;
                        }
                        currSelection.BackColor = SELECTED_COLOR;
                        return;
                    case UP_ARROW:
                        if (index >= 9)
                        {
                            currSelection = Controls[(index - 9).ToString()] as Label;
                        }
                        currSelection.BackColor = SELECTED_COLOR;
                        return;
                    case RIGHT_ARROW:
                        if (index == 0 || index % 9 != 8)
                        {
                            currSelection = Controls[(index + 1).ToString()] as Label;
                        }
                        currSelection.BackColor = SELECTED_COLOR;
                        return;
                    case DOWN_ARROW:
                        if (index < 72)
                        {
                            currSelection = Controls[(index + 9).ToString()] as Label;
                        }
                        currSelection.BackColor = SELECTED_COLOR;
                        return;
                    default:
                        return;
                }
            }
            else
            {
                if (currSelection.ForeColor != STARTING_DIGIT_COLOR)
                {
                    if (val > NUM_ZERO && val <= NUM_NINE)
                    {
                        pressedNumber = val - NUM_ZERO;
                        CheckNumberInput(pressedNumber);
                        if (currSelection.Text != "" || currSelection.ForeColor == MISTAKE_COLOR)
                        {
                            emptySpots++;
                        }
                        currSelection.Text = (pressedNumber).ToString();
                        emptySpots--;
                    }
                    else if (val > NUMPAD_ZERO && val <= NUMPAD_NINE)
                    {
                        pressedNumber = val - NUMPAD_ZERO;
                        CheckNumberInput(pressedNumber);
                        if (currSelection.Text != "" || currSelection.ForeColor == MISTAKE_COLOR)
                        {
                            emptySpots++;
                        }
                        currSelection.Text = (pressedNumber).ToString();
                        emptySpots--;
                    }
                    else if (val == DELETE || val == BACKSPACE)
                    {
                        if (currSelection.Text != "")
                        {
                            currSelection.Text = "";
                            emptySpots++;
                        }
                    }
                }
            }
        }

        private void AddBoardToScreen()
        {
            int i = 0, j = 0, currVal = 0, startingX = 0, currX = 0, startingY = 0, currY = 0, index = 0;
            Label label;

            startingX = (Width / 2) - (BACK_SIZE / 2);
            startingY = (Height / 2) - (BACK_SIZE / 2);
            currY = startingY;

            label = new Label();
            label.Size = new Size(BACK_SIZE, BACK_SIZE);
            label.Location = new Point(startingX, startingY);
            label.BackColor = BACK_BACKGROUND_COLOR;
            Controls.Add(label);

            for (i = 0; i < BOARD_SIZE; i++)
            {
                currX = startingX;
                if (i != 0 && i % 3 == 0)
                {
                    currY += 5;
                }
                else
                {
                    currY += 2;
                }

                for (j = 0; j < BOARD_SIZE; j++)
                {
                    currVal = frontBoard.GetSpot(i, j);

                    if (j != 0 && j % 3 == 0)
                    {
                        currX += 5;
                    }
                    else
                    {
                        currX += 2;
                    }

                    label = new Label();
                    label.Size = new Size(BTN_SIZE, BTN_SIZE);
                    label.Location = new Point(currX, currY);
                    label.BackColor = BACKGROUND_COLOR;
                    label.Name = index.ToString();
                    label.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Click += new EventHandler(HighlightSelection);

                    if (currVal != EMPTY_SLOT)
                    {
                        label.Text = currVal.ToString();
                        label.ForeColor = STARTING_DIGIT_COLOR;
                        emptySpots--;
                    }

                    Controls.Add(label);
                    label.BringToFront();
                    currX += BTN_SIZE;
                    index++;
                }
                currY += BTN_SIZE;
            }
        }

        private void HighlightSelection(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            if (currSelection != null)
            {
                currSelection.BackColor = BACKGROUND_COLOR;
            }

            currSelection = label;
            currSelection.BackColor = SELECTED_COLOR;
        }

        private void ParseBoard(string boardPath)
        {
            string fileContents = File.ReadAllText(boardPath).Substring(1);

            string frontBoardString = fileContents.Substring(fileContents.IndexOf("{") + 1);
            frontBoardString = frontBoardString.Split("}")[0];
            StringIntoBoard(frontBoard, frontBoardString);

            string backBoardString = fileContents.Split("{")[0];
            backBoardString = backBoardString.Split("}")[0];
            StringIntoBoard(backBoard, backBoardString);
        }

        private void StringIntoBoard(Board board, string boardContents)
        {
            int tempIndex = 0, rowIndex = 0, colIndex = 0;
            string[] rows = boardContents.Split("],\r\n");

            foreach (string row in rows)
            {
                if (row.Contains("["))
                {
                    colIndex = 0;
                    tempIndex = row.IndexOf("[");
                    string[] digits = (row.Substring(tempIndex + 1)).Split(", ");

                    foreach (string digit in digits)
                    {
                        if (!string.IsNullOrEmpty(digit))
                        {
                            board.SetSpot(rowIndex, colIndex, int.Parse(digit));
                            colIndex++;
                        }
                    }
                    rowIndex++;
                }
            }
        }

        private void OnFormClose(object sender, FormClosedEventArgs e)
        {
            if (mainScreen != null)
                mainScreen.Show();
        }

        private void CheckNumberInput(int chosenNum)
        {
            if (chosenNum != backBoard.GetSpot(int.Parse(currSelection.Name)))
            {
                currSelection.ForeColor = MISTAKE_COLOR;
                mistakes++;
                mistakeText.Text = "Mistakes: " + mistakes.ToString() + "/4";
                mistakeText.SelectAll();
                mistakeText.SelectionColor = Color.Black;
                if (mistakes == 4)
                {
                    EndGame(false);
                }
            }
            else
            {
                currSelection.ForeColor = NORMAL_DIGIT_COLOR;
                if (emptySpots == 0)
                {
                    EndGame(true);
                }
            }
        }

        private void EndGame(bool win)
        {
            if (win)
            {
                Console.WriteLine("Win");
                Close();
            }
            else
            {
                Console.WriteLine("Lose");
                Close();
            }
        }
    }
}
