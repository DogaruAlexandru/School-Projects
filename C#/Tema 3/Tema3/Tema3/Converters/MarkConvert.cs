using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.Converters
{
    class MarkConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal value;
            if (Decimal.TryParse(values[4].ToString(), out value))
            { }
            else
            { }

            bool? finalExam = null;
            switch (values[2].ToString())
            {
                case "Da":
                    finalExam = true;
                    break;
                case "Nu":
                    finalExam = false;
                    break;
            }

            return new Mark()
            {
                SubjectID = values[0] as int?,
                PupilID = values[1] as int?,
                FinalExam = finalExam,
                DateTime = values[3] as DateTime?,
                MarkScore = value
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Mark mark = value as Mark;
            object[] result = new object[6]
            {
                mark.MarkID,
                mark.SubjectID,
                mark.PupilID,
                mark.FinalExam,
                mark.DateTime,
                mark.MarkScore,
            };
            return result;
        }
    }
}