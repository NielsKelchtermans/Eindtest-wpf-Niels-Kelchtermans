using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TestWpf.Model
{
    public class Bal
    {
        //props
        public Kleur KleurBal { get; set; }

        public int XPositie { get; set; }
        public int YPositie { get; set; }

        //ctor
        public Bal(Kleur kleurBal, int xPositie, int yPositie)
        {
            KleurBal = kleurBal;
            XPositie = xPositie;
            YPositie = yPositie;
        }
    }
}
