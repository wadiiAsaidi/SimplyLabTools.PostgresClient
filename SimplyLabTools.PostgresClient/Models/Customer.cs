namespace TestDockerProject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public int StateId { get; set; }
        public int Zip { get; set; }
        public string Gender { get; set; }
        public int OrderCount { get; set; }
        public List<Order> Orders { get; set; }
    }

    public class State
    {
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        
    }
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }

    public class FakeData
    {
        public static List<Customer> GenerateFakeData()
        {
            var customers = new List<Customer>
            {
                    new Customer
                    {
                        Id = 1,
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "john.doe@example.com",
                        Address = "123 Main St",
                        City = "New York",
                        State = new State { Id = 1, Abbreviation = "NY", Name = "New York" },
                        Zip = 10001,
                        Gender = "Male",
                        OrderCount = 2,
                        Orders = new List<Order>
                        {
                            new Order { Id = 1, Product = "Laptop", Quantity = 1, Price = 999.99m },
                            new Order { Id = 2, Product = "Mouse", Quantity = 2, Price = 25.50m }
                        }
                    },
                    new Customer
                    {
                        Id = 2,
                        FirstName = "Jane",
                        LastName = "Smith",
                        Email = "jane.smith@example.com",
                        Address = "456 Oak St",
                        City = "Los Angeles",
                        State = new State { Id = 2, Abbreviation = "CA", Name = "California" },
                        Zip = 90001,
                        Gender = "Female",
                        OrderCount = 1,
                        Orders = new List<Order>
                        {
                            new Order { Id = 3, Product = "Phone", Quantity = 1, Price = 699.99m }
                        }
                    },
                new Customer
                    {
                        Id = 2,
                        FirstName = "wadoo",
                        LastName = "alsaidi",
                        Email = "wadii.alsaidi@example.com",
                        Address = "456 Oak St",
                        City = "Los Angeles",
                        State = new State { Id = 2, Abbreviation = "CA", Name = "California" },
                        Zip = 2004,
                        Gender = "man",
                        OrderCount = 1,
                        Orders = new List<Order>
                        {
                            new Order { Id = 3, Product = "IPhone", Quantity = 1, Price = 699.99m }
                        }
                    }
             };
            return customers;

        }
    }
}
