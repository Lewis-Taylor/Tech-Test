using GiftAidCalculator.TestConsole.Repositories;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    public class TaxRateShould
    {
        [Test]
        public void Be_Configurable_For_A_Site_Administrator_So_They_Can_Change_The_Tax_Rate_Without_A_Code_Change()
        {
            const decimal expectedTaxRate = 20m;

            var taxRateRepository = new TaxRateRepository(expectedTaxRate);

            Assert.AreEqual(expectedTaxRate, taxRateRepository.TaxRate);
        }
    }
}
