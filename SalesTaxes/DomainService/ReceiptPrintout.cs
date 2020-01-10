using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesTaxes.Helpers;
using SalesTaxes.Models;

namespace SalesTaxes.DomainService
{
    public class ReceiptPrintout
    {
        public decimal _totalReceiptTaxesSummition = 0;
        public decimal _productPriceWithTaxSummition = 0;

        public StringBuilder Printout(List<Receipt> receipt)
        {
            if (!receipt.Any())
                return null;


            var receiptText = new StringBuilder();

            foreach (var product in receipt)
            {
                var productTax = (product.ProductPrice() * product.TaxRate()).RoundUp();
                var productPriceWithTax = product.ProductPrice() + productTax;


                _totalReceiptTaxesSummition += productTax;
                _productPriceWithTaxSummition += productPriceWithTax;


                receiptText.Append(product.Quantity + " ");

                if (product.ImportDuty)
                    receiptText.Append("imported ");

                receiptText.Append(product.ProductName + " : ");
                receiptText.Append(productPriceWithTax.ToString("N2"));
                receiptText.AppendLine();
            }

            receiptText.Append("SalesTaxes" + ": ");
            receiptText.Append(_totalReceiptTaxesSummition.ToString("N2"));

            receiptText.AppendLine();

            receiptText.Append("Total" + ": ");
            receiptText.Append(_productPriceWithTaxSummition.ToString("N2"));

            return receiptText;
        }
    }
}