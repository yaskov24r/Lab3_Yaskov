using System;
using System.Collections.Generic;
public class Vehicle
{
    public string VehicleId { get; set; }
    public string VehicleType { get; set; }
    public double Speed { get; set; }
    public Vehicle(string vehicleId, string vehicleType, double speed)
    {
        VehicleId = vehicleId;
        VehicleType = vehicleType;
        Speed = speed;
    }
    public void UpdateSpeed(double newSpeed)
    {
        Speed = newSpeed;
        Console.WriteLine($"Транспортний засіб {VehicleId} змінив швидкість на {Speed} км/год.");
    }
}
public class TrafficLight
{
    public string Location { get; set; }
    public string CurrentColor { get; private set; }
    public TrafficLight(string location)
    {
        Location = location;
        CurrentColor = "Red";
    }
    public void ChangeColor(string newColor)
    {
        CurrentColor = newColor;
        Console.WriteLine($"Світлофор на {Location} змінив колір на {CurrentColor}.");
    }
}
public class RoadSensor
{
    public string SensorId { get; set; }
    public bool IsVehicleDetected { get; private set; }
    public RoadSensor(string sensorId)
    {
        SensorId = sensorId;
        IsVehicleDetected = false;
    }
    public void DetectVehicle()
    {
        IsVehicleDetected = true;
        Console.WriteLine($"Сенсор {SensorId}: транспортний засіб виявлено.");
    }
    public void ClearDetection()
    {
        IsVehicleDetected = false;
        Console.WriteLine($"Сенсор {SensorId}: виявлення очищене.");
    }
}
public class TrafficManagementSystem
{
    public List<Vehicle> Vehicles { get; private set; }
    public List<TrafficLight> TrafficLights { get; private set; }
    public List<RoadSensor> Sensors { get; private set; }
    public TrafficManagementSystem()
    {
        Vehicles = new List<Vehicle>();
        TrafficLights = new List<TrafficLight>();
        Sensors = new List<RoadSensor>();
    }
    public void AddVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
        Console.WriteLine($"Транспортний засіб {vehicle.VehicleId} додано до системи.");
    }
    public void AddTrafficLight(TrafficLight trafficLight)
    {
        TrafficLights.Add(trafficLight);
        Console.WriteLine($"Світлофор на {trafficLight.Location} додано до системи.");
    }
    public void AddSensor(RoadSensor sensor)
    {
        Sensors.Add(sensor);
        Console.WriteLine($"Сенсор {sensor.SensorId} додано до системи.");
    }
    public void ManageTraffic()
    {
        foreach (var trafficLight in TrafficLights)
        {
            if (Sensors.Exists(s => s.IsVehicleDetected))
            {
                trafficLight.ChangeColor("Green");
            }
            else
            {
                trafficLight.ChangeColor("Red");
            }
        }
    }
    public void SimulateTraffic()
    {
        foreach (var sensor in Sensors)
        {
            if (!sensor.IsVehicleDetected)
            {
                sensor.DetectVehicle();
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Створення об'єкта системи управління дорожнім рухом
        TrafficManagementSystem trafficSystem = new TrafficManagementSystem();
        // Додавання транспортних засобів
        Vehicle vehicle1 = new Vehicle("001", "Car", 60);
        Vehicle vehicle2 = new Vehicle("002", "Bus", 50);
        trafficSystem.AddVehicle(vehicle1);
        trafficSystem.AddVehicle(vehicle2);
        // Додавання світлофорів
        TrafficLight trafficLight1 = new TrafficLight("Main Street");
        TrafficLight trafficLight2 = new TrafficLight("Second Avenue");
        trafficSystem.AddTrafficLight(trafficLight1);
        trafficSystem.AddTrafficLight(trafficLight2);
        // Додавання сенсорів
        RoadSensor sensor1 = new RoadSensor("Sensor1");
        RoadSensor sensor2 = new RoadSensor("Sensor2");
        trafficSystem.AddSensor(sensor1);
        trafficSystem.AddSensor(sensor2);
        // Симуляція руху
        Console.WriteLine("\nСимуляція трафіку:");
        trafficSystem.SimulateTraffic();
        // Управління трафіком
        Console.WriteLine("\nУправління трафіком:");
        trafficSystem.ManageTraffic();
    }
}