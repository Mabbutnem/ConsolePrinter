using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePrinter
{
   class Cat
   {
      public string Name { get; set; }
      public int Age { get; set; }
      public string Character { get; set; }

      public Cat(string name, int age, string character)
      {
         Name = name;
         Age = age;
         Character = character;
      }
   }
}
