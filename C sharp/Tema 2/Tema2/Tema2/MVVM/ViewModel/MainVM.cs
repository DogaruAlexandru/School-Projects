using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tema2.MVVM.View;

namespace Tema2.MVVM.ViewModel
{
    public class MainVM: BaseNotification
    {
        int switchView;
        public int SwitchView
        {
            get { return switchView; }
            set 
            {
                switchView = value;
                NotifyPropertyChanged("SwitchView");
            }
        }

        public MainVM()
        {
            SwitchView = 0;
        }
    }
}
