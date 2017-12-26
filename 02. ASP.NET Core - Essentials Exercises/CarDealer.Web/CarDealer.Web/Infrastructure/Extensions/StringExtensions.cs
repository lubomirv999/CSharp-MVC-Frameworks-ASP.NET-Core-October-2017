namespace CarDealer.Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        private const string NumberFormat = "F2";

        public static string ToPrice(this decimal priceText)
        {
            return $"${priceText.ToString(NumberFormat)}";
        }

        public static string ToPercentage(this double number)
        {
            return $"{number.ToString(NumberFormat)}%";
        }
    }
}
