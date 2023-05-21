
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Решает квадратные уравнения 2 переменных вида\n  " +
            "{0}a{1} * (x1)^2  + {0}b{1} * (x2)^2 + {0}c{1} * x1 * x2 + {0}d{1} * x1 * {0}e{1} * x2 + {0}f{1}", "\u001b[31m", "\u001b[0m");
        Console.WriteLine("Введите коэффициенты");
        var test = new Method(-1.4, -1.4);
        while (test.grad[^1] * 1000 > 0)
            test.MakeIter();
        test.Print();
    }
}


public class Method
{
    readonly double a;
    readonly double b;
    readonly double c;
    readonly double d;
    readonly double e;
    readonly double f;
    List<double> x1;
    List<double> x2;
    List<double> dx1;
    List<double> dx2;
    List<double> h;
    public List<double> grad;
    List<double> funk;

    public Method(double x1, double x2) 
    {
        a = int.Parse(Console.ReadLine());
        b = int.Parse(Console.ReadLine());
        c = int.Parse(Console.ReadLine());
        d = int.Parse(Console.ReadLine());
        e = int.Parse(Console.ReadLine());
        f = int.Parse(Console.ReadLine());
        this.x1 = new List<double> { x1 };
        this.x2 = new List<double> { x2 };
        dx1 = new List<double> ();
        dx2 = new List<double>();
        grad = new List<double>();
        funk = new List<double>();
        this.h = new List<double> { 0.5, 0.15 };
        CalcDx1();
        CalcDx2();
        CalcGrad();
        Funk();
        CalcFirstIter();
    }

    public void CalcFirstIter()
    {
        x1.Add(x1.Last() - h[0] * dx1.Last());
        x2.Add(x2.Last() - h[0] * dx2.Last());
        CalcDx1();
        CalcDx2();
        CalcGrad();
        Funk();
    }

    private void CalcDx1()
    {
        dx1.Add(Math.Round(a * 2 * x1.Last() + c * x2.Last() - d, 3));
    }

    private void CalcDx2()
    {
        dx2.Add(Math.Round(b * 2 * x2.Last() + c * x1.Last() - e, 3));
    }

    private void CalcGrad()
    {
        grad.Add(Math.Round(Math.Sqrt(Math.Pow(dx1.Last(), 2) + Math.Pow(dx2.Last(), 2)), 3));
    }

    private void Funk() 
    {
        funk.Add(Math.Round(a * x1.Last() * x1.Last() + b * x2.Last() * x2.Last() + c * x1.Last() * x2.Last() - d * x1.Last() - e * x2.Last() + f, 3));
    }


    public void MakeIter()
    {
        x1.Add(x1.Last() - h[1] * dx1.Last());
        x2.Add(x2.Last() - h[1] * dx2.Last());
        CalcDx1();
        CalcDx2();
        CalcGrad();
        Funk();
    }

    public void Print()
    {
        var iter = 0;
        for (int i = 0; i < x1.Count; i++)
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}", iter, Math.Round(x1[i],3), Math.Round(x2[i],3), Math.Round(grad[i],3));
            iter++;
        }
    }



}