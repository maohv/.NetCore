using System;
namespace CS10___Lớp_trong_C__và_lập_trình_hướng_đối_tượng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vukhi sungluc = new Vukhi();
            // sungluc.name = "Sung luc";
            // sungluc.ThietlapSatthuong(5);

            // Vukhi sungmay = new Vukhi("Sung may", 15);
            // sungluc.Tancong();
            // sungmay.Tancong();



            // for (int i = 0; i < 100000; i++)
            // {
            //     Student sinhvien = new Student("sinh vien: " + i);
            //     //khi doi tuong nay dc gan = null thi ham huy se chay
            //     sinhvien = null;

            // }

            //Cac cau lenh khoi using thì biến s chỉ hiệu lực trong phạm vi using, ra ngoài là giải phóng, đc thu hồi
            // using (Student s = new Student("Ten sinh vien"))
            // {

            // }
            Conmeo meo = new Conmeo(4, 2);
            Console.WriteLine(meo);

        }
    }

    class Conmeo
    {
        public int sochan { set; get; }
        public int sotai { get; set; }

        public Conmeo(int _sochan, int _sotai)
        {
            _sochan = sochan;
            _sotai = sotai;
        }
        //ditam
    }


}