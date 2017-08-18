using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Behavioral.Command
{
    public interface ICommand
    {
        void Execute();
    }

    public class Switch
    {
        private List<ICommand> _commands = new List<ICommand>();

        public void StoreAndExecute(ICommand command)
        {
            _commands.Add(command);
            command.Execute();
        }
    }

    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Light Is On");
        }

        public void TrunOff()
        {
            Console.WriteLine("Light Is Off");
        }
    }

    public class FlipUpCommand : ICommand
    {
        private Light _light;

        public FlipUpCommand(Light _light)
        {
            this._light = _light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }

    }

    public class FlipDownCommand : ICommand
    {
        private Light _light;

        public FlipDownCommand(Light _light)
        {
            this._light = _light;
        }

        public void Execute()
        {
            _light.TrunOff();
        }
    }


    public class Program
    {
        private static void Main1(string[] args)
        {
            Light lamp = new Light();
            ICommand switchUp = new FlipUpCommand(lamp);
            ICommand switchDown = new FlipDownCommand(lamp);

            Switch s = new Switch();

            while (true)
            {
                Console.WriteLine("\"ON\" or \"OFF\" or \"X\"?");
                string command = Console.ReadLine();
                try
                {
                    if (command.ToUpper() == "ON")
                    {
                        s.StoreAndExecute(switchUp);
                        continue;
                    }
                    if (command.ToUpper() == "OFF")
                    {
                        s.StoreAndExecute(switchDown);
                        continue;
                    }
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Arguments required.");
                }
            }
            

        }
    }
}

/*
The Command Pattern falls under the category of Behavioural Design Patterns.If you have quite amount of experience in C# particularly WPF, 
you must have used DelegateCommand or Routed Command or RelayCommands. This internally uses the Command Pattern only. 
The Command Pattern can be used in any of the projects and we will quicky understand what is it and how to use it in our project.

The Command Pattern encapsulates a request as an object and gives it a known public interface. 
A request or action is mapped and stored as an object. The Invoker will be ultimately responsible for processing the request.
This clearly decouples the request from the invoker.This is more suited for scenarios where we implement Redo, Copy, Paste and Undo operations where the action is stored as an object. 
We generally use Menu or Shortcut key gestures for any of the preceding actions to be executed.
http://www.dotnettricks.com/learn/designpatterns/command-design-pattern-dotnet
*/
