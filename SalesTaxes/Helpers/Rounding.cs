using System;

namespace SalesTaxes.Helpers
{
    public static  class Rounding
    {
        public static decimal RoundUp(this decimal amount)
        {
            var unRoundedAmount = amount.TruncateDecimal();

           var fractionToBeRounded = amount - unRoundedAmount;


           if (fractionToBeRounded < .05M && fractionToBeRounded > 0)
               fractionToBeRounded = .05M;
           
           if (fractionToBeRounded > .05M)
               fractionToBeRounded = .1M;
 

            return unRoundedAmount + fractionToBeRounded;
        }




        public static decimal TruncateDecimal(this decimal value)
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
