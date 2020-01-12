
using System;
using SalesTaxes.Application.DomainService;
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

        public void run()
        {
            var inputs = new ReceiptsInputs();
            Console.Write(_businessLogic.Printout(inputs.FirstTextCase()));
        }
    }
}
