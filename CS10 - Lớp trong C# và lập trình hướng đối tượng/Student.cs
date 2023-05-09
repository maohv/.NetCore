using System;
namespace CS10___Lớp_trong_C__và_lập_trình_hướng_đối_tượng
{
    class Student : IDisposable
    {
        public string name;

        //ham khoi tao
        public Student(string name)
        {
            this.name = name;
            Console.WriteLine("Khoi tao " + name);
        }

        //ham huy
        ~Student()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Huy " + name);
            Console.ResetColor();
        }

        public void Dispose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Huy boi (Dispose) " + name);
            Console.ResetColor();
        }
    }
}