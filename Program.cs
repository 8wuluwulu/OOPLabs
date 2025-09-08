using System.Xml.Schema;

public abstract class Figure
{
    protected double _area;
    protected double _perimeter;
    public abstract string Name
    {
        get;
    }

    public double Area
    {
        get { return _area; }
        protected set { _area = value; }
    }

    public double Perimeter
    {
        get { return _perimeter; }
        protected set { _perimeter = value; }
    }

    protected abstract void Recalculate();

    public override string ToString()
    {
        return $"{Name}: Периметр фигуры: {Perimeter} Площадь фигуры: {Area}";
    }
}

public class Triangle : Figure
{

    double _a, _b, _c;

    public double A
    {
        get { return _a; }
        set { _a = value; Recalculate(); }
    }
    public double B
    {
        get { return _b; }
        set { _b = value; Recalculate(); }
    }

    public double C
    {
        get { return _c; }
        set { _c = value; Recalculate(); }
    }

    public Triangle(double a, double b, double c)
    {
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            _a = _b = _c = 0;
            Recalculate();
        }
        else
        {
            _a = a;
            _b = b;
            _c = c;
            Recalculate();
        }

    }

    protected override void Recalculate()
    {
        Perimeter = _a + _b + _c;
        double p = Perimeter / 2.0;
        Area = Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
    }

    public override string ToString()
    {
        return $"{Name} (A={A}, B={B}, C={C}): Периметр = {Perimeter}, Площадь = {Area}";
    }

    public override string Name
    {
        get { return "Треугольник"; }
    }
}

public class Circle : Figure
{
    double _radius;
    public double Radius
    {
        get { return _radius; }
        set { _radius = value >= 0 ? value : 0; Recalculate(); }
    }

    public Circle(double r)
    {
        Radius = r;

        Recalculate();
    }

    protected override void Recalculate()
    {
        Perimeter = 2 * Math.PI * Radius;
        Area = Math.PI * Radius * Radius;
    }

    public override string ToString()
    {
        return $"{Name} (R={Radius}): Периметр = {Perimeter}, Площадь = {Area}";
    }

    public override string Name
    {
        get { return "Окружность"; }
    }
}

public class Rectangle : Figure
{
    double _a, _b;

    public double A
    {
        get { return _a; }
        set { _a = value >= 0 ? value : 0; Recalculate(); }
    }

    public double B
    {
        get { return _b; }
        set { _b = value >= 0 ? value : 0; Recalculate(); }
    }

    public Rectangle(double a, double b)
    {
        if (a < 0 || b < 0)
        {
            _a = 0;
            _b = 0;
        }
        else
        {
            _a = a;
            _b = b;
        }

        Recalculate();
    }

    protected override void Recalculate()
    {
        Perimeter = 2 * (A + B);
        Area = A * B;
    }

    public override string ToString()
    {
        return $"{Name} (A={A}, B={B}): Периметр = {Perimeter}, Площадь = {Area}";
    }

    public override string Name
    {
        get { return "Прямоугольник"; }
    }
}

class Program
{
    public static void Main()
    {
        var triangle = new Triangle(5, 6, 10);
        System.Console.WriteLine(triangle);
        Random rnd = new Random();
        Figure[] figures = new Figure[10];

        for (int i = 0; i < figures.Length; i++)
        {
            int choice = rnd.Next(3);

            switch (choice)
            {
                case 0:
                    double a, b, c;
                    a = rnd.Next(1, 20);
                    b = rnd.Next(1, 20);
                    c = rnd.Next(1, 20);
                    figures[i] = new Triangle(a, b, c);
                    break;

                case 1:
                    double r = rnd.Next(1, 15);
                    figures[i] = new Circle(r);
                    break;
                case 2:
                    double x = rnd.Next(1, 20);
                    double y = rnd.Next(1, 20);
                    figures[i] = new Rectangle(x, y);
                    break;
            }
        }

        for (int i = 0; i < figures.Length; i++)
        {
            Console.WriteLine($"{figures[i]}");
        } 
    }
}