using System;
using FedUp.Services;

namespace FedUp.Controllers
{
    public class AirportController
    {
        private AirportService _airService = new AirportService();
        public void Run()
        {
            while (true)
            {
                Update();
                GetUserInput();
            }
        }
        private void Update()
        {
            Console.Clear();
            Console.WriteLine(_airService.GetGameDetails());
            Console.WriteLine("Flight Log:");
            foreach (string message in _airService.Messages)
            {
                Console.WriteLine("\t" + message);
            }
            _airService.Messages.Clear();
        }
        private void GetUserInput()
        {
            System.Console.WriteLine("Where To:");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "q":
                case "quit":
                case "exit":
                case "close":
                    Environment.Exit(0);
                    break;
                default:
                    _airService.Fly(input);
                    break;
            }
        }
    }
}