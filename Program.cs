using System;
using RaceSimulator.Races;

namespace RaceSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var race = new MixedRace(1000);
            race.Start();
            var idx = 1;
            foreach (var result in race.Results)
            {
                Console.WriteLine($"{idx++}: {result.Vehicle.Name} - {result.Time}");
            }
            Console.WriteLine($"Winner: {race.WinnerResult.Vehicle.Name}");
            Console.WriteLine();
        }
    }
}
