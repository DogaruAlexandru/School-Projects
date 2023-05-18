using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tema1.Models;
using Tema1.ViewModels;

namespace Tema1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AdminModeModel adminModeModel;
        SearchModeModel searchModeModel;
        FunModeModel funModeModel;

        public MainWindow()
        {
            InitializeComponent();

            adminModeModel = new AdminModeModel();
            searchModeModel = new SearchModeModel();
            funModeModel = new FunModeModel();
        }

        private void adminButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = adminModeModel;
            adminButton.Background = Brushes.LightCyan;
            searchButton.Background = Brushes.LightGray;
            funButton.Background = Brushes.LightGray;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = searchModeModel;
            adminButton.Background = Brushes.LightGray;
            searchButton.Background = Brushes.LightCyan;
            funButton.Background = Brushes.LightGray;
        }

        private void funButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = funModeModel;
            adminButton.Background = Brushes.LightGray;
            searchButton.Background = Brushes.LightGray;
            funButton.Background = Brushes.LightCyan;
        }
    }
}
