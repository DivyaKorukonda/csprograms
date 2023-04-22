using System;
using System.Net;

class Weather
{
    static void Main(string[] args)
    {
        while(true)
        {
            Console.Write("§§§§§§§§§§§§§§§§§§§§Enter city name: ");
            string cityName = Console.ReadLine();
            Console.Write("\n                   ");

            try
            {
                string url = "https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appid=abe3a0f4d0b6cebfbe7393b4b4e3aa28&units=metric";
                WebClient client = new WebClient();
                string json = client.DownloadString(url);

                int index = json.IndexOf("\"temp\":") + 7;
                string tempString = json.Substring(index, 4);
                float temperature = float.Parse(tempString);

                Console.WriteLine("Temperature in " + cityName + " is " + temperature + "°C."); //(Alt + 0176 to get degree symbol)
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}