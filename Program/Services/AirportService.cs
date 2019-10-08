using System.Collections.Generic;
using FedUp.Models;

namespace FedUp.Services
{
    public class AirportService
    {
        private Game _game = new Game();
        //TODO convert to a List<KeyValuePair> for coloring text
        public List<string> Messages { get; set; }

        public string GetGameDetails()
        {
            return _game.CurrentAirport.GetTemplate() + System.Environment.NewLine + _game.Plane.GetTemplate();
        }

        public void Fly(string airportCode)
        {
            //change destination
            string from = _game.CurrentAirport.Name;
            _game.CurrentAirport = _game.CurrentAirport.Fly(airportCode);
            string to = _game.CurrentAirport.Name;

            //NOTE if failed to go anywhere, stop code execution
            if (from == to)
            {
                Messages.Add("Invalid Destination");
                return;
            }
            Messages.Add($"Traveled from {from} to {to}");
            UnloadCargo();
            LoadCargo();
        }

        private void LoadCargo()
        {
            if (_game.CurrentAirport.Pickups.Count == 0)
            {
                Messages.Add("No Packages to Pickup");
                return;
            }

            Messages.Add($"Picking up {_game.CurrentAirport.Pickups.Count} package(s)");
            _game.Plane.Cargo.AddRange(_game.CurrentAirport.Pickups);
            _game.CurrentAirport.Pickups.Clear();
        }
        private void UnloadCargo()
        {
            int deliveries = 0;
            int profits = 0;
            _game.Plane.Cargo.RemoveAll(cargo =>
            {
                if (cargo.Destination == _game.CurrentAirport)
                {
                    _game.Plane.AccountBalance += cargo.Reward;
                    deliveries++;
                    profits += cargo.Reward;
                    return true;
                }
                return false;
            });
            if (deliveries == 0)
            {
                Messages.Add("No Packages to Deliver");
                return;
            }
            Messages.Add($"{deliveries} package(s) delivered, for a profit of {profits}");
        }

        public AirportService()
        {
            Messages = new List<string>();
        }
    }
}