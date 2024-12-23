using System;

namespace Labb_03OP
{ 
    class Program
    {
        static void Main(string[] args)
        {

            // Skapa instans av klassen TemperatureCalculator
            TemperatureCalculator calculator = new TemperatureCalculator();

            // Call methods to test or display data
            //calculator.DisplayTemperatures();
            Console.WriteLine("___________________________________________________________________________________________________________");
            Console.WriteLine("\nVällkommen till ditt väder program. Välj ett alternativ från meny genom att knappa in respektiva siffran \n");
            Console.WriteLine("___________________________________________________________________________________________________________");
            while (true)
            {
                Console.WriteLine("\n1: Lista för alla temperaturdata i maj");
                Console.WriteLine("2: Medeltemperaturen i maj");
                Console.WriteLine("3: Se varmaste/kallaste dagen i maj");
                Console.WriteLine("4: Mediantemperatur i maj");
                Console.WriteLine("5: Filtrera dagar över ett tröskelvärde");
                Console.WriteLine("6: Hämta temperatur för en specifik dag");
                Console.WriteLine("7: Vanligast förekommande temperatur");
                Console.WriteLine("0: Avsluta");
                Console.Write("Ditt val: ");

                char inputChar = Console.ReadKey().KeyChar;

                switch (inputChar)
                {
                    case '1':
                        HandleTemperatureChoice(calculator);
                        break;

                    case '2':
                        double medel = calculator.GetAverageTemperature();
                        Console.WriteLine($"\n\nMedeltemperaturen i maj är {medel}°C");

                        break;
                    case '3':
                        HandleHotColdDay(calculator);

                        break;
                    case '4':
                        double median = calculator.GetMedianTemperature();
                        Console.WriteLine($"\n\nMediantemperaturen i maj var {median} °C");

                        break;

                    case '5':
                        Console.WriteLine("\n\nSkriv in lägsta temperaturen du vill visa");
                        string lowestTemp = Console.ReadLine();
                        double lowestTempDouble = Convert.ToDouble(lowestTemp);
                        calculator.FilterTemperatures(lowestTempDouble);

                        break;


                    case '6':
                        Console.WriteLine("\n\n Visa temperaturen för en specifik dag, ange dagen (1-31) för att visa temperaturen");
                        string day = Console.ReadLine();
                        int dayInt = Convert.ToInt32(day);
                        calculator.GetTemperatureForDay(dayInt);

                        break;

                    case '7':
                        double temp = calculator.GetMostFrequentTemperature();
                        Console.WriteLine($"\n\nVanligaste förekommande temperaturen är {temp} °C");

                        break;


                    case '0':
                        Console.WriteLine("\n\nProgrammet avslutas.");
                        Environment.Exit(0);
                        break;

                    // Trycker användaren på något annat än 1-2 får man felmeddelande
                    default:
                        Console.WriteLine("Ogiltigt val.\n");
                        Console.WriteLine("Programmet avslutas.");
                        Environment.Exit(0);
                        break;
                }


            }
        }



        public static void HandleTemperatureChoice(TemperatureCalculator calculator)
        {
            Console.WriteLine("\n\nVälj ett alternativ:\n");
            Console.WriteLine("1: Se temperaturer i stigande ordning");
            Console.WriteLine("2: Se temperaturer i fallande ordning");
            Console.WriteLine("3: Se alla temperaturer sorterade efter datum");
            Console.WriteLine("\nTryck på tangenten 1, 2 eller 3 för ditt val:\n");

            char inputChar = Console.ReadKey().KeyChar;

            // Hanterar användarens val
            switch (inputChar)
            {
                case '1': // Stigande ordning
                    calculator.SortTemperatures(true);
                    calculator.DisplayTemperatures();
                    break;

                case '2': // Fallande ordning
                    calculator.SortTemperatures(false);
                    calculator.DisplayTemperatures();
                    break;

                case '3': // Efter datum
                    Console.WriteLine("Temperaturer efter datum:");
                    calculator.SortByDate();
                    calculator.DisplayTemperatures(); // Visar utan att sortera
                    break;

                default: // Ogiltigt val
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }


        public static void HandleHotColdDay(TemperatureCalculator calculator)
        {
            Console.WriteLine("\nVälj ett alternativ:\n");
            Console.WriteLine("1: Se varmaste dagen i maj");
            Console.WriteLine("2: Se kallaste dagen i maj");
            Console.WriteLine("3: Gå tillbaka");
            Console.WriteLine("\nTryck på tangenten 1, 2 eller 3 för ditt val:\n");

            char inputChar = Console.ReadKey().KeyChar;

            // Hanterar användarens val
            switch (inputChar)
            {
                case '1': // Varmaste dagen
                    DayAndTemperature varmasteDagen = calculator.GetHighestTemperature();
                    Console.WriteLine($"Varmaste dagen är {varmasteDagen.day} maj. Temperaturen var {varmasteDagen.temperature}°C");

                    break;

                case '2': // Kallaste dagen
                    DayAndTemperature kallasteDagen = calculator.GetLowestTemperature();
                    Console.WriteLine($"Varmaste dagen är {kallasteDagen.day} maj. Temperaturen var {kallasteDagen.temperature}°C");
                    break;

                case '3': // Gå tillbaka
                    Console.WriteLine("Gå tillbaka:");

                    break;

                default: // Ogiltigt val
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }
    }
}