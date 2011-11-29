using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReservation.Dal;

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
            context.Autos.Attach(autoOriginal);
            context.Autos.ApplyCurrentValues(autoModified);
        }
        public void DeleteAuto(Auto autoDelete)
        {
            context.Autos.Attach(autoDelete);
            context.Autos.DeleteObject(autoDelete);
        }

        public Auto GetAuto(int key)
        {
            return context.Autos.ElementAt(key);
        }


        // Reservationen
        public void AddResevation(Reservation reservation)
        {
            context.AddToReservationen(reservation);
        }
        public void EditReservation(Reservation reservationOriginal, Reservation reservationModified)
        {
            context.Reservationen.Attach(reservationOriginal);
            context.Reservationen.ApplyCurrentValues(reservationModified);
        }
        public void DeleteReservation(Reservation reservationDelete)
        {
            context.Reservationen.Attach(reservationDelete);
            context.Reservationen.DeleteObject(reservationDelete);
        }

        public Reservation GetReservation(int key)
        {
            return (Reservation)context.Reservationen.ElementAt(key);
        }

        // Kunden
        public void AddKunde(Kunde kunde)
        {
            context.AddToKunden(kunde);
        }
        public void EditKunde(Kunde kundeOriginal, Kunde kundeModified)
        {
            context.Kunden.Attach(kundeOriginal);
            context.Kunden.ApplyCurrentValues(kundeModified);
        }
        public void DeleteKunde(Kunde kundeDelete)
        {
            context.Kunden.Attach(kundeDelete);
            context.Kunden.DeleteObject(kundeDelete);
        }

        public Kunde GetKunde(int key)
        {
            return (Kunde)context.Kunden.ElementAt(key);
        }
    }
}
