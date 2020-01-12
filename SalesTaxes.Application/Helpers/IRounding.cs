namespace SalesTaxes.Application.Helpers
{
    public interface IRounding
    {
        decimal RoundUp(decimal amount);
        decimal TruncateDecimal(decimal value);
    }
}