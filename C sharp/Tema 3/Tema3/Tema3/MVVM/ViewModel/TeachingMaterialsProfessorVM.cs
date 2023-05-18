using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tema3.Commands;
using Tema3.MVVM.Model.BusinessLogicLayer;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.ViewModel
{
    class TeachingMaterialsProfessorVM : BaseNotification
    {
        public TeachingMaterialsProfessorVM()
        {
            Subjects = TeachingMaterialBLL.GetTeacherTeachingMaterials(ProfessorVM.Professor.ProfessorID);
        }

        private ObservableCollection<Tuple<Subject, ProfessorSubjectClass>> subjects;
        public ObservableCollection<Tuple<Subject, ProfessorSubjectClass>> Subjects
        {
            get
            {
                return subjects;
            }
            set
            {
                subjects = value;
                NotifyPropertyChanged("Subjects");
            }
        }

        private ICommand modifyCommand;
        public ICommand ModifyCommand
        {
            get
            {
                modifyCommand = new RelayCommand<Tuple<Subject, ProfessorSubjectClass>>(o =>
                {
                    if (o == null)
                    {
                        MessageBox.Show("Nicio materie selectata!", "Error", MessageBoxButton.OK);
                        return;
                    }

                    OpenFileDialog fileDialog = new OpenFileDialog();
                    fileDialog.Multiselect = false;
                    fileDialog.Filter = "ZIP File|*.zip";
                    fileDialog.DefaultExt = ".zip";
                    Nullable<bool> dialogOk = fileDialog.ShowDialog();
                    if (dialogOk == true)
                        o.Item2.Teaching_materials = fileDialog.FileNames[0];

                    ProfessorSubjectClassBLL.ModifyProfessorSubjectClass(o.Item2);

                    //Subjects = TeachingMaterialBLL.GetTeacherTeachingMaterials(ProfessorVM.Professor.ProfessorID);
                });
                return modifyCommand;
            }
        }

        private ICommand removeCommand;
        public ICommand RemoveCommand
        {
            get
            {
                removeCommand = new RelayCommand<Tuple<Subject, ProfessorSubjectClass>>(o =>
                {
                    if (o == null)
                    {
                        MessageBox.Show("Nicio materie selectata!", "Error", MessageBoxButton.OK);
                        return;
                    }

                    if(o.Item2.Teaching_materials=="")
                    {
                        MessageBox.Show("Nu exista material didactic adaugat!|", "Error", MessageBoxButton.OK);
                        return;
                    }

                    o.Item2.Teaching_materials = "";
                    ProfessorSubjectClassBLL.ModifyProfessorSubjectClass(o.Item2);

                    //Subjects = TeachingMaterialBLL.GetTeacherTeachingMaterials(ProfessorVM.Professor.ProfessorID);
                });
                return removeCommand;
            }
        }
    }
}
