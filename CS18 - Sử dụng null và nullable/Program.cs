internal class Program
{
    class Abc{
        public void Xinchao() => Console.WriteLine("Xin chao C#");
    }
    static void Main(string[] args)
    {
        // null, nullable
        Abc a = null;
        //Nếu a bằng null mà ta cố gắng truy cập sẽ dẫn tới lỗi

        // if(a != null){
        //     a.Xinchao();
        // }
        a?.Xinchao();

        //Biến này có thể nhận giá trị
        int? age;
        age = null;

        //kiểm tra 1 biến nullable có giá trị hay k dùng Hasvalue hoặc != null
        if(age.HasValue){
            int _age = age.Value;
            Console.WriteLine(_age);
        }
    }
}