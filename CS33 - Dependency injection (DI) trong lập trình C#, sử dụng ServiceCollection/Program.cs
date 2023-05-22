using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

interface IClassB
{
    public void ActionB();
}

interface IClassC
{
    public void ActionC();
}

class ClassC : IClassC
{
    public void ActionC() => Console.WriteLine("Action in ClassC");
}

class ClassB : IClassB
{
    // Phụ thuộc của ClassB là ClassC
    IClassC c_dependency;

    public ClassB(IClassC classc) => c_dependency = classc;
    public void ActionB()
    {
        Console.WriteLine("Action in ClassB");
        c_dependency.ActionC();
    }
}

class ClassA
{
    // Phụ thuộc của ClassA là ClassB
    IClassB b_dependency;

    public ClassA(IClassB classb) => b_dependency = classb;
    public void ActionA()
    {
        Console.WriteLine("Action in ClassA");
        b_dependency.ActionB();
    }
}
class ClassC1 : IClassC
{
    public ClassC1() => Console.WriteLine("ClassC1 is created");
    public void ActionC()
    {
        Console.WriteLine("Action in C1");
    }
}

class ClassB1 : IClassB
{
    IClassC c_dependency;
    public ClassB1(IClassC classc)
    {
        c_dependency = classc;
        Console.WriteLine("ClassB1 is created");
    }
    public void ActionB()
    {
        Console.WriteLine("Action in B1");
        c_dependency.ActionC();
    }
}

class Horn
{
    int level = 0;
    public Horn(int level) => this.level = level;
    public void Beep() => Console.WriteLine("Beep - Beep - Beep...");
}
class Car
{
    public Horn horn { set; get; }

    // Inject bằng phương thức khởi tạo
    public Car(Horn _horn) => horn = _horn;
    public void Beep()
    {
        horn.Beep();
    }
}

class ClassB2 : IClassB
{
    IClassC c_dependency;
    string message;
    public ClassB2(IClassC classc, string mgs)
    {
        c_dependency = classc;
        message = mgs;
        Console.WriteLine("ClassB2 is created");
    }
    public void ActionB()
    {
        Console.WriteLine(message);
        c_dependency.ActionC();
    }
}
class Program
{   //Dependency - injection
    //Dependency - phu thuoc

    public static IClassB CreateB2(IServiceProvider provider)
    {

        var b2 = new ClassB2(
            provider.GetService<IClassC>(), "Thực hiện trong ClassB2"
        );
        return b2;
    }
    public class MyServiceOptions
    {
        public string data1 { get; set; }
        public int data2 { get; set; }
    }
    public class MyService
    {
        public string data1 { get; set; }
        public int data2 { get; set; }
        public MyService(IOptions<MyServiceOptions> options)
        {
            var _options = options.Value;
            data1 = _options.data1;
            data2 = _options.data2;
        }
        public void PrintData() => Console.WriteLine($"{data1} / {data2}");
    }
    static void Main(string[] args)
    {

        //Thu vien Dependency Injection
        // DI Container : ServiceCollection 
        // - Dang ky cac dich vu (lop)
        // - ServiceProvider -> Get Serrvice |

        var services = new ServiceCollection();

        //Dang ki cac dich vu
        //IClassC, ClassC, ClassC1

        //Singleton
        // services.AddSingleton<IClassC, ClassC>();
        //Transient
        // services.AddTransient<IClassC, ClassC>();
        //AddScoped
        //services.AddScoped<IClassC, ClassC1>();

        // ClassA
        // IClassC, ClassC, ClassC1
        // IClassB, ClassB, ClassB1, ClassB2

        // services.AddSingleton<ClassA, ClassA>();
        // services.AddSingleton<IClassB>(CreateB2);
        // services.AddSingleton<IClassC, ClassC1>();
        // services.AddSingleton<string, string>();

        services.Configure<MyServiceOptions>(
            (MyServiceOptions options) =>
            {
                options.data1 = "Xin chao cac ban";
                options.data2 = 2023;
            }
        );
        services.AddSingleton<MyService>();

        var provider = services.BuildServiceProvider();
        var myservice = provider.GetService<MyService>();
        myservice.PrintData();







    }
}