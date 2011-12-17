using System.Collections.Generic;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Exceptions;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
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
        //[FaultContract(typeof(OptimisticConcurrencyException<AutoDto>))]
        //[MapExceptionToFault(typeof(ApplicationException), typeof(MyApplicationFault))]
        void UpdateAuto(AutoDto modified, AutoDto original);
        [OperationContract]
        [FaultContract(typeof(ReservationDto))]
        void UpdateReservation(ReservationDto modified, ReservationDto original);
        [OperationContract]
        [FaultContract(typeof(KundeDto))]
        void UpdateKunde(KundeDto modified, KundeDto original);

        //Löschen 
        [OperationContract]
        void DeleteAuto(AutoDto toDelete);
        [OperationContract]
        void DeleteReservation(ReservationDto toDelete);
        [OperationContract]
        void DeleteKunde(KundeDto toDelete);

        //Collections lesen
        [OperationContract]
        List<AutoDto> GetAutos();
        [OperationContract]
        List<ReservationDto> GetReservationen();
        [OperationContract]
        List<KundeDto> GetKunden();

    }
}
