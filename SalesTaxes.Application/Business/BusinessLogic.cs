using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesTaxes.Application.Models;
using SalesTaxes.Application.Utilities;

namespace SalesTaxes.Application.Business
{
    public class BusinessLogic : IBusinessLogic
    {
        public decimal TotalReceiptTaxesSummation;
        public decimal ProductPriceWithTaxSummation;

        private readonly IRounding _rounding;
        public BusinessLogic(IRounding rounding )
        {
            _rounding = rounding;
        }



        public StringBuilder Printout(List<Receipt> receipt)
        {
            if (!receipt.Any())
                return null;


            var receiptText = new StringBuilder();

            foreach (var product in receipt)
            {
                var productTax = _rounding.RoundUp(product.TaxAmount());
                var productPriceWithTax = product.ProductPrice() + productTax;


                TotalReceiptTaxesSummation += productTax;
                ProductPriceWithTaxSummation += productPriceWithTax;


                receiptText.Append(product.Quantity + " ");

                if (product.ImportDuty)
                    receiptText.Append("imported ");

                receiptText.Append(product.ProductName + " : ");
                receiptText.Append(productPriceWithTax.ToString("N2"));
                receiptText.AppendLine();
            }

            receiptText.Append("SalesTaxes" + ": ");
            receiptText.Append(TotalReceiptTaxesSummation.ToString("N2"));

            receiptText.AppendLine();

            receiptText.Append("Total" + ": ");
            receiptText.Append(ProductPriceWithTaxSummation.ToString("N2"));

            return receiptText;
        }
    }
}