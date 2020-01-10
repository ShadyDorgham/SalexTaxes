using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesTaxes.DomainService;
using SalesTaxes.Inputs;

namespace SalesTaxes
{
  public  class Program
    {
        static void Main(string[] args)
        {
            var inputs = new ReceiptsInputs();
            var result =  new ReceiptPrintout();
            Console.WriteLine(result.Printout(inputs.ThirdTextCase()));
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }







       

    }

  
}
