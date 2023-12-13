using Practice_01;

Shape[] shapes = new Shape[3] { createdTriangle(), createSquare(), createdCircle() };

for(int i = 0; i < shapes.Length; i++)
{
    Console.WriteLine("");
    Console.WriteLine("---------------------------------------");
    Console.WriteLine("");
    shapes[i].Perimeter();
    shapes[i].Area();
}


Shape createdCircle()
{
    Console.WriteLine("");
    Console.WriteLine("Draw Circle");
    Console.WriteLine("---------------------------------------");

    Console.Write("Enter the point x of center  a of circle :");
    int aSidex = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the point y of center  a of circle :");
    int aSidey = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter the point x of circle point :");
    int bSidex = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the point y of circle point :");
    int bSidey = Convert.ToInt32(Console.ReadLine());

    Circle circle = new Circle(new Point(aSidex, aSidey), new Point(bSidex, bSidey));
    return circle;
}

Shape createSquare()
{
    Console.WriteLine("");
    Console.WriteLine("Draw Square");
    Console.WriteLine("---------------------------------------");

    Console.Write("Enter the point x of side  a of square :");
    int aSidex = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the point y of side  a of square :");
    int aSidey = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter the point x of side  b of square :");
    int bSidex = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the point y of side  b of square :");
    int bSidey = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter the point x of side  c of square :");
    int cSidex = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the point y of side  c of square :");
int cSidey = Convert.ToInt32(Console.ReadLine());


    Console.Write("Enter the point x of side  d of square :");
    int dSidex = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the point y of side  d of square :");
    int dSidey = Convert.ToInt32(Console.ReadLine());

    Square square = new Square(new Point(aSidex, aSidey), new Point(bSidex, bSidey), new Point(cSidex, cSidey), new Point(dSidex, dSidey));
    return square;

}

Triangle createdTriangle()
{
    Console.WriteLine("");
    Console.WriteLine("Draw Triangle");
    Console.WriteLine("---------------------------------------");

    Console.Write("Enter the point x of side  a of triangle :");
    int aSidex = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the point y of side  a of triangle :");
    int aSidey = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter the point x of side  b of triangle :");
    int bSidex = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the point y of side  b of triangle :");
    int bSidey = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter the point x of side  c of triangle :");
    int cSidex = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the point y of side  c of triangle :");
    
    int cSidey = Convert.ToInt32(Console.ReadLine());

    Triangle triangle = new Triangle(new Point(aSidex, aSidey), new Point(bSidex, bSidey), new Point(cSidex, cSidey));
    return triangle;
}