using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema2.Services
{
    class SavedGames
    {
        private ObservableCollection<string> games = new ObservableCollection<string>();
        public ObservableCollection<string> Games
        {
            get { return games; }
            set { games = value; }
        }

        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public SavedGames(string path)
        {
            this.path = path;
            string[] filePaths = Directory.GetFiles(path, "*.txt", SearchOption.TopDirectoryOnly);

            foreach (string file in filePaths)
            {
                int start = file.LastIndexOf(@"\") + 1;
                int end = file.LastIndexOf(@".");
                games.Add(file.Substring(start, end - start));
            }
        }

        public void Remove(string data)
        {
            games.Remove(data);

            string aux = path + "\\" + data + ".txt";
            //if (File.Exists(aux))
            //{
            //    File.Delete(aux);
            //}
        }
    }
}
