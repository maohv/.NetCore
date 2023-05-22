using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text.Encodings.Web;

internal class Program
{
    static void ShowHeaders(HttpResponseHeaders headers)
    {
        Console.WriteLine("Cac header");
        foreach (var header in headers)
        {
            Console.WriteLine($"{header.Key} : {header.Value}");
        }
    }

    public static async Task<string> GetWebContent(string url)
    {
        using var httpClient = new HttpClient();
        try
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

            ShowHeaders(httpResponseMessage.Headers);

            string html = await httpResponseMessage.Content.ReadAsStringAsync();
            return html;
        }
        catch (Exception e)
        {
            Console.WriteLine("Loi");
            return "Loi";
        }



;
    }

    public static async Task DownloadStream(string url, string fileName)
    {
        HttpClient httpClient = new HttpClient();
        try
        {
            var httpResponseMessage = await httpClient.GetAsync(url);

            using var stream = await httpResponseMessage.Content.ReadAsStreamAsync();

            using var streamwrite = File.OpenRead(fileName);

            int SIZEBUFFER = 500;
            var buffer = new byte[SIZEBUFFER];

            ;

            bool endread = false;
            do
            {
                int numBytes = await stream.ReadAsync(buffer, 0, SIZEBUFFER);
                if (numBytes == 0)
                {
                    endread = true;
                }
                else
                {
                    await streamwrite.WriteAsync(buffer, 0, numBytes);
                }
            }
            while (!endread);
        }
        catch (Exception e)
        {

        }
    }
    static async Task Main(string[] args)
    {
        // var url = "https://xuanthulab.net";
        // var uri = new Uri(url);
        // Console.WriteLine(uri.Host);

        // var iphostentry = Dns.GetHostEntry(uri.Host);
        // Console.WriteLine(iphostentry.HostName);
        // iphostentry.AddressList.ToList().ForEach(
        //     ip =>
        //     {
        //         Console.WriteLine(ip);
        //     }
        // );

        // var ping = new Ping();
        // var pingReply = ping.Send("google.com.vn");
        // Console.WriteLine(pingReply.Status);
        // if (pingReply.Status == IPStatus.Success)
        // {
        //     Console.WriteLine(pingReply.RoundtripTime);
        //     Console.WriteLine(pingReply.Address);
        // }

        // Http Request - HttpClient (Get/Post)

        //var url = "https://www.google.com.vn/";
        //var html = await GetWebContent(url);

        //Console.WriteLine(html);

        var url = "https://raw.githubusercontent.com/xuanthulabnet/jekyll-example/master/images/jekyll-01.png";
        
    }
}