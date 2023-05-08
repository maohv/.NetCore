internal class Program
{
    private static void Main(string[] args)
    {
        string[] ds = {"Hoa qua", "Com chao"};
        
        int[] number = {1, 2, 3, 4, 5, 6, 7, 8};

        // int sophantu = number.Length;

        // for (int i = sophantu - 1; i >=0 ; i--)
        // {
        //     Console.WriteLine(number[i]);
        // }

        // foreach (var abc in number)
        // {
        //     Console.WriteLine(abc);
        // }

        // Array.Sort(number);
        // foreach (var a in number)
        // {
        //     Console.WriteLine(a);
        // }

        /*
           mảng 2 chiều 

        */
        double[,] numbers =  new double[2,3] {{2,3,4.5},{1,9,8}};

        int hang = 2;
        int cot = 3;

        for (int i = 0; i < hang; i++)
        {
            for (int j = 0; j < cot; j++)
            {
                Console.Write(numbers[i,j]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        

    }
}