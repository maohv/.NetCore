
class CountNumber
{
    public static int number = 0;
    public static void Info()
    {
        Console.WriteLine("So lan truy cap " + number);
    }
    public void Count()
    {
        //number++;
        CountNumber.number++;
    }
}

class Student
{
    public readonly string name; //chỉ đọc ra khi thêm readonly
    public Student(string _name)
    {
        this.name = _name;
    }
}

class Vector
{
    double x;
    double y;
    public Vector(double _x, double _y)
    {
        x = _x;
        y = _y;
    }

    public void Info()
    {
        Console.WriteLine($"x = {x}, y = {y}");
    }

    // vector = Vector + vector
    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.x + v2.x, v1.y + v2.y);
    } //kí hiệu của 1 phép toán operator+
}

internal class Program

{
    static void Main(string[] args)
    {
        // CountNumber.Info();
        // Console.WriteLine(CountNumber.number);

        // CountNumber c1 = new CountNumber();
        // CountNumber c2 = new CountNumber();

        // c1.Count();
        // c2.Count();
        // CountNumber.Info();

        // Student s = new Student("HoangMao");
        // Console.WriteLine(s.name);
        Vector v1 = new Vector(2, 3);
        Vector v2 = new Vector(1, 1);

        // (x1,y1); (x2,y2) : (x1+x2,y1+y2)
        var v3 = v1 + v2;
        v1.Info();
        v2.Info();
        v3.Info();
    }
}