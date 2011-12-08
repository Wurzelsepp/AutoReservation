using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoReservation.Common.Interfaces;
using AutoReservation.Service.Wcf;

namespace AutoReservation.Testing
{
    [TestClass]
    public class ServiceTestRemote : ServiceTestBase
    {

        [ClassInitialize]
        public static void Setup()
        {
            AutoReservationServiceHost.StartService();
        }

        [ClassCleanup]
        public static void TearDown()
        {
            AutoReservationServiceHost.StopService();
        }

        private IAutoReservationService target;
        protected override IAutoReservationService Target
        {
            get
            {
                if (target == null)
                {
                    ChannelFactory<IAutoReservationService> channelFactory = new ChannelFactory<IAutoReservationService>("AutoReservationService");
                    target = channelFactory.CreateChannel();
                }
                return target;
            }
        }
    }
    
    internal class AutoReservationServiceHost
    {
        internal static ServiceHost myServiceHost;

        internal static void StartService()
        {
            //Instantiate new ServiceHost 
            myServiceHost = new ServiceHost(typeof(AutoReservationService));

            //Open myServiceHost
            myServiceHost.Open();
        }

        internal static void StopService()
        {
            //Call StopService from your shutdown logic (i.e. dispose method)
            if (myServiceHost.State != CommunicationState.Closed)
                myServiceHost.Close();
        }
    }
}