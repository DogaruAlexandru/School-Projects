using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1.Models
{
    public class Words
    {
        private ObservableCollection<Word> words = new ObservableCollection<Word>();
        private ObservableCollection<string> categories = new ObservableCollection<string>();
        private Dictionary<string, uint> categoriesCount = new Dictionary<string, uint>();

        string path;
        public ObservableCollection<string> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                categories = value;
            }
        }

        public ObservableCollection<Word> WordsList
        {
            get
            {
                return words;
            }
            set
            {
                words = value;
            }
        }

        public ObservableCollection<Word> GetWordsInCategory(string category)
        {
            ObservableCollection<Word> result = new ObservableCollection<Word>();
            foreach (Word word in words)
                if (word.Category == category)
                    result.Add(word);
            return result;
        }

        public Words()
        {
            path = @"..\..\Resources\File\Words.txt";
            ReadFile();
        }

        public void ReadFile()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path);

            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] fields = line.Split('#');
                if (fields.Length == 4)
                    words.Add(new Word(fields[0], fields[1], fields[2], fields[3]));

                if (categoriesCount.ContainsKey(fields[2]) == true)
                    ++categoriesCount[fields[2]];
                else
                {
                    categoriesCount[fields[2]] = 1;
                    categories.Add(fields[2]);
                }
            }

            file.Close();
        }

        public void UpdateFile()
        {
            string relativPatb = @"..\..\Resources\Images\";

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var word in words)
                {
                    if (!File.Exists(relativPatb + word.ImagePath))
                    {
                        if (File.Exists(word.ImagePath) == false)
                            word.ImagePath = "No-image-found.jpg";
                        else
                        {
                            string imgName = word.Name + ".png";
                            File.Copy(word.ImagePath, relativPatb + imgName);
                            word.ImagePath = imgName;
                        }
                    }

                    writer.WriteLine(word.Name + '#' + word.Description + '#' +
                    word.Category + '#' + word.ImagePath);
                }
            }
        }

        public void Add(Word word)
        {
            words.Add(word);

            if (categoriesCount.ContainsKey(word.Category) == true)
                ++categoriesCount[word.Category];
            else
            {
                categoriesCount[word.Category] = 1;
                categories.Add(word.Category);
            }
        }

        public void Delete(Word word)
        {
            --categoriesCount[word.Category];
            if (categoriesCount[word.Category] == 0)
            {
                categoriesCount.Remove(word.Category);
                categories.Remove(word.Category);
            }
            words.Remove(word);
        }

        public void Clear()
        {
            words.Clear();
            categories.Clear();
            categoriesCount.Clear();
        }
    }
}
