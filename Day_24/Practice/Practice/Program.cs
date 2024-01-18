using Practice;

List<Customer> customers = CustomerMaker.CustomerListMakerMethod();
List<Order> orders = OrderMaker.OrdersListMaker();

var avarageOrderMoreThen10MethodSyntax = Reporter.AvarageOrderMoreThen10MethodSyntax(orders, customers);
var minAmountPerOrderQuerySyntax = Reporter.MinAmountPerOrderQuerySyntax(orders, customers);
var oderCountPerPErsonMethodSyntax = Reporter.OderCountPerPErsonMethodSyntax(orders, customers);
var reportOfCountOrdersMethodSyntax = Reporter.ReportOfCountOrdersMethodSyntax(orders, customers);
var sumAmountPerPErsonMethoSuntax = Reporter.SumAmountPerPErsonMethoSuntax(orders, customers);


foreach(var item in customers.Select(x => x.CustomerID))
{
    string averageOrderMoreThen10 = avarageOrderMoreThen10MethodSyntax.ContainsKey(item) ? $"Order average {avarageOrderMoreThen10MethodSyntax[item]}" : "Hasn't ordeer more then 10";
    string minAmountPerOrder = minAmountPerOrderQuerySyntax.ContainsKey(item) ? $"Min amount {minAmountPerOrderQuerySyntax[item]:C2}" : "Hasn't order";
    string oderCountPerPErson = oderCountPerPErsonMethodSyntax.ContainsKey(item) ? $"Order count per person : {oderCountPerPErsonMethodSyntax[item]}" : "Hasn't order";
    string reportOfCountOrders = reportOfCountOrdersMethodSyntax.ContainsKey(item) ? $"Has more then 1 order {reportOfCountOrdersMethodSyntax[item]}" : "Has less then one order";
    string sumAmountPerPErson = sumAmountPerPErsonMethoSuntax.ContainsKey(item) ? $"Sum amount : {sumAmountPerPErsonMethoSuntax[item]:C2}" : "Hasn't order";




    Console.WriteLine($"{item},  {averageOrderMoreThen10} | {minAmountPerOrder} | {oderCountPerPErson} | {reportOfCountOrders} | {sumAmountPerPErson}");
}