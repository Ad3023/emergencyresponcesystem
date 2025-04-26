# Emergency Response Simulation in C#

## Author: [ADDISU GUCHE ]
[DBU1500959]

## Overview

This C# console application simulates a simplified emergency response system for a city.  It models how different types of emergency units (Police, Firefighters, and Ambulances) respond to various incidents (Crimes, Fires, and Medical emergencies).  This project demonstrates core Object-Oriented Programming (OOP) principles in C#, such as:

* Classes and Objects
* Inheritance
* Polymorphism
* Abstraction
* Encapsulation

## Features

* **Incident Simulation:** The program generates random incidents at different locations within a city.
* **Emergency Units:**
    * **Police:** Respond to crime incidents.
    * **Firefighters:** Respond to fire incidents.
    * **Ambulance:** Respond to medical emergencies.
* **Unit Dispatch:** The simulation automatically dispatches the appropriate emergency unit to each
    incident.
* **Scoring:** The program tracks a score based on how effectively units respond to incidents:
    * \+10 points for each correctly handled incident.
    * -5 points if no unit is available to handle an incident.
* **Console Output:** The simulation provides detailed output in the console, showing the incidents, unit
    responses, and the current score.
* **User Input:**
    * The user can specify the number of simulation rounds.
    * The user can enter names and speeds for the emergency units.
    * The user can add new locations and incident types.

## How to Run

1.  **Prerequisites:**

    * .NET SDK: Ensure you have the .NET SDK installed on your machine. You can download it from
        [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).
2.  **Compilation:**

    * Open a terminal or command prompt.
    * Navigate to the directory containing the `c# assignment.cs` file.
    * Compile the code using the following command:
        ```bash
        dotnet build
        ```
3.  **Execution:**

    * After successful compilation, run the application using:
        ```bash
        dotnet run
        ```
4.  **Simulation:**

    * The program will prompt you to enter the number of simulation rounds.
    * You will then be prompted to enter the name and speed for each emergency unit (Police,
        Firefighter, Ambulance).
    * Optionally, you can add new locations and incident types.
    * The simulation will then run, and the results will be displayed in the console.

## Code Structure

The project consists of the following classes:

* **`EmergencyUnit` (Abstract Class):**
    * Defines the common properties and behavior for all emergency units.
    * Properties:
        * `Name` (string): The name of the emergency unit.
        * `Speed` (int): The speed of the unit.
    * Abstract Methods:
        * `CanHandle(string incidentType)`: Checks if the unit can handle a specific incident type.
        * `RespondToIncident(Incident incident)`: Defines how the unit responds to an incident.
    * `ToString()`: Returns a string representation of the unit (e.g., "Police - Police1 (Speed:
        90)").
* **`Police` (Class):**
    * Inherits from `EmergencyUnit`.
    * Handles "Crime" incidents.
    * Constructor takes `name` and `speed` as parameters.
    * Overrides `CanHandle()` to return `true` for "Crime" incidents.
    * Overrides `RespondToIncident()` to simulate police response to a crime.
* **`Firefighter` (Class):**
    * Inherits from `EmergencyUnit`.
    * Handles "Fire" incidents.
    * Constructor takes `name` and `speed` as parameters.
    * Overrides `CanHandle()` to return `true` for "Fire" incidents.
    * Overrides `RespondToIncident()` to simulate firefighter response to a fire.
* **`Ambulance` (Class):**
    * Inherits from `EmergencyUnit`.
    * Handles "Medical" incidents.
    * Constructor takes `name` and `speed` as parameters.
    * Overrides `CanHandle()` to return `true` for "Medical" incidents.
    * Overrides `RespondToIncident()` to simulate ambulance response to a medical emergency.
* **`Incident` (Class):**
    * Represents an emergency incident.
    * Properties:
        * `Type` (string): The type of incident ("Fire", "Crime", or "Medical").
        * `Location` (string): The location of the incident.
    * Constructor takes `type` and `location` as parameters.
    * `ToString()`: Returns a string representation of the incident (e.g., "Type: Fire, Location:
        City Hall").
* **`Simulation` (Class):**
    * Contains the `RunSimulation()` method, which manages the simulation.
    * Generates incidents, dispatches units, and calculates the score.
    * `GenerateRandomIncident(string[] locations, string[] incidentTypes)`: Generates a random
        incident.
    * `FindAvailableUnit(List<EmergencyUnit> units, string incidentType)`: Finds a unit that can
        handle the incident.
    * `GetUnitSpeedFromUser(string prompt)`: Gets the unit speed from the user with validation.
* **`Program` (Class):**
    * The entry point of the application.
    * Calls the `Simulation.RunSimulation()` method to start the simulation.

