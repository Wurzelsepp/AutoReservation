using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    public interface IAutoReservationService
    {
        //Eine Entität anhand des Primärschlüssels lesen 
        AutoDto GetAuto(int key);
        ReservationDto GetReservation(int key);
        KundeDto GetKunde(int key);

        //Einfügen 
        void AddAuto(AutoDto auto);
        void AddReservation(ReservationDto reservation);
        void AddKunde(KundeDto kunde);

        //Update 
        void UpdateAuto(AutoDto modified, AutoDto original);
        void UpdateReservation(ReservationDto modified, ReservationDto original);
        void UpdateKunde(KundeDto modified, KundeDto original);

        //Löschen 
        void DeleteAuto(AutoDto toDelete);
        void DeleteReservation(ReservationDto toDelete);
        void DeleteKunde(KundeDto toDelete);
    }
}
