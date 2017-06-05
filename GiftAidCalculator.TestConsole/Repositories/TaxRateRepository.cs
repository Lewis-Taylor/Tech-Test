using GiftAidCalculator.TestConsole.Interfaces;

namespace GiftAidCalculator.TestConsole.Repositories
{
    public class TaxRateRepository : ITaxRateRepository
    {
        public TaxRateRepository(decimal taxRate)
        {
            TaxRate = taxRate;
        }

        public decimal TaxRate { get; set; }
    }
}