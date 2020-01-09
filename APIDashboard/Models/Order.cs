using System;

namespace APIDashboard.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Costumer Costumer { get; set; }
        public decimal Total { get; set; }
        public DateTime Placed { get; set; }
        public DateTime? Completed { get; set; }

        // EF relation
        public int CostumerId { get; set; }
    }
}