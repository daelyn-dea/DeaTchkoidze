using Clock;

_Clock clock = new _Clock();
Console.Write("Enter hour: ");
clock._Hour = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter minute: ");
clock._Minute = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter second: ");
clock._Second = Convert.ToInt32(Console.ReadLine());

Console.Write("How many seconds do you want to add?: ");
int addsec =  Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < addsec; i++)
{
    clock.AddSecond();
}
Console.WriteLine("{0} seconds add and now is {1}", addsec, clock.GetCurrentTime());

Console.Write("How many minutes do you want to add?: ");
int addmin = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < addmin; i++)
{
    clock.AddMinute();
}
Console.WriteLine("{0} minutes add and now is {1}", addmin, clock.GetCurrentTime());

Console.Write("How many hours do you want to add?: ");
int addhours = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < addhours; i++)
{
    clock.AddHour();
}
Console.WriteLine("{0} hours reduce and now is {1}", addhours, clock.GetCurrentTime());

Console.Write("How many seconds do you want to reduce?: ");
int reduce = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < reduce; i++)
{
    clock.DecsSecond();
}
Console.WriteLine("{0} seconds subtract and now is {1}", addsec, clock.GetCurrentTime());

Console.Write("How many minutes do you want to reduce?: ");
reduce = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < reduce; i++)
{
    clock.DecsMinute();
}
Console.WriteLine("{0} minutes subtract and now is {1}", addmin, clock.GetCurrentTime());

Console.Write("How many hours do you want to reduce?: ");
reduce = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < reduce; i++)
{
    clock.DecsHour();
}
Console.WriteLine("{0} hours subtract and now is {1}", addhours, clock.GetCurrentTime());