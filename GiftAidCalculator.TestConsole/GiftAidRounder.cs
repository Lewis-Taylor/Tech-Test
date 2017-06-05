using System;

namespace GiftAidCalculator.TestConsole
{
    public class GiftAidRounder
    {
        private readonly decimal _giftAidAmount;

        public GiftAidRounder(decimal giftAidAmount)
        {
            _giftAidAmount = giftAidAmount;
        }

        public decimal RoundToTwoDecimalPlaces()
        {
            return Math.Round(_giftAidAmount, 2);
        }
    }
}