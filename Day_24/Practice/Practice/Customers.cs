namespace Practice
{
    internal class Customer
    {
        public Customer(int customerID, string name)
        {
            CustomerID = customerID;
            Name = name;
        }

        public int CustomerID { get; set; }
        public string Name { get; set; }
    }

    internal static class CustomerMaker
    {
        public static List<Customer> CustomerListMakerMethod()
        {
            string path = @".\Customers.txt";

            List<Customer> customersList = new();

            IEnumerable<string[]> customersinfo = FileReader.FilereaderMethod(path);
            foreach(var item in customersinfo)
            {
                customersList.Add(new Customer(Convert.ToInt32(item[0]), item[1]));
            }

            return customersList;
        }
    }
}
