using System;
using System.Linq;

namespace ConsolePrinter
{
   #region Console Printer
   class ConsolePrinter
   {
      private static readonly int NB_MIN_SPACE = 1;

      public static void Print(string[] fields, string[][] values)
      {
         PrintingColor baseColor = PrintingColor.Base();
         PrintingColor[] printingColors = new PrintingColor[fields.Length];
         for(int i = 0; i < printingColors.Length; i++) { printingColors[i] = baseColor; }
         Print(fields, values, printingColors);
      }

      public static void Print(string[] fields, string[][] values, PrintingColor[] printingColors)
      {
         //Checking length
         if (printingColors.Length != fields.Length)
         {
            Console.WriteLine("Can't print : fields and printing colors don't have same Length.");
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
               PrintingColor printingColor = printingColors[i];
               if (printingColor.PrintingColorPredicate(strArray[i]))
               {
                  Console.ForegroundColor = printingColor.ForegroundColor;
                  Console.BackgroundColor = printingColor.BackgroundColor;
               }
               Console.Write(strArray[i]);
               PrintSpace(maxStrLength[i] - strArray[i].Length);
               Console.ResetColor();
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
   #endregion

   #region Printing Color
   class PrintingColor
   {
      public ConsoleColor ForegroundColor { get; }
      public ConsoleColor BackgroundColor { get; }
      public Predicate<string> PrintingColorPredicate { get; }

      private PrintingColor(ConsoleColor foregroundColor, ConsoleColor backgroundColor, Predicate<string> printingColorPredicate)
      {
         ForegroundColor = foregroundColor;
         BackgroundColor = backgroundColor;
         PrintingColorPredicate = printingColorPredicate;
      }

      public static PrintingColor Create(ConsoleColor foregroundColor, ConsoleColor backgroundColor, Predicate<string> printingColorPredicate)
      {
         return new PrintingColor(foregroundColor, backgroundColor, printingColorPredicate);
      }

      public static PrintingColor Create(ConsoleColor foregroundColor, Predicate<string> printingColorPredicate)
      {
         return new PrintingColor(foregroundColor, ConsoleColor.Black, printingColorPredicate);
      }

      public static PrintingColor Base()
      {
         return new PrintingColor(ConsoleColor.Black, ConsoleColor.Black, (str) => false);
      }

      public static PrintingColor Invisible(Predicate<string> printingColorPredicate)
      {
         return new PrintingColor(ConsoleColor.Black, ConsoleColor.Black, printingColorPredicate);
      }
   }
   #endregion
}
