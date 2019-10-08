using System;
using System.Collections.Generic;
using FedUp.Interfaces;

namespace FedUp.Models
{
    public class Airport : IAirport
    {

        public string Code { get; set; }
        public string Name { get; set; }
        public List<IPackage> Pickups { get; set; }
        public Dictionary<string, IAirport> Connections { get; private set; }


        public void AddConnection(IAirport airport)
        {
            Connections.Add(airport.Code, airport);
        }

        public IAirport Fly(string destinationCode)
        {
            if (Connections.ContainsKey(destinationCode))
            {
                return Connections[destinationCode];
            }
            return this;
        }

        public string GetTemplate()
        {
            string template = $"Airport: ({Code}) {Name} \nConnections:\n";
            foreach (var connection in Connections)
            {
                template += "\t" + connection.Key + " - " + connection.Value.Name + Environment.NewLine;
            }
            return template;
        }

        public Airport(string code, string name)
        {
            Code = code;
            Name = name;
            Pickups = new List<IPackage>();
            Connections = new Dictionary<string, IAirport>();
        }

    }
}