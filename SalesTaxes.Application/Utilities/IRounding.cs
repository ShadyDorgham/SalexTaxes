namespace SalesTaxes.Application.Utilities
{
    public interface IRounding
    {
        decimal RoundUp(decimal amount);
        decimal TruncateDecimal(decimal value);
    }
}