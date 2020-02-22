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


namespace TestWpf.ViewModel
{
    public class KleurLijst : ViewModelBase
    {
        private ObservableCollection<Kleur> kleurenLijst;

        public ObservableCollection<Kleur> KleurenLijst
        {
            get { return kleurenLijst; }
            set { kleurenLijst = value; RaisePropertyChanged("KleurenLijst"); }
        }
        private Kleur selectedKleur;

        public Kleur SelectedKleur
        {
            get { return selectedKleur; }
            set { selectedKleur = value; RaisePropertyChanged("SelectedKleur"); }
        }
        //ctor
        public KleurLijst()
        {
            //we gaan al de kleuren van colors toevoegen aan onze lijst met kleuren
            ObservableCollection<Kleur> eenKleurenLijst = new ObservableCollection<Kleur>();
            foreach (PropertyInfo propInfo in typeof(Colors).GetProperties())
            {
                //het kleur object aanmaken
                Kleur eenKleur = new Kleur();

                BrushConverter eenBrushConverter = new BrushConverter();

                SolidColorBrush deKleur = (SolidColorBrush)eenBrushConverter.ConvertFromString(propInfo.Name);

                eenKleur.Naam = propInfo.Name;
                eenKleur.Borstel = deKleur;


                //toevoegen aan een lijst
                
                eenKleurenLijst.Add(eenKleur);
               
            }
            KleurenLijst = eenKleurenLijst;
        }

    }
}