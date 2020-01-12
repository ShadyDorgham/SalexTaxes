using NUnit.Framework;
using SalesTaxes.Inputs;
using System.Collections.Generic;
using System.Linq;
using SalesTaxes.Application.DomainService;
using SalesTaxes.Application.Helpers;
using SalesTaxes.Application.Models;

namespace SalesTaxes.Tests
{
    [TestFixture]
    public class ReceiptPrintOutTests
    {
        private ReceiptsInputs _receiptsInputs;
        private Rounding _rounding;

        public ReceiptPrintOutTests()
        {
            _receiptsInputs = new ReceiptsInputs();
            _rounding = new Rounding();
        }

        [Test]
        public void Printout_NoProductsEntered_ShouldReturnNull()
        {
            //Arrange
            var receipt = new List<Receipt>();

            //Act
            var businessLogic = new BusinessLogic(_rounding);
            var result = businessLogic.Printout(receipt);

            //Assert
            Assert.That(result, Is.Null);
        }


        [Test]
        public void Printout_IfProductsAreExcemptedAndNotImported_TaxesShouldBeZero()
        {
            //Arrange
            var receipt = new List<Receipt>
            {
                new Receipt {Quantity = 1 , SalesTaxes = false , ImportDuty = false , Price =  1 , ProductName = "HeadachePills"},
                new Receipt {Quantity = 1 , SalesTaxes = false , ImportDuty = false , Price =  1 , ProductName = "Chocolate"}

            };
            var businessLogic = new BusinessLogic(_rounding);

            //Act
            businessLogic.Printout(receipt);
            var totalReceiptTaxes = businessLogic._totalReceiptTaxesSummition;
            //Assert

            Assert.That(totalReceiptTaxes, Is.EqualTo(0));
        }



        [Test]
        public void Printout_IfProductsAreNotExcemptedOrImported_TaxesShouldBeZero()
        {
            //Arrange
            var receipt = new List<Receipt>
            {
                new Receipt {Quantity = 1 , SalesTaxes = false , ImportDuty = true , Price =  1 , ProductName = "HeadachePills"},
                new Receipt {Quantity = 1 , SalesTaxes = true , ImportDuty = false , Price =  1 , ProductName = "Chocolate"}

            };
            var businessLogic = new BusinessLogic(_rounding);

            //Act

            businessLogic.Printout(receipt);
            var totalReceiptTaxes = businessLogic._totalReceiptTaxesSummition;


            //Assert
            Assert.That(totalReceiptTaxes, Is.GreaterThan(0));
        }


        [Test]
        public void Printout_IfProductIsNotExemptedAndNotImported_SalesTaxesShouldBeAddedToProductPrice()
        {
            //Arrange
            var receipt = new List<Receipt>
            {
                new Receipt {Quantity = 1 , SalesTaxes = true , ImportDuty = false , Price =  10M , ProductName = "Perfume"}
            };
            var businessLogic = new BusinessLogic(_rounding);

            //Act
            businessLogic.Printout(receipt);
            var totalReceiptTaxes = businessLogic._totalReceiptTaxesSummition;
            var productPriceWithTax = businessLogic._productPriceWithTaxSummition;

            //Assert
            Assert.That(totalReceiptTaxes, Is.EqualTo(1M));
            Assert.That(productPriceWithTax, Is.EqualTo(1M + receipt.Sum(x => x.Price)));
        }


        



        [Test]
        public void Printout_IfProductIsExemptedAndImported_ImportDutyShouldBeAddedToProductPrice()
        {
            //Arrange
            var receipt = new List<Receipt>
            {
                new Receipt {Quantity = 1 , SalesTaxes = false , ImportDuty = true , Price =  10M , ProductName = "HeadachePills"}
            };
            var businessLogic = new BusinessLogic(_rounding);

            //Act
            businessLogic.Printout(receipt);
            var totalReceiptTaxes = businessLogic._totalReceiptTaxesSummition;
            var productPriceWithTax = businessLogic._productPriceWithTaxSummition;

            //Assert
            Assert.That(totalReceiptTaxes, Is.EqualTo(.5M));
            Assert.That(productPriceWithTax, Is.EqualTo(.5M + receipt.Sum(x => x.Price)));
        }


        [Test]
        public void Printout_IfProductIsNotExemptedAndImported_ImportDutyShouldBeAddedToProductPrice()
        {
            //Arrange
            var receipt = new List<Receipt>
            {
                new Receipt {Quantity = 1 , SalesTaxes = true , ImportDuty = true , Price =  10M , ProductName = "Perfume"}
            };
            var businessLogic = new BusinessLogic(_rounding);

            //Act
            businessLogic.Printout(receipt);
            var totalReceiptTaxes = businessLogic._totalReceiptTaxesSummition;
            var productPriceWithTax = businessLogic._productPriceWithTaxSummition;

            //Assert
            Assert.That(totalReceiptTaxes, Is.EqualTo(1.5M));
            Assert.That(productPriceWithTax, Is.EqualTo(1.5M + receipt.Sum(x => x.Price)));
        }

        [Test]
        public void Printout_IfTestCaseOneEntered_TestCaseOneShouldOutput()
        {
            //Arrange
            var businessLogic = new BusinessLogic(_rounding);

            //Act
            var receiptText = businessLogic.Printout(_receiptsInputs.FirstTextCase());
            var totalReceiptTaxes = businessLogic._totalReceiptTaxesSummition;
            var productPriceWithTax = businessLogic._productPriceWithTaxSummition;


            //Assert
            Assert.That(totalReceiptTaxes, Is.EqualTo(1.5M));
            Assert.That(productPriceWithTax, Is.EqualTo(29.83M));



            foreach (var product in _receiptsInputs.FirstTextCase())
            {
                Assert.That(receiptText.ToString(), Does.Contain(product.ProductName));
            }

        }














        [Test]
        public void Printout_IfTestCaseTwoEntered_TestCaseTwoShouldOutput()
        {
            //Arrange
            var businessLogic = new BusinessLogic(_rounding);

            //Act
            var receiptText = businessLogic.Printout(_receiptsInputs.SecondTextCase());
            var totalReceiptTaxes = businessLogic._totalReceiptTaxesSummition;
            var productPriceWithTax = businessLogic._productPriceWithTaxSummition;


            //Assert
            Assert.That(totalReceiptTaxes, Is.EqualTo(7.65M));
            Assert.That(productPriceWithTax, Is.EqualTo(65.15M));



            foreach (var product in _receiptsInputs.SecondTextCase())
            {
                Assert.That(receiptText.ToString(), Does.Contain(product.ProductName));
            }

        }

        [Test]
        public void Printout_IfTestCaseThreeEntered_TestCaseThreeShouldOutput()
        {
            //Arrange
            var businessLogic = new BusinessLogic(_rounding);

            //Act
            var receiptText = businessLogic.Printout(_receiptsInputs.ThirdTextCase());
            var totalReceiptTaxes = businessLogic._totalReceiptTaxesSummition;
            var productPriceWithTax = businessLogic._productPriceWithTaxSummition;


            //Assert
            Assert.That(totalReceiptTaxes, Is.EqualTo(6.7M));
            Assert.That(productPriceWithTax, Is.EqualTo(74.68M));



            foreach (var product in _receiptsInputs.ThirdTextCase())
            {
                Assert.That(receiptText.ToString(), Does.Contain(product.ProductName));
            }

        }
    }
}
