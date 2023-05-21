
public class Program
{
    public static void Main()
    {
        var test = new Method(-1.4, -1.4);
        while (test.grad[^1] * 1000 > 0)
            test.MakeIter();
        test.Print();
    }
}


public class Method
{
    List<double> x1;
    List<double> x2;
    List<double> dx1;
    List<double> dx2;
    List<double> h;
    public List<double> grad;
    List<double> funk;

    public Method(double x1, double x2) 
    {
        this.x1 = new List<double> { x1 };
        this.x2 = new List<double> { x2 };
        dx1 = new List<double> ();
        dx2 = new List<double>();
        grad = new List<double>();
        funk = new List<double>();
        this.h = new List<double> { 0.5, 0.167 };
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
        dx1.Add(Math.Round(4 * x1.Last() + 2 * x2.Last() - 14,3));
    }

    private void CalcDx2()
    {
        dx2.Add(Math.Round(4 * x2.Last() + 2 * x1.Last() - 12, 3));
    }

    private void CalcGrad()
    {
        grad.Add(Math.Sqrt(Math.Pow(dx1.Last(), 2) + Math.Pow(dx2.Last(), 2)));
    }

    private void Funk() 
    {
        funk.Add(2 * x1.Last() * x1.Last() + 2 * x2.Last() * x2.Last() + 2*x1.Last()*x2.Last() - 14 * x1.Last() - 12 * x2.Last() + 29);
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