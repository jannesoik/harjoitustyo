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
        public int MaxHp;
        public int Str;
        public int Dex;
        public int Def;
        public bool Kuollut;
        public bool Puolustautunut;
        int puolustusDef;

        public void LisääHptä(int def, int hp, int maxHp)
        {
            int maxHplisäys = def * 2;
            int hplisäys = def * 2;
            MaxHp += maxHplisäys;
            Hp += hplisäys;
        }

        public void MenetäHPtä(int vahinko)
        {
            Hp = Hp - vahinko;

            if (Hp <= 0) //<-kuolema
            {
                if (Nimi.Contains("elaaja"))
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                
                Console.WriteLine("\n"+Nimi + " kuoli.");
                Console.ResetColor();
                Kuollut = true;

                if (Nimi.Contains("Vahva"))
                {
                    Pelaaja.SaaKokemusta(8);
                    Random arvonta = new Random();
                    if (arvonta.Next(1, 101) > 25)
                        Pelaaja.SaaTavara("Pommi");
                }
                else if (Nimi.Contains("Heikko"))
                {
                    Pelaaja.SaaKokemusta(5);
                    Random arvonta = new Random();
                    if (arvonta.Next(1,101) > 25)
                        Pelaaja.SaaTavara("Pommi");
                }

                Areena.PoistaKuolleet();
            }
        }

        public int Hyökkää(int puolustajanDef, string puolustajanNimi)
        {
            Random arvonta = new Random();
            int vahinkoKerroin = arvonta.Next(1,3);
            int vahinko = (Str*vahinkoKerroin) - puolustajanDef;
            if (vahinko < 1)
            {
                int torjuttuVahinko = (Str * vahinkoKerroin)-1;
                vahinko = 1;
                Console.Write("{0} hyökkäsi, {1} otti vain ", Nimi, puolustajanNimi);
                VahinkoVäri(vahinko);
                Console.Write(":n vanhinkopisteen (" + torjuttuVahinko + " vastustettu)\n");
            }
            else
            {
                Console.Write("{0} hyökkäsi, {1} otti ", Nimi, puolustajanNimi);
                VahinkoVäri(vahinko);
                Console.Write(" pistettä vahinkoa (" + puolustajanDef + " vastustettu)\n");
            }      
            
            return vahinko;
        }

        public bool Väistä()
        {
            Random arvonta = new Random();
            int arpaNro = arvonta.Next(1, 100);
            int väistöprosentti = Dex * 5;
            //Console.WriteLine(Nimi+"n väistömahdollisuus: " + väistöprosentti+"%");
            if (arpaNro <= 5 * Dex)
                return true;
            else
                return false;
        }

        public void Puolusta()
        {
            Random arvonta = new Random();
            int arpaNro = arvonta.Next(1,3);
            puolustusDef = arpaNro + Def;
            Def = Def+puolustusDef;
            Dex = Dex + 1;
            Puolustautunut = true;
        }
        public void LaskePuolustus()
        {            
            Def = Def -puolustusDef;
            Dex = Dex - 1;
            Puolustautunut = false;
        }

        static public void VahinkoVäri(int vahinko)
        {
            if (vahinko >= 10)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(vahinko);
                Console.ResetColor();
            }else if (vahinko > 5)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(vahinko);
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(vahinko);
                Console.ResetColor();
            }
        }

        public static void HpVäri(int hp, int maxHp)
        {
            if (hp*10 >= maxHp*7)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(hp+"/"+maxHp);
                Console.ResetColor();
            }
            else if (hp*10 > maxHp * 3)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(hp + "/" + maxHp);
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(hp + "/" + maxHp);
                Console.ResetColor();
            }
        }
    }
}
