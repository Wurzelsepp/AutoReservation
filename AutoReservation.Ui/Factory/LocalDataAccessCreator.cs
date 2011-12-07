using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReservation.Common.Interfaces;

namespace AutoReservation.Ui.Factory
{
    class LocalDataAccessCreator:Creator
    {
        public override IAutoReservationService CreateAutoReservationServiceInstance()
        {
            return GetCreatorInstance().CreateAutoReservationServiceInstance();
        }
    }
}
