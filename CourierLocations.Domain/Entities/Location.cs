
namespace CourierLocations.Domain.Entities;

public class Location : BaseEntity
{
    public Guid CourierId { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public double Accuracy { get; init; }
    public DateTime LocateDateTime { get; init; }
}