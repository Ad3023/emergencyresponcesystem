using System;
using System.Collections.Generic;
using System.Linq;
abstract class EmergencyUnit
{
 
    public string Name { get; protected set; }
    public int Speed { get; protected set; }
    public abstract bool CanHandle(string incidentType);


    public abstract void RespondToIncident(Incident incident);
    public override string ToString()
    {
        return $"{GetType().Name} - {Name} (Speed: {Speed})";
    }
}
class Police : EmergencyUnit
{
    public Police(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }
    public override bool CanHandle(string incidentType)
    {
        return incidentType.Equals("Crime", StringComparison.OrdinalIgnoreCase);
    }
    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is handling the crime at {incident.Location}.");
        Console.WriteLine("Police are investigating the scene and apprehending suspects.");
    }
}
class Firefighter : EmergencyUnit
{
    public Firefighter(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }
    public override bool CanHandle(string incidentType)
    {
        return incidentType.Equals("Fire", StringComparison.OrdinalIgnoreCase);
    }
    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is extinguishing the fire at {incident.Location}.");
        Console.WriteLine("Firefighters are rescuing people and putting out the flames.");
    }
}


class Ambulance : EmergencyUnit
{

    public Ambulance(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }
    public override bool CanHandle(string incidentType)
    {
        return incidentType.Equals("Medical", StringComparison.OrdinalIgnoreCase);
    }
    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is treating patients at {incident.Location}.");
        Console.WriteLine("Medical personnel are providing aid and transporting the injured.");
    }
}

class Incident
{
 
    public string Type { get; }
    public string Location { get; }
    public Incident(string type, string location)
    {
        Type = type;
        Location = location;
    }
    public override string ToString()
    {
        return $"Type: {Type}, Location: {Location}";
    }
}

class Simulation
{
    
    static Incident GenerateRandomIncident(string[] locations, string[] incidentTypes)
    {
        Random random = new Random();
        string type = incidentTypes[random.Next(incidentTypes.Length)];
        string location = locations[random.Next(locations.Length)];
        return new Incident(type, location);
    }
    static EmergencyUnit FindAvailableUnit(List<EmergencyUnit> units, string incidentType)
    {
        foreach (EmergencyUnit unit in units)
        {
            if (unit.CanHandle(incidentType))
            {
                return unit;
            }
        }
        return null; 
    }

    public static void RunSimulation()
    {

        List<EmergencyUnit> units = new List<EmergencyUnit>();
        string[] locations = { "City Hall", "Main Street", "Central Park", "Industrial Area", "Residential District" };
        string[] incidentTypes = { "Fire", "Crime", "Medical" };
        int rounds = 0;
        while (rounds <= 0)
        {
            Console.Write("Enter the number of simulation rounds: ");
            if (int.TryParse(Console.ReadLine(), out rounds) && rounds > 0)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a positive number.");
        }

        Console.WriteLine("Enter initial unit information:");
        Console.WriteLine("For each unit type (Police, Firefighter, Ambulance), enter name and speed.");

        for (int i = 0; i < 2; i++)
        {
            Console.Write($"Police Unit {i + 1} Name: ");
            string policeName = Console.ReadLine();
            int policeSpeed = GetUnitSpeedFromUser($"Police Unit {i + 1} Speed");
            units.Add(new Police(policeName, policeSpeed));
        }

        for (int i = 0; i < 2; i++)
        {
            Console.Write($"Firefighter Unit {i + 1} Name: ");
            string firefighterName = Console.ReadLine();
            int firefighterSpeed = GetUnitSpeedFromUser($"Firefighter Unit {i + 1} Speed");
            units.Add(new Firefighter(firefighterName, firefighterSpeed));
        }

        for (int i = 0; i < 2; i++)
        {
            Console.Write($"Ambulance Unit {i + 1} Name: ");
            string ambulanceName = Console.ReadLine();
            int ambulanceSpeed = GetUnitSpeedFromUser($"Ambulance Unit {i + 1} Speed");
            units.Add(new Ambulance(ambulanceName, ambulanceSpeed));
        }
      
        Console.Write("Enter new locations, separated by commas (or leave blank to use defaults): ");
        string newLocationsInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newLocationsInput))
        {
            string[] newLocations = newLocationsInput.Split(',').Select(s => s.Trim()).ToArray();
            locations = locations.Concat(newLocations).ToArray(); 
        }

        Console.Write("Enter new incident types, separated by commas (or leave blank to use defaults): ");
        string newIncidentTypesInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newIncidentTypesInput))
        {
            string[] newIncidentTypes = newIncidentTypesInput.Split(',').Select(s => s.Trim()).ToArray();
            incidentTypes = incidentTypes.Concat(newIncidentTypes).ToArray(); 
        }

        int score = 0;
        for (int round = 1; round <= rounds; round++)
        {
            Console.WriteLine($"- - - Turn {round} - - -");
            Incident currentIncident = GenerateRandomIncident(locations, incidentTypes);
            Console.WriteLine($"Incident: {currentIncident.Type} at {currentIncident.Location}");
            EmergencyUnit respondingUnit = FindAvailableUnit(units, currentIncident.Type);
            if (respondingUnit != null)
            {
                respondingUnit.RespondToIncident(currentIncident);
                score += 10;
                Console.WriteLine("+10 points");
            }
            else
            {
                Console.WriteLine("No suitable unit available to handle this incident.");
                score -= 5;
                Console.WriteLine("-5 points");
            }

            Console.WriteLine($"Current Score: {score}");
            Console.WriteLine();
        }
        Console.WriteLine("- - - Simulation Results - - -");
        Console.WriteLine("Locations:");
        foreach (string location in locations)
        {
            Console.WriteLine($"- {location}");
        }
        Console.WriteLine("\nIncident Types:");
        foreach (string type in incidentTypes)
        {
            Console.WriteLine($"- {type}");
        }
        Console.WriteLine("\nEmergency Units:");
        foreach (EmergencyUnit unit in units)
        {
            Console.WriteLine($"- {unit}"); 
        }
        Console.WriteLine("- - - Simulation Over - - -");
        Console.WriteLine($"Final Score: {score}");
        Console.ReadKey();
    }
    static int GetUnitSpeedFromUser(string prompt)
    {
        int speed = 0;
        while (speed <= 0)
        {
            Console.Write($"{prompt}: ");
            if (int.TryParse(Console.ReadLine(), out speed) && speed > 0)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a positive number for speed.");
        }
        return speed;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Simulation.RunSimulation(); 
    }
}
