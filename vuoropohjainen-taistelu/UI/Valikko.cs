using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuoropohjainen_taistelu.UI
{
    class Valikko
    {
        public static void Ohje()
        {
            Console.WriteLine("\nTAIDOT");
            Console.WriteLine("STR - Hyökkäysvahinko");
            Console.WriteLine("DEX - Vuorojärjestys, väistömahdollisuus");
            Console.WriteLine("DEF - Vahingonvastustus, kestopisteet");
            Console.WriteLine("\nKOMENNOT");
            Console.WriteLine("Hyökkää - STR-riippuvainen hyökkäys.");
            Console.WriteLine("Puolusta - Nostaa hahmon vahingonvastustusta, tehokkuus riippuu DEF-taidosta. Nostaa väistömahdollisuutta.");
            Console.ReadKey(true);
            Päävalikko();
        }
        public static void Päävalikko()
        {
            ConsoleKeyInfo nappiInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("Päävalikko\nValitse komento: \n1) Aloita taistelu \n2) Ohje");
                nappiInfo = Console.ReadKey(true);
                if (nappiInfo.Key == ConsoleKey.D2)
                    break;
            } while (nappiInfo.Key != ConsoleKey.D1);

            if (nappiInfo.Key == ConsoleKey.D1 || nappiInfo.Key == ConsoleKey.NumPad1)
                Console.Clear();

            if (nappiInfo.Key == ConsoleKey.D2 || nappiInfo.Key == ConsoleKey.NumPad2)
            {
                Console.Clear();
                Ohje();
            }
        }
    }
}
