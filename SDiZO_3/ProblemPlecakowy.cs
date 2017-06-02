using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDiZO_3
{
    
    class Przedmiot
    {
        public double cena;
        public double waga;

        public Przedmiot(double waga, double cena)
        {
            this.cena = cena;
            this.waga = waga;
        }

        public Przedmiot()
        {

        }
    }

    class ProblemPlecakowy
    {
        int PojemnoscPlecaka; 
        int MiejsceWPlecaku;
        int PrzedmiotyWPlecaku; // iterator
        int LiczbaPrzedmiotow;
        Przedmiot Przedmiot;
        Przedmiot[] TablicaPrzedmiotow;
        Przedmiot[] Plecak;

        public ProblemPlecakowy(int pojemnoscPlecaka, int liczbaPrzedmiotow)
        {
            Random r = new Random();
            double cena, waga;
            this.PojemnoscPlecaka = pojemnoscPlecaka;
            this.LiczbaPrzedmiotow = liczbaPrzedmiotow;
            this.MiejsceWPlecaku = pojemnoscPlecaka;

            TablicaPrzedmiotow = new Przedmiot[liczbaPrzedmiotow];
            Plecak = new Przedmiot[liczbaPrzedmiotow];

            for(int i = 0; i < liczbaPrzedmiotow; i++)
            {
                cena = r.Next(1, 20);
                waga = r.Next(1, 15);
                Przedmiot = new Przedmiot(cena, waga);
                TablicaPrzedmiotow[i] = Przedmiot;
            }

            Sortuj();
        }

        public ProblemPlecakowy() { }

        public void WczytajZPliku(string nazwaPliku)
        {
            int i, j;
            string[] wczytaneLinie;
            int[] wczytanaLinia;
            wczytaneLinie = File.ReadAllLines(nazwaPliku);
            wczytanaLinia = wczytaneLinie[0].Split(' ').Select(int.Parse).ToArray();
            this.PojemnoscPlecaka = wczytanaLinia[0];
            this.LiczbaPrzedmiotow = wczytanaLinia[1];
            this.MiejsceWPlecaku = wczytanaLinia[0];

            TablicaPrzedmiotow = new Przedmiot[LiczbaPrzedmiotow];
            Plecak = new Przedmiot[LiczbaPrzedmiotow];

            for (i = 0; i < LiczbaPrzedmiotow; i++)
            {
                wczytanaLinia = wczytaneLinie[i + 1].Split(' ').Select(int.Parse).ToArray();
                Przedmiot = new Przedmiot(wczytanaLinia[0], wczytanaLinia[1]);
                TablicaPrzedmiotow[i] = Przedmiot;
            }

            Sortuj();
        }

        public void WyswietlPrzedmioty()
        {
            Console.WriteLine("Pojemność plecaka: {0}", PojemnoscPlecaka);
            for (int i = 0; i < LiczbaPrzedmiotow; i++)
            {
                Console.WriteLine("Przedmiot {0}: Waga: {1} | Cena: {2}", i + 1, TablicaPrzedmiotow[i].waga, TablicaPrzedmiotow[i].cena);
            }
            
        }

        private void Sortuj()
        {
            IEnumerable<Przedmiot> bufor;
            bufor = TablicaPrzedmiotow.OrderByDescending(k => (k.cena/k.waga));
            TablicaPrzedmiotow = bufor.ToArray();
        }

        public void Zachlanny()
        {
            PrzedmiotyWPlecaku = 0;
            for(int i = 0; i < LiczbaPrzedmiotow; i++)
            {             
                if(TablicaPrzedmiotow[i].waga <= MiejsceWPlecaku)
                {
                    Plecak[PrzedmiotyWPlecaku] = TablicaPrzedmiotow[i];
                    MiejsceWPlecaku -= Convert.ToInt32(TablicaPrzedmiotow[i].waga);
                    PrzedmiotyWPlecaku++;
                }
            }
        }

        public void WyswietlPlecak()
        {
            double sumaWag = 0;
            double sumaCen = 0;
            Console.WriteLine("Zawartosc plecaka: ");
            for(int i = 0; i < PrzedmiotyWPlecaku; i++)
            {
                Console.WriteLine("[Waga: {0} | Cena: {1}]", Plecak[i].waga, Plecak[i].cena);
                sumaWag += Plecak[i].waga;
                sumaCen += Plecak[i].cena;
            }

            Console.WriteLine("Sumaryczna waga: {0}", sumaWag);
            Console.WriteLine("Sumaryczna cena: {0}", sumaCen);
        }
    }
}
