using DomainModel.Models;
using FlightManagementWebAPI.DatabaseContext;
using System.Collections.Generic;
using System.Linq;

namespace FlightManagementWebAPI.Repositories
{
    public class FlightRepository
    {
        private readonly AirportSystemContext _airportSystemContext;
        public FlightRepository(AirportSystemContext airportSystemContext)
        {
            _airportSystemContext = airportSystemContext;
        }

        public List<Flight> GetFlights()
        {
            return _airportSystemContext.Flights.ToList();
        }

        public void InsertFlight(Flight flight)
        {
            _airportSystemContext.Flights.Add(flight);
            _airportSystemContext.SaveChanges();
        }

        public Flight GetFlight(int flightId)
        {
            return _airportSystemContext.Flights
                .FirstOrDefault(flight => flight.Id == flightId);
        }

        public void UpdateFlight(Flight flight)
        {
            var flightForUpdate = GetFlight(flight.Id);
            if(flightForUpdate != null)
            {
                flightForUpdate.Number = flight.Number;
                flightForUpdate.AirportTo = flight.AirportTo;
                flightForUpdate.Carrier = flight.Carrier;
                flightForUpdate.FlightDate = flight.FlightDate;
                flightForUpdate.FlightTime = flight.FlightTime;

                _airportSystemContext.SaveChanges();
            }
        }

        public void DeleteFlight(int flightId)
        {
            var flightForDelete = GetFlight(flightId);
            if(flightForDelete != null)
            {
                _airportSystemContext.Flights.Remove(flightForDelete);
                _airportSystemContext.SaveChanges();
            }
        }

        public void ArchiveFlight(int flightId)
        {
            var flight = GetFlight(flightId);
            if(flight != null)
            {
                flight.IsArchived = true;
                _airportSystemContext.SaveChanges();
            }
        }

        public IEnumerable<Flight> GetArchivedFlights()
        {
            return _airportSystemContext.Flights.Where(flight => flight.IsArchived).ToList();
        }
    }
}
