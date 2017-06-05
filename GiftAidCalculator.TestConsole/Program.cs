using System;
using GiftAidCalculator.TestConsole.Repositories;

namespace GiftAidCalculator.TestConsole
{
	class Program
	{
	    static void Main(string[] args)
		{
            // Set TaxRate
            var taxRate = new TaxRateRepository(20m);

            // Calc Gift Aid Based on Previous
            Console.WriteLine("Please Enter donation amount:");
            
            var giftAidCalculator = new CalculateCalculateGiftAid(taxRate);
	        var donationAmount = giftAidCalculator.GiftAidAmount(decimal.Parse(Console.ReadLine()));
            var giftAidRounder = new GiftAidRounder(donationAmount);

            Console.WriteLine(giftAidRounder.RoundToTwoDecimalPlaces());

			Console.WriteLine("Press any key to exit.");
			Console.ReadLine();
		}
	}
}
