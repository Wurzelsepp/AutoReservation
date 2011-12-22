using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReservation.Common.Interfaces;
using System.ServiceModel;

namespace AutoReservation.Ui.Factory
{
    class RemoteDataAccessCraetor:Creator
    {
        public override IAutoReservationService CreateAutoReservationServiceInstance()
        {
            //ChannelFactory<IAutoReservationService> channelFactory = new ChannelFactory<IAutoReservationService>("AutoReservationService");	
            //return channelFactory.CreateChannel();
            return new ChannelProxy();
        }
    }
}
