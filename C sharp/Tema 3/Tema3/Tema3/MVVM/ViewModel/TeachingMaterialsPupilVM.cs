using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.Commands;
using Tema3.MVVM.Model.DataAccessLayer;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.ViewModel
{
    class TeachingMaterialsPupilVM : BaseNotification
    {
        public TeachingMaterialsPupilVM()
        {
            classID = PupilVM.Pupil.ClassID;
            TeachingMaterials = TeachingMaterialDAL.GetClassTeachingMaterials(classID);
        }

        private ObservableCollection<TeachingMaterial> teachingMaterials;
        public ObservableCollection<TeachingMaterial> TeachingMaterials
        {
            get
            {
                return teachingMaterials;
            }
            set
            {
                teachingMaterials = value;
                NotifyPropertyChanged("TeachingMaterials");
            }
        }

        private int? classID;
        public int? ClassID
        {
            get
            {
                return classID;
            }
            set
            {
                classID = value;
                NotifyPropertyChanged("ClassID");
            }
        }

        private ICommand open;
        public ICommand Open
        {
            get
            {
                open = new RelayCommand<object>(o =>
                {
                    TeachingMaterial material = o as TeachingMaterial;
                    System.Diagnostics.Process.Start(material.MaterialPath);
                });
                return open;
            }
        }
    }
}
