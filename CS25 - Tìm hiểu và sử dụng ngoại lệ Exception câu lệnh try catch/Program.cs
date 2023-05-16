using MyExceptions;
internal class Program
{
    static void Register(string name, int age)
    {
        if (string.IsNullOrEmpty(name))
        { //nếu tên bằng null hoặc rỗng sẽ phát sinh ra 1 ngoại lệ
            Exception exception = new Exception("Ten phai khac rong");
            throw exception;
        }
        if (age < 18 || age > 100)
        {
            throw new AgeException(age);
        }
        Console.WriteLine($"Xin chao {name} {age}");
    }
    static void Main(string[] args)
    {
        //int a = 5;
        //int b = 6;
        //try
        //{
        //    var c = a / b;          //phat sinh doi tuong lop Expception, ke thua Expception
        //    Console.WriteLine(c);
        //}
        //catch(Exception e)
        //{
        //    Console.WriteLine("Phep chia co loi");
        //}
        //Console.WriteLine("Co loi");



        // string path = /*"1.txt"*/ null;
        // try
        // {
        //     string s = File.ReadAllText(path);
        //     Console.WriteLine(s);
        // }
        // catch (ArgumentNullException ane)
        // {
        //     Console.WriteLine(ane.Message);
        //     Console.WriteLine("Duong dan file phai khac null");
        // }
        // catch (FileNotFoundException fnfe)
        // {
        //     Console.WriteLine(fnfe.Message);
        //     Console.WriteLine("File k ton tai");
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e.Message);
        // }

        try
        {
            Register("", 20);
        }
        catch (NameEmtyException nee)
        {
            Console.WriteLine(nee.Message);
        }
        catch (AgeException e)
        {
            Console.WriteLine(e.Message);
            e.Detail();
        }

    }
}