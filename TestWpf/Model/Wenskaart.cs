using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Media;


namespace TestWpf.Model
{
    public class Wenskaart
    {
        //props
        public BitmapImage Achtergrond { get; set; }
        public string AchtergrondNaam { get; set; }

        public List<Bal> Ballen { get; set; }

        public string WensTekst { get; set; }

        //public FontFamily LettertypeVanWens { get; set; }

        public int LetterGrootte { get; set; }
        public string StatusBarTekst { get; set; }

        public Wenskaart()
        {
            Achtergrond = null;
            Ballen = null;
            WensTekst = string.Empty;
            //default lettertype is Segoe UI
            //LettertypeVanWens = new FontFamily("Segoe UI");
            LetterGrootte = 20;
            StatusBarTekst = "Nieuw";
        }




    }
}
