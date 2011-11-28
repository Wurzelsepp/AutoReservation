using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    interface IAutoReservationService
    {

        //Alle Entitäten lesen 
        public virtual List<AutoDto> GetAutos();
        public virtual List<ReservationDto> GetReservationen();
        public virtual List<KundeDto> GetKunden();
            
        //Eine Entität anhand des Primärschlüssels lesen 
        public virtual AutoDto GetAuto(int key);
        public virtual ReservationDto GetReservation(int key);
        public virtual KundeDto GetKunde(int key);

        //Einfügen 
        public virtual void AddAuto(AutoDto auto);
        public virtual void AddReservation(ReservationDto reservation);
        public virtual void AddKunde(KundeDto kunde);

        //Update 
        public virtual void UpdateAuto(AutoDto modified, AutoDto original);
        public virtual void UpdateReservation(ReservationDto modified, ReservationDto original);
        public virtual void UpdateKunde(KundeDto modified, KundeDto original);

        //Löschen 
        public virtual void DeleteAuto(AutoDto toDelete);
        public virtual void DeleteReservation(ReservationDto toDelete);
        public virtual void DeleteKunde(KundeDto toDelete);

    }
}
