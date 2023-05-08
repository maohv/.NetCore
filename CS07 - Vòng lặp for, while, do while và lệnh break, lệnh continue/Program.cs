internal class Program
{
    private static void Main(string[] args)
    {
        /*
        for (khởi_tạo; điều_kiện; cập nhật)
        {
            //Các câu lệnh trong khối
        }
        */
        
        for (int i = 1; i <= 10; i++)
        {
            if(i % 2 == 0) continue;

            Console.WriteLine($"i = {i}");

            Console.WriteLine($"3 x {i} = {3 * i}");
        }


        // int i = 1;
        // while(i <= 10)
        // {
        //     Console.WriteLine($"3 x {i} = {3 * i}");
        //     i++;
        //     if (i == 10)
        //        break;
        // }

        // do
        // {
        //     Console.WriteLine($"3 x {i} = {3 * i}");
        //       i++;
        // }
        // while(i <= 10);


    }
}