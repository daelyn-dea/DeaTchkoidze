namespace Practice
{
    internal class Order
    {
        public Order(int orderID, string date, string product, double price, int customerID)
        {
            OrderID = orderID;
            Date = date;
            Product = product;
            Price = price;
            CustomerID = customerID;
        }

        public int OrderID { get; set; }
        public string Date { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public int CustomerID { get; set; }
    }

    internal static class OrderMaker
    {
        public static List<Order> OrdersListMaker()
        {
            string path = @".\Orders.txt";

            List<Order> OrdersList = new();

            IEnumerable<string[]> orderInfo = FileReader.FilereaderMethod(path);
            foreach (var item in orderInfo)
            {
                OrdersList.Add(new Order(int.Parse(item[0]), item[1], item[2], double.Parse(item[3]), int.Parse(item[4])));
            }

            return OrdersList;
        }
    }
}