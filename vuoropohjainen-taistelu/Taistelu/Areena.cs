﻿using System;
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

        public static async void LuoLuuranko(int kpl)
        {
            
            int listaNro = LuurankoLista.Count();

            for (int i = 0; i < kpl; i++)
            {
                Random arvonta = new Random();
                int taso = arvonta.Next(1, 10);
                if (taso > 5)
                {
                    LuurankoLista.Add(new Luuranko("Luuranko " + i + 1, 15, 3, 6, 2, 15));
                    Areenalista.Add(LuurankoLista[i]);
                }
                else
                {
                    LuurankoLista.Add(new Luuranko("Heikko luuranko " + i + 1, 10, 2, 1, 2, 10));
                    Areenalista.Add(LuurankoLista[i]);
                }
                await Task.Delay(100);
            }

        }
        public static void LuoUusiPelaaja()
        {
            Areenalista.Add(new Pelaaja("Pelaaja", 25, 1, 1, 1,25));
        }

        public static void PoistaLuuranko()
        {
            for (int i = 0; i < LuurankoLista.Count; i++)
            {
                if (LuurankoLista[i].Hp <= 0)
                    LuurankoLista.Remove(LuurankoLista[i]);
            }
            for (int i = 0; i < Areenalista.Count; i++)
            {
                if (Areenalista[i].Hp <= 0)
                    Areenalista.Remove(Areenalista[i]);
            }
        }
    }
}
