using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.Dal;
using AutoReservation.Common.Exceptions;

namespace AutoReservation.Service.Wcf
{
    //Der Service Layer ist die eigentliche WCF-Serviceschnittstelle (Klasse 
    //AutoReservationService) und implementiert das Interface IAutoReservationService.  
    public class AutoReservationService : IAutoReservationService
    {
        public AutoReservationBusinessComponent instance;
        public AutoReservationService()
        {
            instance = new AutoReservationBusinessComponent();
        }

        //Gibt den Namen der aufrufenden Methode auf die Konsole aus.
        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        #region GET
        public AutoDto GetAuto(int key)
        {
            WriteActualMethod();
            return instance.GetAuto(key).ConvertToDto();
        }
        public ReservationDto GetReservation(int key)
        {
            WriteActualMethod();
            return instance.GetReservation(key).ConvertToDto();
        }
        public KundeDto GetKunde(int key)
        {
            WriteActualMethod();
            return instance.GetKunde(key).ConvertToDto();
        }
        #endregion GET

        #region GETALL
        public List<AutoDto> GetAutos()
        {
            WriteActualMethod();
            return instance.GetAutos().ConvertToDtos();
        }
        public List<ReservationDto> GetReservationen()
        {
            WriteActualMethod();
            return instance.GetReservations().ConvertToDtos();
        }
        public List<KundeDto> GetKunden()
        {
            WriteActualMethod();
            return instance.GetKunden().ConvertToDtos();
        }
        #endregion GETALL

        #region ADD
        public void AddAuto(AutoDto auto)
        {
            WriteActualMethod();
            instance.AddAuto(auto.ConvertToEntity());
        }
        public void AddReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            instance.AddResevation(reservation.ConvertToEntity());
        }
        public void AddKunde(KundeDto kunde)
        {
            WriteActualMethod();
            instance.AddKunde(kunde.ConvertToEntity());
        }
        #endregion ADD

        #region UPDATE
        public void UpdateAuto(AutoDto modified, AutoDto original)
        {
            WriteActualMethod();
            instance.EditAuto(original.ConvertToEntity(), modified.ConvertToEntity());
        }
        public void UpdateReservation(ReservationDto modified, ReservationDto original)
        {
            WriteActualMethod();
            instance.EditReservation(original.ConvertToEntity(), modified.ConvertToEntity());
        }
        public void UpdateKunde(KundeDto modified, KundeDto original)
        {
            WriteActualMethod();
            instance.EditKunde(original.ConvertToEntity(), modified.ConvertToEntity());
        }
        #endregion UPDATE

        #region DELETE
        public void DeleteAuto(AutoDto toDelete)
        {
            WriteActualMethod();
            instance.DeleteAuto(toDelete.ConvertToEntity());
        }
        public void DeleteReservation(ReservationDto toDelete)
        {
            WriteActualMethod();
            instance.DeleteReservation(toDelete.ConvertToEntity());
        }
        public void DeleteKunde(KundeDto toDelete)
        {
            WriteActualMethod();
            instance.DeleteKunde(toDelete.ConvertToEntity());
        }
        #endregion DELETE

    }
    //Der Service-Layer ist in dieser einfachen 
    //Applikation also nicht viel mehr als ein „Durchlauferhitzer“. Die wichtigste Aufgabe ist 
    //das Konvertieren von DTO’s in Objekte des Business-Layers sowie das Mapping von 
    //Exceptions auf WCF-FaultExceptions. In grösseren Projekten kann hier aber durchaus 
    //noch Funktionalität – z.B. Sicherheitslogik –  enthalten sein. 

    //Wie Sie das Hosting des WCF Services handhaben ist Ihnen überlassen.  
    //Empfohlen ist jedoch, die Projekte AutoReservation.Service.Wcf.Host und 
    //AutoReservation.Ui als Startprojekte zu definieren, so umgehen Sie allfällige Probleme 
    //mit dem Generieren von Service-Referenzen und dem Autohosting Feature im Visual 
    //Studio. 

    //Achtung: 
    //Sie benötigen für diesen Schritt Admin-Rechte auf dem Entwicklungsrechner. 
}