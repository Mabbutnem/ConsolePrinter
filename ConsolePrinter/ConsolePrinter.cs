using System;
using System.Linq;

namespace ConsolePrinter
{
   class ConsolePrinter
   {
      private static readonly int NB_MIN_SPACE = 1;

      public static void Print(string[] fields, string[][] values)
      {
         Func<string, ConsoleColor>[] colorsToPrint = new Func<string, ConsoleColor>[fields.Length];
         for(int i = 0; i < colorsToPrint.Length; i++) { colorsToPrint[i] = BaseColor; }
         Print(fields, values, colorsToPrint);
      }

      public static void Print(string[] fields, string[][] values, Func<string, ConsoleColor>[] colorsToPrint)
      {
         //Checking length
         if (colorsToPrint.Length != fields.Length)
         {
            Console.WriteLine("Can't print : fields and colors to print don't have same Length.");
            return;
         }
         foreach (string[] strArray in values)
         {
            if (strArray.Length != fields.Length)
            {
               Console.WriteLine("Can't print : fields and values don't have same Length.");
               return;
            }
         }

         //Calculating needed spaces
         int[] maxStrLength = fields.Select(str => str.Length).ToArray();
         foreach (string[] strArray in values)
         {
            for (int i = 0; i < strArray.Length; i++)
            {
               maxStrLength[i] = Math.Max(maxStrLength[i], strArray[i].Length);
            }
         }
         maxStrLength = maxStrLength.Select(i => i + NB_MIN_SPACE).ToArray();

         //Printing
         Console.WriteLine();
         Console.ForegroundColor = ConsoleColor.White;
         for (int i = 0; i < fields.Length; i++)
         {
            Console.Write(fields[i]);
            PrintSpace(maxStrLength[i] - fields[i].Length);
         }
         Console.ResetColor();
         Console.WriteLine();
         foreach (string[] strArray in values)
         {
            for (int i = 0; i < strArray.Length; i++)
            {
               Console.ForegroundColor = colorsToPrint[i](strArray[i]);
               Console.Write(strArray[i]);
               PrintSpace(maxStrLength[i] - strArray[i].Length);
               Console.ResetColor();
            }
            Console.WriteLine();
         }
         Console.WriteLine();
      }

      private static void PrintSpace(int nb)
      {
         for (int i = 0; i < nb; i++)
         {
            Console.Write(' ');
         }
      }

      public static ConsoleColor BaseColor(string str) => ConsoleColor.Gray;
   }
}
