using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.Converters
{
    class AbsenceConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Absence.State? state = null;
            switch(values[2].ToString())
            {
                case "Motivata":
                    state = Absence.State.Motivated;
                    break;
                case "Nemotivata":
                    state = Absence.State.Unmotivated;
                    break;
                case "Nemotivabila":
                    state = Absence.State.Unmotivable;
                    break;
            }
            return new Absence()
            {
                AbsenceID = null,
                SubjectID = values[0] as int?,
                PupilID = values[1] as int?,
                MarkState = state,
                DateTime = values[3] as DateTime?
            };
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Absence absence = value as Absence;
            object[] result = new object[5]
            {
                absence.AbsenceID,
                absence.SubjectID,
                absence.PupilID,
                absence.MarkState,
                absence.DateTime,
            };
            return result;
        }
    }
}
