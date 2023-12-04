//მოცემულია მთელი რიცხვების N ელემენტიანია მასივი. მისი მაქსიმალური ელემენტია N+1, რაც იმას
//ნიშნავს, რომ რომელიღაც ელემენტი გაუჩინარდა. დაწერეთ ფუნქცია, რომელიც იპოვნის
//გაუჩინარებულ ელემენტს.
//მაქსიმალური ქულა - სწორი შედეგი, 1 ციკლი, პარამეტრად მიღებული მასივის გამოყენება მხოლოდ.

int[] array = { 3, 5, 4, 6, 2 };
int n = 5;
Console.WriteLine(Method1(array));
Console.Read();

int Method1(int[] array)
{
    int numLenght = array.Length;
    int sum = 2 * n + 1;
    int arraysum = 0;
    for (int i = 0, y = 0; i < n; i++, y++)
    {
        sum += i;
        arraysum += array[y];
    }
    return sum - arraysum;
}