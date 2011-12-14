using AutoReservation.BusinessLayer;
using AutoReservation.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AutoReservation.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {

        [TestMethod]
        public void UpdateAutoTest()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                TestEnvironmentHelper.InitializeTestData();
                AutoReservationBusinessComponent arbc = new AutoReservationBusinessComponent();

                var res = (from auto in context.Autos select auto).FirstOrDefault().Id;
                //Console.WriteLine("Abgefragte Id:" + res);

                Auto autoOriginal = arbc.GetAuto(res);
                Auto autoModified = arbc.GetAuto(res);
                //Console.WriteLine("Marke original vorher:" + autoOriginal.Marke);
                //Console.WriteLine("Marke modified vorher:" + autoModified.Marke);

                autoModified.Marke = "Fiat Punto Abart";
                arbc.EditAuto(autoOriginal, autoModified);

                //Auto autoControl = arbc.GetAuto(res);
                //Console.WriteLine("Marke original nachher:" + autoOriginal.Marke);
                //Console.WriteLine("Marke control  nachher:" + autoControl.Marke);
                //Console.WriteLine("Marke modified nachher:" + autoModified.Marke);
                
                Assert.AreEqual(autoOriginal.Marke, autoModified.Marke, "UpdateAutoTest: Autos sind nicht gleich nach Update");
            }
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                TestEnvironmentHelper.InitializeTestData();

                AutoReservationBusinessComponent arbc = new AutoReservationBusinessComponent();

                var res = (from kunde in context.Kunden select kunde).FirstOrDefault().Id;

                Kunde kundeOriginal = arbc.GetKunde(res);
                Kunde kundeModified = arbc.GetKunde(res);

                kundeModified.Nachname = "Geiser";
                arbc.EditKunde(kundeOriginal, kundeModified);

                Assert.AreEqual(kundeOriginal.Nachname, kundeModified.Nachname, "UpdateKundeTest: Kunden sind nicht gleich nach Update");
            }        
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                TestEnvironmentHelper.InitializeTestData();

                AutoReservationBusinessComponent arbc = new AutoReservationBusinessComponent();

                var res = (from reservation in context.Reservationen select reservation).FirstOrDefault().ReservationsNr;

                Reservation reservationOriginal = arbc.GetReservation(res);
                Reservation reservationModified = arbc.GetReservation(res);

                reservationModified.Bis = new System.DateTime(2020, 1, 21);
                arbc.EditReservation(reservationOriginal, reservationModified);

                Assert.AreEqual(reservationOriginal.Bis, reservationModified.Bis, "UpdateReservationTest: Reservationen sind nicht gleich nach Update");
            }
        }
    }
}
