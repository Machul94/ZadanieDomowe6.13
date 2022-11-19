using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieDomowe3._21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Podaj imię: ");
                var imię = Console.ReadLine();

                Console.WriteLine("Podaj rok urodzenia: ");
                var rok = GetImput();

                Console.WriteLine("Podaj miesiąc urodzenia: ");
                var miesiąc = GetImput();

                Console.WriteLine("Podaj dzień urodzenia: ");
                var dzień = GetImput();

                Console.WriteLine("Podaj miejsce urodzenia: ");
                var miejsce = (Console.ReadLine());

                DateTime Teraz = DateTime.Now;
                DateTime DataUrodzenia = new DateTime(rok, miesiąc, dzień);
                int wiek = Teraz.Year - DataUrodzenia.Year;
                if (DataUrodzenia > Teraz.AddYears(-wiek))
                    wiek--;
                Console.WriteLine($"Cześć {imię} urdziłeś się w {miejsce} i  masz {wiek} lat");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
        private static int GetImput()
        {
            if (!int.TryParse(Console.ReadLine(), out int imput))
                throw new Exception("Podawna wartość jest nieprawidłowa");
            return imput;
        }
    }
}
