using System.Collections.Generic;
using SalesTaxes.Application.Models;

namespace SalesTaxes.Inputs
{
    public  class ReceiptsInputs
    {
        public List<Receipt> FirstTextCase()
        {
            return new List<Receipt>
            {
                new Receipt {Quantity = 1 , SalesTaxes = false , ImportDuty = false , Price =  12.49M , ProductName = "book"},
                new Receipt {Quantity = 1 , SalesTaxes = true , ImportDuty = false , Price =  14.99M , ProductName = "music CD"},
                new Receipt {Quantity = 1 , SalesTaxes = false , ImportDuty = false , Price =  .85M , ProductName = "chocolate bar"}
            };
        }


        public List<Receipt> SecondTextCase()
        {
            return new List<Receipt>
            {
                new Receipt {Quantity = 1 , SalesTaxes = false , ImportDuty = true , Price =  10.00M , ProductName = "box of chocolate"},
                new Receipt {Quantity = 1 , SalesTaxes = true , ImportDuty = true , Price =  47.50M , ProductName = "bottle of perfume"}
            };
        }



        public List<Receipt> ThirdTextCase()
        {
            return new List<Receipt>
            {
                new Receipt {Quantity = 1 , SalesTaxes = true , ImportDuty = true , Price =  27.99M , ProductName = "bottle of perfume"},
                new Receipt {Quantity = 1 , SalesTaxes = true , ImportDuty = false , Price =  18.99M , ProductName = "bottle of perfume"},
                new Receipt {Quantity = 1 , SalesTaxes = false , ImportDuty = false , Price =  9.75M , ProductName = "packet of headache pills"},
                new Receipt {Quantity = 1 , SalesTaxes = false , ImportDuty = true , Price =  11.25M , ProductName = "box of chocolate"},
            };
        }


        
    }
}
