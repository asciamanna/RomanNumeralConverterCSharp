using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RomanNumeralConverter {
  //http://able2know.org/topic/54469-1

  public class IntegerToRomanNumeralConverter {
    public string Convert(int number) {
      if (number < 1) throw new ArgumentException("Number must be greater than 0 to convert.");
      if (number > 3999) throw new ArgumentException("Number must be less than 3,999 to convert.");

      return ToRomanNumeral(number, string.Empty);
    }

    string ToRomanNumeral(int number, string currentRomanNumeral) {
      currentRomanNumeral = CorrectFourNumeralsInARow(currentRomanNumeral);

      if (number >= 1000) return ToRomanNumeral(number - 1000, currentRomanNumeral + "M");
      if (number >= 500) return ToRomanNumeral(number - 500, currentRomanNumeral + "D");
      if (number >= 100) return ToRomanNumeral(number - 100, currentRomanNumeral + "C");
      if (number >= 50) return ToRomanNumeral(number - 50, currentRomanNumeral + "L");
      if (number >= 10) return ToRomanNumeral(number - 10, currentRomanNumeral + "X");
      if (number >= 5) return ToRomanNumeral(number - 5, currentRomanNumeral + "V");
      if (number >= 1) return ToRomanNumeral(number - 1, currentRomanNumeral + "I");
      return currentRomanNumeral;
    }

    string CorrectFourNumeralsInARow(string input) {
      if (!String.IsNullOrWhiteSpace(input) && input.Length >= 4) {
        var endsWith = input[input.Length - 1].ToString();
        if (Regex.IsMatch(input, nextSymbol[endsWith] + fourNumeralsInARowMatch)) {
          return Regex.Replace(input, nextSymbol[endsWith] + fourNumeralsInARowMatch, endsWith + nextSymbol[nextSymbol[endsWith]]);
        }
        else if (Regex.IsMatch(input, fourNumeralsInARowMatch)) {
          return Regex.Replace(input, fourNumeralsInARowMatch, endsWith + nextSymbol[endsWith]);
        }
      }
      return input;
    }

    string fourNumeralsInARowMatch = @"(\w)\1{3}";

    Dictionary<string, string> nextSymbol = new Dictionary<string, string> { { "I", "V" }, { "V", "X" }, { "X", "L" }, { "L", "C" }, { "C", "D" }, { "D", "M" } };
  }
}
