using System.Collections.Generic;

namespace APIDashboard.Models
{
    public class Customer : Entity
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}