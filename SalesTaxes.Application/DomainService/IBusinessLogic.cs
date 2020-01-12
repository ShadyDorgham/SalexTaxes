using System.Collections.Generic;
using System.Text;
using SalesTaxes.Application.Models;

namespace SalesTaxes.Application.DomainService
{
    public interface IBusinessLogic
    {
        StringBuilder Printout(List<Receipt> receipt);
    }
}