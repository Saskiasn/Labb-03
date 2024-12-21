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

            Console.WriteLine("\nVällkommen till ditt väder program. Välj ett alternativ från meny genom att knappa in respektiva siffran ");
  
            Console.WriteLine("1: Lista för alla temperaturdata i maj");
            Console.WriteLine("2: Medeltemperaturen i maj");
            Console.WriteLine("3: Se varmaste/kallaste dagen i maj");
            Console.WriteLine("4: Mediantemperatur i maj");
            //Console.WriteLine("6: Sortera temperaturerna");
            //Console.WriteLine("7: Filtrera dagar över ett tröskelvärde");
            //Console.WriteLine("8: Hämta temperatur för en specifik dag");
            //Console.WriteLine("9: Vanligast förekommande temperatur");
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
                    Console.WriteLine($"Medeltemperaturen i maj är {medel}°C");

                    break;
                case '3':
                    HandleHotColdDay(calculator);

                    break;
                case '4':

                    break;

                case '5':
                    double median = calculator.GetMedianTemperature();
                    Console.WriteLine($"Mediantemperaturen i maj var {median} °C");

                    break;


                case '6':


                    break;

                case '7':


                    break;

                case '8':


                    break;


                case '9':
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



        public static void HandleTemperatureChoice(TemperatureCalculator calculator)
        {
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1: Se temperaturer i stigande ordning");
            Console.WriteLine("2: Se temperaturer i fallande ordning");
            Console.WriteLine("3: Se alla temperaturer sorterade efter datum");
            Console.WriteLine("Tryck på tangenten 1, 2 eller 3 för ditt val:");

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
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1: Se varmaste dagen i maj");
            Console.WriteLine("2: Se kallaste dagen i maj");
            Console.WriteLine("3: Gå tillbaka");
            Console.WriteLine("Tryck på tangenten 1, 2 eller 3 för ditt val:");

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