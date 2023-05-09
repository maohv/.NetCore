namespace CS16___S__d_ng_generic__ph__ng_th_c_generic__l_p_generic
{
    internal class Program
    {
        // static void Swap<T>(ref T x, ref T y)
        // {
        //     T t;
        //     t = x;
        //     x = y;
        //     y = t;
        // }

        class Product<A> //có thể sử dụng kiểu A thay trường dữ liệu
        {
            A ID;

            public void SetID(A _id)
            {
                this.ID = _id;
            }
            public void PrintInf()
            {
                Console.WriteLine($"ID = {this.ID}");
            }
        }
        static void Main(string[] args)
        {
            // int a = 5;
            // int b = 10;

            // Console.WriteLine($"a = {a}, b = {b}");
            // Swap(ref a, ref b);
            // Console.WriteLine($"Sau khi đảo a = {a}, b = {b}");

            Product<int> product1 = new Product<int>();
            product1.SetID(1);
            product1.PrintInf();

            Product<string> product2 = new Product<string>();
            product2.SetID("Kieu du lieu string");
            product2.PrintInf();
        }
    }
}
