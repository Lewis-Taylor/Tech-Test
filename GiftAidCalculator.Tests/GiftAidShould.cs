using System;
using GiftAidCalculator.TestConsole;
using GiftAidCalculator.TestConsole.Interfaces;
using Moq;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    public class GiftAidShould
    {
        [Test]
        public void Return_The_Extra_Amount_To_The_Donor_Given_That_Gift_Aid_Has_Been_Selected()
        {
            const double expectedGiftAidAmount = 25.00;
            const decimal donationAmount = 100;
            const decimal taxRate = 20m;

            var taxRateRepository = new Mock<ITaxRateRepository>();
            taxRateRepository.SetupGet(x => x.TaxRate).Returns(taxRate);

            var giftAidCalculator = new CalculateCalculateGiftAid(taxRateRepository.Object);
            var actualGiftAidAmount = giftAidCalculator.GiftAidAmount(donationAmount);

            Assert.AreEqual(expectedGiftAidAmount, actualGiftAidAmount);
        }

        [TestCase("23.123", "23.12")]
        [TestCase("32.98213", "32.98")]
        [TestCase("3.999", "4.0")]
        public void Return_The_Gift_Aid_Rounded_To_Two_Decimal_Places(string totalGiftAid, string expectedGiftAid)
        {
            var totalGiftAidAsDecimal = Convert.ToDecimal(totalGiftAid);
            var expectedGiftAidAsDecimal = Convert.ToDecimal(expectedGiftAid);
            var taxRateRepository = new Mock<ITaxRateRepository>();

            var giftAidCalculator = new Mock<CalculateCalculateGiftAid>(taxRateRepository.Object);
            giftAidCalculator.Setup(x => x.GiftAidAmount(It.IsAny<decimal>())).Returns(totalGiftAidAsDecimal);
            var giftAidRounder = new GiftAidRounder(giftAidCalculator.Object.GiftAidAmount(It.IsAny<decimal>()));
            var actualGiftAid = giftAidRounder.RoundToTwoDecimalPlaces();

            Assert.AreEqual(expectedGiftAidAsDecimal, actualGiftAid);
        }
    }
}
