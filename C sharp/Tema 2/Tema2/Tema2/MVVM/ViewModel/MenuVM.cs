using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Tema2.Commands;
using Tema2.MVVM.View;
using Tema2.Services;

namespace Tema2.MVVM.ViewModel
{
    class MenuVM : BaseNotification
    {
        private ICommand newGame;
        public ICommand NewGame
        {
            get
            {
                newGame = new RelayCommand<object>(o =>
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Use multiple jump mode?",
                        "Game mode", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                        Helper.IsMultipleJump = true;
                    else if (result == MessageBoxResult.No)
                        Helper.IsMultipleJump = false;

                    Helper.LoadGamePath = Helper.NewGamePath;

                    MainVM mainVM = App.Current.MainWindow.DataContext as MainVM;
                    mainVM.SwitchView = 1;
                });
                return newGame;
            }
        }

        private ICommand about;
        public ICommand About
        {
            get
            {
                about = new RelayCommand<object>(o =>
                {
                    MainVM mainVM = App.Current.MainWindow.DataContext as MainVM;
                    mainVM.SwitchView = 2;
                });
                return about;
            }
        }

        private ICommand fileLocation;
        public ICommand FileLocation
        {
            get
            {
                fileLocation = new RelayCommand<object>(o =>
                {
                    System.IO.StreamReader locationPathFile = new System.IO.StreamReader(Helper.SaveLocationPath);
                    string locationPath = locationPathFile.ReadLine();
                    locationPathFile.Close();
                    if (MessageBoxResult.Yes == System.Windows.MessageBox.Show("Current file location:\n" +
                        locationPath + "\n\nChange the location?", "File location", MessageBoxButton.YesNo))
                        using (var fbd = new FolderBrowserDialog())
                        {
                            DialogResult result = fbd.ShowDialog();

                            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                            {
                                string newPath = fbd.SelectedPath;
                                using (StreamWriter writer = new StreamWriter(Helper.SaveLocationPath))
                                {
                                    writer.WriteLine(newPath);
                                }
                            }
                        }
                });
                return fileLocation;
            }
        }

        private ICommand statistics;
        public ICommand Statistics
        {
            get
            {
                statistics = new RelayCommand<object>(o =>
                {
                    System.IO.StreamReader statisticsFile = new System.IO.StreamReader(Helper.StatisticsPath);
                    string red = statisticsFile.ReadLine();
                    string black = statisticsFile.ReadLine();
                    statisticsFile.Close();
                    System.Windows.MessageBox.Show("Games won:\nRed: " + red + "\nBlack: " + black,
                        "Statistics", MessageBoxButton.OK);
                });
                return statistics;
            }
        }

        private ICommand loadGame;
        public ICommand LoadGame
        {
            get
            {
                loadGame = new RelayCommand<object>(o =>
                {
                    MainVM mainVM = App.Current.MainWindow.DataContext as MainVM;
                    mainVM.SwitchView = 3;
                });
                return loadGame;
            }
        }

        private ICommand exit;
        public ICommand Exit
        {
            get
            {
                exit = new RelayCommand<object>(o =>
                {
                    MainWindow mainWindow = App.Current.MainWindow as MainWindow;
                    mainWindow.Close();
                });
                return exit;
            }
        }
    }
}
