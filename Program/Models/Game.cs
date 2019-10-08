using System;
using FedUp.Interfaces;

namespace FedUp.Models
{
    public class Game : IGame
    {
        public IPlane Plane { get; set; }
        public IAirport CurrentAirport { get; set; }

        /// <summary>This method will create all airports, cargo, and the relationships there of. It will set the starting airport</summary>
        private void Setup()
        {
            //NOTE Create Airports
            Airport boi = new Airport("boi", "Boise Airport");
            Airport pdx = new Airport("pdx", "Portland Airport");
            Airport ord = new Airport("ord", "Chicago O'Hare Airport");
            Airport den = new Airport("den", "Denver Airport");
            Airport oak = new Airport("oak", "Oakland Airport");
            Airport yyz = new Airport("yyz", "Toronto Airport");
            Airport hnl = new Airport("hnl", "Honolulu Airport");

            //NOTE Create relationships between
            boi.AddConnection(pdx);
            pdx.AddConnection(boi);

            boi.AddConnection(den);
            den.AddConnection(boi);

            pdx.AddConnection(den);
            den.AddConnection(pdx);

            pdx.AddConnection(oak);
            oak.AddConnection(pdx);

            pdx.AddConnection(hnl);
            hnl.AddConnection(pdx);

            ord.AddConnection(yyz);
            yyz.AddConnection(ord);

            ord.AddConnection(den);
            den.AddConnection(ord);

            //NOTE Create Packages
            Package p1 = new Package(boi, 100);
            Package p2 = new Package(pdx, 125);
            Package p3 = new Package(ord, 250);
            Package p4 = new Package(den, 50);
            Package p5 = new Package(oak, 300);
            Package p6 = new Package(yyz, 310);
            Package p7 = new Package(hnl, 5);

            //NOTE Add pacakges to Airports
            hnl.Pickups.Add(p1);
            yyz.Pickups.Add(p2);
            oak.Pickups.Add(p3);
            oak.Pickups.Add(p4);
            ord.Pickups.Add(p5);
            pdx.Pickups.Add(p6);
            boi.Pickups.Add(p7);

            //NOTE Set your starting point, this creates access to the web of connections that was made
            CurrentAirport = boi;
        }

        public Game()
        {
            Plane = new Plane();
            Setup();
        }


    }
}