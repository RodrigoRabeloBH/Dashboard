using System;

namespace APIDashboard.Models
{
    public class Order : Entity
    {
        public Customer Customer { get; set; }
        public decimal Total { get; set; }
        public DateTime Placed { get; set; }
        public DateTime? Completed { get; set; }

        // EF relation
        public int CustomerId { get; set; }

        public Order()
        {
            Placed = DateTime.Now;
        }
    }
}