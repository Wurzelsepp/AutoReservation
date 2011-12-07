using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReservation.Common.DataTransferObjects;
using System.ServiceModel;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract(Namespace ="http://localhost:7876/AutoReservationService")]
    public interface IAutoReservationService
    {
        //Eine Entität anhand des Primärschlüssels lesen
        [OperationContract]
        AutoDto GetAuto(int key);
        [OperationContract]
        ReservationDto GetReservation(int key);
        [OperationContract]
        KundeDto GetKunde(int key);

        //Einfügen 
        [OperationContract]
        void AddAuto(AutoDto auto);
        [OperationContract]
        void AddReservation(ReservationDto reservation);
        [OperationContract]
        void AddKunde(KundeDto kunde);

        //Update 
        [OperationContract]
        void UpdateAuto(AutoDto modified, AutoDto original);
        [OperationContract]
        void UpdateReservation(ReservationDto modified, ReservationDto original);
        [OperationContract]
        void UpdateKunde(KundeDto modified, KundeDto original);

        //Löschen 
        [OperationContract]
        void DeleteAuto(AutoDto toDelete);
        [OperationContract]
        void DeleteReservation(ReservationDto toDelete);
        [OperationContract]
        void DeleteKunde(KundeDto toDelete);
    }
}
