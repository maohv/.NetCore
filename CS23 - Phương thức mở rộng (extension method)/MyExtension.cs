using System;
namespace Mylib
{
    public static class Xyz
    {
        public static double BinhPhuong(this double x) => x * x; //phương thức mở rộng BinhPhuong thêm từ khóa this
        public static double CanBacHai(this double x) => Math.Sqrt(x);

        public static double Sin(this double x) => Math.Sin(x);

        public static double Cos(this double x) => Math.Cos(x);
    }
}