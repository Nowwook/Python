using System;

namespace Command_Pattern_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var remote = new SimpleRemoteControl();

            var light = new Light();
            var garagedoor = new garagedoor();

            var lightOn = new LightOnCommand(light);
            var garageOpen = new GarageDoorOpenCommand(garagedoor);

            remote.SetCommand(lightOn);
            remote.ButtonWasPressed();

            remote.SetCommand(garageOpen);
            remote.ButtonWasPressed();
        }
    }
    public class SimpleRemoteControl
    {
        private ICommand _slot;

        public void SetCommand(ICommand command) => _slot = command;

        public void ButtonWasPressed() => _slot.Execute();
    }
    public class GarageDoor
    {
        public void Up() => Console.WriteLine("Garage Door is Open");

        public void Down() => Console.WriteLine("Garage Door is Closed");

        public void Stop() => Console.WriteLine("Garage Door is Stopped");

        public void LightOn() => Console.WriteLine("Garage light is on");

        public void LightOff() => Console.WriteLine("Garage light is off");
    }
    public class Light
    {
        public void On() => Console.WriteLine("Light is on");

        public void Off() => Console.WriteLine("Light is off");
    }
    public interface ICommand
    {
        void Execute();
    }
    public class GarageDoorOpenCommand : ICommand
    {
        private readonly GarageDoor _garageDoor;

        public GarageDoorOpenCommand(GarageDoor garageDoor)
        {
            _garageDoor = garageDoor;
        }

        public void Execute() => _garageDoor.Up();
    }
    public class LightOffCommand : ICommand
    {
        private readonly Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute() => _light.Off();
    }
    public class LightOnCommand : ICommand
    {
        private readonly Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute() => _light.On();
    }
}
