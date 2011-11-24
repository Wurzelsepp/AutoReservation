using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    interface IAutoReservationService
    {
        private Dictionary<int, AutoDto> autos;
        private Dictionary<int, ReservationDto> reservationen;
        private Dictionary<int, KundeDto> kunden;

        public List<AutoDto> GetAutos()
    }
}
