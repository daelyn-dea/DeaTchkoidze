namespace Practice
{
    internal static class Reporter
    {
        public static Dictionary<int, int> ReportOfCountOrdersMethodSyntax(List<Order> orders, List<Customer> customers)
        {
            //method
            return (from order in orders
                    group order by order.CustomerID into goupedOrder
                    join customer in customers on goupedOrder.Key equals customer.CustomerID
                    select new
                    {
                        CustomerId = customer.CustomerID,
                        CountOfOrders = goupedOrder.Count()
                    })
                                                   .ToDictionary(x => x.CustomerId, x => x.CountOfOrders);
        }

        public static Dictionary<int, int> ReportOfCountOrdersQuerySyntax(List<Order> orders, List<Customer> customers)
        {
            return customers
                            .Join(
                             orders.GroupBy(order => order.CustomerID),
                             customer => customer.CustomerID,
                             order => order.Key,
                             (customer, order) => new
                             {
                                 CustomerId = customer.CustomerID,
                                 OrderCount = order.Count()
                             })
                            .ToDictionary(x => x.CustomerId, x => x.OrderCount);
        }

        public static Dictionary<int, double> SumAmountPerPersonQuerySyntax(List<Order> orders, List<Customer> customers)
        {
            return (from order in orders
                    group order by order.CustomerID into groupedOrder
                    join customer in customers on groupedOrder.Key equals customer.CustomerID
                    select new
                    {
                        CustomerId = customer.CustomerID,
                        SumAmount = groupedOrder.Sum(order => order.Price)
                    })
                                        .ToDictionary(x => x.CustomerId, x => x.SumAmount);
        }
        public static Dictionary<int, double> SumAmountPerPErsonMethoSuntax(List<Order> orders, List<Customer> customers)
        {
            return customers
        .Join(orders
        .GroupBy(order => order.CustomerID),
        customer => customer.CustomerID,
        ordered => ordered.Key,
        (customer, ordered) => new
        {
            CustomerId = customer.CustomerID,
            SumAmount = ordered.Sum(order => order.Price)
        })
        .ToDictionary(x => x.CustomerId, x => x.SumAmount);
        }
        public static Dictionary<int, double> MinAmountPerOrderQuerySyntax(List<Order> orders, List<Customer> customers)
        {
            return (from order in orders
                    group order by order.CustomerID into groupedOrder
                    join customer in customers
                    on groupedOrder.Key equals customer.CustomerID
                    select new
                    {
                        CustomerId = customer.CustomerID,
                        MinAmount = groupedOrder.Min(order => order.Price)
                    })
                                             .ToDictionary(x => x.CustomerId, x => x.MinAmount);
        }

        public static Dictionary<int, double> MinAmountPerPersonMethoSyntax(List<Order> orders, List<Customer> customers)
        {
            return orders.GroupBy(order => order.CustomerID).Join(
            customers,
            ordered => ordered.Key,
            customer => customer.CustomerID,
            (ordered, customer) =>
            new
            {
                MinAmount = ordered.Min(order => order.Price),
                CustomerId = customer.CustomerID
            }
            )
            .ToDictionary(x => x.CustomerId, x => x.MinAmount);
        }
        public static Dictionary<int, int> OrderCountPerPersonQuerySyntax(List<Order> orders, List<Customer> customers)
        {
            return (from order in orders
                    group order by order.CustomerID into groupedOrders
                    join customer in customers on groupedOrders.Key equals customer.CustomerID
                    select new
                    {
                        CustomerId = customer.CustomerID,
                        OrderCount = groupedOrders.Count(),
                    })
                                              .Where(x => x.OrderCount > 1)
                                              .ToDictionary(x => x.CustomerId, x => x.OrderCount);
        }

        public static Dictionary<int, int> OderCountPerPErsonMethodSyntax(List<Order> orders, List<Customer> customers)
        {
            return orders.GroupBy(order => order.CustomerID)
            .Join(customers,
            ordered => ordered.Key,
            custoemr => custoemr.CustomerID,
            (ordered, custoemr) =>
            new
            {
                OrderCount = ordered.Count(),
                CustomerId = custoemr.CustomerID
            })
            .Where(x => x.OrderCount > 1)
            .ToDictionary(x => x.CustomerId, x => x.OrderCount);
        }
        public static Dictionary<int, double> AvarageOrderMoreThen10MethodSyntax(List<Order> orders, List<Customer> customers)
        {
            return orders.GroupBy(order => order.CustomerID)
            .Join(customers,
            groupedOrder => groupedOrder.Key,
            custoemr => custoemr.CustomerID,
            (ord, cus) => new
            {
                AvarageAmount = ord.Average(x => x.Price),
                CustomerId = cus.CustomerID
            }) 
            .Where(x => x.AvarageAmount > 10)
            .ToDictionary(x => x.CustomerId, x => x.AvarageAmount);
        }

        public static Dictionary<int, double> AvarageOrderMoreThen10QuerySyntax(List<Order> orders, List<Customer> customers)
        {
            return (from order in orders
                    group order by order.CustomerID into groupedOrder
                    join customer in customers on groupedOrder.Key equals customer.CustomerID
                    let averageAmount = groupedOrder.Average(x => x.Price)
                    where averageAmount > 10
                    select new
                    {
                        CustomerId = customer.CustomerID,
                        AvarageAmount = averageAmount
                    })
                    .ToDictionary(x => x.CustomerId, x => x.AvarageAmount);
        }
    }
}
