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

namespace Tema1.Views
{
    /// <summary>
    /// Interaction logic for SearchMode.xaml
    /// </summary>
    public partial class SearchMode : UserControl
    {
        public Words words;

        public SearchMode()
        {
            InitializeComponent();

            words = DataContext as Words;
        }

        private void categoryCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (categoryCheckBox.IsChecked == true)
                categoryComboBox.IsEnabled = true;
            else
            {
                categoryComboBox.SelectedItem = null;
                categoryComboBox.IsEnabled = false;
            }
        }

        private void TextBoxKeyUp(object sender, KeyEventArgs e)
        {
            bool isFound = false;
            var border = (searchStackPanel.Parent as ScrollViewer).Parent as Border;

            ObservableCollection<Word> data = new ObservableCollection<Word>();
            if (categoryComboBox.SelectedItem != null)
                data = words.GetWordsInCategory(categoryComboBox.Text);
            else
                data = words.WordsList;

            string find = (sender as TextBox).Text;
            if (find.Length == 0)
            {
                searchStackPanel.Children.Clear();
                border.Visibility = Visibility.Collapsed;
            }
            else
                border.Visibility = Visibility.Visible;

            searchStackPanel.Children.Clear();
            foreach (var word in data)
            {
                if (word.Name.ToLower().StartsWith(find.ToLower()))
                {
                    AddItems(word);
                    isFound = true;
                }
            }

            if (!isFound)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "Nu exista..";
                textBlock.FontSize = 15;
                textBlock.Foreground = new SolidColorBrush(Colors.White);
                searchStackPanel.Children.Add(textBlock);
            }
        }

        public void AddItems(Word word)
        {
            Label block = new Label();
            block.DataContext = word;
            block.Content = word.Name;
            block.FontSize = 16;
            block.Height = 30;
            block.Foreground = new SolidColorBrush(Colors.White);
            block.Margin = new Thickness(1, 1, 1, 1);
            block.HorizontalContentAlignment = HorizontalAlignment.Left;
            block.VerticalAlignment = VerticalAlignment.Center;

            block.MouseLeftButtonDown += (sender, e) =>
            {
                searchTextBox.Text = (sender as Label).Content.ToString();
                searchTextBox.DataContext = (sender as Label).DataContext;

                var border = (searchStackPanel.Parent as ScrollViewer).Parent as Border;
                border.Visibility = Visibility.Hidden;

                image.Source = new ImageSourceConverter().
                ConvertFromString(@"..\..\Resources\Images\" + word.ImagePath) as ImageSource;
            };

            block.MouseEnter += (sender, e) =>
            {
                Label label = sender as Label;
                label.Background = new SolidColorBrush(Colors.WhiteSmoke);
                label.Foreground = new SolidColorBrush(Colors.DodgerBlue);
            };

            block.MouseLeave += (sender, e) =>
            {
                Label label = sender as Label;
                label.Background = new SolidColorBrush(Colors.Transparent);
                label.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
            };

            searchStackPanel.Children.Add(block);
        }
    }
}
