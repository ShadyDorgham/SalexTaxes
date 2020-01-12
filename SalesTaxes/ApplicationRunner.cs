
using System;
using SalesTaxes.Application.Business;
using SalesTaxes.Inputs;

namespace SalesTaxes
{
    public class ApplicationRunner : IApplicationRunner
    {
        private IBusinessLogic _businessLogic;

        public ApplicationRunner(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        public void Print()
        {
            var inputs = new ReceiptsInputs();
            Console.Write(_businessLogic.Printout(inputs.FirstTextCase()));
        }
    }
}
