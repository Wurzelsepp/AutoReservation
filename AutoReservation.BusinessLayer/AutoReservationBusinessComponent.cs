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
                    //context.AcceptAllChanges();
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
                var result = from auto in context.Autos
                             where auto.Id == key
                             select auto;
                return result.FirstOrDefault();
            }
        }
        public List<Auto> GetAutos()
        {
            //Console.WriteLine("AutoReservationBusinessComponent Anfang");
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                //Console.WriteLine("AutoReservationBusinessComponent Linq");
                var result = from auto in context.Autos
                             select auto;
                return result.ToList();
                //List<Auto> res = new List<Auto>();

                //Console.WriteLine("AutoReservationBusinessComponent foreach");
                //foreach (Auto auto in result)
                //{
                    //Console.WriteLine("AutoReservationBusinessComponent Auto.Marke: " + auto.Marke);
                    //res.Add(auto);
                //}
                //Console.WriteLine("AutoReservationBusinessComponent Ende");
                //return res;
            }

            //return context.Autos.ToList<Auto>();
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
                    throw new LocalOptimisticConcurrencyException<Reservation>(ex.Message) { Entity = reservationModified };
                }

            //using (AutoReservationEntities context = new AutoReservationEntities())
            //{
            //    try
            //    {
            //        context.Reservationen.Attach(reservationOriginal);
            //        context.Reservationen.ApplyCurrentValues(reservationModified);
            //        context.Reservationen.Execute(System.Data.Objects.MergeOption.PreserveChanges);
            //        context.AcceptAllChanges();
            //        context.SaveChanges();
            //    }
            //    catch (OptimisticConcurrencyException ex)
            //    {
            //        throw new LocalOptimisticConcurrencyException<Reservation>(ex.Message);
            //    }
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
                var result = from reservation in context.Reservationen
                             where reservation.ReservationsNr == key
                             select reservation;
                return result.FirstOrDefault();
            }
        }
        public List<Reservation> GetReservations()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                //Hier werden nicht alle reservationen zurückgegeben
                var result = from reservation in context.Reservationen
                             select reservation;

                //Test output begin
                Reservation test = (Reservation)result.FirstOrDefault();
                //Console.WriteLine("AutoReservationBusinessComponent Resultate GetReservation:");

                //Console.WriteLine("AutoId:" +test.AutoId );
                //Console.WriteLine("reservation auto ref: " + test.AutoReference);
                //Console.WriteLine("reservation auto Id: " + test.Auto.Id);
                //Console.WriteLine("reservation auto marke: " + test.Auto.Marke);
                //Console.WriteLine("reservation auto tagestarif: " + test.Auto.Tagestarif);

                //Console.WriteLine("reservation kunde ref: " + test.KundeReference);
                //Console.WriteLine("reservation kunde id: " + test.Kunde.Id);
                //Console.WriteLine("reservation kunde nachn: " + test.Kunde.Nachname);
                //Console.WriteLine("reservation kunde vorn: " + test.Kunde.Vorname);
                //Console.WriteLine("reservation kunde geb: " + test.Kunde.Geburtsdatum);
                //Test output end

                return result.ToList();
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
                    throw new LocalOptimisticConcurrencyException<Kunde>(ex.Message) { Entity = kundeModified };
                }
            }

            //using (AutoReservationEntities context = new AutoReservationEntities())
            //{
            //    try
            //    {
            //        context.Kunden.Attach(kundeOriginal);
            //        context.Kunden.ApplyCurrentValues(kundeModified);
            //        context.Kunden.Execute(System.Data.Objects.MergeOption.PreserveChanges);
            //        context.AcceptAllChanges();
            //        context.SaveChanges();
            //    }
            //    catch (OptimisticConcurrencyException ex)
            //    {
            //        throw new LocalOptimisticConcurrencyException<Kunde>(ex.Message);
            //    }
            //}
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
                var result = from kunde in context.Kunden
                             where kunde.Id == key
                             select kunde;
                return result.FirstOrDefault();
            }
        }
        public List<Kunde> GetKunden()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                var result = from kunde in context.Kunden
                             select kunde;
                return result.ToList();
            }

            //return context.Kunden.ToList<Kunde>();
        }
        #endregion Kunden
    }
}
