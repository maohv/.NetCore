using System;

namespace CS10___Lớp_trong_C__và_lập_trình_hướng_đối_tượng
{

    /*<Access Modifiers> class Class_Name {
        // khai báo các thành viên dữ  liệu (thuộc tính, biến trường dữ liệu)
         // khai báo các thành viên  hàm (phương thức)
    }*/
    class Vukhi
    {
        //Truong Du Lieu
        public string name = "Ten vu khi";
        int dosatthuong = 0;

        //Thuoc tinh
        public int Satthuong
        {
            // dc thi hanh khi thuc hien phep gan
            set
            {
                dosatthuong = value;
            }
            // dc thi hanh khi truy cap, phai tra ve gia tri cung kieu voi thuoc tinh
            get
            {
                return dosatthuong;
            }
        }
        // thuoc tinh Satthuong o tren tuong duong voi Noisanxuat, cach ghi nhanh la { get; set; }
        public string Noisanxuat { get; set; }


        //Phuong thuc khoi tao
        public Vukhi()
        {
            dosatthuong = 1;
        }

        public Vukhi(string name, int _dosatthuong)
        {
            dosatthuong = _dosatthuong;
            this.name = name;
        }

        //Phuong thuc
        public void ThietlapSatthuong(int dosatthuong)
        {
            this.dosatthuong = dosatthuong;

            //this là tham chiếu trỏ tới đối tượng lớp hiện tại
        }

        public void Tancong()
        {
            Console.Write(name + "\t");
            for (int i = 0; i < dosatthuong; i++)
            {
                Console.Write(" * ");
            }
            Console.WriteLine();
        }
    }
}