using System;

namespace APIDashboard.Dto.Order
{
    public class OrderIndexDto
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime Placed { get; set; }
        public DateTime? Completed { get; set; }
        public string Customer { get; set; }
    }
}