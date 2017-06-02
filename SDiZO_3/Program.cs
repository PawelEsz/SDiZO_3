using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDiZO_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcja;
            string nazwaPliku;
            int liczbaWierzcholkow;
            int pojemnoscPlecaka;
            int liczbaPrzedmiotow;
            Komiwojazer Komiwojazer = new Komiwojazer();
            ProblemPlecakowy Plecak = new ProblemPlecakowy();

            do
            {
                Console.WriteLine();
                Console.WriteLine("ASYMETRYCZNY PROBLEM KOMIWOJAŻERA");
                Console.WriteLine("1. Wczytaj graf z pliku");
                Console.WriteLine("2. Wyświetl graf (macierz sąsiedztwa)");
                Console.WriteLine("3. Wykonaj przegląd zupełny");
                Console.WriteLine("4. Wyświetl wynik przeglądu zupełnego");
                Console.WriteLine("5. Wykonaj algorytm zachłanny");
                Console.WriteLine("6. Wyświetl wynik algorytmu zachłannego");
                Console.WriteLine("7. Wygeneruj losowy graf");
                Console.WriteLine("DYSKRETNY PROBLEM PLECAKOWY:");
                Console.WriteLine("8. Wczytaj z pliku");
                Console.WriteLine("9. Wyświetl przedmioty");
                Console.WriteLine("10. Wykonaj algorytm zachłanny");
                Console.WriteLine("11. Wyświetl wynik algorytmu zachłannego");
                Console.WriteLine("12. Wygeneruj losowe przedmioty");
                opcja = Console.ReadLine();
                Console.WriteLine();

                switch(opcja)
                {
                    case "1":
                        Console.WriteLine("Podaj nazwę pliku: ");
                        nazwaPliku = Console.ReadLine();
                        Komiwojazer.WczytajZPliku(nazwaPliku);
                        Komiwojazer.WyswietlMacierz();
                        break;

                    case "2":
                        Komiwojazer.WyswietlMacierz();
                        break;

                    case "3":
                        Komiwojazer.KomiwojazerZupelny(0);
                        Komiwojazer.WyswietlKomiwojazerZupelny();
                        break;

                    case "4":
                        Komiwojazer.WyswietlKomiwojazerZupelny();
                        break;

                    case "5":
                        Komiwojazer.KomiwojazerZachlanny(0);
                        Komiwojazer.WyswietlKomiwojazerZachlanny();
                        break;

                    case "6":
                        Komiwojazer.WyswietlKomiwojazerZachlanny();
                        break;

                    case "7":
                        Console.WriteLine("Podaj liczbę wierzchołków: ");
                        liczbaWierzcholkow = Convert.ToInt32(Console.ReadLine());
                        Komiwojazer = new Komiwojazer(liczbaWierzcholkow);
                        Komiwojazer.WyswietlMacierz();
                        break;

                    case "8":
                        Console.WriteLine("Podaj nazwę pliku: ");
                        nazwaPliku = Console.ReadLine();
                        Plecak.WczytajZPliku(nazwaPliku);
                        Plecak.WyswietlPrzedmioty();
                        break;

                    case "9":
                        Plecak.WyswietlPrzedmioty();
                        break;

                    case "10":
                        Plecak.Zachlanny();
                        Plecak.WyswietlPlecak();
                        break;

                    case "11":
                        Plecak.WyswietlPlecak();
                        break;

                    case "12":
                        Console.Write("Podaj pojemność plecaka: ");
                        pojemnoscPlecaka = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Podaj liczbę przedmiotów: ");
                        liczbaPrzedmiotow = Convert.ToInt32(Console.ReadLine());
                        Plecak = new ProblemPlecakowy(pojemnoscPlecaka, liczbaPrzedmiotow);
                        Plecak.WyswietlPrzedmioty();
                        break;

                }

            } while (opcja != "0");
        }
    }
}
