using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Behavioral.Command
{
    class Reciver
    {
        public void Action()
        {
            Console.WriteLine("Called Reciver.Action()");
        }
    }

    abstract class Command
    {
        protected Reciver reciver;

        public Command(Reciver reciver)
        {
            this.reciver = reciver;
        }

        public abstract void Execute();
    }

    //class ConcreteCommand : Command
    //{
    //    public ConcreteCommand(Reciver reciver)
    //        : base(reciver)
    //    { 
    //    }

    //    public void Execute()
    //    {
    //        reciver.Action();
    //    }
    //}

    class Invoker
    {
        private Command _command;

        public void SetCommand(Command Command)
        {
            _command = Command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }

    class Example2
    {
        //public static void Main
    }
}
