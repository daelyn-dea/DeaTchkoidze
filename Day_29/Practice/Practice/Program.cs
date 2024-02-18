using ConsoleApp2;

List<object> list = new List<object> { "Mary", 20, 'C' };


List<Student> students = new List<Student>
        {
            new Student { Name = "Mary", Age = 20, Group = 'C' },
            new Student { Name = "John", Age = 22, Group = 'A' },
            new Student { Name = "Jane", Age = 20, Group = 'B' },
        };

List<Student> filteredStudents = Helper.FilterStudents(students, list);


DisplayFilteredStudents(filteredStudents, "Filtered Students:");


    static void DisplayFilteredStudents(List<Student> filteredStudents, string message)
    {
        Console.WriteLine(message);
        foreach (var student in filteredStudents)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Group: {student.Group}");
        }
        Console.WriteLine();
    }

 