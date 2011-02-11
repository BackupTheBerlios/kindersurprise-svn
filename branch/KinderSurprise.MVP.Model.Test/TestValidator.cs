using KinderSurprise.MVP.Model.Interfaces;
using NUnit.Framework;
using StructureMap;

namespace KinderSurprise.MVP.Model.Test
{
    [TestFixture]
    public class TestValidator
    {
        [Test]
        public void Test_String_GetEmptyString_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidString(string.Empty));
        }

        [Test]
        public void Test_String_GetNullString_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidString(null));
        }

        [Test]
        public void Test_String_GetOnlyWhiteSpaces_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidString("   "));
        }

        [Test]
        public void Test_String_GetMixed_ShouldPass()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsTrue(validator.IsValidString(" text  "));
        }

        [Test]
        public void Test_String_GetValidString_ShouldPass()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsTrue(validator.IsValidString("A string"));
        }

        [Test]
        public void Test_Year_GetEmptyYear_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidYear(string.Empty));
        }

        [Test]
        public void Test_Year_GetNullYear_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidYear(null));
        }

        [Test]
        public void Test_Year_GetOnlyWhitespaces_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidYear("   "));
        }

        [Test]
        public void Test_Year_GetOnlyLetters_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidYear("year"));
        }

        [Test]
        public void Test_Year_GetMixedLetterAndNumber_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidYear("aa2354aa"));
        }

        [Test]
        public void Test_Year_GetMixedMinusNumber_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidYear("-2000"));
        }

        [Test]
        public void Test_Year_GetZeroAsYear_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidYear("0"));
        }

        [Test]
        public void Test_Year_GetSomethingGreaterThan9999_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidYear("100000"));
        }

        [Test]
        public void Test_Year_GetTheYear2_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidYear("2"));
        }

        [Test]
        public void Test_Year_GetTheYear1800_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidYear("1800"));
        }

        [Test]
        public void Test_Year_GetTheYear1900_ShouldPass()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsTrue(validator.IsValidYear("1900"));
        }

        [Test]
        public void Test_Year_GetTheYear2100_ShouldPass()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsTrue(validator.IsValidYear("2100"));
        }

        [Test]
        public void Test_Price_GetEmptyPrice_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidPrice(string.Empty));
        }

        [Test]
        public void Test_Price_GetNullPrice_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidPrice(null));
        }

        [Test]
        public void Test_Price_GetOnlyWhitespaces_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidPrice("   "));
        }

        [Test]
        public void Test_Price_GetOnlyLetters_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidPrice("price"));
        }

        [Test]
        public void Test_Price_GetMixedLetterAndNumber_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidPrice("aa2354aa"));
        }
        
        [Test]
        public void Test_Price_GetMixedLetterAndNumberAlsoAfterPoint_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidPrice("234.0a"));
        }

        [Test]
        public void Test_Price_GetMinusNumber_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidPrice("-2000"));
        }

        [Test]
        public void Test_Price_GetPriceWithWrongDelimiter_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidPrice("0,00"));
        }

        [Test]
        public void Test_Price_GetPriceWithPointButMoreThenTwoDigitsAfter_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidPrice("0.100"));
        }

        [Test]
        public void Test_Price_ContainsOfMoreThenOneDelimiter_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidPrice("0.12.100"));
        }

        [Test]
        public void Test_Price_GetZeroAsPrice_ShouldPass()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsTrue(validator.IsValidPrice("0"));
        }

        [Test]
        public void Test_Price_GetZeroAsPriceWithDigits_ShouldPass()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsTrue(validator.IsValidPrice("0.11"));
        }
        
        [Test]
        public void Test_Price_GetValidPriceWithoutDigitsAfterPoint_ShouldPass()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsTrue(validator.IsValidPrice("235"));
        }

        [Test]
        public void Test_Price_GetValidPriceWithDigitsAfterPoint_ShouldPass()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsTrue(validator.IsValidPrice("1198.99"));
        }

        [Test]
        public void Test_Price_GetValidPriceWithLettersAfterPoint_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidPrice("1198.9a"));
        }

        [Test]
        public void Test_Price_GetValidPriceWithLettersBeforePoint_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidPrice("1a98.99"));
        }

        [Test]
        public void Test_Price_GetValidPriceWithMoreThenTwoDigitsAfterPoint_ShouldFail()
        {
            IValidator validator = ObjectFactory.GetInstance<IValidator>();
            Assert.IsFalse(validator.IsValidPrice("1198.999"));
        }
    }
}
