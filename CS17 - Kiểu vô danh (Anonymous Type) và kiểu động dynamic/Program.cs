using System.Collections.Generic;
using System;
using System.Linq;
internal class Program
{
    //Anonymous - kieu du lieu vo danh
    //Object - thuoc tinh - chi doc
    //new {thuoctinh = giatri, thuoctinh2 = giatri2}
    //Dynamic - kieu du lieu dong

    class Sinhvien
    {
        public string HoTen { get; set; }

        public int Namsinh { get; set; }

        public string Noisinh { get; set; }

    }
    static void Main(string[] args)
    {
        // var sanpham = new
        // {
        //     Ten = "iphone X",
        //     Gia = 1000,
        //     Namsx = 2018
        // };

        // Console.WriteLine(sanpham.Ten);
        // Console.WriteLine(sanpham.Gia);

        // List<Sinhvien> cacsinhvien = new List<Sinhvien>() {
        //     new Sinhvien() {HoTen = "Nam", Namsinh = 2000, Noisinh = "Binh Duong"},
        //     new Sinhvien() {HoTen = "Hoang", Namsinh = 2002, Noisinh = "Hai Phong"},
        //     new Sinhvien() {HoTen = "Hung", Namsinh = 2003, Noisinh = "Ha Noi"},
        // };

        // var kq = from sv in cacsinhvien
        //          where sv.Namsinh <= 2001
        //          select new
        //          {
        //              Ten = sv.HoTen,
        //              NS = sv.Noisinh
        //          };

        // foreach (var sinhvien in kq)
        // {
        //     Console.WriteLine(sinhvien.Ten + " - " + sinhvien.NS);
        // }

    }
    static void PrintInfo(dynamic obj)
    {
        obj.Name = "Test dyamic";
        obj.Hello();
    }
}