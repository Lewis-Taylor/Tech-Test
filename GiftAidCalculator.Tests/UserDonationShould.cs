using System;
using GiftAidCalculator.TestConsole;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    public class UserDonationShould
    {
        [TestCase("2.246", true)]
        [TestCase("235.35346", true)]
        [TestCase("absd", false)]
        [TestCase("2135.213", true)]
        [TestCase("-123", false)]
        [TestCase("", false)]
        public void Be_A_Positive_Decimal(string userDonation, bool expectedInput)
        {
            var inputValidator = new ValidateInput(userDonation);
            var actualInput = inputValidator.IsInputValid();

            Assert.AreEqual(expectedInput, actualInput);
        }
    }
}
