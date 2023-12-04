using _Cat;

Console.WriteLine("Creating cat object");
Cat cat1 = new Cat();
Console.Write("Enter Name: ");
cat1.Name = Console.ReadLine();
Console.Write("Enter Breed : ");
cat1.Breed = Console.ReadLine();
Console.Write("Enter Age : ");
cat1.Age = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter Sex : ");
cat1.Sex = Console.ReadLine();
Console.WriteLine("Cat object created");
Console.Write("Enter food weight in grams: ");
int grams = Convert.ToInt32(Console.ReadLine());
cat1.Eating(grams);
Console.Write("Enter Meowing count: ");
int meowingcount = Convert.ToInt32(Console.ReadLine());
cat1.Meowing(meowingcount);