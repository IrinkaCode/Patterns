//Задача. Урок 18 
//Реализуйте паттерн проектирования Команда.
//Контекстом будет система управления электронными устройствами в умном доме.
//Необходимо создать команды для выполнения различных действий (например,включение/выключение света, регулировка температуры

using System;
using System.Collections.Generic;

var light = new Light();
var thermostat = new Thermostat();

var lightOnCommand = new LightOnCommand(light);
var lightOffCommand = new LightOffCommand(light);
var setTemperatureCommand = new SetTemperatureCommand(thermostat, 22);

var remoteControl = new RemoteControl();
remoteControl.AddCommand(lightOnCommand);
remoteControl.AddCommand(setTemperatureCommand);
remoteControl.AddCommand(lightOffCommand);

remoteControl.ExecuteCommands();


public interface ICommand
{
    void Execute();
}

public class LightOnCommand : ICommand
{
    private readonly Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }
}

public class LightOffCommand : ICommand
{
    private readonly Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }
}

public class SetTemperatureCommand : ICommand
{
    private readonly Thermostat _thermostat;
    private readonly int _temperature;

    public SetTemperatureCommand(Thermostat thermostat, int temperature)
    {
        _thermostat = thermostat;
        _temperature = temperature;
    }

    public void Execute()
    {
        _thermostat.SetTemperature(_temperature);
    }
}

public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Свет включен.");
    }

    public void TurnOff()
    {
        Console.WriteLine("Свет выключен.");
    }
}

public class Thermostat
{
    public void SetTemperature(int temperature)
    {
        Console.WriteLine($"Температура установлена на {temperature} градусов.");
    }
}

public class RemoteControl
{
    private readonly List<ICommand> _commands = new List<ICommand>();

    public void AddCommand(ICommand command)
    {
        _commands.Add(command);
    }

    public void ExecuteCommands()
    {
        foreach (var command in _commands)
        {
            command.Execute();
        }
        _commands.Clear(); 
    }
}

