using System;
using System.IO;
internal class Program
{
    static void Main(string[] args)
    {
        //DriveInfo
        //Directory - Thu muc
        var drives = DriveInfo.GetDrives(); //;ấy hết tất cả các ổ trong PC
        // DriveInfo drive = new DriveInfo("C");

        // foreach (var drive in drives)
        // {
        //     Console.WriteLine($"Drive: {drive.Name}");
        //     Console.WriteLine($"Drive Type: {drive.DriveType}");
        //     Console.WriteLine($"Lable: {drive.VolumeLabel}");
        //     Console.WriteLine($"Format: {drive.DriveFormat}");
        //     Console.WriteLine($"Drive: {drive.TotalSize}");
        //     Console.WriteLine($"Drive: {drive.TotalFreeSpace}");
        // }

        string path = "C";
        if (Directory.Exists(path)) //kiem tra xem thu muc ton tai hay khong
        {
            Console.WriteLine($"Thu muc {path} ton tai");
        }
        else
        {
            Console.WriteLine($"Thu muc {path} khong ton tai");
        }

    }
}