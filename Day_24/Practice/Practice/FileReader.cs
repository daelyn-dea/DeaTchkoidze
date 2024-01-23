namespace Practice
{
    public static  class FileReader
    {
        public static IEnumerable<string[]> FilereaderMethod(string path)
        {
            return File.ReadAllLines(path).Select(line => line.Split('|'));
        }
    }
}