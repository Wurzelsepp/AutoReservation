using System;
using AutoReservation.BusinessLayer;
using AutoReservation.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoReservation.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {

        [TestMethod]
        public void UpdateAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent arbc = new AutoReservationBusinessComponent();
            
            Auto autoOriginal = arbc.GetAuto(1);
            Auto autoModified = arbc.GetAuto(1);

            autoModified.Marke="Fiat Punto Abart";
            arbc.EditAuto(autoOriginal, autoModified);

            autoOriginal = arbc.GetAuto(1);
            Assert.AreEqual(autoOriginal, autoModified, "UpdateAutoTest: Autos sind nicht gleich nach Update");
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();

            AutoReservationBusinessComponent arbc = new AutoReservationBusinessComponent();

            Kunde kundeOriginal = arbc.GetKunde(1);
            Kunde kundeModified = arbc.GetKunde(1);

            kundeModified.Nachname = "Geiser";
            arbc.EditKunde(kundeOriginal, kundeModified);

            kundeOriginal = arbc.GetKunde(1);
            Assert.AreEqual(kundeOriginal, kundeModified, "UpdateKundeTest: Kunden sind nicht gleich nach Update");
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            TestEnvironmentHelper.InitializeTestData();

            AutoReservationBusinessComponent arbc = new AutoReservationBusinessComponent();

            Reservation reservationOriginal = arbc.GetReservation(1);
            Reservation reservationModified = arbc.GetReservation(1);

            reservationModified.Bis = new System.DateTime(2020, 1, 21);
            arbc.EditReservation(reservationOriginal, reservationModified);

            reservationOriginal = arbc.GetReservation(1);
            Assert.AreEqual(reservationOriginal, reservationModified, "UpdateReservationTest: Reservationen sind nicht gleich nach Update");
       }
    }
}
