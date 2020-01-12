using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SalesTaxes.Application.Business;
using SalesTaxes.Application.Models;
using SalesTaxes.Application.Utilities;
using SalesTaxes.Inputs;

namespace SalesTaxes.Tests.BusinessTests
{
    [TestFixture]
    public class BusinessLogicTest
    {
        private ReceiptsInputs _receiptsInputs;
        private readonly Rounding _rounding;
        private BusinessLogic _businessLogic;

        public BusinessLogicTest()
        {
            _receiptsInputs = new ReceiptsInputs();
            _rounding = new Rounding();
            _businessLogic = new BusinessLogic(_rounding);
        }

        [Test]
        public void Printout_NoProductsEntered_ShouldReturnNull()
        {
            //Arrange
            var receipt = new List<Receipt>();

            //Act
            _businessLogic = new BusinessLogic(_rounding);
            var result = _businessLogic.Printout(receipt);

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
            _businessLogic = new BusinessLogic(_rounding);

            //Act
            _businessLogic.Printout(receipt);
            var totalReceiptTaxes = _businessLogic.TotalReceiptTaxesSummation;
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
            _businessLogic = new BusinessLogic(_rounding);

            //Act

            _businessLogic.Printout(receipt);
            var totalReceiptTaxes = _businessLogic.TotalReceiptTaxesSummation;


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
            _businessLogic = new BusinessLogic(_rounding);

            //Act
            _businessLogic.Printout(receipt);
            var totalReceiptTaxes = _businessLogic.TotalReceiptTaxesSummation;
            var productPriceWithTax = _businessLogic.ProductPriceWithTaxSummation;

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
            _businessLogic = new BusinessLogic(_rounding);

            //Act
            _businessLogic.Printout(receipt);
            var totalReceiptTaxes = _businessLogic.TotalReceiptTaxesSummation;
            var productPriceWithTax = _businessLogic.ProductPriceWithTaxSummation;

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
            _businessLogic = new BusinessLogic(_rounding);

            //Act
            _businessLogic.Printout(receipt);
            var totalReceiptTaxes = _businessLogic.TotalReceiptTaxesSummation;
            var productPriceWithTax = _businessLogic.ProductPriceWithTaxSummation;

            //Assert
            Assert.That(totalReceiptTaxes, Is.EqualTo(1.5M));
            Assert.That(productPriceWithTax, Is.EqualTo(1.5M + receipt.Sum(x => x.Price)));
        }

        [Test]
        public void Printout_IfTestCaseOneEntered_TestCaseOneShouldOutput()
        {
            //Arrange
            _businessLogic = new BusinessLogic(_rounding);

            //Act
            var receiptText = _businessLogic.Printout(_receiptsInputs.FirstTextCase());
            var totalReceiptTaxes = _businessLogic.TotalReceiptTaxesSummation;
            var productPriceWithTax = _businessLogic.ProductPriceWithTaxSummation;


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
            _businessLogic = new BusinessLogic(_rounding);

            //Act
            var receiptText = _businessLogic.Printout(_receiptsInputs.SecondTextCase());
            var totalReceiptTaxes = _businessLogic.TotalReceiptTaxesSummation;
            var productPriceWithTax = _businessLogic.ProductPriceWithTaxSummation;


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
            _businessLogic = new BusinessLogic(_rounding);

            //Act
            var receiptText = _businessLogic.Printout(_receiptsInputs.ThirdTextCase());
            var totalReceiptTaxes = _businessLogic.TotalReceiptTaxesSummation;
            var productPriceWithTax = _businessLogic.ProductPriceWithTaxSummation;


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
