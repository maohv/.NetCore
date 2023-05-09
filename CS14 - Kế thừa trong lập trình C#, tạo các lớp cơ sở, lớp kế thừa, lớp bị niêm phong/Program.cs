internal class Program
{
    /*
        tinh ke thua
        A, B
        B ke thua A
        A - lop co so, lop cha
        B - lop ke thua, lop con

        class B : A 
        {
        }
    */
    /*Sealed nghiêm phong k cho phép lớp khác kế thừa*/
    class Animal
    {
        public int Legs { get; set; }
        public float Weight { get; set; }

        public void ShowLegs()
        {
            Console.WriteLine($"Legs: {Legs}");
        }
        public Animal()
        {
            Console.WriteLine("Khoi tao Animal");
        }
    }

    class Cat : Animal
    {
        public string Food { get; set; }

        public Cat()
        {
            this.Legs = 4;
            this.Food = "mouse";
            Console.WriteLine("Khoi tao Cat");
        }

        public void Eat()
        {
            Console.WriteLine(Food);
        }

        //Để biết đây là phương thức khai báo lại mới từ lớp cơ sở, thêm new
        public new void ShowLegs()
        {
            Console.WriteLine($"Loai meo co: {Legs} chan");
        }
        public void ShowInfo()
        {
            //khi gọi ShowLegs nó sẽ gọi lớp mới, tuy nhiên vẫn có thể sử dụng ở lớp cơ sở bằng base
            base.ShowLegs();
            ShowLegs();

        }

    }

    static void Main(string[] args)
    {
        Cat c = new Cat();
        c.ShowLegs();
        c.Eat();
    }
}