using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ConsolePrinter
{
   class ConsolePrinter
   {
      private static readonly int NB_MIN_SPACE = 1;

      public static void Print(string[] fields, string[][] values)
      {
         //Verification
         foreach (string[] strArray in values)
         {
            if (strArray.Length != fields.Length)
            {
               Console.WriteLine("Can't print : fields and values don't have same Length.");
               return;
            }
         }

         //Calculate needed spaces
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
               Console.Write(strArray[i]);
               PrintSpace(maxStrLength[i] - strArray[i].Length);
            }
            Console.WriteLine();
         }
      }

      private static void PrintSpace(int nb)
      {
         for (int i = 0; i < nb; i++)
         {
            Console.Write(' ');
         }
      }
   }
}
