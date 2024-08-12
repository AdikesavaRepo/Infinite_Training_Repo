using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Library
{
    public class TravelConcession
    {
        public string CalculateConcession(int age)
        {
            const decimal TotalFare = 500m; 
            decimal calculatedFare = TotalFare;

            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                decimal concession = TotalFare * 0.3m;
                calculatedFare = TotalFare - concession;
                return $"Senior Citizen - Calculated Fare: {calculatedFare:C}";
            }
            else
            {
                return $"Ticket Booked - Fare: {TotalFare:C}";
            }
        }
    }
}
