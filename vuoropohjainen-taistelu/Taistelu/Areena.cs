using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vuoropohjainen_taistelu.Hahmot;

namespace vuoropohjainen_taistelu.Taistelu
{
    public class Areena
    {
        public static List<Luuranko> LuurankoLista = new List<Luuranko>();
        public static List<Hahmo> Areenalista = new List<Hahmo>();

        public static void LuoLuuranko()
        {
            int listaNro = LuurankoLista.Count();
            LuurankoLista.Add(new Luuranko("Luuranko "+listaNro+1, 15, 6, 6, 2));
            Areenalista.Add(LuurankoLista[listaNro]);
            
        }
        public static void LuoUusiPelaaja()
        {
            Areenalista.Add(new Pelaaja("Pelaaja", 25, 10, 5, 2));
        }

        public static void PoistaLuuranko()
        {
            for (int i = 0; i < LuurankoLista.Count; i++)
            {
                if (LuurankoLista[i].Hp <= 0)
                    LuurankoLista.Remove(LuurankoLista[i]);
            }
        }
    }
}
