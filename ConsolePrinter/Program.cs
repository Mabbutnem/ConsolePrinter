using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsolePrinter
{
   class Program
   {
      #region Data
      public static bool Quit { get; set; } = false;

      public static List<Person> Persons { get; set; } = new List<Person>
      {
            new Person("Thibault", 22, "Laval",     "Jeux"),
            new Person("Anthony",  22, "Cholet",    "Netflix"),
            new Person("Kevin",    22, "Marseille", "Compter les chevaux"),
            new Person("Patty",    23, "Laval",     "Travail"),
      };

      public static List<Cat> Cats { get; set; } = new List<Cat>
      {
            new Cat("Caline",   11, "Aggresive"),
            new Cat("Poupette", 14, "Hug"),
            new Cat("Pacha",    1,  "Friendly"),
            new Cat("Rasta",    0,  "Energetic"),
      };
      #endregion

      public static Parser CommandLineParser { get; } = CommandLine.Parser.Default;

      static void Main()
      {
         do
         {
            Console.Write('>');
            string[] args = Console.ReadLine().Trim().Split();
            ParserResult<object> parserResult = CommandLineParser.ParseArguments<PersonOptions, CatOptions, QuitOptions>(args);
            parserResult
               .WithParsed<PersonOptions>(opt => PersonAction(opt))
               .WithParsed<CatOptions>(opt => CatAction(opt))
               .WithParsed<QuitOptions>(opt => QuitAction(opt))
               .WithNotParsed(err => { });
         }
         while (!Quit);
      }

      static int PersonAction(PersonOptions opt)
      {
         ParserResult<object> parserResult = CommandLineParser.ParseArguments<PersonLSOptions, PersonAddOptions>(opt.Options);
         parserResult.WithParsed<PersonLSOptions>(opt => DisplayPersons(opt))
            .WithParsed<PersonAddOptions>(opt => AddPerson(opt))
            .WithNotParsed(err => { });
         
         return 0;
      }
      static int DisplayPersons(PersonLSOptions opt)
      {
         ConsolePrinter.Print(
            new string[] { "Name", "Age", "Town", "Hobbies" },
            Persons.Select(p => new string[] { p.Name, p.Age.ToString(), p.Town, p.Hobbies }).ToArray(),
            new PrintingColor[]
            {
               PrintingColor.Base(),
               PrintingColor.Create(ConsoleColor.Red,    str => int.TryParse(str, out int i) && i == 23),
               PrintingColor.Base(),
               PrintingColor.Base(),
            }
         );
         return 0;
      }
      static int AddPerson(PersonAddOptions opt)
      {
         Persons.Add(new Person("#", 0, "#", "#"));
         return 0;
      }

      static int CatAction(CatOptions opt)
      {
         ParserResult<object> parserResult = CommandLineParser.ParseArguments<CatLSOptions, CatAddOptions>(opt.Options);
         parserResult.WithParsed<CatLSOptions>(opt => DisplayCats(opt))
            .WithParsed<CatAddOptions>(opt => AddCat(opt))
            .WithNotParsed(err => { });

         return 0;
      }
      static int DisplayCats(CatLSOptions opt)
      {
         ConsolePrinter.Print(
            new string[] { "Name", "Age", "Character" },
            Cats.Select(c => new string[] { c.Name, c.Age.ToString(), c.Character }).ToArray()
         );
         return 0;
      }
      static int AddCat(CatAddOptions opt)
      {
         Cats.Add(new Cat("#", 0, "#"));
         return 0;
      }

      static int QuitAction(QuitOptions opt)
      {
         Quit = true;
         return 0;
      }
   }

   [Verb("person", HelpText = "Actions related to Persons.")]
   class PersonOptions
   {
      [Value(0)]
      public IEnumerable<string> Options { get; set; }
   }

   [Verb("ls", HelpText = "Print all Persons.")]
   class PersonLSOptions
   {
   }

   [Verb("add", HelpText = "Add a generic Person.")]
   class PersonAddOptions
   {
   }

   [Verb("cat", HelpText = "Actions related to Cats.")]
   class CatOptions
   {
      [Value(0)]
      public IEnumerable<string> Options { get; set; }
   }

   [Verb("ls", HelpText = "Print all Cats.")]
   class CatLSOptions
   {
   }

   [Verb("add", HelpText = "Add a generic Cat.")]
   class CatAddOptions
   {
   }

   [Verb("quit", HelpText = "Quit application.")]
   class QuitOptions
   {
   }
}
