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

using Microsoft.Win32;
using Tema1.Models;
using Tema1.Views;

namespace Tema1.Views
{
    /// <summary>
    /// Interaction logic for AdminMode.xaml
    /// </summary>
    public partial class AdminMode : UserControl
    {
        public Words words;

        public AdminMode()
        {
            InitializeComponent();

            words = DataContext as Words;
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Filter = "PNG File|*.png|JPG File|*.jpg|All Files|*.*";
            fileDialog.DefaultExt = ".*";
            Nullable<bool> dialogOk = fileDialog.ShowDialog();
            if (dialogOk == true)
                imageTextBox.Text = fileDialog.FileNames[0];

            imageTextBox.Focus();
        }

        private void categoryCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (categoryCheckBox.IsChecked == true)
            {
                categoryComboBox.IsEnabled = false;
                categoryTextBox.IsEnabled = true;
                categoryComboBox.SelectedItem = null;
            }
            else
            {
                categoryComboBox.IsEnabled = true;
                categoryTextBox.IsEnabled = false;
                categoryTextBox.Text = "";
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if ((System.IO.File.Exists(imageTextBox.Text) == false && imageTextBox.Text != "") ||
                (categoryComboBox.SelectedItem == null && categoryTextBox.Text == "") ||
                nameTextBox.Text == "" || descriptionTextBox.Text == "")
                return;

            foreach (Word word in words.WordsList)
                if (word.Name == nameTextBox.Text)
                    return;

            if (imageTextBox.Text != "")
            {
                string imgName = nameTextBox.Text + ".png";
                System.IO.File.Copy(imageTextBox.Text, @"..\..\Resources\Images\" + imgName);

                if (categoryCheckBox.IsChecked == true)
                    words.Add(new Word(nameTextBox.Text.ToLower(), 
                        descriptionTextBox.Text, categoryTextBox.Text.ToLower(), imgName));
                else
                    words.Add(new Word(nameTextBox.Text.ToLower(),
                        descriptionTextBox.Text, categoryComboBox.Text, imgName));
            }
            else if (categoryCheckBox.IsChecked == true)
                words.Add(new Word(nameTextBox.Text.ToLower(), 
                    descriptionTextBox.Text, categoryTextBox.Text.ToLower()));
            else
                words.Add(new Word(nameTextBox.Text.ToLower(),
                    descriptionTextBox.Text, categoryComboBox.Text));

            categoryCheckBox.IsChecked = false;
            categoryComboBox.SelectedItem = null;
            categoryComboBox.IsEnabled = true;
            categoryTextBox.IsEnabled = false;
            nameTextBox.Text = "";
            descriptionTextBox.Text = "";
            categoryTextBox.Text = "";
            imageTextBox.Text = "";

            Reload();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem == null)
                return;
            Word word = listView.SelectedItem as Word;

            words.Delete(word);

            Reload();
        }

        private void deselectButton_Click(object sender, RoutedEventArgs e)
        {
            listView.UnselectAll();
            categoryCheckBox.IsChecked = false;
            categoryTextBox.IsEnabled = false;
            categoryComboBox.IsEnabled = true;
            deselectButton.IsEnabled = false;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            deselectButton.IsEnabled = true;
            Word word = listView.SelectedItem as Word;
            if (word != null)
                categoryComboBox.SelectedItem = word.Category;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            words.UpdateFile();
            words.Clear();
            words.ReadFile();
        }
    }
}
