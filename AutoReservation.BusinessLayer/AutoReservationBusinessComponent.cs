using System;
using System.Linq;
using AutoReservation.Dal;
using System.Data;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {

        // Autos
        public void AddAuto(Auto auto)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.AddToAutos(auto);
            }
        }
        public void EditAuto(Auto autoOriginal, Auto autoModified)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                try
                {
                    context.Autos.Attach(autoOriginal);
                    context.Autos.ApplyCurrentValues(autoModified);
                    context.SaveChanges();
                }
                catch (OptimisticConcurrencyException ex)
                {
                    throw new LocalOptimisticConcurrencyException<Auto>(ex.Message);
                }
            }
        }
        public void DeleteAuto(Auto autoDelete)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
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
        }

        public Auto GetAuto(int key)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                var result = from auto in context.Autos
                                           where auto.Id == key
                                           select auto;
                return result.FirstOrDefault();
            }
        }

        public List<Auto> GetAutos()
        {
            return context.Autos.ToList<Auto>();
        }

        // Reservationen
        public void AddResevation(Reservation reservation)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.AddToReservationen(reservation);
            }
        }
        public void EditReservation(Reservation reservationOriginal, Reservation reservationModified)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {

                try
                {
                    context.Reservationen.Attach(reservationOriginal);
                    context.Reservationen.ApplyCurrentValues(reservationModified);
                    context.SaveChanges();
                }
                catch (OptimisticConcurrencyException ex)
                {
                    throw new LocalOptimisticConcurrencyException<Reservation>(ex.Message);
                }
            }
        }
        public void DeleteReservation(Reservation reservationDelete)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
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
        }

        public Reservation GetReservation(int key)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                var result = from reservation in context.Reservationen
                                where reservation.ReservationsNr == key
                                select reservation;
                return result.FirstOrDefault();
            }
        }

        public List<Reservation> GetReservations()
        {
            return context.Reservationen.ToList<Reservation>();
        }

        // Kunden
        public void AddKunde(Kunde kunde)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.AddToKunden(kunde);
            }
        }
        public void EditKunde(Kunde kundeOriginal, Kunde kundeModified)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                try
                {
                    context.Kunden.Attach(kundeOriginal);
                    context.Kunden.ApplyCurrentValues(kundeModified);
                    context.SaveChanges();
                }
                catch (OptimisticConcurrencyException ex)
                {
                    throw new LocalOptimisticConcurrencyException<Kunde>(ex.Message);
                }
            }
        }
        public void DeleteKunde(Kunde kundeDelete)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
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
        }

        public Kunde GetKunde(int key)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                var result = from kunde in context.Kunden
                                where kunde.Id == key
                                select kunde;
                return result.FirstOrDefault();
            }
        }

        public List<Kunde> GetKunden()
        {
            return context.Kunden.ToList<Kunde>();
        }
    }
}
