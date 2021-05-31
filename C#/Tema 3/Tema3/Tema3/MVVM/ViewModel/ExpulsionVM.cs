using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.Model.BusinessLogicLayer;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.ViewModel
{
    class ExpulsionVM : BaseNotification
    {
        public ExpulsionVM()
        {
            ObservableCollection<Pupil> ps = PupilBLL.GetPupilInClass(HomeroomTeacherVM.Class.ClassID);
            Pupils = new ObservableCollection<Tuple<Pupil, int>>();

            int max;
            using (TextReader reader = File.OpenText(@"..\..\Resources\config.txt"))
            {
                max = int.Parse(reader.ReadLine());
            }

            foreach (Pupil p in ps)
            {
                int aux = AbsenceBLL.GetPupilAllAbsences(p.PupilID).Count;
                if (aux > max)
                    Pupils.Add(new Tuple<Pupil, int>(p, aux));
            }
        }

        private ObservableCollection<Tuple<Pupil, int>> pupils;
        public ObservableCollection<Tuple<Pupil, int>> Pupils
        {
            get
            {
                return pupils;
            }
            set
            {
                pupils = value;
                NotifyPropertyChanged("Pupils");
            }
        }
    }
}
