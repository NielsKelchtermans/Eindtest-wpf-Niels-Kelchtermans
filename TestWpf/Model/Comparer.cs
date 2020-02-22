using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging; //bitmapimage
using GalaSoft.MvvmLight; //viewModelBase
using GalaSoft.MvvmLight.Command; //voor RelayCommand
using Microsoft.Win32;
using System.IO;                //voor saveFiledialog etc
using System.Windows;
using System.ComponentModel; //voor cancelEventArghs
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows.Media;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace TestWpf.Model
{
    public class Comparer : IComparer<FontFamily>
    {
        public int Compare(FontFamily x, FontFamily y)
        {
            string xString = x.ToString();
            string yString = y.ToString();
            if (x==null || y==null)
            {
                return 0;
            }
            return xString.CompareTo(yString);
        }
    }
}
