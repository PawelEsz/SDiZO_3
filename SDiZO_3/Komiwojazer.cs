using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDiZO_3
{
    class Komiwojazer
    {
        public int LiczbaMiast; 
        public int[,] MacierzSasiedztwa;

        //Zupelny
        int KosztAlgZupelnego;
        public bool[] OdwiedzoneAlgZupelnego;
        int[] StosAlgZupelnego;
        int[] Sh;
        int SptrAlgZupelnego;
        int shptr;
        int dh;
        public int v0;

        //Zachlanny
        int KosztAlgZachlannego;
        public bool[] OdwiedzoneAlgZachlannego;
        int[] StosAlgZachlannego;
        int mini;

        public Komiwojazer(int n)
        {
            this.LiczbaMiast = n;
            Random r = new Random();
            
            //tworze macierz sasiedztwa            
            MacierzSasiedztwa = new int[LiczbaMiast, LiczbaMiast];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    MacierzSasiedztwa[i, j] = r.Next(1, 6);
            }

            for (int i = 0; i < n; i++)
            {
                MacierzSasiedztwa[i, i] = 0;
            }

            //dane dla algorytmu zupelnego
            StosAlgZupelnego = new int[n];
            Sh = new int[n];
            OdwiedzoneAlgZupelnego = new bool[n];
            dh = 0;
            v0 = 0;
            KosztAlgZupelnego = int.MaxValue;
            SptrAlgZupelnego = shptr = 0;

            //dane dla algorytmu zachlannego
            StosAlgZachlannego = new int[n + 2];
            OdwiedzoneAlgZachlannego = new bool[n];
            KosztAlgZachlannego = 0;

            //ustawiam tablice odwiedzin na nieodwiedzone
            for (int i = 0; i < n; i++)
            {
                OdwiedzoneAlgZupelnego[i] = false;
                OdwiedzoneAlgZachlannego[i] = false;
            }

        }

        public Komiwojazer()
        {

        }

        /*public void WczytajZPliku(string nazwaPliku)
        {
            int i, j;
            string[] wczytaneLinie;
            int[] wczytanaLinia;
            wczytaneLinie = File.ReadAllLines(nazwaPliku);
            wczytanaLinia = wczytaneLinie[0].Split(' ').Select(int.Parse).ToArray();
            this.LiczbaMiast = wczytanaLinia[0];

            MacierzSasiedztwa = new int[LiczbaMiast, LiczbaMiast];

            for(i = 0; i < LiczbaMiast; i++)
            {
                wczytanaLinia = wczytaneLinie[i + 1].Split(' ').Select(int.Parse).ToArray();
                int iter = 0;
                for(j = 0; j < LiczbaMiast; j++)
                {
                    if (i == j) MacierzSasiedztwa[i,j] = 0;
                    else
                    {
                        MacierzSasiedztwa[i, j] = wczytanaLinia[iter];
                        iter++;
                    }
                }
            }

            S = new int[LiczbaMiast];
            Sh = new int[LiczbaMiast];
            Odwiedzone = new bool[LiczbaMiast];
            sptr = shptr = 0;
            d = int.MaxValue;

            for (i = 0; i < LiczbaMiast; i++)
                Odwiedzone[i] = false;

            dh = 0;
            v0 = 0;
        }*/

        
        public void WczytajZPliku(string nazwaPliku)
        {         
            int i, j;
            string[] wczytaneLinie;
            int[] wczytanaLinia;
            wczytaneLinie = File.ReadAllLines(nazwaPliku);
            wczytanaLinia = wczytaneLinie[0].Split(' ').Select(int.Parse).ToArray();
            this.LiczbaMiast = wczytanaLinia[0];

            MacierzSasiedztwa = new int[LiczbaMiast, LiczbaMiast];

            for (i = 0; i < LiczbaMiast; i++)
            {
                wczytanaLinia = wczytaneLinie[i + 1].Split(' ').Select(int.Parse).ToArray();

                for (j = 0; j < LiczbaMiast; j++)
                {
                    MacierzSasiedztwa[i, j] = wczytanaLinia[j];
                }
            }

            //dane dla algorytmu zupelnego
            StosAlgZupelnego = new int[LiczbaMiast]; 
            Sh = new int[LiczbaMiast];
            OdwiedzoneAlgZupelnego = new bool[LiczbaMiast];
            SptrAlgZupelnego = shptr = 0;
            KosztAlgZupelnego = int.MaxValue; 
            dh = 0;
            v0 = 0;      

            //dane dla algorytmu zachlannego
            StosAlgZachlannego = new int[LiczbaMiast + 1];
            OdwiedzoneAlgZachlannego = new bool[LiczbaMiast];
            KosztAlgZachlannego = 0;

            for (i = 0; i < LiczbaMiast; i++)
            {
                OdwiedzoneAlgZupelnego[i] = false;
                OdwiedzoneAlgZachlannego[i] = false;
            }

        }

        public void WyswietlMacierz()
        {
            int i, j;
            Console.WriteLine("Macierz siąsiedztwa:");
            Console.Write("{0,5}", "");
            for (i = 0; i < LiczbaMiast; i++) Console.Write("{0,5}", i);
            Console.WriteLine();

            for (i = 0; i < LiczbaMiast; i++)
            {
                Console.Write("{0,5}", i);
                for (j = 0; j < LiczbaMiast; j++)
                {
                    Console.Write("{0,5}", MacierzSasiedztwa[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void KomiwojazerZupelny(int v)
        {
            int u;

            Sh[shptr++] = v;

            if (shptr < LiczbaMiast)
            {
                OdwiedzoneAlgZupelnego[v] = true;
                for (u = 0; u < LiczbaMiast; u++)
                {               
                    if (!OdwiedzoneAlgZupelnego[u] && Convert.ToBoolean(MacierzSasiedztwa[v,u]))
                    {
                        dh += MacierzSasiedztwa[v, u];
                        KomiwojazerZupelny(u);
                        dh -= MacierzSasiedztwa[v, u];
                    }                
                }
                OdwiedzoneAlgZupelnego[v] = false;
            }
            else if(Convert.ToBoolean(MacierzSasiedztwa[v0,v]))
            {
                dh += MacierzSasiedztwa[v, v0];
                if(dh < KosztAlgZupelnego)
                {
                    KosztAlgZupelnego = dh;
                    for (u = 0; u < shptr; u++)
                        StosAlgZupelnego[u] = Sh[u];
                    SptrAlgZupelnego = shptr;
                }
                dh -= MacierzSasiedztwa[v, v0];
            }
            shptr--;
        }

        public void WyswietlKomiwojazerZupelny()
        {
            if (Convert.ToBoolean(SptrAlgZupelnego))
            {
                for (int i = 0; i < SptrAlgZupelnego; i++) Console.Write(StosAlgZupelnego[i] + " ");
                Console.WriteLine(v0);
                Console.WriteLine("Koszt drogi = {0}", KosztAlgZupelnego);
            }
            else
            {
                Console.WriteLine("Brak cyklu hamiltona!");
            }
        }

        public void KomiwojazerZachlanny(int v)
        {
            int u = v;
            int min;
            OdwiedzoneAlgZachlannego[u] = true;
            StosAlgZachlannego[0] = u;
            for (int i = 1; i < LiczbaMiast; i++)
            {
                min = int.MaxValue;

                for (int j = 0; j < LiczbaMiast; j++)
                    if (!OdwiedzoneAlgZachlannego[j] && MacierzSasiedztwa[u,j] < min && Convert.ToBoolean(MacierzSasiedztwa[u,j]))
                    {
                        min = MacierzSasiedztwa[u,j];
                        mini = j;
                    }
                OdwiedzoneAlgZachlannego[mini] = true;
                KosztAlgZachlannego += min;
                u = mini;
                StosAlgZachlannego[i] = mini;
            }
            StosAlgZachlannego[LiczbaMiast] = v;
            KosztAlgZachlannego += MacierzSasiedztwa[u,v];
        }

        public void WyswietlKomiwojazerZachlanny()
        {
            for (int i = 0; i < LiczbaMiast +1; i++) Console.Write(StosAlgZachlannego[i] + " ");
            Console.WriteLine();
            Console.WriteLine("Koszt drogi = {0}", KosztAlgZachlannego);
        }

    }
}
