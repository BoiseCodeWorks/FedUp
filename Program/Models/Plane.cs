using System;
using System.Collections.Generic;
using FedUp.Interfaces;

namespace FedUp.Models
{
    public class Plane : IPlane
    {
        public List<IPackage> Cargo { get; set; }
        public int AccountBalance { get; set; }

        public string GetTemplate()
        {
            string template = "Cargo: \n";
            foreach (var c in Cargo)
            {
                template += $"{c.Destination.Code}: {c.Reward:c} \n";
            }
            return template + $"AccountBalance: {AccountBalance:c}";
        }

        public Plane()
        {
            AccountBalance = 0;
            Cargo = new List<IPackage>();
        }

    }
}