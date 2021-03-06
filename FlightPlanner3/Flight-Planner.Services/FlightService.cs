﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;


namespace Flight_Planner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        public FlightService(IFlightPlannerDbContext context) : base(context) 
        {
        }

        public async Task<ServiceResult> AddFlight(Flight flight)
        {
            return Create(flight);
        }

        public async Task DeleteFlights()
        {
            _ctx.Flights.RemoveRange(_ctx.Flights);
            _ctx.Airports.RemoveRange(_ctx.Airports);
            await _ctx.SaveChangesAsync();
        }

        public async Task<ServiceResult> DeleteFlightById(int id)
        {
            var flight = await GetById(id);
            return Delete(flight);
        }

        public async Task<bool> FlightExists(Flight flight)
        {
            var li = await Query().ToListAsync();
            var res = li.Contains(flight);
            return res;
        }

        public async Task<IEnumerable<Flight>> GetFlights()
        {
            return await Query().ToListAsync();
        }
    }
}
