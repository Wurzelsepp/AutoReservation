using AutoReservation.Service.Wcf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoReservation.Common.Interfaces;

namespace AutoReservation.Testing
{
    [TestClass]
    public class ServiceTestLocal : ServiceTestBase
    {

        private IAutoReservationService target;
        protected override IAutoReservationService Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationService();
                }
                return target;
            }
        }

    }
}