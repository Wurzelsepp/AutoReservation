using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReservation.Common.Interfaces;
using AutoReservation.Ui.Properties;
using AutoReservation.Service.Wcf;

namespace AutoReservation.Ui.Factory
{
    abstract class Creator
    {
        public abstract IAutoReservationService CreateAutoReservationServiceInstance();

        public Creator GetCreatorInstance()
        {
            Type businessLayerType = Type.GetType(Settings.Default.BusinessLayerType);
            return (Creator)Activator.CreateInstance(businessLayerType);
        }
    }
}
