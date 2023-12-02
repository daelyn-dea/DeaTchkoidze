//ორობითში გადაყვანა
//მოცემულია მთელი დადებითი რიცხვი ათობითში. დაწერეთ ფუნქცია რომელიც ამ რიცხვს
//გადაიყვანს ორობითში. შეგიძლიათ დაწეროთ როგორც რეკურსიულად, ასევე იტერაციულად.

//მაქსიმალური ქულა - სწორი შედეგი, იტერაციული ამოხსნა, რეკურსიული ამოხსნა.
int num = 5;
Console.WriteLine(Method1(num));
Console.WriteLine(Method2(num));

string Method2(int num)
{
    string binary;
    if (num == 0)
    {
        return "";
    }
    int div = num % 2;
    return Method2(num / 2) + div;
}

string Method1(int num)
{
    string binary = " ";
    if (num == 0)
    {
        return "";
    }
    while (num > 0)
    {
        int div = num % 2;
        binary = div + binary;
        num /= 2;
    }
    return binary;

}
