using Microsoft.AspNetCore.Mvc;

namespace CryptoWebScraper.Controllers
{
    public class WebScraperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }


/*

{
    var directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

    HtmlWeb web = new HtmlWeb();
    HtmlDocument doc = web.Load("https://unsplash.com/");

    var HeaderNames = doc.DocumentNode.SelectNodes("//img");

    var titles = new List<Row>();
    var index = 0;
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    foreach (var item in HeaderNames)
    {
        var urlDownload = item.GetAttributes("src").ToList();
        titles.Add(new Row { Title = urlDownload[0].Value });

        if (index > 0)
        {
            HttpClient client = new();
            Stream stream = await client.GetStreamAsync(urlDownload[0].Value);

            if (!urlDownload[0].Value.Contains(".gif"))
            {
                Image img = System.Drawing.Image.FromStream(stream);
                img.Save(directory + $"\\images\\image_{index}.jpg", ImageFormat.Jpeg);
            }
        }
        index++;
    }
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        ts.Hours, ts.Minutes, ts.Seconds,
        ts.Milliseconds / 10);
    Console.WriteLine("RunTime: " + elapsedTime);

    using (var writer = new StreamWriter(Path.Combine(directory, "example.csv")))
    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
    {
        csv.WriteRecords(titles);
    }


    Console.WriteLine("Operation Ended...");
    Console.ReadKey();
}

class Row
{
    public string? Title { get; set; }
}

*/






}
