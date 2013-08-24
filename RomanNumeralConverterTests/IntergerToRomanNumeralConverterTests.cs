using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RomanNumeralConverter;

namespace RomanNumeralConverterTests {
  [TestFixture]
  public class IntergerToRomanNumeralConverterTests {
    [Test]
    public void Convert_Throws_Exception_Less_Than_1() {
      Assert.Throws<ArgumentException>(() => new IntegerToRomanNumeralConverter().Convert(0), "Number must be greater than 0 to convert.");
    }

    [Test]
    public void Convert_Throws_Exception_Greater_Than_3999() {
      Assert.Throws<ArgumentException>(() => new IntegerToRomanNumeralConverter().Convert(50000), "Number must be less than 3,999 to convert.");
    }

    [TestCase(1000, "M")]
    [TestCase(1001, "MI")]
    [TestCase(1010, "MX")]
    [TestCase(1500, "MD")]
    [TestCase(1050, "ML")]
    [TestCase(1005, "MV")]
    [TestCase(1867, "MDCCCLXVII")]
    [TestCase(4, "IV")]
    [TestCase(9, "IX")]
    [TestCase(40, "XL")]
    [TestCase(19, "XIX")]
    [TestCase(555, "DLV")]
    [TestCase(1950, "MCML")]
    [TestCase(1990, "MCMXC")]
    public void Convert(int num, string expectedResult) {
      Assert.AreEqual(expectedResult, new IntegerToRomanNumeralConverter().Convert(num));
    }
  }
}
