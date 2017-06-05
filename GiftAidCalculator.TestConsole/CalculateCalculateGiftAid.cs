using GiftAidCalculator.TestConsole.Interfaces;

namespace GiftAidCalculator.TestConsole
{
    public class CalculateCalculateGiftAid : ICalculateGiftAid
    {
        private readonly ITaxRateRepository _taxRateRepository;

        public CalculateCalculateGiftAid(ITaxRateRepository taxRateRepository)
        {
            _taxRateRepository = taxRateRepository;
        }

        public virtual decimal GiftAidAmount(decimal donationAmount)
        {
            var giftAidRatio = _taxRateRepository.TaxRate / (100 - _taxRateRepository.TaxRate);
            return donationAmount * giftAidRatio;
        }
    }
}