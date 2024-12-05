namespace Car.MVC.Models
{
    public class About
    {   
        public string? title { get; set; }
        public string? description { get; set; }
        public List<string> tags { get; set; } = new List<string>();
    }
}
