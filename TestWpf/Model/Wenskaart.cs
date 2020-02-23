using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Media;
using System.Collections.ObjectModel;


namespace TestWpf.Model
{
    public class Wenskaart
    {
        //props
        public BitmapImage Achtergrond { get; set; }
        public string AchtergrondNaam { get; set; }

        private ObservableCollection<Bal> ballen = new ObservableCollection<Bal>();
        public ObservableCollection<Bal> Ballen { get; set; }

        public string WensTekst { get; set; }

        //public FontFamily LettertypeVanWens { get; set; }

        public int LetterGrootte { get; set; }
        public string StatusBarTekst { get; set; }
        //voor de balcoordinaten
        public int TempX { get; set; }
        public int TempY { get; set; }

        public Wenskaart()
        {
            Achtergrond = null;
            Ballen = new ObservableCollection<Bal> { };
            WensTekst = string.Empty;
            //default lettertype is Segoe UI
            //LettertypeVanWens = new FontFamily("Segoe UI");
            LetterGrootte = 20;
            StatusBarTekst = "Nieuw";
            TempX = 0;
            TempY = 0;
        }




    }
}
