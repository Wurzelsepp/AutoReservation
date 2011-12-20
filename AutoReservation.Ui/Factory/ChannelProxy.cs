using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using AutoReservation.Common.Interfaces;

namespace AutoReservation.Ui.Factory
{
    class ChannelProxy : ClientBase<IAutoReservationService>, IAutoReservationService
    {
        public List<Common.DataTransferObjects.AutoDto> GetAutos()
        {
            return Channel.GetAutos();
        }

        public List<Common.DataTransferObjects.KundeDto> GetKunden()
        {
            return Channel.GetKunden();
        }

        public List<Common.DataTransferObjects.ReservationDto> GetReservationen()
        {
            return Channel.GetReservationen();
        }

        public Common.DataTransferObjects.AutoDto GetAuto(int id)
        {
            return Channel.GetAuto(id);
        }

        public Common.DataTransferObjects.KundeDto GetKunde(int id)
        {
            return GetKunde(id);
        }

        public Common.DataTransferObjects.ReservationDto GetReservation(int id)
        {
            return Channel.GetReservation(id);
        }

        public void AddAuto(Common.DataTransferObjects.AutoDto auto)
        {
            Channel.AddAuto(auto);
        }

        public void AddKunde(Common.DataTransferObjects.KundeDto kunde)
        {
            Channel.AddKunde(kunde);
        }

        public void AddReservation(Common.DataTransferObjects.ReservationDto reservation)
        {
            Channel.AddReservation(reservation);
        }

        public void UpdateKunde(Common.DataTransferObjects.KundeDto modified, Common.DataTransferObjects.KundeDto original)
        {
            Channel.UpdateKunde(modified, original);
        }

        public void UpdateAuto(Common.DataTransferObjects.AutoDto modified, Common.DataTransferObjects.AutoDto original)
        {
            Channel.UpdateAuto(modified, original);
        }

        public void UpdateReservation(Common.DataTransferObjects.ReservationDto modified, Common.DataTransferObjects.ReservationDto original)
        {
            Channel.UpdateReservation(modified, original);
        }

        public void DeleteKunde(Common.DataTransferObjects.KundeDto kunde)
        {
            Channel.DeleteKunde(kunde);
        }

        public void DeleteAuto(Common.DataTransferObjects.AutoDto auto)
        {
            Channel.DeleteAuto(auto);
        }

        public void DeleteReservation(Common.DataTransferObjects.ReservationDto reservation)
        {
            Channel.DeleteReservation(reservation);
        }
    }
}
