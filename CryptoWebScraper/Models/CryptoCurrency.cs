namespace CryptoWebScraper.Models
{
    public class CryptoCurrency
    {
        public int Index { get; set; }
        public int Rank { get; set; }
        public string? Symbol { get; set; }
        public string? CurrencyName { get; set; }
        public string? Price { get; set; }
    }
}
