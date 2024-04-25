//using Practice___1;
//using Practice_01;
////1.
//Console.WriteLine("Enter text which you want to reverced: ");
//string input = Console.ReadLine();
//Console.WriteLine($"Reversed text: {input.ReversecString()}");

////2.
//Console.WriteLine("---------------------");
//Console.WriteLine();
//Console.WriteLine("Enter caracter, which you want to count: ");
//char caracter = Convert.ToChar(Console.ReadLine());
//Console.WriteLine($"the letter \"{caracter}\" in the text {input.CountCaracterInString(caracter)} - times");


////3.
//Console.WriteLine("---------------------");
//Console.WriteLine();
//Console.WriteLine("Enter substring, to know start or end text by this: ");
//string substrng = Console.ReadLine();
//Console.WriteLine(input.StartOrEndString(substrng));

////4.
//Console.WriteLine("---------------------");
//Console.WriteLine();
//Console.WriteLine("Enter number to know is it odd or even: ");
//int number = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine($"number {number}  is {number.EvenOrOdd()}");

////5.
//Console.WriteLine("---------------------");
//Console.WriteLine();
//Console.WriteLine("Enter number to know absolute value: ");
//int number1 = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine($"number {number1}'s absolute value is:  {number1.AbsoluteValue()}");

//6.
Console.WriteLine("---------------------");
Console.WriteLine();
Console.WriteLine("Enter number to rounds nearest multiple: ");
int number2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter number: ");
int number3 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"number {number2}'s nearest multiple is:  {number2.RoundNearestMultiple(number3)}");


////7.
//Console.WriteLine("---------------------");
//Console.WriteLine();
//Console.WriteLine("Enter number for array length: ");
//int arrayLength = Convert.ToInt32(Console.ReadLine());
//int[] array = new int[arrayLength];

//Console.WriteLine("Enter numbers for array : ");
//for (int i = 0; i < arrayLength; i++)
//{
//    Console.Write($"array[{i}] : ");
//    array[i] = Convert.ToInt32(Console.ReadLine());
//}

//Console.WriteLine("Delete dublicate element from array : ");
//int[] newarray = array.RemovesDublicate();
//for (int i = 0; i < newarray.Length; i++)
//{
//    Console.Write($"{newarray[i]} ");
//}

////8.
//Console.WriteLine("---------------------");
//Console.WriteLine();
//Console.WriteLine("Enter numbers for search array : ");
//int searchNumber = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine(array.FindNumber(searchNumber));

////9.
//Console.WriteLine("---------------------");
//Console.WriteLine();
//Console.WriteLine($"max value on array is : {array.ReturneMaxElement()}");

//////10.DateTime
//Console.WriteLine("---------------------");
//Console.WriteLine();
//DateTime currentDateTime = DateTime.Now;
//Console.WriteLine($"To string DateTime  : {currentDateTime.DateTimeToString()}");

////10.DateTime
//Console.WriteLine("---------------------");
//Console.WriteLine();
//Console.Write($"Enter start Date : ");
//DateTime startDate = Convert.ToDateTime(Console.ReadLine());
//Console.Write($"Enter end Date : ");
//DateTime endDate = Convert.ToDateTime(Console.ReadLine());
//Console.WriteLine($"DateTime falls within a certain date range: {currentDateTime.DateTimeInDiapason(startDate, endDate)}");

////11.DateTime
//Console.WriteLine("---------------------");
//Console.WriteLine();
//Console.Write($"Enter your date of birth : ");
//DateTime birthDate = Convert.ToDateTime(Console.ReadLine());
//Console.WriteLine($"Your age is : {birthDate.CalculateAge()}");

////12.
//Console.WriteLine("---------------------");
//Console.WriteLine();

//Console.WriteLine("Enter number for first array length: ");
//int firstArrayLength = Convert.ToInt32(Console.ReadLine());
//int[] firstArray = new int[firstArrayLength];
//Console.WriteLine("Enter numbers for first array : ");
//for (int i = 0; i < firstArrayLength; i++)
//{
//    Console.Write($"array[{i}] : ");
//    firstArray[i] = Convert.ToInt32(Console.ReadLine());
//}

//Console.WriteLine("Enter number for second array length: ");
//int secondArrayLength = Convert.ToInt32(Console.ReadLine());
//int[] secondArray = new int[secondArrayLength];
//Console.WriteLine("Enter numbers for first array : ");
//for (int i = 0; i < secondArrayLength; i++)
//{
//    Console.Write($"array[{i}] : ");
//    secondArray[i] = Convert.ToInt32(Console.ReadLine());
//}

//int[] array3 = firstArray.MergeTwoArray(secondArray);
//Console.WriteLine("Merged Array:");
//for (int i = 0; i < array3.Length; i++)
//{
//    Console.Write($"{array3[i]} ");
//}

////13.
//Console.WriteLine();
//Console.WriteLine("---------------------");
//Console.WriteLine();

//Console.WriteLine("Enter number for array length: ");
//int arrayLengthForSeperate = Convert.ToInt32(Console.ReadLine());
//int[] arraySeperate = new int[arrayLengthForSeperate];

//Console.WriteLine("Enter numbers for array : ");
//for (int i = 0; i < arrayLengthForSeperate; i++)
//{
//    Console.Write($"array[{i}] : ");
//    arraySeperate[i] = Convert.ToInt32(Console.ReadLine());
//}
//Console.WriteLine("Enter seperate : ");
//char seperate = Convert.ToChar(Console.ReadLine());
//Console.WriteLine(arraySeperate.arrayToString(seperate));