namespace APIDashboard.Dto
{
    public class OrderIndexDto
    {
        public int Id { get; set; }        
        public string Placed { get; set; }
        public decimal Total { get; set; }
        public string Completed { get; set; }
    }
}