// See https://aka.ms/new-console-template for more information
int a = 5;
int b = 7;
Console.WriteLine($"a={a}  b={b}");
int c = a;
a = b;
b = c;
Console.WriteLine($"a={a}  b={b}");

 a = 5;
 b = 7;
Console.WriteLine($"a={a}  b={b}");
a = b - a;
b = b - a;
a = b + a;
Console.WriteLine($"a={a}  b={b}");


