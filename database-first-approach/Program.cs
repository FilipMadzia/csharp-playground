// dotnet ef dbcontext scaffold "Database=Northwind; Trusted_Connection=true; Encrypt=false" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models  

using database_first_approach.Models;

using var context = new NorthwindContext();

context.Database.EnsureCreated();

Exercise1();
Exercise2();
Exercise3();
Exercise4(); 

void Exercise1()
{
    var clientsByRegion = context.Customers.GroupBy(x => x.Region);

    Console.WriteLine($"\tClients by region:");

    foreach (var customer in clientsByRegion)
    {
        Console.WriteLine($"{customer.Key ?? "None"} - {customer.Count()}");
    }
}

void Exercise2()
{
    var ordersByDate = context.Orders.GroupBy(x => x.OrderDate);
    
    Console.WriteLine($"\tOrders by date:");

    foreach (var order in ordersByDate)
    {
        Console.WriteLine($"{order.Key} - {order.Count()}");
    }
}

void Exercise3()
{
    var longestWorkingEmployees = context.Employees.OrderBy(x => x.HireDate).Take(5);

    Console.WriteLine($"\tLongest working customers:");

    foreach (var longestWorkingEmployee in longestWorkingEmployees)
    {
        Console.WriteLine($"{longestWorkingEmployee.FirstName} {longestWorkingEmployee.LastName}");
    }
}

void Exercise4()
{
    var customerCountries = context.Customers.GroupBy(x => x.Country);
    var customerCities = context.Customers.GroupBy(x => x.City);

    Console.WriteLine($"\tCustomers by countries:");
    
    foreach (var customer in customerCountries)
    {
        Console.WriteLine($"{customer.Key ?? "None"}");
    }
    
    Console.WriteLine($"\tCustomers by city:");

    foreach (var customer in customerCities)
    {
        Console.WriteLine($"{customer.Key ?? "None"}");
    }
}