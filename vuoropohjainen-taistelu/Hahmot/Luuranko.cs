using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuoropohjainen_taistelu.Hahmot
{
    public class Luuranko : Hahmo
    {
        public Luuranko(string nimi, int hp, int str, int dex, int def, int maxHp)
        {
            this.Nimi = nimi;
            this.Hp = hp;
            this.Str = str;
            this.Dex = dex;
            this.Def = def;
            this.MaxHp = maxHp;
        }
        

    }
}
