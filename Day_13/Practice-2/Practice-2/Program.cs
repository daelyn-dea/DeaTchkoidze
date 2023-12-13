using Practice_02;
using Practice_2;
using static Practice_2.Sport;

Console.WriteLine("Choose one option: ");
foreach(VehicleTypes type in Enum.GetValues(typeof(VehicleTypes)))
{
    Console.WriteLine(type.ToString());
}

string userInput = Console.ReadLine();
string finallyChoosen = " ";

if (Enum.TryParse(userInput, true, out VehicleTypes vehicleTypes))
{
    switch (vehicleTypes)
    {
        case VehicleTypes.Combat:
            Console.WriteLine("Choose which type Combat : ");
            foreach (combatTypes type in Enum.GetValues(typeof(combatTypes)))
            {
                Console.WriteLine(type.ToString());
            }
             finallyChoosen = Console.ReadLine();
            combatMethod(finallyChoosen);
            break;
        case VehicleTypes.Public:
            Console.WriteLine("Choose which type Public : ");
            foreach (publictypes type in Enum.GetValues(typeof(publictypes)))
            {
                Console.WriteLine(type.ToString());
            }
            finallyChoosen = Console.ReadLine();
            Public publiccar = new Public();
            publiccar.publicMethod(finallyChoosen);
            break;
        case VehicleTypes.Sport:
            Console.WriteLine("Choose which type Sport : ");
            foreach (Sporttypes type in Enum.GetValues(typeof(Sporttypes)))
            {
                Console.WriteLine(type.ToString());
            }
            finallyChoosen = Console.ReadLine();
            Sport sportcar = new Sport();
            sportcar.sportMethod(finallyChoosen);
            break;

    }
    }
void combatMethod(string userInput1)
{
    switch (userInput1)
    {
        case "Tank":
            Console.WriteLine("----------Create Object-----------");
            Console.Write("Enter Num of Wheel: ");
            int NumOfWheel = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Speed: ");
            int SpeedKmH = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter power of shoot: ");
            int PowerOfShot = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Barrel Length: ");
            int BarrelLength = Convert.ToInt32(Console.ReadLine());
            Tank tank = new Tank(NumOfWheel, SpeedKmH, PowerOfShot, BarrelLength, vehicleTypes, combatTypes.Tank);
            tank.PrintInfo();
            break;
        case "Beteer":
            Console.WriteLine("----------Create Object-----------");
            Console.Write("Enter Num of Wheel: ");
            NumOfWheel = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Speed: ");
            SpeedKmH = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter power of shoot: ");
            PowerOfShot = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Barrel Length: ");
            BarrelLength = Convert.ToInt32(Console.ReadLine());
            Beteer beteer = new Beteer(NumOfWheel, SpeedKmH, PowerOfShot, BarrelLength, vehicleTypes, combatTypes.Tank);
            beteer.PrintInfo();
            break;
        case "Info":
            Console.WriteLine("----------Print Info-----------");
            Combat combat = new Combat();
            combat.PrintInfo();
            break;

    }
}