using Tema2.MVVM.Model;
using Tema2.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace Tema2.Services
{
    class GameBusinessLogic: BaseNotification
    {
        public ObservableCollection<ObservableCollection<Cell>> cells { get; set; }
        public GameBoardVM gameBoardVM;
        private bool attackMade;

        public GameBusinessLogic(Tuple<ObservableCollection<ObservableCollection<Cell>>, bool, bool> game)
        {
            cells = game.Item1;
            Helper.RedTurn = game.Item2;
            Helper.IsMultipleJump = game.Item3;
            attackMade = false;
        }

        public void ClickAction(Cell obj)
        {
            Helper.CurrentCell = obj;
            if (Helper.PreviousCell == null)
            {
                cells[Helper.CurrentCell.X][Helper.CurrentCell.Y].Square = Cell.CellColor.Selected;
                PossibleMoves(Helper.CurrentCell);
                Helper.PreviousCell = Helper.CurrentCell;
                gameBoardVM.GameBoard = gameBoardVM.CellBoardToCellVMBoard(cells);
            }
            else if (Helper.PreviousCell != null)
            {
                switch (Helper.CurrentCell.Square)
                {
                    case Cell.CellColor.Possible:
                        attackMade = Execute();

                        if (PossibleMoves(cells[Helper.CurrentCell.X][Helper.CurrentCell.Y], false, true) &&
                            Helper.IsMultipleJump && attackMade)
                        {
                            DeselectAll(true);
                            cells[Helper.CurrentCell.X][Helper.CurrentCell.Y].Square = Cell.CellColor.Selected;
                            cells[Helper.CurrentCell.X][Helper.CurrentCell.Y].Clickable = true;
                            PossibleMoves(cells[Helper.CurrentCell.X][Helper.CurrentCell.Y], true, true);
                            Helper.PreviousCell = Helper.CurrentCell;
                        }
                        else
                        {
                            DeselectAll();
                            ChnageTurn();
                            Helper.PreviousCell = null;
                        }

                        gameBoardVM.GameBoard = gameBoardVM.CellBoardToCellVMBoard(cells);
                        GameEnded();
                        break;
                    case Cell.CellColor.Black:
                        DeselectAll();
                        cells[Helper.CurrentCell.X][Helper.CurrentCell.Y].Square = Cell.CellColor.Selected;
                        PossibleMoves(Helper.CurrentCell);
                        Helper.PreviousCell = Helper.CurrentCell;
                        gameBoardVM.GameBoard = gameBoardVM.CellBoardToCellVMBoard(cells);
                        break;
                    case Cell.CellColor.Selected:
                        DeselectAll();
                        if (attackMade)
                        {
                            attackMade = false;
                            ChnageTurn();
                        }
                        gameBoardVM.GameBoard = gameBoardVM.CellBoardToCellVMBoard(cells);
                        break;
                }
            }
            Helper.Cells = cells;
        }

        private void GameEnded()
        {
            for (int line = 0; line < cells.Count; ++line)
                for (int column = 0; column < cells[line].Count; column += 2)
                    if (cells[line][column + (line + 1) % 2].Piece != Cell.PieceType.Empty &&
                        Helper.RedPiece(cells[line][column + (line + 1) % 2]) == Helper.RedTurn &&
                        PossibleMoves(cells[line][column + (line + 1) % 2], false))
                        return;

            string s;
            if (!Helper.RedTurn)
            {
                s = "Red";
            }
            else
                s = "Black";
            System.Windows.MessageBox.Show(s + " player won!", "", MessageBoxButton.OK);

            string redScore, blackScore;
            using (StreamReader reader = new StreamReader(Helper.StatisticsPath))
            {
                redScore = reader.ReadLine();
                blackScore = reader.ReadLine();
            }
            using (StreamWriter writer = new StreamWriter(Helper.StatisticsPath))
            {
                if (!Helper.RedTurn)
                {
                    redScore = (int.Parse(redScore) + 1).ToString();
                }
                else
                    blackScore = (int.Parse(blackScore) + 1).ToString();

                writer.WriteLine(redScore);
                writer.WriteLine(blackScore);
            }

            MainVM mainVM = App.Current.MainWindow.DataContext as MainVM;
            mainVM.SwitchView = 0;
        }

        private void MakeKing()
        {
            int x = Helper.CurrentCell.X;
            int y = Helper.CurrentCell.Y;

            switch (cells[x][y].Piece)
            {
                case Cell.PieceType.Red:
                    if (x == 0)
                        cells[x][y].Piece = Cell.PieceType.RedKing;
                    break;
                case Cell.PieceType.Black:
                    if (x == 7)
                        cells[x][y].Piece = Cell.PieceType.BlackKing;
                    break;
            }
        }

        private void ChnageTurn()
        {
            Helper.RedTurn = Helper.RedTurn == false;
            Helper.ClickableCells(cells, Helper.RedTurn);
            if (Helper.RedTurn)
                gameBoardVM.PlayerTurnText = "Player turn: Red";
            else
                gameBoardVM.PlayerTurnText = "Player turn: Black";
            NotifyPropertyChanged("gameBoardVM.PlayerTurnText");
        }

        private void DeselectAll(bool resetClickable = false)
        {
            for (int line = 0; line < cells.Count; ++line)
                for (int column = 0; column < cells[line].Count; column += 2)
                {
                    cells[line][column + (line + 1) % 2].Square = Cell.CellColor.Black;
                    if (resetClickable)
                        cells[line][column + (line + 1) % 2].Clickable = false;
                }
        }

        private bool PossibleMoves(Cell cell, bool show = true, bool onlyAttack = false)
        {
            bool foundAttacks = Attacks(cell, show);
            if (!onlyAttack)
            {
                bool foundMoves = Moves(cell, show);
                return foundMoves || foundAttacks;
            }
            return foundAttacks;
        }

        private bool Moves(Cell cell, bool show)
        {
            switch (cell.Piece)
            {
                case Cell.PieceType.Red:
                    return MovesUp(cell, show);
                case Cell.PieceType.Black:
                    return MovesDown(cell, show);
                case Cell.PieceType.RedKing:
                case Cell.PieceType.BlackKing:
                    bool foundUp = MovesUp(cell, show);
                    bool foundDown = MovesDown(cell, show);
                    return foundUp || foundDown;
                default:
                    return false;
            }
        }

        private bool MovesUp(Cell cell, bool show)
        {
            bool found = false;
            if (cell.X > 0)
            {
                if (cell.Y > 0 && cells[cell.X - 1][cell.Y - 1].Piece == Cell.PieceType.Empty)
                {
                    if (show)
                    {
                        cells[cell.X - 1][cell.Y - 1].Square = Cell.CellColor.Possible;
                        cells[cell.X - 1][cell.Y - 1].Clickable = true;
                    }
                    found = true;
                }
                if (cell.Y < 7 && cells[cell.X - 1][cell.Y + 1].Piece == Cell.PieceType.Empty)
                {
                    if (show)
                    {
                        cells[cell.X - 1][cell.Y + 1].Square = Cell.CellColor.Possible;
                        cells[cell.X - 1][cell.Y + 1].Clickable = true;
                    }
                    found = true;
                }
            }
            return found;
        }

        private bool MovesDown(Cell cell, bool show)
        {
            bool found = false;
            if (cell.X < 7)
            {
                if (cell.Y > 0 && cells[cell.X + 1][cell.Y - 1].Piece == Cell.PieceType.Empty)
                {
                    if (show)
                    {
                        cells[cell.X + 1][cell.Y - 1].Square = Cell.CellColor.Possible;
                        cells[cell.X + 1][cell.Y - 1].Clickable = true;
                    }
                    found = true;
                }
                if (cell.Y < 7 && cells[cell.X + 1][cell.Y + 1].Piece == Cell.PieceType.Empty)
                {
                    if (show)
                    {
                        cells[cell.X + 1][cell.Y + 1].Square = Cell.CellColor.Possible;
                        cells[cell.X + 1][cell.Y + 1].Clickable = true;
                    }
                    found = true;
                }
            }
            return found;
        }

        private bool Attacks(Cell cell, bool show)
        {
            switch (cell.Piece)
            {
                case Cell.PieceType.Red:
                    return AttackUp(cell, show);
                case Cell.PieceType.Black:
                    return AttackDown(cell, show);
                case Cell.PieceType.RedKing:
                case Cell.PieceType.BlackKing:
                    bool foundUp = AttackUp(cell, show);
                    bool foundDown = AttackDown(cell, show);
                    return foundUp || foundDown;
            }
            return false;
        }

        private bool AttackUp(Cell cell, bool show)
        {
            bool found = false;
            if (cell.X > 1)
            {
                if (cell.Y > 1 && cells[cell.X - 2][cell.Y - 2].Piece == Cell.PieceType.Empty &&
                    cells[cell.X - 1][cell.Y - 1].Piece != Cell.PieceType.Empty &&
                    Helper.RedPiece(cells[cell.X - 1][cell.Y - 1]) != Helper.RedPiece(cells[cell.X][cell.Y]))
                {
                    if (show)
                    {
                        cells[cell.X - 2][cell.Y - 2].Square = Cell.CellColor.Possible;
                        cells[cell.X - 2][cell.Y - 2].Clickable = true;
                    }
                    found = true;
                }
                if (cell.Y < 6 && cells[cell.X - 2][cell.Y + 2].Piece == Cell.PieceType.Empty &&
                    cells[cell.X - 1][cell.Y + 1].Piece != Cell.PieceType.Empty &&
                    Helper.RedPiece(cells[cell.X - 1][cell.Y + 1]) !=
                    Helper.RedPiece(cells[cell.X][cell.Y]))
                {
                    if (show)
                    {
                        cells[cell.X - 2][cell.Y + 2].Square = Cell.CellColor.Possible;
                        cells[cell.X - 2][cell.Y + 2].Clickable = true;
                    }
                    found = true;
                }
            }
            return found;
        }

        private bool AttackDown(Cell cell, bool show)
        {
            bool found = false;
            if (cell.X < 6)
            {
                if (cell.Y > 1 && cells[cell.X + 2][cell.Y - 2].Piece == Cell.PieceType.Empty &&
                    cells[cell.X + 1][cell.Y - 1].Piece != Cell.PieceType.Empty &&
                    Helper.RedPiece(cells[cell.X + 1][cell.Y - 1]) !=
                    Helper.RedPiece(cells[cell.X][cell.Y]))
                {
                    if (show)
                    {
                        cells[cell.X + 2][cell.Y - 2].Square = Cell.CellColor.Possible;
                        cells[cell.X + 2][cell.Y - 2].Clickable = true;
                    }
                    found = true;
                }
                if (cell.Y < 6 && cells[cell.X + 2][cell.Y + 2].Piece == Cell.PieceType.Empty &&
                    cells[cell.X + 1][cell.Y + 1].Piece != Cell.PieceType.Empty &&
                    Helper.RedPiece(cells[cell.X + 1][cell.Y + 1]) !=
                    Helper.RedPiece(cells[cell.X][cell.Y]))
                {
                    if (show)
                    {
                        cells[cell.X + 2][cell.Y + 2].Square = Cell.CellColor.Possible;
                        cells[cell.X + 2][cell.Y + 2].Clickable = true;
                    }
                    found = true;
                }
            }
            return found;
        }

        private bool Execute()
        {
            int cx = Helper.CurrentCell.X;
            int cy = Helper.CurrentCell.Y;
            int px = Helper.PreviousCell.X;
            int py = Helper.PreviousCell.Y;

            bool attackMade = false;

            cells[cx][cy].Piece = cells[px][py].Piece;

            if ((cx + px) % 2 == 0)
            {
                cells[(cx + px) / 2][(cy + py) / 2].Piece = Cell.PieceType.Empty;
                attackMade = true;
            }

            cells[px][py].Piece = Cell.PieceType.Empty;
            MakeKing();
            return attackMade;
        }
    }
}
