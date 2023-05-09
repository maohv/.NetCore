using static System.Console;
using MynameSpace;
using Sanpham;
namespace CS15___Namespace_v__partial_trong_t__ch_c_code_l_p_tr_nh_C_
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            product.name = "Ipad";
            product.price = 20000;
            product.description = "Day la ipad cua toi";
            WriteLine(product.GetInfo());

        }
    }
}
