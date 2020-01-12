using System.Collections.Generic;
using System.Text;
using SalesTaxes.Application.Models;

namespace SalesTaxes.Application.Business
{
    public interface IBusinessLogic
    {
        StringBuilder Printout(List<Receipt> receipt);
    }
}