using System.Net;
using System.Text;
using Newtonsoft.Json;

internal class Program
{
    class MyHttpServer
    {
        private HttpListener listener;

        public MyHttpServer(string[] prifixes)
        {
            if (!HttpListener.IsSupported)
            {
                throw new Exception("HttpListener is not supported");
            }

            listener = new HttpListener();
            foreach (var prefix in prifixes) listener.Prefixes.Add(prefix);

        }
        public async Task Start()
        {
            listener.Start();

            Console.WriteLine("HttpListener started");

            do
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString() + " waiting a cilent connect");
                var context = await listener.GetContextAsync();

                await ProcessRequest(context);

                Console.WriteLine(DateTime.Now.ToLongTimeString() + " cilent connected");

            }
            while (listener.IsListening);
        }

        async Task ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            Console.WriteLine($"{request.HttpMethod} {request.RawUrl} {request.Url.AbsolutePath}");

            var outputStream = response.OutputStream;
            switch (request.Url.AbsolutePath)
            {
                case "/":
                    {
                        var buffer = Encoding.UTF8.GetBytes("Xin chao cac ban");
                        response.ContentLength64 = buffer.Length;
                        await outputStream.WriteAsync(buffer, 0, buffer.Length);

                    }
                    break;
                case "/json":
                    {
                        response.Headers.Add("Content-Type", "application/json");
                        var product = new
                        {
                            Name = "Macbook",
                            Price = 2000
                        };

                        var json = JsonConvert.SerializeObject(product);
                        var buffer = Encoding.UTF8.GetBytes(json);
                        response.ContentLength64 = buffer.Length;
                        await outputStream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    break;
                default:
                    {
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        var buffer = Encoding.UTF8.GetBytes("NOT FOUND");
                        response.ContentLength64 = buffer.Length;
                        await outputStream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    break;
            }

            outputStream.Close();
        }
    }


    static async Task Main(string[] args)
    {
        //kiem tra ho tro hay k
        // if (HttpListener.IsSupported)
        // {
        //     Console.WriteLine("Support HttpListener");
        // }
        // else
        // {
        //     Console.WriteLine("Not Support HttpListener");
        // }

        // var server = new HttpListener();

        // server.Prefixes.Add("http://localhost:8080/");
        // server.Start();
        // Console.WriteLine("Sever HTTP Start");

        // do
        // {
        //     var context = await server.GetContextAsync();
        //     Console.WriteLine("Client connected");
        //     var response = context.Response;
        //     var outputStream = response.OutputStream;

        //     response.Headers.Add("content-type", "text/html");

        //     var html = "<h1>Hello World!</h1>";
        //     var bytes = Encoding.UTF8.GetBytes(html);
        //     await outputStream.WriteAsync(bytes, 0, bytes.Length);
        //     outputStream.Close();
        // }
        // while (server.IsListening);

        var server = new MyHttpServer(new string[] { "http://localhost:8080/" });
        await server.Start();
    }
}