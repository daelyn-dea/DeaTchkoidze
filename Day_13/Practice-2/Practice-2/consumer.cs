using Practice_02;

namespace Practice_2
{
    internal class Consumer : Vehicle
    {
        int NumOfWheel { get; set; }
        int SpeedKmH { get; set; }
        private int ReleaseYear { get; set; }
        ConsumerTypes CombatTypes { get; set; }
        public Consumer()
        {

        }

        public override void PrintInfo()
        {
            Console.WriteLine($"You choose Consumer");
        }

        
    }
    enum ConsumerTypes
    {
        Sedan,
        Byce
    }
    internal class Sedan : Consumer
    {
        int NumOfWheel { get; set; }
        int SpeedKmH { get; set; }
        int Pessanger { get; set; }
        int Door { get; set; }
        public Sedan(int numOfWheel, int speedKmH, int pessanger, int door) 
        {
            NumOfWheel = numOfWheel;
            SpeedKmH = speedKmH;
            Pessanger = pessanger;
            Door = door;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("----------Print Finally Info-----------");
            Console.WriteLine($"Numbers of Wheel of Tank is: {NumOfWheel}");
            Console.WriteLine($"Speed in kilometer per houer of Tank is: {SpeedKmH}");
            Console.WriteLine($"Pessanger is: {Pessanger}");
            Console.WriteLine($"Door is: {Door}");
        }
    }
    internal class Byke : Consumer
    {
        int NumOfWheel { get; set; }
        int SpeedKmH { get; set; }

        string Collor { get; set; }
        public Byke(int numOfWheel, int speedKmH,string color)
        {
            NumOfWheel = numOfWheel;
            SpeedKmH = speedKmH;
            Collor = color;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("----------Print Finally Info-----------");
            Console.WriteLine($"Numbers of Wheel of Beteer is: {NumOfWheel}");
            Console.WriteLine($"Speed in kilometer per houer of Beteer is: {SpeedKmH}");
            Console.WriteLine($"Colors  is: {Collor}");
        }

    }
}