using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    interface IAutoReservationService
    {
        private virtual Dictionary<int, AutoDto> autos;
        private virtual Dictionary<int, ReservationDto> reservationen;
        private virtual Dictionary<int, KundeDto> kunden;

        public virtual List<AutoDto> GetAutos();
        public virtual List<ReservationDto> GetReservationen();
        public virtual List<KundeDto> GetKunden();

        public virtual AutoDto GetAuto(int key);
        public virtual ReservationDto GetReservation(int key);
        public virtual KundeDto GetKunde(int key);

        public virtual void AddAuto(AutoDto auto);
        public virtual void AddReservation(ReservationDto reservation);
        public virtual void AddKunde(KundeDto kunde);

        public virtual void UpdateAuto(AutoDto modified, AutoDto original);
        public virtual void UpdateReservation(ReservationDto modified, ReservationDto original);
        public virtual void UpdateKunde(KundeDto modified, KundeDto original);

        //unvollständig
    }
}
