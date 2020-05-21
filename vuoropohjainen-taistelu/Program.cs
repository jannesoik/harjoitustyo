using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vuoropohjainen_taistelu.Hahmot;
using vuoropohjainen_taistelu.Taistelu;

namespace vuoropohjainen_taistelu
{    
    class Program
    {
        static void Main(string[] args)
        {
            Areena.LuoLuuranko(); //luo vihollinen
            Areena.LuoUusiPelaaja(); // luo pelaaja
            Hahmo pelaaja1 = Areena.Areenalista.Find(item => item.Nimi == "Pelaaja"); 

            for (int j = 0; pelaaja1.Hp > 0 ; j++)//taistelu jatkuu, kunnes pelaajan hp loppuu
            {
                if (Areena.LuurankoLista.Count < 1)
                {
                    Console.WriteLine("VOITIT");
                    break;
                }
                Console.Clear();
                Console.Write("KIERROS {0}\nAreenalla:", (j + 1));
                for (int k = 0; k < Areena.Areenalista.Count(); k++)
                {
                    if (Areena.Areenalista[k] != null)
                    {
                        Console.Write("\n"+Areena.Areenalista[k].Nimi+", HP: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Areena.Areenalista[k].Hp/* +", def: "+ Areena.Areenalista[k].Def*/);
                        Console.ResetColor();
                        if (Areena.Areenalista[k].Puolustautunut)
                            Console.WriteLine(" [puolustautuu]");

                    }
                }
                Console.WriteLine();
                //kierroksen alussa valitaan hahmo jolla suurin dex:
                Hahmo vuorossa = Vuoromanageri.SuurinDex(Areena.Areenalista);

                Console.ReadKey(true);

                if (vuorossa.Nimi.Contains("Luuranko"))//Luurangot aloittavat
                {
                    if (Areena.LuurankoLista.Count > 0)
                        Vuoromanageri.LuurankojenVuoro(Areena.LuurankoLista, pelaaja1);
                    if (pelaaja1.Kuollut == false)
                    {
                        Vuoromanageri.PelaajanVuoro(pelaaja1, Areena.LuurankoLista[0]);
                        Console.ReadKey(true);
                    }
                    
                    Console.WriteLine("\n***\n");                    
                }
                else // pelaaja aloittaa
                {
                    Vuoromanageri.PelaajanVuoro(pelaaja1, Areena.LuurankoLista[0]);
                    Console.ReadKey();
                    if (Areena.LuurankoLista.Count>0)//luurankoja vielä elossa                    
                        Vuoromanageri.LuurankojenVuoro(Areena.LuurankoLista, pelaaja1);
                    
                    Console.WriteLine("\n***\n");                    
                }
            }        
        }
    }
}
