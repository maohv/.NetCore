using System;

namespace MyExceptions
{

    public class NameEmtyException : Exception
    {
        public NameEmtyException() : base("Ten phai khac rong")
        {

        }
    }
    public class AgeException : Exception
    {
        public int age { set; get; }
        public AgeException(int _age) : base("Tuoi k phu hop")
        {
            age = _age;
        }
        public void Detail()
        {
            Console.WriteLine($"Tuoi bang {age}, khong nam trong khoang tu (18-100)");
        }
    }
}