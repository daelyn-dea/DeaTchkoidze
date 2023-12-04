using _Triangle;

Triangle triangle = new Triangle();

Console.Write("Enter Side 1: ");
triangle.Side1 = Convert.ToDouble(Console.ReadLine());
Console.Write("Enter Side 2: ");
triangle.Side2 = Convert.ToDouble(Console.ReadLine());
Console.Write("Enter Side 3: ");
triangle.Side3 = Convert.ToDouble(Console.ReadLine());

triangle.CalculatePerimeter();
triangle.CalculateArea();

Console.Read();