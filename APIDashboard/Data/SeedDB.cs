using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDashboard.Models;

namespace APIDashboard.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;

        public SeedDB(DataContext context)
        {
            _context = context;
        }

        private List<Customer> BuildCustomers(int nCustomers)
        {
            var customers = new List<Customer>();
            var names = new List<string>();

            for (int i = 1; i <= nCustomers; i++)
            {
                var name = Helpers.Helper.MakeUniqueCustomerName(names);
                names.Add(name);
                customers.Add(new Customer
                {
                    Name = name,
                    Email = Helpers.Helper.MakeCustomerEmail(name),
                    State = Helpers.Helper.GetRandomState(),
                });
            }
            return customers;
        }

        private List<Order> BuildOrdersList(int nOrders)
        {
            var orders = new List<Order>();
            var rand = new Random();

            for (int i = 1; i <= nOrders; i++)
            {
                var randomCustomerId = rand.Next(1, _context.Customers.Count());
                var placed = Helpers.Helper.GetRandomOrderPlaced();
                var completed = Helpers.Helper.GetRandomOrderCompleted(placed);

                orders.Add(new Order
                {
                    Customer = _context.Customers.FirstOrDefault(c => c.Id == randomCustomerId),
                    Total = Helpers.Helper.GetRandomOrderTotal(),
                    Placed = placed,
                    Completed = completed
                });
            }
            return orders;
        }

        private List<Server> BuildServers()
        {
            return new List<Server>()
            {
                new Server
                {
                    Name = "Dev-Web",
                    IsOnline = true
                },
                new Server
                {
                    Name = "Dev-Mail",
                    IsOnline = true
                },
                new Server
                {
                    Name = "Dev-Services",
                    IsOnline = false
                },
                new Server
                {
                    Name = "QA-Web",
                    IsOnline = true
                },
                new Server
                {
                    Name = "QA-Mail",
                    IsOnline = true
                },
                new Server
                {
                    Name = "QA-Services",
                    IsOnline = false
                },
                new Server
                {
                    Name = "Prod-Web",
                    IsOnline = true
                },
                new Server
                {
                    Name = "Prod-Mail",
                    IsOnline = true
                },
                new Server
                {
                    Name = "Prod-Services",
                    IsOnline = false
                }
            };
        }

        private void SeedCustomers(int nCustomers)
        {
            List<Customer> customers = BuildCustomers(nCustomers);

            foreach (var customer in customers) _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        private void SeedOrders(int nOrders)
        {
            List<Order> orders = BuildOrdersList(nOrders);

            foreach (var order in orders) _context.Orders.Add(order);
            _context.SaveChanges();
        }

        private void SeedServers()
        {
            List<Server> servers = BuildServers();

            foreach (var server in servers) _context.Servers.Add(server);
            _context.SaveChanges();
        }
        public void SeedData(int nCustomers, int nOrders)
        {
            if (!_context.Customers.Any()) SeedCustomers(nCustomers);

            if (!_context.Orders.Any()) SeedOrders(nOrders);

            if (!_context.Servers.Any()) SeedServers();
        }
    }
}