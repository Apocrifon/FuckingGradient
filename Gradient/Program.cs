using System.Net.Http.Headers;

public class Program
{
    public static void Main()
    {
        var test = new Method(-1.4, -1.4, 0.190, 0.150);
        while (test.grad[^1] * 1000 > 0)
            test.MakeIter();
        test.Print();
    }
}


public class Method
{
    readonly double h;
    readonly double a;
    List<double> x1;
    List<double> x2;
    List<double> dx1;
    List<double> dx2;
    public List<double> grad;
    List<double> funk;

    public Method(double x1, double x2, double h, double a) 
    {
        this.x1 = new List<double> { x1 };
        this.x2 = new List<double> { x2 };
        dx1 = new List<double> ();
        dx2 = new List<double>();
        grad = new List<double>();
        funk = new List<double>();
        this.h = h;
        this.a = a;
        CalcDx1();
        CalcDx2();
        CalcGrad();
        Funk();
        CalcFirstIter();
    }

    private void CalcFirstIter()
    {
        x1.Add(x1.Last() - h * dx1.Last());
        x2.Add(x2.Last() - h * dx2.Last());
        CalcDx1();
        CalcDx2();
        CalcGrad();
        Funk();
    }

    private void CalcDx1()
    {
        dx1.Add(Math.Round(4 * x1.Last() + 2 * x2.Last() - 14,3));
    }

    private void CalcDx2()
    {
        dx2.Add(Math.Round(4 * x2.Last() + 2 * x1.Last() - 12, 3));
    }

    private void CalcGrad()
    {
        grad.Add(Math.Round(Math.Sqrt(Math.Pow(dx1.Last(), 2) + Math.Pow(dx2.Last(), 2)), 3));
    }

    private void Funk() 
    {
        funk.Add(Math.Round(2 * x1.Last() * x1.Last() + 2 * x2.Last() * x2.Last() + 2*x1.Last()*x2.Last() - 14 * x1.Last() - 12 * x2.Last() + 29, 3));
    }


    public void MakeIter()
    {
        x1.Add(x1[^1] - a * (x1[^1] - x1[^2]) - h * dx1[^1]);
        x2.Add(x2[^1] - a * (x2[^1] - x2[^2]) - h * dx2[^1]);
        CalcDx1();
        CalcDx2();
        CalcGrad();
        Funk();
    }

    public void Print()
    {
        var iter = 1;
        foreach (var item in grad)
        {
            Console.WriteLine("{0} {1}",iter++, item);
        }
    }



}