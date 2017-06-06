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
	        var donationAmount = Console.ReadLine();
            var donationValidator = new ValidateInput(donationAmount);
	        var isInputValid = donationValidator.IsInputValid();
	        if (!isInputValid)
	        {
	            Console.WriteLine("Donation amount {0} was not valid. Please enter a positive donation amount", donationAmount);
	        }
	        else
	        {
                var giftAidCalculator = new CalculateCalculateGiftAid(taxRate);
                var donation = giftAidCalculator.GiftAidAmount(decimal.Parse(donationAmount));
                var giftAidRounder = new GiftAidRounder(donation);
                Console.WriteLine(giftAidRounder.RoundToTwoDecimalPlaces());
            }
			Console.WriteLine("Press any key to exit.");
			Console.ReadLine();
		}
	}
}
