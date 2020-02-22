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

namespace TestWpf.ViewModel
{
    public class LettertypenVM : ViewModelBase
    {
        private ObservableCollection<FontFamily> fontLijst = new ObservableCollection<FontFamily>();

        public ObservableCollection<FontFamily> FontLijst
        {
            get { return fontLijst; }
            set { fontLijst = value; RaisePropertyChanged("FontLijst"); }
            
        }
        private FontFamily selectedFont;

        public FontFamily SelectedFont
        {
            get { return selectedFont; }
            set { selectedFont = value; RaisePropertyChanged("SelectedFont"); }
        }
        //ctor
        public LettertypenVM()
        {
            List<FontFamily> eenFontLijst = new List<FontFamily>();
            foreach (FontFamily fontje in Fonts.SystemFontFamilies)
            
            {

                eenFontLijst.Add(fontje);
            }
            Model.Comparer vgl = new Model.Comparer();

            eenFontLijst.Sort(vgl);
            ObservableCollection<FontFamily> gesorteerdeLijstOC= new ObservableCollection<FontFamily> (eenFontLijst);

            FontLijst = gesorteerdeLijstOC;

        }

    }
}
