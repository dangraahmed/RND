﻿using System;
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
 
            try
            {
                //if (args[0].ToUpper().Equals("ON"))
                if ("ON" == "ON")
                {
                    s.StoreAndExecute(switchUp);
                    Console.ReadLine();
                    return;
                }
                if (args[0].ToUpper().Equals("OFF"))
                {
                    s.StoreAndExecute(switchDown);
                    return;
                }
                Console.WriteLine("Argument \"ON\" or \"OFF\" is required.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Arguments required.");
            }
            
        }
    }
}
