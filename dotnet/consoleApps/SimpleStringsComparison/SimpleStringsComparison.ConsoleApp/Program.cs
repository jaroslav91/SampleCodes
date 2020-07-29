using System;


namespace SimpleStringsComparison.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadanie 1 - porównywarka ciągów znaków");
            Console.WriteLine("Podaj pierwszy ciąg znaków");
            var stringOne = Console.ReadLine();
            Console.WriteLine("Podaj drugi ciąg znaków");
            var stringTwo = Console.ReadLine();

            IStringsComparisonService stringComparison = new StringsComparisonService();

            var result = stringComparison.Compare(stringOne, stringTwo);

            Console.WriteLine("\n###########\nRezultat:");
            if (result.AreEqual)
            {
                Console.WriteLine("Podane ciągi nie zawierają różnic");
            }
            else
            {
                Console.WriteLine("Podane ciągi są róźne");
                Console.WriteLine("Różnice:");
                foreach (var d in result.Differences)
                {
                    Console.WriteLine(d.Description.ToString());
                }
            }
        }
    }
}
