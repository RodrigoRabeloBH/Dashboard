using System;

namespace APIDashboard.Models
{
    public class Order : Entity
    {
        public decimal Total { get; set; }
        public DateTime Placed { get; set; }
        public DateTime? Completed { get; set; }

        // EF relation
        public int CostumerId { get; set; }
        public Costumer Costumer { get; set; }
    }
}