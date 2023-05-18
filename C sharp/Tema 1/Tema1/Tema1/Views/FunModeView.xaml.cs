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
    /// Interaction logic for FunMode.xaml
    /// </summary>
    public partial class FunMode : UserControl
    {
        TestQuestions testQuestions;
        ObservableCollection<string> answers;
        int currentQuesion;

        public FunMode()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            testQuestions = new TestQuestions();
            currentQuesion = 0;
            answerTextBox.Text = "";

            answers = new ObservableCollection<string>();
            for (int index = 0; index < testQuestions.Count; ++index)
                answers.Add(answerTextBox.Text);

            startButton.Visibility = Visibility.Hidden;
            answerTextBox.Visibility = Visibility.Visible;
            nextButton.Visibility = Visibility.Visible;
            restartButton.Visibility = Visibility.Hidden;
            endScreenGrid.Visibility = Visibility.Hidden;

            ShowQuestion(currentQuesion);
        }

        private void ShowQuestion(int index)
        {
            if (index > 0)
                backButton.Visibility = Visibility.Visible;
            else
                backButton.Visibility = Visibility.Hidden;

            if (index < testQuestions.Count - 1)
            {
                nextButton.Visibility = Visibility.Visible;
                finishButton.Visibility = Visibility.Hidden;
            }
            else
            {
                nextButton.Visibility = Visibility.Hidden;
                finishButton.Visibility = Visibility.Visible;
            }

            Word word = testQuestions.QuestionsList[index].Item1;
            if (testQuestions.QuestionsList[index].Item2 == TestQuestions.ClueType.Description)
            {
                clueImage.Visibility = Visibility.Hidden;
                clueDescriptonGrid.Visibility = Visibility.Visible;

                descriptionTextBlock.Text = word.Description;
            }
            else
            {
                clueImage.Visibility = Visibility.Visible;
                clueDescriptonGrid.Visibility = Visibility.Hidden;

                clueImage.Source = new ImageSourceConverter().
                ConvertFromString(@"..\..\Resources\Images\" + word.ImagePath) as ImageSource;
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            answers[currentQuesion] = answerTextBox.Text;
            answerTextBox.Text = answers[currentQuesion + 1];

            ShowQuestion(++currentQuesion);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            answers[currentQuesion] = answerTextBox.Text;
            answerTextBox.Text = answers[currentQuesion - 1];

            ShowQuestion(--currentQuesion);
        }

        private void finishButton_Click(object sender, RoutedEventArgs e)
        {
            answers[currentQuesion] = answerTextBox.Text;

            EndScreen();
        }

        private void EndScreen()
        {
            restartButton.Visibility = Visibility.Visible;
            endScreenGrid.Visibility = Visibility.Visible;

            nextButton.Visibility = Visibility.Hidden;
            finishButton.Visibility = Visibility.Hidden;
            backButton.Visibility = Visibility.Hidden;
            answerTextBox.Visibility = Visibility.Hidden;
            clueImage.Visibility = Visibility.Hidden;
            clueDescriptonGrid.Visibility = Visibility.Hidden;

            int count = 0;
            string score = string.Empty;
            for (int index = 0; index < testQuestions.Count; ++index)
            {
                string correctAnswers = testQuestions.QuestionsList[index].Item1.Name.ToLower();
                score += index + 1 + ". răspuns: " + answers[index] + " | ";
                if (answers[index].ToLower() == correctAnswers)
                {
                    score += "corect" + Environment.NewLine;
                    ++count;
                }
                else
                    score += "greșit - răspuns corect: " + correctAnswers + Environment.NewLine;
            }
            score += Environment.NewLine + "Scor: " + count + "/" + testQuestions.Count;

            endScreenTextBlock.Text = score;
        }
    }
}
