using System;

namespace SalesTaxes.Application.Helpers
{
    public class Rounding : IRounding
    {
        public decimal RoundUp(decimal amount)
        {
            var unRoundedAmount = TruncateDecimal(amount);

           var fractionToBeRounded = amount - unRoundedAmount;


           if (fractionToBeRounded < .05M && fractionToBeRounded > 0)
               fractionToBeRounded = .05M;
           
           if (fractionToBeRounded > .05M)
               fractionToBeRounded = .1M;


            return unRoundedAmount + fractionToBeRounded;
        }




        public decimal TruncateDecimal(decimal value)
        {
            var integralValue = Math.Truncate(value);

            var fraction = value - integralValue;

            var factor = (decimal)Math.Pow(10, 1);

            var truncatedFraction = Math.Truncate(fraction * factor) / factor;

            var result = integralValue + truncatedFraction;

            return result;
        }
    }
}
