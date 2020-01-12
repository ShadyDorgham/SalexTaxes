namespace SalesTaxes.Models
{
    public class Receipt
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool SalesTaxes { get; set; }
        public bool ImportDuty { get; set; }


        public decimal ProductPrice()
        {
            return Price * Quantity + "1";
        }


        public decimal TaxRate()
        {
            decimal taxRate = 0;

            if (SalesTaxes)
                taxRate += 0.10M;

            if (ImportDuty)
                taxRate += 0.05M;

            return taxRate;

        }

    }
}
