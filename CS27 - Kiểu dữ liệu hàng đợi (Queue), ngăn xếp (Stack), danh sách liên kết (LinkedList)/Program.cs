using System.Collections.Generic;
internal class Program
{

    static void Main(string[] args)
    { //Queue vao truoc ra trước
      // Queue<string> cachoso = new Queue<string>();
      // cachoso.Enqueue("Ho so 1");
      // cachoso.Enqueue("Ho so 2");
      // cachoso.Enqueue("Ho so 3");

        // foreach (var hs in cachoso)
        // {
        //     Console.WriteLine(hs);
        // }
        // var hoso = cachoso.Dequeue();
        // Console.WriteLine($"Xu ly ho so: {hoso} - Con lai: {cachoso.Count}");

        //stack vao sau ra trước.
        // Stack<string> hoanghoa = new Stack<string>();
        // hoanghoa.Push("mat hang 1");
        // hoanghoa.Push("mat hang 2");
        // hoanghoa.Push("mat hang 3");

        // //xoa phan tu stack
        // var mathang = hoanghoa.Pop();
        // Console.WriteLine($"Boc do: {mathang}");

        //LinkedList

        // LinkedList<string> cacbaihoc = new LinkedList<string>();

        // var bh1 = cacbaihoc.AddFirst("Bai hoc 1"); //thêm vào đầu tiên của danh sách
        // var bh3 = cacbaihoc.AddLast("Bai hoc 3"); //thêm vào cuối danh sách
        // var bh2 = cacbaihoc.AddAfter(bh1, "Bai hoc 2"); //add vào sau bh1
        // cacbaihoc.AddLast("Bai hoc 4");

        // foreach (var item in cacbaihoc)
        // {
        //     Console.WriteLine(item);
        // }

        // var node = bh2;
        // Console.WriteLine(node.Value);

        // node = node.Next;
        // Console.WriteLine(node.Value);

        // node = node.Previous;
        // Console.WriteLine(node.Value);

        // var node = cacbaihoc.Last;
        // while (node != null)
        // {
        //     Console.WriteLine(node.Value);
        //     node = node.Previous;
        // }

        //Dictionary

        // Dictionary<string, int> sodem = new Dictionary<string, int>()
        // {
        //     ["one"] = 1,
        //     ["tow"] = 2,
        // };
        // //Thêm hoặc cập nhật
        // sodem["three"] = 3;

        // var keys = sodem.Keys;
        // foreach (var k in keys)
        // {
        //     var value = sodem[k];
        //     Console.WriteLine($"{k} = {value}");
        // }

        //HashSet

        HashSet<int> set1 = new HashSet<int>() { 1, 2, 3, 4, 5, 6 };
        HashSet<int> set2 = new HashSet<int>() { 7, 8, 9, 4, 5, 6 };

        set1.UnionWith(set2); // hợp set2 lại set1 nhưng k trùng giá trị
    }
}