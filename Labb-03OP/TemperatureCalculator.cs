using System;
using System.Linq;
/*LINQ innehåller användbara funktioner för att smidigare skriva ut beräkningar */




namespace Labb_03OP
{
    public struct DayAndTemperature
    {
        public int day;
        public double temperature;

        public DayAndTemperature(int day, double temperature)
        {
            this.day = day;
            this.temperature = temperature;
        }
    }

    public class TemperatureCalculator
    {
        private double[] temperatures;

        private DayAndTemperature[] dayAndTemperatures;


        public TemperatureCalculator()
        {
            /* Statisk array med index för alla dagar i maj, 31st */

            dayAndTemperatures = new DayAndTemperature[31];

            Random random = new Random();

            /* Fyller arrayen med slumpade temperaturer mellan -5 och 25 °C */
            for (int i = 0; i < dayAndTemperatures.Length; i++)
            {
                
                dayAndTemperatures[i] = new DayAndTemperature(i+1, random.Next(-5, 26));
            }
        }

        public void DisplayTemperatures()
        {   /* temperaturerna genererade i index itereras genom en for-loop */
            Console.WriteLine("Temperaturer i maj");
            for (int i = 0; i < dayAndTemperatures.Length; i++)
            {
                Console.WriteLine($"{dayAndTemperatures[i].day} maj är temperaturen {dayAndTemperatures[i].temperature} °C");
            }
        }

        /* LINQ-funktion, beräknar medelvärdet i arrayen */
        public double GetAverageTemperature()
        {
            return dayAndTemperatures.Average(dayAndTemperature => dayAndTemperature.temperature);
        }

        /* LINQ-funktion, Max() hittar högsta värde(temperatur) i index och + 1 ger oss motsvarande dag */
        public DayAndTemperature GetHighestTemperature()
        {
            DayAndTemperature highestTemp = dayAndTemperatures.MaxBy(dayAndTemperature => dayAndTemperature.temperature);
            return highestTemp;
        }
        /* samma som funktionen ovanför, men istället lägsta temp */
        public DayAndTemperature GetLowestTemperature()
        {
            DayAndTemperature lowestDayTemp = dayAndTemperatures.MinBy(dayAndTemperature => dayAndTemperature.temperature);
            return lowestDayTemp;
        }

        /*LINQ. OrderBy() sorterar temperaturerna stigande och ToArray() konverterar ordningen till en array */
        public double GetMedianTemperature()
        {
            SortTemperatures(true); /* Vi ser till att arrayen är sorterad på temperatur för att kunna hämta ut rätt median */
            int midIndex = dayAndTemperatures.Length / 2; /* räknar ut medianen */
            if (dayAndTemperatures.Length % 2 == 0) /*kollar om antalet temperaturer är jämnt */
            {
                return (dayAndTemperatures[midIndex - 1].temperature + dayAndTemperatures[midIndex].temperature) / 2; /*ger oss de 2 medianerna om jämt antal */
            }
            return dayAndTemperatures[midIndex].temperature; /* ger medianen om ojämnt antal */
        }

        /* sorterar temperaturer i stigande ordning om ascending = true */
        public void SortTemperatures(bool ascending = true)
        {
            if (ascending)
            {
                dayAndTemperatures = dayAndTemperatures.OrderBy(dayAndTemperature => dayAndTemperature.temperature).ToArray();
            }
            else
            {
                dayAndTemperatures = dayAndTemperatures.OrderBy(dayAndTemperature => dayAndTemperature.temperature).ToArray();
                Array.Reverse(dayAndTemperatures); /* vänder på ordningen i arrayen så det blir fallande istället */
            }
        }

        public void SortByDate()
        {
            dayAndTemperatures = dayAndTemperatures.OrderBy(dayAndTemperature => dayAndTemperature.day).ToArray();
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