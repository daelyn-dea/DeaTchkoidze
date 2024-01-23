namespace Geography_Now_
{
    internal static class ErrorLog
    {
        internal static void ErrorLogInFile(string errorMessage, string errorStackTrace)
        {
            string logFilePath = @"C:\Users\dchko\Desktop\visual studio\.NET\Day_20\Logs.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine($"{DateTime.Now}: {errorMessage}: StackTrace: {errorStackTrace}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}