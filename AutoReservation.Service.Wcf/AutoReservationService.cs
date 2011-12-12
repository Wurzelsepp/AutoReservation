﻿using System;
using System.Diagnostics;
using AutoReservation.Common.Interfaces;
using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;

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
        //sollte bei jedem Service-Aufruf ausgeführt werden
        //so wird auf der Konsole des Services immer ausgegeben, was gerade passiert.         
        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        //Im Normalfall müsste es hier genügen, eine Instanz der 
        //AutoReservationBusinessComponent zu halten und die eingehenden Calls mehr 
        //oder weniger direkt an diese weiterzureichen.

        public AutoDto GetAuto(int key)
        {
            WriteActualMethod();
            return instance.GetAuto(key).ConvertToDto();
            throw new NotImplementedException();
        }

        public ReservationDto GetReservation(int key)
        {
            WriteActualMethod();
            return instance.GetReservation(key).ConvertToDto();
            throw new NotImplementedException();
        }

        public KundeDto GetKunde(int key)
        {
            WriteActualMethod();
            return instance.GetKunde(key).ConvertToDto();
            throw new NotImplementedException();
        }

        public void AddAuto(AutoDto auto)
        {
            WriteActualMethod();
            instance.AddAuto(auto.ConvertToEntity());
            throw new NotImplementedException();
        }

        public void AddReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            instance.AddResevation(reservation.ConvertToEntity());
            throw new NotImplementedException();
        }

        public void AddKunde(KundeDto kunde)
        {
            WriteActualMethod();
            instance.AddKunde(kunde.ConvertToEntity());
            throw new NotImplementedException();
        }

        public void UpdateAuto(AutoDto modified, AutoDto original)
        {
            WriteActualMethod();
            instance.EditAuto(original.ConvertToEntity(), modified.ConvertToEntity());
            throw new NotImplementedException();
        }

        public void UpdateReservation(ReservationDto modified, ReservationDto original)
        {
            WriteActualMethod();
            instance.EditReservation(original.ConvertToEntity(), modified.ConvertToEntity());
            throw new NotImplementedException();
        }

        public void UpdateKunde(KundeDto modified, KundeDto original)
        {
            WriteActualMethod();
            instance.EditKunde(original.ConvertToEntity(), modified.ConvertToEntity());
            throw new NotImplementedException();
        }

        public void DeleteAuto(AutoDto toDelete)
        {
            WriteActualMethod();
            instance.DeleteAuto(toDelete.ConvertToEntity());
            throw new NotImplementedException();
        }

        public void DeleteReservation(ReservationDto toDelete)
        {
            WriteActualMethod();
            instance.DeleteReservation(toDelete.ConvertToEntity());
            throw new NotImplementedException();
        }

        public void DeleteKunde(KundeDto toDelete)
        {
            WriteActualMethod();
            instance.DeleteKunde(toDelete.ConvertToEntity());
            throw new NotImplementedException();
        }


        public List<AutoDto> Autos
        {
            get
            {
                WriteActualMethod();
                List<AutoDto> ret = new List<AutoDto>();
                foreach (Dal.Auto auto in instance.GetAutos())
                    ret.Add(auto.ConvertToDto());
                return ret;
            }          
        }

        public List<ReservationDto> Reservationen
        {
            get
            {
                WriteActualMethod();
                List<ReservationDto> ret = new List<ReservationDto>();
                foreach (Dal.Reservation res in instance.GetReservations())
                    ret.Add(res.ConvertToDto());
                return ret;
            }    
        }

        public List<KundeDto> Kunden
        {
            get
            {
                WriteActualMethod();
                List<KundeDto> ret = new List<KundeDto>();
                foreach (Dal.Kunde kunde in instance.GetKunden())
                    ret.Add(kunde.ConvertToDto());
                return ret;
            } 
        }
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