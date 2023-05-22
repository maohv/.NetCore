using System.ComponentModel.DataAnnotations;

internal class Program
{
    //Type -> class, struct, ... int, bool...
    //Attribute
    //Reflection: thong tin kieu du lieu, thoi diem thuc thi
    //AttributeName
    //ObsoleteAttribute

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)] //Mo ta dc su dung o dau(lop, thuoc tinh, method)
    class MotaAttribute : Attribute
    {
        public string Thongtinchitiet { get; set; }
        public MotaAttribute(string _Thongtinchitiet)
        {
            Thongtinchitiet = _Thongtinchitiet;
        }

    }


    class User
    {
        [Required(ErrorMessage = "Name khong duoc de trong")] //bat buoc phai nhap
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ten phai dai tu 3 den 50 ki tu")]
        public string Name { get; set; }

        [Range(18, 80, ErrorMessage = "tuoi phai tu 18 - 80")]
        public int Age { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Dia chi Email sai")]
        public string Email { get; set; }

    }
    static void Main(string[] args)
    {
        // int a;
        // var t = a.GetType();
        // Type t1 = typeof(int);
        // var t2 = typeof(string);

        User user = new User() { Name = "Hoang Mao", Age = 20, PhoneNumber = "091123123", Email = "Oknhe123@gmail.com", };

        ValidationContext context = new ValidationContext(user);
        var result = new List<ValidationResult>();
        bool kq = Validator.TryValidateObject(user, context, result, true);

        if (kq == false)
        {
            result.ToList().ForEach((er) =>
            {
                Console.WriteLine(er.ErrorMessage);
            });
        }
    }
}