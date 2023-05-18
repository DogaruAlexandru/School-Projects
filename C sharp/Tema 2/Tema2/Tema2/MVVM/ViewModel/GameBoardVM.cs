using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema2.Commands;
using Tema2.MVVM.Model;
using Tema2.Services;

namespace Tema2.MVVM.ViewModel
{
    class GameBoardVM : BaseNotification
    {
        private GameBusinessLogic bl;
        public GameBoardVM()
        {
            Tuple<ObservableCollection<ObservableCollection<Cell>>, bool, bool> board =
                Helper.InitGameBoard(Helper.LoadGamePath, Helper.IsMultipleJump);
            Helper.RedTurn = board.Item2;
            bl = new GameBusinessLogic(board);
            gameBoard = CellBoardToCellVMBoard(board.Item1);
            bl.gameBoardVM = this;

            if (Helper.RedTurn)
                PlayerTurnText = "Player turn: Red";
            else
                PlayerTurnText = "Player turn: Black";
        }

        public ObservableCollection<ObservableCollection<CellVM>>
            CellBoardToCellVMBoard(ObservableCollection<ObservableCollection<Cell>> board)
        {
            ObservableCollection<ObservableCollection<CellVM>> result =
                new ObservableCollection<ObservableCollection<CellVM>>();
            for (int i = 0; i < board.Count; i++)
            {
                ObservableCollection<CellVM> line = new ObservableCollection<CellVM>();
                for (int j = 0; j < board[i].Count; j++)
                {
                    Cell c = board[i][j];
                    CellVM cellVM = new CellVM(c.X, c.Y, c.Square, c.Piece, bl);
                    cellVM.SimpleCell.Clickable = c.Clickable;
                    line.Add(cellVM);
                }
                result.Add(line);
            }
            return result;
        }

        private ObservableCollection<ObservableCollection<CellVM>> gameBoard;
        public ObservableCollection<ObservableCollection<CellVM>> GameBoard
        {
            get
            {
                return gameBoard;
            }
            set
            {
                gameBoard = value;
                NotifyPropertyChanged("GameBoard");
            }
        }

        private ICommand backToMenu;
        public ICommand BackToMenu
        {
            get
            {
                backToMenu = new RelayCommand<object>(o =>
                {
                    MainVM mainVM = App.Current.MainWindow.DataContext as MainVM;
                    mainVM.SwitchView = 0;
                });
                return backToMenu;
            }
        }

        private ICommand save;
        public ICommand Save
        {
            get
            {
                save = new RelayCommand<object>(o =>
                {
                    using (StreamReader reader = new StreamReader(Helper.SaveLocationPath))
                    {
                        string name = DateTime.Now.ToString().Replace(':', '-');
                        string path = reader.ReadLine() + "\\" + name + ".txt";

                        using (StreamWriter writer = new StreamWriter(path))
                        {
                            for (int line = 0; line < Helper.Cells.Count; line++)
                            {
                                string aux = "";
                                for (int column = 0; column < Helper.Cells[line].Count; column++)
                                    aux += Helper.Cells[line][column].PieceTypeToPieceIndex + " ";
                                writer.WriteLine(aux);
                            }

                            if (Helper.RedTurn)
                                writer.WriteLine("1");
                            else
                                writer.WriteLine("2");

                            if (Helper.IsMultipleJump)
                                writer.WriteLine("1");
                            else
                                writer.WriteLine("2");
                        }
                    }

                    MainVM mainVM = App.Current.MainWindow.DataContext as MainVM;
                    mainVM.SwitchView = 0;
                });
                return save;
            }
        }

        public string GameModeText
        {
            get
            {
                if (Helper.IsMultipleJump)
                    return "Game mode: Multiple jumps";
                else
                    return "Game mode: Single jump";
            }
        }

        private string playerTurnText;
        public string PlayerTurnText
        {
            get { return playerTurnText; }
            set
            {
                playerTurnText = value;
                NotifyPropertyChanged("PlayerTurnText");
            }
        }
    }
}