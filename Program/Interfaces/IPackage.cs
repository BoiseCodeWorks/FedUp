namespace FedUp.Interfaces
{
    public interface IPackage
    {
        IAirport Destination { get; set; }
        int Reward { get; set; }
    }
}