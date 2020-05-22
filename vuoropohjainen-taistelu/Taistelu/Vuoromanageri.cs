using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vuoropohjainen_taistelu.Hahmot;

namespace vuoropohjainen_taistelu.Taistelu
{
    class Vuoromanageri
    {
        static public Hahmo SuurinDex(List<Hahmo> areenalista)
        {
            //järjestä lista dex:n mukaan
            int pelaajanDex = areenalista[0].Dex;
            List<Hahmo> järjestettyLista = areenalista.OrderByDescending(o => o.Dex).ToList();
            for (int i = 0; i < järjestettyLista.Count; i++)
            {
                if(järjestettyLista[i]!=null)
                    Console.WriteLine((i+1)+". vuorossa "+järjestettyLista[i].Nimi/* + ", Dex: " + järjestettyLista[i].Dex*/);
            }
            return järjestettyLista[0];
        }

        public static void LuurankojenVuoro(List<Luuranko> luurankolista, Hahmo pelaaja)
        {
            Console.Clear();

            Console.WriteLine("\nLuurankojen vuoro");
            for (int i = 0; i < luurankolista.Count(); i++) //käydään luurankolista läpi
            {
                if (pelaaja.Väistä() == false)
                {
                    pelaaja.MenetäHPtä(luurankolista[i].Hyökkää(pelaaja.Def));
                    Console.ReadKey(true);

                }
                else
                {
                    Console.WriteLine("{0} hyökkäsi, pelaaja väisti.", luurankolista[i].Nimi);
                    Console.ReadKey(true);
                }
            }
        }

        public static void PelaajanVuoro(Hahmo pelaaja, Hahmo vihollinen)
        {
            if (pelaaja.Puolustautunut)
            {
                pelaaja.LaskePuolustus(); 
            }

            //Console.WriteLine("pelaajan str{0}, dex {1}, def {2} ", pelaaja.Str, pelaaja.Dex, pelaaja.Def);
            ConsoleKeyInfo nappiInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("\nPelaajan vuoro\nValitse komento: \n1) Hyökkää \n2) Puolusta");
                nappiInfo=Console.ReadKey(true);
                if (nappiInfo.Key == ConsoleKey.D2)
                    break;                
            } while (nappiInfo.Key != ConsoleKey.D1);

            if (nappiInfo.Key==ConsoleKey.D1 || nappiInfo.Key == ConsoleKey.NumPad1)
            {
                if (vihollinen.Väistä()==false)
                {
                    vihollinen.MenetäHPtä(pelaaja.Hyökkää(vihollinen.Def));
                }else
                    Console.WriteLine("{0} hyökkäsi, {1} väisti.", pelaaja.Nimi, vihollinen.Nimi);
            }
            if (nappiInfo.Key == ConsoleKey.D2 || nappiInfo.Key == ConsoleKey.NumPad2)
            {
                pelaaja.Puolusta();
                Console.WriteLine("Pelaaja puolustautuu");
            }
        }

        public async void ClickHandler()
        {
            // whatever you need to do before delay goes here         

            await Task.Delay(2000);

            // whatever you need to do after delay.
        }
    }
}
