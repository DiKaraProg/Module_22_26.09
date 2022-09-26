using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_22_Wpf
{
    public static class ext
    {
        public static ObservableCollection<Worker> ToObservableCollection(this IEnumerable<Worker> e)
        {
            ObservableCollection<Worker> t = new ObservableCollection<Worker>();
            foreach (var item in e)
            {
                t.Add(item);
            }
            return t;
        }
    }
}
