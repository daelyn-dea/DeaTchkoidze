using Day_21;

Console.WriteLine("Choose one: 1) Start Test 2) Add Test.");
try
{
    string choose = Console.ReadLine();
    if (choose == "Start Test")
    {
        ReadTestFromFile.ReadFileMethod();
    }
    else if (choose == "Add Test")
    {
        WriteTestInFile.CallCreateTest();
    }
    else
    {
        throw new Exception("Enter just Start Test or Add Test");
    }

}
catch(Exception ex)
{
    ErrorLog.ErrorLogInFile(ex.Message, ex.StackTrace);
}