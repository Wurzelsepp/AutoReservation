using System;
using System.Linq;
using AutoReservation.Dal;
using System.Data;
using System.Collections.Generic;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {
        #region Autos
        public void AddAuto(Auto auto)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.AddToAutos(auto);
                context.SaveChanges();
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
                    Console.WriteLine("AutoReservationBusinessComponent ConcurrencyException");
                    context.Refresh(System.Data.Objects.RefreshMode.StoreWins, autoModified);
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
                    context.DeleteObject(autoDelete);
                    context.SaveChanges();
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
                return context.Autos.Where(a => a.Id == key).FirstOrDefault();
            }
        }
        public List<Auto> GetAutos()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                return context.Autos.ToList();
            }
        }
        #endregion Auto

        #region Reservationen
        public void AddResevation(Reservation reservation)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.AddToReservationen(reservation);
                context.SaveChanges();
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
                    Console.WriteLine("AutoReservationBusinessComponent ConcurrencyException");
                    //context.AcceptAllChanges();
                    context.Refresh(System.Data.Objects.RefreshMode.StoreWins, reservationModified);
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
                    context.DeleteObject(reservationDelete);
                    context.SaveChanges();
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
                return context.Reservationen.Include("Auto").Include("Kunde").Where(a => a.ReservationsNr == key).FirstOrDefault();
            }
        }
        public List<Reservation> GetReservations()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
              
                    return context.Reservationen.Include("Auto").Include("Kunde").ToList();
                
            }
        }
        #endregion Reservationen
        
        #region Kunden
        public void AddKunde(Kunde kunde)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.AddToKunden(kunde);
                context.SaveChanges();
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
                    context.Refresh(System.Data.Objects.RefreshMode.StoreWins, kundeModified);
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
                    context.DeleteObject(kundeDelete);
                    context.SaveChanges();
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
                return context.Kunden.Where(k => k.Id == key).FirstOrDefault();
            }
        }
        public List<Kunde> GetKunden()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                return context.Kunden.ToList();
            }
        }
        #endregion Kunden
    }
}
