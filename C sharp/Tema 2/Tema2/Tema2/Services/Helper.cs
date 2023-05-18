using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema2.MVVM.Model;

namespace Tema2.Services
{
    class Helper
    {
        public static Cell CurrentCell { get; set; }
        public static Cell PreviousCell { get; set; }

        public static Tuple<ObservableCollection<ObservableCollection<Cell>>, bool, bool>
            InitGameBoard(string filePath, bool mode = true)
        {
            ObservableCollection<ObservableCollection<Cell>> board = new ObservableCollection<ObservableCollection<Cell>>();
            bool playerRed = true;

            System.IO.StreamReader piecesPositionFile = new System.IO.StreamReader(filePath);
            System.IO.StreamReader boardColorsFile = new System.IO.StreamReader(BoardColorsPath);
            for (int line = 0; line < 8; ++line)
            {
                board.Add(new ObservableCollection<Cell>());
                string piecesLine, boardLine;
                piecesLine = piecesPositionFile.ReadLine();
                boardLine = boardColorsFile.ReadLine();
                for (int column = 0; column < 8; ++column)
                {
                    board[line].Add(new Cell(line, column,
                        ConvertCellColor(boardLine[2 * column]),
                        ConvertPieceType(piecesLine[2 * column])));
                }
            }
            boardColorsFile.Close();

            string playerIndex = piecesPositionFile.ReadLine();
            if (playerIndex == "2")
                playerRed = false;

            string modeIndex;
            if ((modeIndex = piecesPositionFile.ReadLine()) != null)
            {
                if (modeIndex == "1")
                    mode = true;
                else
                    mode = false;
            }
            piecesPositionFile.Close();

            ClickableCells(board, playerRed);

            return new Tuple<ObservableCollection<ObservableCollection<Cell>>, bool, bool>(board, playerRed, mode);
        }

        private static bool PieceOfColor(Cell cell, bool red)
        {
            if (red)
                return (cell.Piece == Cell.PieceType.Red || cell.Piece == Cell.PieceType.RedKing);
            else
                return (cell.Piece == Cell.PieceType.Black || cell.Piece == Cell.PieceType.BlackKing);
        }

        public static void ClickableCells(ObservableCollection<ObservableCollection<Cell>> cells, bool redTurn)
        {
            for (int line = 0; line < cells.Count; ++line)
                for (int column = 0; column < cells[line].Count; ++column)
                    cells[line][column].Clickable = PieceOfColor(cells[line][column], redTurn);
        }

        public static bool RedPiece(Cell cell)
        {
            return cell.Piece == Cell.PieceType.Red || cell.Piece == Cell.PieceType.RedKing;
        }

        public static Cell.CellColor ConvertCellColor(char colorIndex)
        {
            switch (colorIndex)
            {
                case '1':
                    return Cell.CellColor.Red;
                case '2':
                    return Cell.CellColor.Black;
                default:
                    return Cell.CellColor.None;
            }
        }

        public static Cell.PieceType ConvertPieceType(char pieceIndex)
        {
            switch (pieceIndex)
            {
                case '1':
                    return Cell.PieceType.Red;
                case '2':
                    return Cell.PieceType.Black;
                case '3':
                    return Cell.PieceType.RedKing;
                case '4':
                    return Cell.PieceType.BlackKing;
                default:
                    return Cell.PieceType.Empty;
            }
        }

        private static bool isMultipleJump;
        public static bool IsMultipleJump
        {
            get { return isMultipleJump; }
            set { isMultipleJump = value; }
        }

        private static bool redTurn;
        public static bool RedTurn
        {
            get { return redTurn; }
            set { redTurn = value; 
            }
        }

        private static string loadGamePath;
        public static string LoadGamePath
        {
            get { return loadGamePath; }
            set { loadGamePath = value; }
        }

        private static ObservableCollection<ObservableCollection<Cell>> cells;
        public static ObservableCollection<ObservableCollection<Cell>> Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        public static string BoardColorsPath
        {
            get { return @"..\..\Resources\Helper\BoardColors.txt"; }
        }

        public static string NewGamePath
        {
            get { return @"..\..\Resources\Helper\New Game.txt"; }
        }

        public static string SaveLocationPath
        {
            get { return @"..\..\Resources\Helper\SaveLocation.txt"; }
        }

        public static string StatisticsPath
        {
            get { return @"..\..\Resources\Helper\Statistics.txt"; }
        }
    }
}