using ConsoleApp1;

var blu = new List<int>() { 1,3,3,2,2,5,5,6 };


MyList<int> intMyList =  new MyList<int>();
intMyList.AddRange(blu);


var auuuuuu = intMyList.Distinct();

var really = intMyList.Where(x => x > 100);

intMyList[1] = 2;
intMyList.RemoveAt(1);
var b = intMyList.Count;


var bbdb = intMyList.Contains(9);


