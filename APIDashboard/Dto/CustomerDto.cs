using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIDashboard.Models;

namespace APIDashboard.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} character")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} character")]
        public string State { get; set; }
        public int QtdOrdes { get; set; }
        public decimal Amount { get; set; }
    }
}