using System;
using System.Linq;

namespace ConsolePrinter
{
   class Program
   {
      static void Main(string[] args)
      {
         Person[] persons = new Person[]
         {
            new Person("Thibault", 22, "Laval",     "Jeux"),
            new Person("Anthony",  22, "Cholet",    "Netflix"),
            new Person("Kevin",    22, "Marseille", "Compter les chevaux"),
            new Person("Patty",    23, "Laval",     "Travail"),
         };

         ConsolePrinter.Print(
            new string[] { "Name", "Age", "Town", "Hobbies" },
            persons.Select(p => new string[] {p.Name, p.Age.ToString(), p.Town, p.Hobbies}).ToArray(),
            new PrintingColor[]
            {
               PrintingColor.Base(),
               PrintingColor.Create(ConsoleColor.Red,    str => int.TryParse(str, out int i) && i == 23),
               PrintingColor.Create(ConsoleColor.Yellow, str => str.CompareTo("Laval")==0),
               PrintingColor.Base(),
            }
         );
      }
   }
}
