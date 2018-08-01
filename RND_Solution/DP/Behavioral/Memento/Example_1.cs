using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP.Behavioral.Memento
{
    public class Example_1
    {
        public static void Main(string[] arg)
        {
            Originator<string> orig = new Originator<string>();

            orig.SetState("One");
            CareTaker<string>.SaveState(orig);
            orig.ShowState();

            orig.SetState("Two");
            CareTaker<string>.SaveState(orig);
            orig.ShowState();

            orig.SetState("Three");
            CareTaker<string>.SaveState(orig);
            orig.ShowState();

            CareTaker<string>.RestoreState(orig, 0);
            orig.ShowState();

            Console.ReadLine();
        }
    }

    /// <summary>
    ///object that stores the historical state
    /// </summary>
    /// <typeparam name="T">Type of object to store</typeparam>
    public class Memento<T>
    {
        private T state;

        public T GetState()
        {
            return state;
        }

        public void SetState(T state)
        {
            this.state = state;
        }
    }

    /// <summary>
    /// the object that we want to save and restore, such as a check point in an application
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Originator<T>
    {
        private T state;

        /// <summary>
        /// for saving the state
        /// </summary>
        /// <returns></returns>
        public Memento<T> CreateMemento()
        {
            Memento<T> m = new Memento<T>();
            m.SetState(state);
            return m;
        }

        /// <summary>
        /// for restoring the state
        /// </summary>
        /// <param name="m"></param>
        public void SetMemento(Memento<T> m)
        {
            state = m.GetState();
        }

        /// <summary>
        /// change the state of the Originator
        /// </summary>
        /// <param name="state"></param>
        public void SetState(T state)
        {
            this.state = state;
        }

        /// <summary>
        /// show the state of the Originator
        /// </summary>
        public void ShowState()
        {
            Console.WriteLine(state.ToString());
        }
    }

    /// <summary>
    /// object for the client to access
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CareTaker<T>
    {
        /// list of states saved
        private static List<Memento<T>> mementoList = new List<Memento<T>>();

        //save state of the originator
        public static void SaveState(Originator<T> orig)
        {
            mementoList.Add(orig.CreateMemento());
        }

        //restore state of the originator
        public static void RestoreState(Originator<T> orig, int stateNumber)
        {
            orig.SetMemento(mementoList[stateNumber]);
        }
    }
}
