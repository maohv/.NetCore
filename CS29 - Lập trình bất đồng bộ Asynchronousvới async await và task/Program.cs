namespace CS29___L_p_tr_nh_b_t___ng_b__Asynchronousv_i_async_await_v__task
{
    internal class Program
    {
        static void DoSomething(int seconds, string msg, ConsoleColor color)
        {

            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{msg} ...Start");
                Console.ResetColor();
            }

            for (var i = 0; i < seconds; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{msg} - {i}");
                    Console.ResetColor();
                }
                Thread.Sleep(1000);

            }
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{msg} ...End");
                Console.ResetColor();
            }

        }

        static async Task Task2()
        {
            Task t2 = new Task(
            () =>
            {
                DoSomething(5, "T2", ConsoleColor.Red);
            }
        );
            t2.Start(); //Thread
            await t2; //Thêm async sẽ phải có await (await ở đây tương đương với t2.Wait())
            //t2.Wait(); //Đảm bảo tác vụ hoàn thành

            Console.WriteLine("T2 da hoan thanh");
        }

        static async Task Task3()
        {
            Task t3 = new Task(
                         (object ob) =>
                         {
                             string tentacvu = (string)ob;
                             DoSomething(5, tentacvu, ConsoleColor.Green);
                         }
                     , "T3");

            //Chạy trên Thread khác nhau
            t3.Start();
            await t3;
            Console.WriteLine("T3 da hoan thanh");

        }

        static async Task<string> Task4()
        {
            Task<string> t4 = new Task<string>(
               () =>
               {
                   DoSomething(10, "T4", ConsoleColor.Green);
                   return "Return from T4";
               }); //tương ứng với delagate () => {return string}
            t4.Start();
            var kq = await t4;
            Console.WriteLine("T4 da hoan thanh");
            return kq;
        }

        static async Task<string> Task5()
        {

            Task<string> t5 = new Task<string>(
                (object ob) =>
                {
                    string t = (string)ob;
                    DoSomething(4, t, ConsoleColor.Yellow);
                    return "Return from T5";
                }, "T5");
            t5.Start();
            var kq = await t5;
            Console.WriteLine("T5 da hoan thanh");
            return kq;

        }

        static async Task<string> Getweb(string url)
        {
            HttpClient httpClient = new HttpClient();
            Console.WriteLine("Bat dau tai");
            HttpResponseMessage kq = await httpClient.GetAsync(url);
            Console.WriteLine("Bat dau doc noi dung");
            string content = await kq.Content.ReadAsStringAsync();
            Console.WriteLine("Hoan thanh");
            return content;
        }
        //asynchronous (multi thread)
        //asyn/await
        static async Task Main(string[] args)
        {
            //synchronous
            //Task
            //Task<T>

            var task = Getweb("https://xuanthulab.net/");
            DoSomething(6, "T1", ConsoleColor.Blue);
            
            var content = await task;

            Console.WriteLine(content);


            // Task<string> t4 = Task4();
            // Task<string> t5 = Task5();



            // Task t2 = Task2();
            // Task t3 = Task3();
            // Task.WaitAll(t2, t3); //Đảm bảo các tác vụ được hoàn thành mới thực hiện đc các tác phụ tiếp theo

            // await t2;
            // await t3;

            //Task.WaitAll(t4, t5);


            Console.WriteLine("bam phim bat ky de ket thuc");
            Console.ReadKey();

        }
    }

}

