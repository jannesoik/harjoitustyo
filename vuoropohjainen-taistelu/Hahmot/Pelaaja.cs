using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vuoropohjainen_taistelu.Taistelu;

namespace vuoropohjainen_taistelu.Hahmot
{
    public class Pelaaja : Hahmo
    {
        static public int Exp;
        static public int Taso=1;

        public Pelaaja(string nimi,int hp, int str, int dex, int def, int maxHp)
        {
            this.Nimi = nimi;
            this.Hp = hp;
            this.Str = str;
            this.Dex = dex;
            this.Def = def;
            MaxHp = maxHp;
        }

        static public void SaaKokemusta(int exp)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Sait {0} kokemusta.", exp);
            Exp = Exp + exp;
            if (Exp >= 5)
            {
                Console.WriteLine("Nousit tasolle 2.");
                Taso++;
                Console.ResetColor();
                Taidonnosto();
            }
            Console.ResetColor();
        }

        static public void Taidonnosto()
        {
            Hahmo pelaaja = Areena.Areenalista.Find(item => item.Nimi == "Pelaaja");
            ConsoleKeyInfo nappiInfo;
            do
            {
                Console.WriteLine("\nValitse nostettava taito: \n1) STR {0} \n2) DEX {1} \n3) DEF {2}", pelaaja.Str, pelaaja.Dex, pelaaja.Def);
                nappiInfo = Console.ReadKey(true);
                if (nappiInfo.Key == ConsoleKey.D2)
                    break;
                if (nappiInfo.Key == ConsoleKey.D3)
                    break;
            } while (nappiInfo.Key != ConsoleKey.D1);
            if (nappiInfo.Key == ConsoleKey.D1)
            {
                Console.Clear();
                pelaaja.Str++;
                Console.WriteLine("Voimaa nostettu, STR {0}", pelaaja.Str);
            }
            if (nappiInfo.Key == ConsoleKey.D2)
            {
                Console.Clear();
                pelaaja.Dex++;
                Console.WriteLine("Nopeutta nostettu, DEX {0}", pelaaja.Dex);

            }
            if (nappiInfo.Key == ConsoleKey.D3)
            {
                Console.Clear();
                pelaaja.Def++;
                Console.WriteLine("Puolustusta nostettu, DEF {0}", pelaaja.Def);

            }
        }

    }
}
