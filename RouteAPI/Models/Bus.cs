namespace RouteAPI.Models
{
    public class Bus
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<MyRoute> Routes { get; set; } = new List<MyRoute>();
    }

}
