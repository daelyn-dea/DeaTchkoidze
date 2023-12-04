using _Triangle;

Triangle triangle = new Triangle();
Console.Write("Enter Side 1: ");
triangle.Side1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter Side 2: ");
triangle.Side2 = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter Side 3: ");
triangle.Side3 = Convert.ToInt32(Console.ReadLine());
if (triangle.ValidateTriangle())
{
    Console.WriteLine($"Perimeter of the triangle is: {triangle.CalculatePerimeter()}");
    Console.WriteLine($"Area of the triangle is: {triangle.CalculateArea()}");
}
else
{
    Console.WriteLine("It isn't valid Triangle");
}
Console.Read();