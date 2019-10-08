using System;
using FedUp.Controllers;

namespace FedUp
{
    class Program
    {
        static void Main(string[] args)
        {
            new AirportController().Run();
        }
    }
}
