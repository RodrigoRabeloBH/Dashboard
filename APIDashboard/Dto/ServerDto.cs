using System.ComponentModel.DataAnnotations;

namespace APIDashboard.Dto
{
    public class ServerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        public bool IsOnline { get; set; }

    }
}