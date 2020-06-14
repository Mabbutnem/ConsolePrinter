using System;

namespace ConsolePrinter
{
   class Program
   {
      static void Main(string[] args)
      {
         ConsolePrinter.Print(
            new string[] { "Nom", "Age", "Ville", "Loisirs" },
            new string[][]
            {
               new string[] {"Thibault", "22", "Laval",     "Jeux"},
               new string[] {"Anthony",  "22", "Cholet",    "Netflix"},
               new string[] {"Kevin",    "22", "Marseille", "Compter les chevaux"},
               new string[] {"Patty",    "23", "Laval",     "Travail"},
            },
            new PrintingColor[]
            {
               PrintingColor.Base(),
               PrintingColor.Create(ConsoleColor.Red, EqualTo23),
               PrintingColor.Create(ConsoleColor.Yellow, IsLaval),
               PrintingColor.Base(),
            }
         );
      }

      static bool EqualTo23(string str)
      {
         bool parsable = int.TryParse(str, out int i);
         return parsable && i == 23;
      }

      static bool IsLaval(string str)
      {
         return str.CompareTo("Laval")==0;
      }
   }
}
