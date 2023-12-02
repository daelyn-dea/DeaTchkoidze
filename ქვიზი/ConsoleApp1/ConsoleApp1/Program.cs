//მოცემულია მთელი რიცხვების დალაგებული მასივი, რომლის ყველა ელემენტი უნიკალურია.
//დაწერეთ ფუნქცია ShowPairs(int number, int[] array) რომელსაც გადაეცემა მთელი რიცხვი და მასივი,
//ფუნქციამ უნდა დაბეჭდოს ყველა ისეთი წყვილი ელემენტებისა რომელთა ჯამი უდრის გადმოცემულ
//რიცხვს.
//მაქსიმალური ქულა - სწორი შედეგი, 1 ციკლი, პარამეტრად მიღებული მასივის გამოყენება მხოლოდ.
int[] array = { 1, 2, 3, 4, 5, 6 };
int number = 8;
ShowPairs(number, array);
Console.Read();

void ShowPairs(int number, int[] array)
{
    for (int i = 0; i < array.Length / 2; i++)
    {
        for (int j = 1; j < array.Length; j++)
        {
            if (array[i] + array[j] == number && i != j)
            {
                Console.WriteLine("wyvili: {0}, {1}", array[i], array[j]);
            }
        }
    }
}
