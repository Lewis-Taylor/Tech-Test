using System.Globalization;
using GiftAidCalculator.TestConsole.Interfaces;

namespace GiftAidCalculator.TestConsole
{
    public class ValidateInput : IValidateInput
    {
        private readonly string _input;

        public ValidateInput(string input)
        {
            _input = input;
        }

        public bool IsInputValid()
        {
            decimal number;
            decimal.TryParse(_input.ToString(CultureInfo.InvariantCulture), out number);
            var isValid = number > 0;
            return isValid;
        }
    }
}