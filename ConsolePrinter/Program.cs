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
               new string[] {"Patty",    "22", "Laval",     "Travail"},
            }
         );
      }
   }
}
