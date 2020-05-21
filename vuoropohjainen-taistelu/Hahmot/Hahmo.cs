using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vuoropohjainen_taistelu.Taistelu;

namespace vuoropohjainen_taistelu.Hahmot
{
    public class Hahmo
    {
        public string Nimi { get; set; }
        public int Hp;
        public int Str;
        public int Dex;
        public int Def;
        public bool Kuollut;
        public bool Puolustautunut;


        public void MenetäHPtä(int vahinko)
        {
            Hp = Hp - vahinko;
            if (Hp <= 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n"+Nimi + " kuoli.");
                Console.ResetColor();

                Kuollut = true;
                if (Nimi.Contains("ranko"))
                {
                    Areena.PoistaLuuranko();
                }
            }
        }

        public int Hyökkää(int puolustajanDef)
        {
            int vahinko = this.Str - puolustajanDef;
            if (vahinko < 1)
                vahinko = 1;            
            Console.Write("{0} hyökkäsi ja teki ", Nimi);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(vahinko);
            Console.ResetColor();
            Console.Write(" vahinkoa");
            return vahinko;
        }

        public bool Väistä()
        {
            Random arvonta = new Random();
            int arpaNro = arvonta.Next(1, 100);
            int väistöprosentti = Dex * 5;
            Console.WriteLine(Nimi+"n väistömahdollisuus: " + väistöprosentti+"%");
            if (arpaNro <= 5 * Dex)
                return true;
            else
                return false;
        }

        public void Puolusta()
        {
            Def = Def + 2;
            Dex = Dex + 1;
            Puolustautunut = true;
        }
        public void LaskePuolustus()
        {
            Def = Def - 2;
            Dex = Dex - 1;
            Puolustautunut = false;
        }
    }
}
