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
            Hahmo pelaaja = Areena.Areenalista.Find(item => item.Nimi == "Pelaaja");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Sait {0} kokemusta.", exp);
            Exp = Exp + exp;
            Console.ReadKey(true);
            if (Exp >= 5 && Taso <2)
            {
                Console.Clear();
                Console.Write("Nousit tasolle 2.");
                Taso++;
                Console.ReadKey(true);
                Console.ResetColor();
                pelaaja.MaxHp += 5;
                Taidonnosto();
            }
            else if (Exp >=10 && Taso <3)
            {
                Console.Clear();
                Console.Write("Nousit tasolle 3.");
                Taso++;
                Console.ReadKey(true);
                Console.ResetColor();
                pelaaja.MaxHp += 5;
                Taidonnosto();
            }
            Console.ResetColor();
        }

        static public void Taidonnosto()
        {
            Console.Clear();
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
                Console.WriteLine("\nVoimaa nostettu.");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("   STR {0}", pelaaja.Str);
                Console.ResetColor();
                Console.WriteLine("   DEX {0}\n   DEF {1}", pelaaja.Dex, pelaaja.Def);
                
            }
            if (nappiInfo.Key == ConsoleKey.D2)
            {
                Console.Clear();
                pelaaja.Dex++;
                Console.WriteLine("\nNopeutta nostettu");
                
                Console.WriteLine("   STR {0}", pelaaja.Str);                
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("   DEX {0}", pelaaja.Dex);
                Console.ResetColor();
                Console.WriteLine("   DEF {0}", pelaaja.Def);

            }
            if (nappiInfo.Key == ConsoleKey.D3)
            {
                Console.Clear();
                pelaaja.Def++;
                Console.WriteLine("\nPuolustusta nostettu");
                Console.WriteLine("   STR {0}\n   DEX {1}", pelaaja.Str, pelaaja.Dex);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("   DEF {0}", pelaaja.Def);
                Console.ResetColor();
            }
        }
        static public void Hahmonluonti(int taitopisteet)
        {
            do
            {
                if(taitopisteet==1)
                    Console.WriteLine("Sinulla on {0} taitopiste.", taitopisteet);
                else
                    Console.WriteLine("Sinulla on {0} taitopistettä.", taitopisteet);
                Console.ReadKey(true);
                Taidonnosto();
                taitopisteet--;
            } while (taitopisteet>0);
            Console.ReadKey(true);
        }
    }
}
