using CryptoWebScraper.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWebScraper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebScraperController : Controller
    {
        private readonly string url = "https://coinmarketcap.com/all/views/all/";
        private readonly string currencyUrl = "https://coinmarketcap.com/currencies/";

        [HttpGet("cryptocurrency/{cryptoName}")]
        public IActionResult GetCryptocurrencyPrice(string cryptoName)
        {
            List<CryptoCurrency> cryptocurrencies = new();

            HtmlWeb web = new();
            HtmlDocument htmlDocument = web.Load(url);
            var ranks = htmlDocument.DocumentNode.SelectNodes("//td[contains(@class, 'cmc-table__cell--sort-by__rank')]//div").ToList();
            var names = htmlDocument.DocumentNode.SelectNodes("//a[contains(@class, 'cmc-table__column-name--name cmc-link')]").ToList();
            var symbols = htmlDocument.DocumentNode.SelectNodes("//td[contains(@class, 'cmc-table__cell--sort-by__symbol')]//div").ToList();
            var prices = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'sc-131di3y-0 cLgOOr')]/a[contains(@class, 'cmc-link')]").ToList();
            for (int index = 0; index < names.Count - 1; index++)
            {
                if (cryptoName.ToLower() == names[index].InnerText.ToLower())
                {
                    cryptocurrencies.Add(new CryptoCurrency
                    {
                        Index = index,
                        Rank = int.Parse(ranks[index].InnerText),
                        Symbol = symbols[index].InnerText,
                        CurrencyName = names[index].InnerText,
                        Price = prices[index].InnerText
                    });
                    return Ok(cryptocurrencies);
                }
            }
            return Ok();
        }

        [HttpGet("cryptocurrencies")]
        public IActionResult GetCryptocurrencies()
        {
            List<CryptoCurrency> cryptocurrencies = new();

            HtmlWeb web = new();
            HtmlDocument htmlDocument = web.Load(url);
            var ranks = htmlDocument.DocumentNode.SelectNodes("//td[contains(@class, 'cmc-table__cell--sort-by__rank')]//div").ToList();
            var names = htmlDocument.DocumentNode.SelectNodes("//a[contains(@class, 'cmc-table__column-name--name cmc-link')]").ToList();
            var symbols = htmlDocument.DocumentNode.SelectNodes("//td[contains(@class, 'cmc-table__cell--sort-by__symbol')]//div").ToList();
            var prices = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'sc-131di3y-0 cLgOOr')]/a[contains(@class, 'cmc-link')]").ToList();
            for (int index = 0; index < names.Count - 1; index++)
            {
                cryptocurrencies.Add(new CryptoCurrency {
                    Index = index,
                    Rank = int.Parse(ranks[index].InnerText),
                    Symbol = symbols[index].InnerText,
                    CurrencyName = names[index].InnerText,
                    Price = prices[index].InnerText
                });
            }
            return Ok(cryptocurrencies);
        }

        [HttpGet("cryptocurrencyHistoricalData/{cryptoName}")]
        public IActionResult GetCryptocurrencyHistoricalData(string cryptoName)
        {
            List<CryptoCurrencyHistoricalData> data = new();

            HtmlWeb web = new();
            HtmlDocument htmlDocument = web.Load(currencyUrl + cryptoName + "/historical-data/");
            var body = htmlDocument.DocumentNode.SelectNodes("//body").ToList();

            var div = body[0].ChildNodes[0];
            var div1 = div.ChildNodes[0];
            var div2 = div1.ChildNodes[0];
            var div3 = div2.ChildNodes[1];
            var div4 = div3.ChildNodes[0];
            var div5 = div4.ChildNodes[2];

            //var div6 = div5.ChildNodes[1];
            //var div7 = div6.ChildNodes[0];
            //var div8 = div7.ChildNodes[0];
            //var table = div8.ChildNodes[0];

            return Ok(data);
        }

        [HttpGet("cryptocurrencyInfo/{name}")]
        public IActionResult GetCryptocurrencyInfo(string name)
        {
            List<CryptoCurrencyInfo> cryptocurrency = new();

            HtmlWeb web = new();
            HtmlDocument htmlDocument = web.Load(currencyUrl + name);

            var liveData = htmlDocument.DocumentNode.SelectNodes("//h2[contains(@class, 'sc-1q9q90x-0 jCInrl')]").ToList();
            var allData = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'sc-2qtjgt-0 eApVPN')]//div").ToList();
            var articlesTitle = htmlDocument.DocumentNode.SelectNodes($"//div[contains(@class, 'sc-101ku0o-2 exKUGw')]//p").ToList();
            var articlesList = htmlDocument.DocumentNode.SelectNodes($"//div[contains(@class, 'sc-101ku0o-2 exKUGw')]//ul").ToList();

            string message = "";

            message += liveData[1].InnerText + "\n\n";
            message += liveData[1].NextSibling.InnerText + "\n\n";
            message += liveData[1].NextSibling.NextSibling.InnerText + "\n\n\n";

            foreach (var item in allData[0].ChildNodes)
            {
                message += item.InnerText + "\n\n";
            }
            message += articlesTitle[0].InnerText + "\n";
            foreach (var item in articlesList[0].ChildNodes)
            {
                message += "\t* " + item.InnerText + "\n";
            }

            cryptocurrency.Add(new CryptoCurrencyInfo
            {
                Message = message,
            });
            return Ok(cryptocurrency);
        }
    }
}
