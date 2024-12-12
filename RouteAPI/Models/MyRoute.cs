using RouteAPI.Models;
using System.Text.Json.Serialization;

public class MyRoute
{
    public int Id { get; set; }
    public string StartPoint { get; set; } = string.Empty;
    public string EndPoint { get; set; } = string.Empty;
    public TimeSpan DepartureTime { get; set; }
    public int BusId { get; set; }

    [JsonIgnore]
    public Bus? Bus { get; set; }
}
