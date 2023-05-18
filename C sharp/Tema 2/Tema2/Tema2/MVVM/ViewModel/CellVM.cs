using Tema2.Commands;
using Tema2.MVVM.Model;
using Tema2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tema2.MVVM.ViewModel
{
    class CellVM : BaseNotification
    {
        GameBusinessLogic bl;
        public CellVM(int x, int y, Cell.CellColor cellType, Cell.PieceType pieceType, GameBusinessLogic bl)
        {
            SimpleCell = new Cell(x, y, cellType, pieceType);
            this.bl = bl;
        }

        private Cell simpleCell;
        public Cell SimpleCell
        {
            get { return simpleCell; }
            set
            {
                simpleCell = value;
                NotifyPropertyChanged("SimpleCell");
            }
        }

        private ICommand clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                clickCommand = new RelayCommand<Cell>(bl.ClickAction);
                return clickCommand;
            }
        }
    }
}
