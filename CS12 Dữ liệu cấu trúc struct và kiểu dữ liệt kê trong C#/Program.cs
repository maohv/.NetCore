internal class Program
{
    //struct
    // public struct Product
    // {
    //     //du lieu
    //     public string name;
    //     public double price;
    //     //phuong thuc
    //     public string GetInfo()
    //     {
    //         return $"Ten san pham {name}, gia: {price}";
    //     }
    //     // constructor 
    //     public Product(string _name, double _price)
    //     {
    //         name = _name;
    //         price = _price;
    //     }
    // }

    //kieu liet ke enum
    /*
    0 - kem
    1 - trung binh
    2 - kha
    3 - gioi 
    */
    enum HOCLUC
    {
        Kem, //0
        TrungBinh, //1
        Kha, //2
        Gioi, //3
    }


    static void Main(string[] args)
    {
        //     Product sanpham1;
        //     sanpham1.name = "Iphone";
        //     sanpham1.price = 1000;
        //     Console.WriteLine(sanpham1.GetInfo());

        HOCLUC hocluc;
        hocluc = HOCLUC.Kha;

        switch (hocluc)
        {
            case HOCLUC.Kem:
                Console.WriteLine("Hoc luc kem");
                break;
            case HOCLUC.TrungBinh:
                Console.WriteLine("Hoc luc trung binh");
                break;
            case HOCLUC.Kha:
                Console.WriteLine("Hoc luc kha");
                break;
            case HOCLUC.Gioi:
                Console.WriteLine("Hoc luc gioi");
                break;
        }
    }
}