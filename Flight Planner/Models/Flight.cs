﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Flight_Planner.Models
{
    public class Flight
    {

        public int Id {get; set;}
        public Airport From { get; set; }
        public Airport To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Flight))
            {
                return false;
            }

            Flight flight = obj as Flight;

            return flight.From.Equals(this.From) &&
                flight.To.Equals(this.To) &&
                flight.Carrier.ToUpper().Trim() == this.Carrier.ToUpper().Trim() &&
                flight.DepartureTime == this.DepartureTime &&
                flight.ArrivalTime == this.ArrivalTime;
        }

        public static bool NotValidFlight(Flight flight) 
        {
            
            return flight.To == null || flight.From == null ||
                
                String.IsNullOrEmpty(flight.From.City) ||
                String.IsNullOrEmpty(flight.From.Country) ||
                String.IsNullOrEmpty(flight.From.AirportCode) ||
                String.IsNullOrEmpty(flight.To.City) ||
                String.IsNullOrEmpty(flight.To.Country) ||
                String.IsNullOrEmpty(flight.To.AirportCode) ||
                String.IsNullOrEmpty(flight.Carrier) ||
                String.IsNullOrEmpty(flight.DepartureTime) ||
                String.IsNullOrEmpty(flight.ArrivalTime);
      
        }
        public static bool IsSameAirport(Flight flight)
        {
            return flight.From.AirportCode.ToUpper().Trim() == flight.To.AirportCode.ToUpper().Trim();
        }

        public static bool NotValidDate(Flight flight) 
        {
            DateTime departureT = DateTime.ParseExact(flight.DepartureTime, "yyyy-MM-dd hh:mm", CultureInfo.InvariantCulture);
            DateTime arrivalT = DateTime.ParseExact(flight.ArrivalTime, "yyyy-MM-dd hh:mm", CultureInfo.InvariantCulture);
            int compareDate = DateTime.Compare(departureT,arrivalT);
            var ret = (compareDate > 0 || (flight.ArrivalTime == flight.DepartureTime)) ? true : false;
            return ret;
            
        }

    }

}