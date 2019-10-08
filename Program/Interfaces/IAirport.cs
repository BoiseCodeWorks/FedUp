using System.Collections.Generic;

namespace FedUp.Interfaces
{
    public interface IAirport
    {
        string Code { get; set; }
        string Name { get; set; }
        List<IPackage> Pickups { get; set; }

        Dictionary<string, IAirport> Connections { get; }

        /// <summary>Takes in a destination string and returns the airport at that code or if no airport returns itself</summary>
        IAirport Fly(string destinationCode);

        /// <summary>Returns airport name and destinations</summary>
        string GetTemplate();
    }
}