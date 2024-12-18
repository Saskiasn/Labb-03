using System;
using System.Linq;

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

            /* Fyller arrayen med slumpade temperaturer mellan -5 och 25 grader Celsius */
            for (int i = 0; i < temperatures.Length; i++)
            {
                temperatures[i] = random.Next(-5, 26);
            }
        }


    
    
    
    
    
    
    
    
    
    }













}