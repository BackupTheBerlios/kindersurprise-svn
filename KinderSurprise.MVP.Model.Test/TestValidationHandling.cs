using NUnit.Framework;

namespace KinderSurprise.MVP.Model.Test
{
    [TestFixture]
    public class TestValidationHandling
    {
        [Test]
        public void Test_String_GetEmptyString_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidString(string.Empty));
        }

        [Test]
        public void Test_String_GetNullString_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidString(null));
        }

        [Test]
        public void Test_String_GetOnlyWhiteSpaces_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidString("   "));
        }

        [Test]
        public void Test_String_GetMixed_ShouldPass()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsTrue(validationHandling.IsValidString(" text  "));
        }

        [Test]
        public void Test_String_GetValidString_ShouldPass()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsTrue(validationHandling.IsValidString("A string"));
        }

        [Test]
        public void Test_Year_GetEmptyYear_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidYear(string.Empty));
        }

        [Test]
        public void Test_Year_GetNullYear_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidYear(null));
        }

        [Test]
        public void Test_Year_GetOnlyWhitespaces_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidYear("   "));
        }

        [Test]
        public void Test_Year_GetOnlyLetters_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidYear("year"));
        }

        [Test]
        public void Test_Year_GetMixedLetterAndNumber_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidYear("aa2354aa"));
        }

        [Test]
        public void Test_Year_GetMixedMinusNumber_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidYear("-2000"));
        }

        [Test]
        public void Test_Year_GetZeroAsYear_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidYear("0"));
        }

        [Test]
        public void Test_Year_GetSomethingGreaterThan9999_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidYear("100000"));
        }

        [Test]
        public void Test_Year_GetTheYear2_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidYear("2"));
        }

        [Test]
        public void Test_Year_GetTheYear1800_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidYear("1800"));
        }

        [Test]
        public void Test_Year_GetTheYear1900_ShouldPass()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsTrue(validationHandling.IsValidYear("1900"));
        }

        [Test]
        public void Test_Year_GetTheYear2100_ShouldPass()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsTrue(validationHandling.IsValidYear("2100"));
        }

        [Test]
        public void Test_Price_GetEmptyPrice_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidPrice(string.Empty));
        }

        [Test]
        public void Test_Price_GetNullPrice_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidPrice(null));
        }

        [Test]
        public void Test_Price_GetOnlyWhitespaces_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidPrice("   "));
        }

        [Test]
        public void Test_Price_GetOnlyLetters_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidPrice("price"));
        }

        [Test]
        public void Test_Price_GetMixedLetterAndNumber_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidPrice("aa2354aa"));
        }
        
        [Test]
        public void Test_Price_GetMixedLetterAndNumberAlsoAfterPoint_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidPrice("234.0a"));
        }

        [Test]
        public void Test_Price_GetMinusNumber_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidPrice("-2000"));
        }

        [Test]
        public void Test_Price_GetPriceWithWrongDelimiterPoint_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidPrice("0.00"));
        }

        [Test]
        public void Test_Price_GetPriceWithPointButMoreThenTwoDigitsAfter_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidPrice("0,100"));
        }

        [Test]
        public void Test_Price_ContainsOfMoreThenOnePoints_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidPrice("0,12,100"));
        }

        [Test]
        public void Test_Price_GetZeroAsPrice_ShouldPass()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsTrue(validationHandling.IsValidPrice("0"));
        }

        [Test]
        public void Test_Price_GetZeroAsPriceWithDigits_ShouldPass()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsTrue(validationHandling.IsValidPrice("0,11"));
        }
        
        [Test]
        public void Test_Price_GetValidPriceWithoutDigitsAfterPoint_ShouldPass()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsTrue(validationHandling.IsValidPrice("235"));
        }

        [Test]
        public void Test_Price_GetValidPriceWithDigitsAfterPoint_ShouldPass()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsTrue(validationHandling.IsValidPrice("1198,99"));
        }

        [Test]
        public void Test_Price_GetValidPriceWithLettersAfterPoint_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidPrice("1198,9a"));
        }

        [Test]
        public void Test_Price_GetValidPriceWithLettersBeforePoint_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidPrice("1a98,99"));
        }

        [Test]
        public void Test_Price_GetValidPriceWithMoreThenTwoDigitsAfterPoint_ShouldFail()
        {
            ValidationHandling validationHandling = new ValidationHandling();
            Assert.IsFalse(validationHandling.IsValidPrice("1198,999"));
        }
    }
}
