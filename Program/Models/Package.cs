using FedUp.Interfaces;

namespace FedUp.Models
{
    public class Package : IPackage
    {
        public IAirport Destination { get; set; }
        public int Reward { get; set; }

        public Package(IAirport destination, int reward)
        {
            Destination = destination;
            Reward = reward;
        }
    }
}