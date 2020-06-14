using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePrinter
{
   class Person
   {
      public string Name { get; }
      public int Age { get; }
      public string Town { get; }
      public string Hobbies { get; }

      public Person(string name, int age, string town, string hobbies)
      {
         Name = name;
         Age = age;
         Town = town;
         Hobbies = hobbies;
      }
   }
}
