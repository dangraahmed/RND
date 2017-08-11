using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Structural.FacadePattern
{

    public interface IEngineController
    {
        bool Running { get; }

        void Start();

        void Stop();
    }

    public interface ITachometerController
    {
        int Rpm { get; set; }

        int Limit { get; }
    }

    public interface ITransmissionController
    {
        int Gear { get; set; }

        int MaxGear { get; set; }

        void ShiftUp();

        void ShiftDown();
    }

    public interface ITractionControlController
    {
        bool Enabled { get; set; }

        void Enable();

        void Disable();
    }

    public interface IVehicleFacade
    {
        void Start();

        void Accelerate();

        void Brake();

        void Off();
    }



    public class EngineController : IEngineController
    {
        #region IEngineController Members

        public bool Running { get; private set; }

        public void Start()
        {
            Running = true;
            Console.WriteLine("Engine started");
        }

        public void Stop()
        {
            Running = false;
            Console.WriteLine("Engine stopped");
        }

        #endregion
    }

    public class TachometerController : ITachometerController
    {
        public TachometerController()
        {
            Limit = 1000;
        }

        public int Rpm { get; set; }

        public int Limit { get; private set; }

    }

    public class TransmissionController : ITransmissionController
    {
        public TransmissionController()
        {
            MaxGear = 6;
        }

        #region ITransmissionController Members

        public int Gear { get; set; }

        public int MaxGear { get; set; }

        public void ShiftUp()
        {
            if (Gear < MaxGear)
            {
                Gear++;
                Console.WriteLine(string.Format("Shifted up to gear {0}", Gear));
            }
        }

        public void ShiftDown()
        {
            if (Gear > 0)
            {
                Gear--;
                Console.WriteLine(string.Format("Shifted down to gear {0}", Gear));
            }
        }

        #endregion
    }

    public class TractionControlController : ITractionControlController
    {
        public bool Enabled { get; set; }

        public void Enable()
        {
            Enabled = true;
            Console.WriteLine("Traction controled enabled");
        }

        public void Disable()
        {
            Enabled = false;
            Console.WriteLine("Traction control disabled");
        }
    }

    public class VehicleFacade : IVehicleFacade
    {
        private readonly IEngineController _engineController;
        private readonly ITransmissionController _transmissionController;
        private readonly ITractionControlController _tractionControlController;
        private readonly ITachometerController _tachometerController;

        public VehicleFacade(IEngineController engineController, ITransmissionController transmissionController,
            ITractionControlController tractionControlController, ITachometerController tachometerController)
        {
            _engineController = engineController;
            _transmissionController = transmissionController;
            _tractionControlController = tractionControlController;
            _tachometerController = tachometerController;
        }
        
        public void Start()
        {
            _engineController.Start();
            _tractionControlController.Enable();
        }

        public void Accelerate()
        {
            _tachometerController.Rpm += 500;
            if (_tachometerController.Rpm >= _tachometerController.Limit || _transmissionController.Gear == 0)
            {
                _transmissionController.ShiftUp();
            }
        }

        public void Brake()
        {
            _tachometerController.Rpm -= 500;
            if (_tachometerController.Rpm <= 1500)
            {
                _transmissionController.ShiftDown();
            }
        }

        public void Off()
        {
            _tractionControlController.Disable();
            _engineController.Stop();
        }
    }

    class Example1
    {
        private static VehicleFacade _vehicle;
        static void Main1(string[] args)
        {
            _vehicle = new VehicleFacade(new EngineController(), new TransmissionController(),
                new TractionControlController(), new TachometerController());
            _vehicle.Start();

            for (int i = 0; i < 20; i++)
            {
                //System.Threading.Thread.Sleep(100);
                _vehicle.Accelerate();
            }

            for (int i = 0; i < 30; i++)
            {
                //System.Threading.Thread.Sleep(100);
                _vehicle.Brake();
            }

            _vehicle.Off();
            Console.ReadLine();
        }
    }

}

/*
"Provide a unified interface to a set of interfaces in a subsystem. Façade defines a higher-level interface that makes the subsystem easier to use."
So it is clear if the software system is composed of number of subsystems (which generally is the case) we may want to create a “facade” object which would call all these subsystems from one place. The main adavantages of incorporating a facade pattern are:
1) It provides a single simplified interface and hence makes the subsystems easier to use.
2) The client code is shielded from creating various objects of subsystem. This would be taken care of facade object.
3) Facade object decouples the subsystem from the client and other subsystems.
*/
