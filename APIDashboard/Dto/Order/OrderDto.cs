using System;
using System.ComponentModel.DataAnnotations;
using APIDashboard.Models;

namespace APIDashboard.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        public decimal Total { get; set; }
        public string Placed { get; set; }
        public DateTime? Completed { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public string State { get; set; }
    }
}