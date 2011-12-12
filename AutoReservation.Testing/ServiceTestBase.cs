using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoReservation.Common.Interfaces;
using AutoReservation.Dal;
using AutoReservation.BusinessLayer;
using System;
using AutoReservation.Service.Wcf;
using System.Collections.Generic;

namespace AutoReservation.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }
        //Autos Kunden Reservationen
        //##########################
        //Updaten => sehe hier noch nicht den Unterschied zu Updates
        //noch nicht implementiert

        //Autos Kunden Reservationen
        //##########################
        //Abfragen einer Liste 
        [TestMethod]
        public void AutosTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            List<Auto> autoListTestData = TestEnvironmentHelper.InitializeAutoListTestData();

            IAutoReservationService ars = Target;

            List<Auto> autoList = DtoConverter.ConvertToEntities(ars.Autos);
            foreach (Auto auto in autoList){
                //Console.WriteLine("Auto: " + auto.Marke);
                Auto found = autoListTestData.Find(delegate(Auto a) { return a.Marke == auto.Marke; });

                //Console.WriteLine("Das wurde gefunden: "+ found.Marke);
                Assert.AreEqual(auto.Marke, found.Marke, auto.Marke + " wurde nicht gefunden.");
            }
        }

        [TestMethod]
        public void KundenTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            List<Kunde> kundenListTestData = TestEnvironmentHelper.InitializeKundenListTestData();

            IAutoReservationService ars = Target;

            List<Kunde> kundenList = DtoConverter.ConvertToEntities(ars.Kunden);
            foreach (Kunde kunde in kundenList)
            {
                Kunde found = kundenListTestData.Find(delegate(Kunde k) { return k.Nachname == kunde.Nachname; });
                Assert.AreEqual(kunde.Nachname, found.Nachname, kunde.Nachname + " wurde nicht gefunden.");
            }
        }

        [TestMethod]
        public void ReservationenTest()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                TestEnvironmentHelper.InitializeTestData();
                List<Reservation> reservationListTestData = TestEnvironmentHelper.InitializeReservationTestData();
                List<Kunde> kundenListTestData = TestEnvironmentHelper.InitializeKundenListTestData();
                List<Auto> autoListTestData = TestEnvironmentHelper.InitializeAutoListTestData();
                Auto foundAuto=null;
                Kunde foundKunde=null;
                Reservation found = null;
                IAutoReservationService ars = Target;
                
                //Console.WriteLine("###reservationList abfüllen");
                List<Reservation> reservationList = DtoConverter.ConvertToEntities(ars.Reservationen);

                //Console.WriteLine("###autoList abfüllen");
                List<Auto> autoList = DtoConverter.ConvertToEntities(ars.Autos);

                //Console.WriteLine("###kundenList abfüllen");
                List<Kunde> kundenList= DtoConverter.ConvertToEntities(ars.Kunden);

                //Console.WriteLine("###foreach Reservation");
                foreach (Reservation reservation in reservationList)
                {
                    //Console.WriteLine("###foreach Reservation suche von reservation." + reservation.ReservationsNr);
                    found = reservationListTestData.Find(delegate(Reservation r) { return r.Von == reservation.Von; });

                    //Console.WriteLine("###foreach Auto suche von reservation.auto.id: " + reservation.AutoId);                    
                    foreach (Auto auto in autoList)
                    {
                        if (auto.Id == reservation.AutoId)
                        {
                            //Console.WriteLine("AutoId: " + auto.Id);
                            //Console.WriteLine("AutoMarke: " + auto.Marke);
                            foundAuto = autoListTestData.Find(delegate(Auto a) { return a.Marke == auto.Marke; });
                        }
                    }

                    //Console.WriteLine("###foreach Kunde suche von reservation.kunde.id: " + reservation.KundeId);
                    foreach (Kunde kunde in kundenList)
                    {
                        if (kunde.Id == reservation.KundeId)
                        {
                            //Console.WriteLine("KundeId: " + kunde.Id);
                            //Console.WriteLine("KundeNachname: " + kunde.Nachname);
                            foundKunde = kundenListTestData.Find(delegate(Kunde k) { return k.Nachname == kunde.Nachname; });
                        }
                    }

                    //Console.WriteLine("Found Reservation: " + (found != null));
                    //Console.WriteLine("AutoId "+ reservation.AutoId + " Found Auto: " + (foundAuto != null));
                    //Console.WriteLine("KundeId " + reservation.KundeId + " Found Kunde: " + (foundKunde != null));

                    Assert.IsTrue(found != null, "Reservation mit der Nr.: " + reservation.ReservationsNr + " wurde nicht gefunden.");
                    Assert.IsTrue(foundKunde != null, "Zugehöriger Kunde wurde nicht gefunden.");
                    Assert.IsTrue(foundAuto != null, "Zugehöriges Auto wurde nicht gefunden.");
                    //Console.WriteLine("###foreach Reservation Ende");
                }
            }
        }

        //Autos Kunden Reservationen
        //##########################
        //Suche anhand des Primärschlüssels => ToDo ByIllegalNr noch machen
        [TestMethod]
        public void GetAutoByIdTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            List<Auto> autoListTestData = TestEnvironmentHelper.InitializeAutoListTestData();

            IAutoReservationService ars = Target;

            List<Auto> autoList = DtoConverter.ConvertToEntities(ars.Autos);
            foreach (Auto auto in autoList)
            {
                Auto found = DtoConverter.ConvertToEntity(ars.GetAuto(auto.Id));

                //Console.WriteLine("Das wurde gefunden: " + found.Id);
                Assert.AreEqual(auto.Id, found.Id, auto.Id + " wurde nicht gefunden.");
            }
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            List<Kunde> kundeListTestData = TestEnvironmentHelper.InitializeKundenListTestData();

            IAutoReservationService ars = Target;

            List<Kunde> kundeList = DtoConverter.ConvertToEntities(ars.Kunden);
            foreach (Kunde kunde in kundeList)
            {
                Kunde found = DtoConverter.ConvertToEntity(ars.GetKunde(kunde.Id));

                //Console.WriteLine("Das wurde gefunden: " + found.Id);
                Assert.AreEqual(kunde.Id, found.Id, kunde.Id+ " wurde nicht gefunden.");
            }
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            List<Reservation> reservationListTestData = TestEnvironmentHelper.InitializeReservationTestData();

            IAutoReservationService ars = Target;

            List<Reservation> reservationList = DtoConverter.ConvertToEntities(ars.Reservationen);
            foreach (Reservation reservation in reservationList)
            {
                Reservation found = DtoConverter.ConvertToEntity(ars.GetReservation(reservation.ReservationsNr));

                Console.WriteLine("Das wurde gefunden: " + found.ReservationsNr);
                Assert.AreEqual(reservation.ReservationsNr, found.ReservationsNr, reservation.ReservationsNr + " wurde nicht gefunden.");
            }
        }

        [TestMethod]
        public void GetReservationByIllegalNr()
        {
            TestEnvironmentHelper.InitializeTestData();
            List<Reservation> reservationListTestData = TestEnvironmentHelper.InitializeReservationTestData();

            IAutoReservationService ars = Target;

            List<Reservation> reservationList = DtoConverter.ConvertToEntities(ars.Reservationen);
            foreach (Reservation reservation in reservationList)
            {
                Assert.IsNull(ars.GetReservation(reservation.ReservationsNr+10));
            }
        }

        //Autos Kunden Reservationen
        //##########################
        //Einfügen 
        [TestMethod]
        public void InsertAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();

        }

        [TestMethod]
        public void InsertKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();

        }

        [TestMethod]
        public void InsertReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();

        }

        //Autos Kunden Reservationen
        //##########################
        //Updates 
        [TestMethod]
        public void UpdateAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();

        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();

        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();

        }

        //Autos Kunden Reservationen
        //##########################
        //Updates mit Optimistic Concurrency Verletzung 

        [TestMethod]
        public void UpdateAutoTestWithOptimisticConcurrency()
        {
            TestEnvironmentHelper.InitializeTestData();

        }

        [TestMethod]
        public void UpdateKundeTestWithOptimisticConcurrency()
        {
            TestEnvironmentHelper.InitializeTestData();

        }

        [TestMethod]
        public void UpdateReservationTestWithOptimisticConcurrency()
        {
            TestEnvironmentHelper.InitializeTestData();

        }

        //Autos Kunden Reservationen
        //##########################
        //Löschen 
        [TestMethod]
        public void DeleteKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();

        }

        [TestMethod]
        public void DeleteAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();

        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();

        }


//Die Funktionalität muss einmal als Test auf eine lokale Klasseninstanz (new 
//AutoReservationService()) und einmal als Test auf einen WCF-Service (via 
//ChannelFactory<T>) getestet werden. So kann sichergestellt werden, dass das 
//Verhalten der Serialisierungsmachanismen von WCF abgedeckt sind. 
 
//Tipp: 
//Verwenden Sie dazu die bereits bestehende Klasse ServiceTestBase. Die 
//erforderlichen Testmethoden sind bereits angegeben. 
    }
}
