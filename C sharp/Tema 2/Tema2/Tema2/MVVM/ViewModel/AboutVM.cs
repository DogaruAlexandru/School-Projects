using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema2.Commands;
using Tema2.MVVM.View;

namespace Tema2.MVVM.ViewModel
{
    class AboutVM : BaseNotification
    {
        private ICommand back;
        public ICommand Back
        {
            get
            {
                back = new RelayCommand<object>(o =>
                {
                    MainVM mainVM = App.Current.MainWindow.DataContext as MainVM;
                    mainVM.SwitchView = 0;
                });
                return back;
            }
        }
    }
}
