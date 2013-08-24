using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralConverter {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("----------Roman Numeral Converter Code Kata------------");
      var converter = new IntegerToRomanNumeralConverter();
      while (true) {
        Console.Write("Enter a number to convert between 1 - 3999.  Enter 'q' to quit: ");
        var input = Console.ReadLine();
        if (input == "q") break;

        int integerInput;
        if (Int32.TryParse(input, out integerInput)) {
          try {
            var result = converter.Convert(integerInput);
            Console.WriteLine("Roman Numeral is: {0}", result);
          }
          catch (ArgumentException) {
            InvalidInput();
          }
        }
        else {
          InvalidInput();
        }
      }
    }

    static void InvalidInput() {
      Console.WriteLine("Invalid Input!");
    }
  }
}
