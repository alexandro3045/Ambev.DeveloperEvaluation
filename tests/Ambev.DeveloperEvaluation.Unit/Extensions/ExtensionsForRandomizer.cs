using Bogus;


namespace Ambev.DeveloperEvaluation.Unit.Extensions
{
    public static class ExtensionsForRandomizer
    {
        public static decimal Decimal(this Randomizer r, decimal min = 0.0m, decimal max = 1.0m, int? decimals = null)
        {
            var value = r.Decimal(min, max);
            if (decimals.HasValue)
            {
                return Math.Round(value, decimals.Value);
            }
            return value;
        }
    }
}
