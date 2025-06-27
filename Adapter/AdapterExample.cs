using System;

// Interface comum
public interface ITemperatureSensor
{
    double ReadTemperature();
}

// APIs dos sensores
public class SensorA
{
    public double GetTemperatureInCelsius() => 25.0;
}
public class SensorB
{
    public double ObtenerTemperaturaEnCentigrados() => 26.5;
}
public class SensorC
{
    public double FetchTempC() => 24.3;
}

// Adaptadores
public class SensorAAdapter : ITemperatureSensor
{
    private SensorA _sensorA;
    public SensorAAdapter(SensorA sensorA) { _sensorA = sensorA; }
    public double ReadTemperature() => _sensorA.GetTemperatureInCelsius();
}
public class SensorBAdapter : ITemperatureSensor
{
    private SensorB _sensorB;
    public SensorBAdapter(SensorB sensorB) { _sensorB = sensorB; }
    public double ReadTemperature() => _sensorB.ObtenerTemperaturaEnCentigrados();
}
public class SensorCAdapter : ITemperatureSensor
{
    private SensorC _sensorC;
    public SensorCAdapter(SensorC sensorC) { _sensorC = sensorC; }
    public double ReadTemperature() => _sensorC.FetchTempC();
}

// Demonstração
public class AdapterDemo
{
    public static void Main()
    {
        ITemperatureSensor[] sensores = new ITemperatureSensor[]
        {
            new SensorAAdapter(new SensorA()),
            new SensorBAdapter(new SensorB()),
            new SensorCAdapter(new SensorC())
        };
        int i = 1;
        foreach (var sensor in sensores)
        {
            Console.WriteLine($"Sensor {i++}: {sensor.ReadTemperature()} °C");
        }
    }
}
