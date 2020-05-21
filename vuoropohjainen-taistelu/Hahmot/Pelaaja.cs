using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuoropohjainen_taistelu.Hahmot
{
    public class Pelaaja : Hahmo
    {
        public int Exp;
        public int Taso;      

        public Pelaaja(string nimi,int hp, int str, int dex, int def)
        {
            this.Nimi = nimi;
            this.Hp = hp;
            this.Str = str;
            this.Dex = dex;
            this.Def = def;
        }
     
        

        //public int NostaTasoa(int str, int dex, int def)
        //{
        //    this.Taso++;

        //}
    }
}
