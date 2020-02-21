using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpf.Model
{
    public class Ballen
    {
        //props
        public List<Bal> LijstBallen { get; set; }
        //lengte
        public int LengteLijstBallen 
        {
            get { return LijstBallen.Count; }  
        }


        //ctor
        public Ballen(List<Bal> lijstBallen)
        {
            LijstBallen = lijstBallen;
        }
       
    }
}
