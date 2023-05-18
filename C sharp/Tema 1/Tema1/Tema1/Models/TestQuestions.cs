using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1.Models
{
    public class TestQuestions
    {
        public enum ClueType
        {
            None,
            Description,
            Image
        }

        private int count;
        private ObservableCollection<Tuple<Word, ClueType>> questions;

        public TestQuestions(int size = 5)
        {
            count = size;
            questions = new ObservableCollection<Tuple<Word, ClueType>>();

            Random random = new Random();
            Words words = new Words();
            HashSet<int> choices = new HashSet<int>();

            while (questions.Count < count)
            {
                int index = random.Next(0, words.WordsList.Count);

                Word word = words.WordsList[index];
                Debug.WriteLine(index);

                if (choices.Contains(index) == false)
                {
                    choices.Add(index);
                    if (word.ImagePath == "No-image-found.jpg")
                        questions.Add(new Tuple<Word, ClueType>(word, ClueType.Description));
                    else
                        questions.Add(new Tuple<Word, ClueType>(word, (ClueType)random.Next(1, 3)));
                }
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public ObservableCollection<Tuple<Word, ClueType>> QuestionsList
        {
            get
            {
                return questions;
            }
        }
    }
}
