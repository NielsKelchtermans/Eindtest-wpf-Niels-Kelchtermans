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

        public Ballen BallenLijst { get; set; }

        public string WensTekst { get; set; }

        public FontFamily LettertypeVanWens { get; set; }

        public int LetterGrootte { get; set; }

        public Wenskaart()
        {
            Achtergrond = null;
            BallenLijst = null;
            WensTekst = string.Empty;
            //default lettertype is Segoe UI
            LettertypeVanWens = new FontFamily("Segoe UI");
            LetterGrootte = 20;

        }




    }
}
