using Sudoku;
using SudokuGUI;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace SudokuGUI.Code
{
    internal class Sudoku
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainScreen());
        }
    }
}