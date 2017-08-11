using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Structural.ObserverPattern.Example1
{
    public interface ISubscriber
    {
        void Update(WeatherData data);
    }

    public interface IPublisher
    {
        void RegisterSubscriber(ISubscriber subscriber);
        void RemoveSubscriber(ISubscriber subscriber);
        void NotifySubscribers();
    }

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

    public class CurrentConditionsDisplay : ISubscriber
    {
        WeatherData data;
        IPublisher weatherData;

        public CurrentConditionsDisplay(IPublisher weatherDataProvider)
        {
            weatherData = weatherDataProvider;
            weatherData.RegisterSubscriber(this);
        }

        public void Display()
        {
            Console.WriteLine("Current Conditions : Temp = {0}Deg | Humidity = {1}% | Pressure = {2}bar", data.Temperature, data.Humidity, data.Pressure);
        }
       
        public void Update(WeatherData data)
        {
            this.data = data;
            Display();
        }
    }

    public class ForecastDisplay : ISubscriber, IDisposable
    {
        WeatherData data;
        IPublisher weatherData;

        public ForecastDisplay(IPublisher weatherDataProvider)
        {
            weatherData = weatherDataProvider;
            weatherData.RegisterSubscriber(this);
        }

        public void Display()
        {
            Console.WriteLine("Forecast Conditions : Temp = {0}Deg | Humidity = {1}% | Pressure = {2}bar", data.Temperature + 6, data.Humidity + 20, data.Pressure - 3);
        }

        public void Update(WeatherData data)
        {
            this.data = data;
            Display();
        }

        public void Dispose()
        {
            weatherData.RemoveSubscriber(this);
        }
    }

    public class WeatherDataProvider : IPublisher
    {
        List<ISubscriber> ListOfSubscribers;
        WeatherData data;
        public WeatherDataProvider()
        {
            ListOfSubscribers = new List<ISubscriber>();
        }
        public void RegisterSubscriber(ISubscriber subscriber)
        {
            ListOfSubscribers.Add(subscriber);
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            ListOfSubscribers.Remove(subscriber);
        }

        public void NotifySubscribers()
        {
            foreach (var sub in ListOfSubscribers)
            {
                sub.Update(data);
            }
        }

        private void MeasurementsChanged()
        {
            NotifySubscribers();
        }
        public void SetMeasurements(float temp, float humid, float pres)
        {
            data = new WeatherData(temp, humid, pres);           
            MeasurementsChanged();
        }
    }

    public class Example1
    {
        public static void Main1(string[] args)
        {
            WeatherDataProvider weatherData = new WeatherDataProvider();

            CurrentConditionsDisplay currentDisp = new CurrentConditionsDisplay(weatherData);            
            ForecastDisplay forecastDisp = new ForecastDisplay(weatherData);

            weatherData.SetMeasurements(40, 78, 3);
            Console.WriteLine();
            weatherData.SetMeasurements(45, 79, 4);
            Console.WriteLine();
            weatherData.SetMeasurements(46, 73, 6);

            //Remove forecast display
            forecastDisp.Dispose();
            Console.WriteLine();
            Console.WriteLine("Forecast Display removed");
            Console.WriteLine();
            weatherData.SetMeasurements(36, 53, 8);

            Console.Read();
        }
    }
}
