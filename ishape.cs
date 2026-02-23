using System;
interface IShape
{
    double Shapearea { get; }
    void DisplayShapeInfo();
}

interface ICircle : IShape
{
    double Circleradius { get; set; }
}

interface IRectangle : IShape
{
    double Rectlength { get; set; }
    double Rectwidth { get; set; }
}

class Circle : ICircle
{
    public double Circleradius { get; set; }

    public double Shapearea
    {
        get { return Math.PI * Circleradius * Circleradius; }
    }

    public void DisplayShapeInfo()
    {
        Console.WriteLine("Circle:");
        Console.WriteLine("Radius= " + Circleradius);
        Console.WriteLine("Area= " + Shapearea);
    }
}

class Rectangle : IRectangle
{
    public double Rectlength { get; set; }
    public double Rectwidth { get; set; }

    public double Shapearea
    {
        get { return Rectlength * Rectwidth; }
    }

    public void DisplayShapeInfo()
    {
        Console.WriteLine("Rectangle:");
        Console.WriteLine("Length= " + Rectlength);
        Console.WriteLine("Width= " + Rectwidth);
        Console.WriteLine("Area= " + Shapearea);
    }
}
class Program
{
    static void Main()
    {
        Circle c = new Circle();
        c.Circleradius = 7;
        c.DisplayShapeInfo();
        Console.WriteLine();
        Rectangle r = new Rectangle();
        r.Rectlength = 9;
        r.Rectwidth = 5;
        r.DisplayShapeInfo();
    }
}