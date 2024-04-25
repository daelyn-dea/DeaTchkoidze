using Practice_1;
using System.Collections;
using System.Net.WebSockets;
//1.
Console.WriteLine("-----------practice_01----------");
string brackets = "{[()}]";
string brackets2 = "{[()]}";
Console.WriteLine($"is \"{brackets}\" balanced : {BalancingBracket.BalancingBracketMethod(brackets)}");
Console.WriteLine($"is \"{brackets2}\" balanced : {BalancingBracket.BalancingBracketMethod(brackets2)}");

//2.
Console.WriteLine();
Console.WriteLine("-----------practice_02----------");
Tuple<double, double> pointA = Tuple.Create(1.0, 2.0);
Tuple<double, double> pointB = Tuple.Create(4.0, 6.0);
TuplePoint tuplePoint = new TuplePoint(pointA, pointB);
double distnace = tuplePoint.CalculateLength(pointA, pointB); 
Console.WriteLine($"distance from pointA : x = {pointA.Item1}, y = {pointB.Item2} to pointB : x = {pointB.Item1}, y ={pointB.Item2} is {distnace}");

//3.აუთიანი გასაოცარი მეთოდის მოფიქრებას უფრო დიდი დრო მიქონდა ვიდრე წერას ამიტომ გთავაზობთ კალკულატორს
Console.WriteLine();
Console.WriteLine("-----------practice_03----------");
int num1 = 5;
int num2 = 6;
int sum;
int difference;

Calculate.CalculateSumAndDifference(num1, num2, out sum, out difference);
Console.WriteLine($"sum of {num1} and {num2} is {sum}, difference of {num1} and {num2} is {difference}");

Tuple<int, int> tupleResult =  Calculate.CalculateSumAndDifferenceByTuple(num1, num2);
Console.WriteLine($"sum of {num1} and {num2} is {tupleResult.Item1}, difference of {num1} and {num2} is {tupleResult.Item2}");

//4.
Console.WriteLine();
Console.WriteLine("-----------practice_04----------");
Book greatGatsby = new Book("F. Scott Fitzgerald", "The Great Gatsby", 1982, "123-22-341-2-2", BookGenre.ScienceFiction);
Book piligrimsProgress = new Book("John Bunyan", "The Pilgrim’s Progress", 1678, "983-32-3421-2-2", BookGenre.Fiction);
Book clarissa = new Book("Samuel Richardson", "Clarissa", 1748, "263-32-3421-2-2", BookGenre.NonFiction);
Book frankenstein = new Book("Mary Shelle", "Frankenstein", 1818, "773-372-3421-2", BookGenre.Mystery);
Book janeEyre = new Book("Charlotte Brontë", "Jane Eyre", 1847, "75-372-3421-2", BookGenre.Romance);

List<Book> booksList = new List<Book> { greatGatsby, piligrimsProgress, clarissa, frankenstein };
booksList.Add(janeEyre);
booksList.RemoveAt(1);
Console.WriteLine();
Console.WriteLine("sorted by ISBN");
ISBNComparer comparerISBN = new ISBNComparer();
booksList.Sort(comparerISBN);

foreach (var book in booksList)
{
    Console.WriteLine(book.ToString());
}

Console.WriteLine();
Console.WriteLine("sorted by year of publication");
YearOfPublicationComparer comparerYear = new YearOfPublicationComparer();
booksList.Sort(comparerYear);

foreach (var book in booksList)
{
    Console.WriteLine(book.ToString());
}

Console.WriteLine();
Console.WriteLine("sorted by author");
AuthorComparer comparerAuthor = new AuthorComparer();
booksList.Sort(comparerAuthor);

foreach (var book in booksList)
{
    Console.WriteLine(book.ToString());
}