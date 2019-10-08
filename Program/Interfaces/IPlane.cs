using System.Collections.Generic;

namespace FedUp.Interfaces
{
    public interface IPlane
    {
        List<IPackage> Cargo { get; set; }
        int AccountBalance { get; set; }

        string GetTemplate();
    }
}