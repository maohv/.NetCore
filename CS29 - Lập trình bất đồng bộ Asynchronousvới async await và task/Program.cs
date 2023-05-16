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

        //asynchronous (multi thread)
        //asyn/await
        static void Main(string[] args)
        {
            // //synchronous
            // //Task
            Task t2 = Task2();
            Task t3 = Task3();
            Task.WaitAll(t2, t3); //Đảm bảo các tác vụ được hoàn thành mới thực hiện đc các tác phụ tiếp theo

            DoSomething(6, "T1", ConsoleColor.Blue);

            Console.WriteLine("bam phim bat ky de ket thuc");
            Console.ReadKey();

        }
    }

}

