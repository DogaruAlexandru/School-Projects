using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema2.MVVM.Model
{
    class Cell : INotifyPropertyChanged
    {
        public Cell(int x, int y, CellColor cellColor, PieceType pieceType)
        {
            this.X = x;
            this.Y = y;
            this.cellColor = cellColor;
            this.pieceType = pieceType;
        }

        private int x;
        public int X
        {
            get { return x; }
            set
            {
                x = value;
                NotifyPropertyChanged("X");
            }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set
            {
                y = value;
                NotifyPropertyChanged("Y");
            }
        }

        public enum CellColor
        {
            None,
            Red,
            Black,
            Selected,
            Possible,
        }
        private CellColor cellColor;
        public CellColor Square
        {
            get { return cellColor; }
            set
            {
                cellColor = value;
                NotifyPropertyChanged("Square");
            }
        }
        public string BackgroundColor
        {
            get
            {
                switch (cellColor)
                {
                    case CellColor.Black: return "Black";
                    case CellColor.Red: return "Red";
                    case CellColor.Selected: return "#58A1A1";
                    case CellColor.Possible: return "#70B798";
                    default: return "Transparent";
                }
            }
            set
            {
                switch (value)
                {
                    case "Black":
                        cellColor = CellColor.Black;
                        break;
                    case "Red":
                        cellColor = CellColor.Red;
                        break;
                    case "#58A1A1":
                        cellColor = CellColor.Selected;
                        break;
                    case "#70B798":
                        cellColor = CellColor.Possible;
                        break;
                    default:
                        cellColor = CellColor.None;
                        break;
                }
                NotifyPropertyChanged("BackgroundColor");
            }
        }

        public enum PieceType
        {
            Empty,
            Red,
            Black,
            RedKing,
            BlackKing
        }
        private PieceType pieceType;
        public PieceType Piece
        {
            get { return pieceType; }
            set
            {
                pieceType = value;
                NotifyPropertyChanged("Piece");
            }
        }

        public string PieceTypeToPieceIndex
        {
            get
            {
                switch (Piece)
                {
                    case PieceType.Red:
                        return "1";
                    case PieceType.Black:
                        return "2";
                    case PieceType.RedKing:
                        return "3";
                    case PieceType.BlackKing:
                        return "4";
                    default:
                        return "0";
                }
            }
        }
        public string PieceImage
        {
            get
            {
                switch (pieceType)
                {
                    case PieceType.Black:
                        return "/Tema2;component/Resources/Images/Black.png";
                    case PieceType.Red:
                        return "/Tema2;component/Resources/Images/Red.png";
                    case PieceType.BlackKing:
                        return "/Tema2;component/Resources/Images/BlackKing.png";
                    case PieceType.RedKing:
                        return "/Tema2;component/Resources/Images/RedKing.png";
                    default:
                        return null;
                }
            }
        }

        private bool clickable;
        public bool Clickable
        {
            get { return clickable; }
            set
            {
                clickable = value;
                NotifyPropertyChanged("Clickable");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
