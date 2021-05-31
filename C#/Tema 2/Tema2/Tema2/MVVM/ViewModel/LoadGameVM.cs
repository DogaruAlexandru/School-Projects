using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema2.Commands;
using Tema2.MVVM.View;
using Tema2.Services;

namespace Tema2.MVVM.ViewModel
{
    class LoadGameVM : BaseNotification
    {
        private SavedGames games;
        public SavedGames Games
        {
            get { return games; }
            set
            {
                games = value;
                NotifyPropertyChanged("Games");
            }
        }

        public LoadGameVM()
        {
            using (StreamReader reader = new StreamReader(Helper.SaveLocationPath))
            {
                string path = reader.ReadLine();
                games = new SavedGames(path);
            }
        }

        private ICommand back;
        public ICommand Back
        {
            get
            {
                back = new RelayCommand<object>(o =>
                {
                    MainVM mainVM = App.Current.MainWindow.DataContext as MainVM;
                    mainVM.SwitchView = 0;
                });
                return back;
            }
        }

        private ICommand open;
        public ICommand Open
        {
            get
            {
                open = new RelayCommand<object>(o =>
                {
                    string aux;
                    string name = o as string;
                    using (StreamReader reader = new StreamReader(Helper.SaveLocationPath))
                    {
                        string path = reader.ReadLine();
                        aux = path + "\\" + name + ".txt";
                    }
                    Helper.LoadGamePath = aux;

                    games.Remove(name);
                    MainVM mainVM = App.Current.MainWindow.DataContext as MainVM;
                    mainVM.SwitchView = 1;
                });
                return open;
            }
        }
    }
}