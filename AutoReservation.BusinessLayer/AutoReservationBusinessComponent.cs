using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReservation.Dal;
using System.Data;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {
        AutoReservationEntities context;

        public AutoReservationBusinessComponent()
        {
            context = new AutoReservationEntities();
        }

        // Autos
        public void AddAuto(Auto auto)
        {
            context.AddToAutos(auto);
        }
        public void EditAuto(Auto autoOriginal, Auto autoModified)
        {
            try
            {
                context.Autos.Attach(autoOriginal);
                context.Autos.ApplyCurrentValues(autoModified);
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw new LocalOptimisticConcurrencyException<Auto>(ex.Message);
            }
        }
        public void DeleteAuto(Auto autoDelete)
        {
            try
            {
                context.Autos.Attach(autoDelete);
                context.Autos.DeleteObject(autoDelete);
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw new LocalOptimisticConcurrencyException<Auto>(ex.Message);
            }
        }

        public Auto GetAuto(int key)
        {
            return context.Autos.ElementAt(key);
        }

        public List<Auto> GetAutos()
        {
            return context.Autos.ToList<Auto>();
        }

        // Reservationen
        public void AddResevation(Reservation reservation)
        {
            context.AddToReservationen(reservation);
        }
        public void EditReservation(Reservation reservationOriginal, Reservation reservationModified)
        {
            try
            {
                context.Reservationen.Attach(reservationOriginal);
                context.Reservationen.ApplyCurrentValues(reservationModified);
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw new LocalOptimisticConcurrencyException<Reservation>(ex.Message);
            }
        }
        public void DeleteReservation(Reservation reservationDelete)
        {
            try
            {
                context.Reservationen.Attach(reservationDelete);
                context.Reservationen.DeleteObject(reservationDelete);
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw new LocalOptimisticConcurrencyException<Reservation>(ex.Message);
            }
        }

        public Reservation GetReservation(int key)
        {
            return (Reservation)context.Reservationen.ElementAt(key);
        }

        public List<Reservation> GetReservations()
        {
            return context.Reservationen.ToList<Reservation>();
        }

        // Kunden
        public void AddKunde(Kunde kunde)
        {
            context.AddToKunden(kunde);
        }
        public void EditKunde(Kunde kundeOriginal, Kunde kundeModified)
        {
            try
            {
                context.Kunden.Attach(kundeOriginal);
                context.Kunden.ApplyCurrentValues(kundeModified);
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw new LocalOptimisticConcurrencyException<Kunde>(ex.Message);
            }
        }
        public void DeleteKunde(Kunde kundeDelete)
        {
            try
            {
                context.Kunden.Attach(kundeDelete);
                context.Kunden.DeleteObject(kundeDelete);
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw new LocalOptimisticConcurrencyException<Kunde>(ex.Message);
            }
        }

        public Kunde GetKunde(int key)
        {
            return (Kunde)context.Kunden.ElementAt(key);
        }

        public List<Kunde> GetKunden()
        {
            return context.Kunden.ToList<Kunde>();
        }
    }
}
