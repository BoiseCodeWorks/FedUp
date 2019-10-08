namespace FedUp.Interfaces
{
    public interface IGame
    {
        IPlane Plane { get; set; }
        IAirport CurrentAirport { get; set; }
    }
}