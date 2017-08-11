using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Structural.ObserverPattern.Example2
{
    public class WeatherData
    {
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float Pressure { get; set; }

        public WeatherData(float temp, float humid, float pres)
        {
            Temperature = temp;
            Humidity = humid;
            Pressure = pres;
        }
    }

    public class WeatherDataEventArgs : EventArgs
    {
        public WeatherData data { get; private set; }
        public WeatherDataEventArgs(WeatherData data)
        {
            this.data = data;
        }
    }

    public class WeatherDataProvider : IDisposable
    {
        public event EventHandler<WeatherDataEventArgs> RaiseWeatherDataChangedEvent;

        protected virtual void OnRaiseWeatherDataChangedEvent(WeatherDataEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<WeatherDataEventArgs> handler = RaiseWeatherDataChangedEvent;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void NotifyDisplays(float temp, float humid, float pres)
        {
            OnRaiseWeatherDataChangedEvent(new WeatherDataEventArgs(new WeatherData(temp, humid, pres)));
        }

        public void Dispose()
        {
            if (RaiseWeatherDataChangedEvent != null)
            {
                foreach (EventHandler<WeatherDataEventArgs> item in RaiseWeatherDataChangedEvent.GetInvocationList())
                {
                    RaiseWeatherDataChangedEvent -= item;
                }
            }
        }
    }

    class Example2
    {
    }
}
