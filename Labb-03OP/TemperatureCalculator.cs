using System;
using System.Linq;
/*LINQ innehåller användbara funktioner för att smidigare skriva ut beräkningar */



namespace Labb_03OP
{
    public class TemperatureCalculator
    {
        private double[] temperatures;

        public TemperatureCalculator()
        {
            /* Statisk array med index för alla dagar i maj, 31st */
            temperatures = new double[31];
            Random random = new Random();

            /* Fyller arrayen med slumpade temperaturer mellan -5 och 25 °C */
            for (int i = 0; i < temperatures.Length; i++)
            {
                temperatures[i] = random.Next(-5, 26);
            }
        }

        public void DisplayTemperatures()
        {   /* temperaturerna genererade i index itereras genom en for-loop */
            Console.WriteLine("Temperaturer i maj");
            for (int i = 0; i < temperatures.Length; i++)
            {
                Console.WriteLine($"{i + 1} maj är temperaturen {temperatures[i]} °C");
            }
        }

        /* LINQ-funktion, beräknar medelvärdet i arrayen */
        public double GetAverageTemperature()
        {
            return temperatures.Average();
        }

        /* LINQ-funktion, Max() hittar högsta värde(temperatur) i index och + 1 ger oss motsvarande dag */
        public (int day, double temp) GetHighestTemperature()
        {
            double maxTemp = temperatures.Max();
            int day = Array.IndexOf(temperatures, maxTemp) + 1;
            return (day, maxTemp);
        }
        /* samma som funktionen ovanför, men istället lägsta temp */
        public (int day, double temp) GetLowestTemperature()
        {
            double minTemp = temperatures.Min();
            int day = Array.IndexOf(temperatures, minTemp) + 1;
            return (day, minTemp);
        }

        /*LINQ. OrderBy() sorterar temperaturerna stigande och ToArray() konverterar ordningen till en array */
        public double GetMedianTemperature()
        {
            var indexTemps = temperatures.OrderBy(t => t).ToArray();
            int midIndex = indexTemps.Length / 2; /* räknar ut medianen */
            if (indexTemps.Length % 2 == 0) /*kollar om antalet temperaturer är jämnt */
            {
                return (indexTemps[midIndex] - 1 + indexTemps[midIndex]) / 2; /*ger oss de 2 medianerna om jämt antal */
            }
            return indexTemps[midIndex]; /* ger medianen om ojämnt antal */
        }

        /* sorterar temperaturer i stigande ordning om ascending = true */
        public void SortTemperatures(bool ascending = true)
        {
            if (ascending)
            {
                Array.Sort(temperatures);
            }
            else
            {
                Array.Sort(temperatures);
                Array.Reverse(temperatures); /* vänder på ordningen i arrayen så det blir fallande istället */
            }
        }

        /* visar temperaturer över angivet värde */
        public void FilterTemperatures(double threshold)
        {
            Console.WriteLine($"Temperaturer över {threshold} °C"); /* for-loop itererar varje element i arrayen */
            for (int i = 0; i < temperatures.Length; i++)
            {
                if (temperatures[i] > threshold) /*kontroll om temp är högre än värdet angivet */
                {
                    Console.WriteLine($"{i + 1} maj: {temperatures[i]} °C"); /*skriver ut dag och temp om ovanstående stämmer */
                }
            }
        }

        public void GetTemperatureForDay(int day)
        {
            if (day < 1 || day > 31)    /* kontrollerar så att datumet är giltligt (1-31) */
            {
                Console.WriteLine("Ogiltigt val. Välj ett datum mellan 1 och 31.");
                return;
            }

            Console.WriteLine($"{day} maj: {temperatures[day - 1]} °C"); /* temp för specifik dag */
            if (day > 1)
            {
                Console.WriteLine($"{day} maj: {temperatures[day - 2]} °C"); /* temp för föregående dag (om ej lägre än 1) */
            }
            if (day < 31)
            {
                Console.WriteLine($"{day + 1} maj: {temperatures[day]} °C"); /* temp för nästa dag, (om ej större än 31) */
            }
        }
        public double GetMostFrequentTemperature()
        { /* Grupperar sen sorterar temperaturer inom index i fallande ordning, alltså högsta först */
            return temperatures.GroupBy(t => t) /* Gruppering av index */
                               .OrderByDescending(g => g.Count()) /* Sortering av grupper */
                               .First() /* Hämtar första gruppen i sorterade listan */
                               .Key; /* Nyckel för gruppen */
        }
    }
}