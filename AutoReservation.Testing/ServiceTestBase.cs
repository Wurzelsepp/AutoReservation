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
        //noch nicht implementiert
        //Updaten => sehe hier noch nicht den Unterschied zu Updates
        //Updates mit Concurrency Exception => versteh ich nicht wirklich??

        //Autos Kunden Reservationen: Abfragen einer Liste 
        //################################################
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

        //Autos Kunden Reservationen: Suche anhand des Primärschlüssels
        //#############################################################
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

        //Autos Kunden Reservationen: Einfügen
        //####################################
        [TestMethod]
        public void InsertAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();

            List<Auto> autoListTestData = TestEnvironmentHelper.InitializeAutoListTestData();

            IAutoReservationService ars = Target;
            StandardAuto addtest = new StandardAuto();
            addtest.Marke = "Fiat Punto Abart";
            addtest.Tagestarif = 90;

            ars.AddAuto(DtoConverter.ConvertToDto(addtest));

            List<Auto> autoList = DtoConverter.ConvertToEntities(ars.Autos);
            foreach (Auto auto in autoList)
            {
                if (auto.Marke == addtest.Marke)
                {
                    Assert.AreEqual(addtest, auto);
                }
            }
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();

            List<Kunde> kundeListTestData = TestEnvironmentHelper.InitializeKundenListTestData();

            IAutoReservationService ars = Target;
            Kunde addtest = new Kunde();

            addtest.Nachname = "Person";
            addtest.Vorname = "Testoni";
            addtest.Geburtsdatum = new DateTime(1984,7, 21);

            ars.AddKunde(DtoConverter.ConvertToDto(addtest));

            List<Kunde> kundeList = DtoConverter.ConvertToEntities(ars.Kunden);
            foreach (Kunde kunde in kundeList)
            {
                if (kunde.Nachname == addtest.Nachname)
                {
                    Assert.AreEqual(addtest, kunde);
                }
            }
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();

            List<Reservation> reservationListTestData = TestEnvironmentHelper.InitializeReservationTestData();

            IAutoReservationService ars = Target;
            Reservation addtest = new Reservation();

            addtest.Von = new DateTime(2020, 1, 10);
            addtest.Bis = new DateTime(2020, 1, 20);

            List<Auto> autoList = DtoConverter.ConvertToEntities(ars.Autos);
            foreach (Auto auto in autoList)
            {
                addtest.AutoId = auto.Id;
            }
            List<Kunde> kundeList = DtoConverter.ConvertToEntities(ars.Kunden);
            foreach (Kunde kunde in kundeList)
            {
                addtest.KundeId = kunde.Id;
            }

            ars.AddReservation(DtoConverter.ConvertToDto(addtest));

            List<Reservation> reservationList = DtoConverter.ConvertToEntities(ars.Reservationen);
            foreach (Reservation reservation in reservationList)
            {
                if (reservation.AutoId == addtest.AutoId && reservation.KundeId==addtest.KundeId)
                {
                    Assert.AreEqual(addtest, reservation);
                }
            }
        }

        //Autos Kunden Reservationen: Updates
        //###################################
        [TestMethod]
        public void UpdateAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();

            List<Auto> autoListTestData = TestEnvironmentHelper.InitializeAutoListTestData();

            IAutoReservationService ars = Target;
            StandardAuto updatetest = new StandardAuto();
            updatetest.Marke = "Fiat Punto Abart";
            updatetest.Tagestarif = 90;

            StandardAuto updateOriginal = new StandardAuto();

            updateOriginal.Marke = "Fiat Punto";
            updateOriginal.Tagestarif = 50;

            ars.UpdateAuto(DtoConverter.ConvertToDto(updatetest),DtoConverter.ConvertToDto(updateOriginal));

            List<Auto> autoList = DtoConverter.ConvertToEntities(ars.Autos);
            foreach (Auto auto in autoList)
            {
                if (auto.Marke == updatetest.Marke)
                {
                    Assert.AreEqual(updatetest, auto);
                }
            }
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();

            List<Kunde> kundeListTestData = TestEnvironmentHelper.InitializeKundenListTestData();

            IAutoReservationService ars = Target;
            Kunde updateTest = new Kunde();
            updateTest.Nachname = "Nass";
            updateTest.Vorname = "Annarosa";
            updateTest.Geburtsdatum = new DateTime(1961, 5, 5);

            Kunde updateOriginal = new Kunde();

            updateOriginal.Nachname = "Nass";
            updateOriginal.Vorname = "Anna";
            updateOriginal.Geburtsdatum = new DateTime(1961, 5, 5);

            ars.UpdateKunde(DtoConverter.ConvertToDto(updateTest), DtoConverter.ConvertToDto(updateOriginal));

            List<Kunde> kundeList = DtoConverter.ConvertToEntities(ars.Kunden);
            foreach (Kunde kunde in kundeList)
            {
                if (kunde.Nachname == updateTest.Nachname)
                {
                    Assert.AreEqual(updateTest.Nachname, kunde.Nachname);
                }
            }
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            int updateAutoId=0;
            int updateKundeId=0;
            Reservation updateTest = new Reservation();

            TestEnvironmentHelper.InitializeTestData();
            List<Reservation> reservationListTestData = TestEnvironmentHelper.InitializeReservationTestData();

            IAutoReservationService ars = Target;

            Reservation updateOriginal = new Reservation();
            List<Reservation> reservationList = DtoConverter.ConvertToEntities(ars.Reservationen);
            foreach (Reservation reservation in reservationList)
            {
                updateOriginal = reservation;
            }

            List<Auto> autoList = DtoConverter.ConvertToEntities(ars.Autos);
            foreach (Auto auto in autoList)
            {
                if (auto.Id != updateOriginal.AutoId)
                {
                    //Console.WriteLine("autoid: " + auto.Id);
                    //Console.WriteLine("automarke: " + auto.Marke);
                    updateAutoId = auto.Id;
                }
            }
            List<Kunde> kundeList = DtoConverter.ConvertToEntities(ars.Kunden);
            foreach (Kunde kunde in kundeList)
            {
                if (kunde.Id != updateOriginal.KundeId)
                {
                    updateKundeId = kunde.Id;
                }
            }
            updateTest.ReservationsNr = updateOriginal.ReservationsNr;
            updateTest.KundeId = updateKundeId;
            updateTest.AutoId = updateAutoId;
            updateTest.Von = updateOriginal.Von;
            updateTest.Bis = updateOriginal.Bis;

            //Console.WriteLine("UpdateReservationTest updatetest.autoid: " + updateTest.AutoId);
            //Console.WriteLine("UpdateReservationTest updatetest.kundeid: " + updateTest.KundeId);
            //Console.WriteLine("UpdateReservationTest updatetest.autoid: " + updateTest.Von);
            //Console.WriteLine("UpdateReservationTest updatetest.autoid: " + updateTest.Bis);

            //Console.WriteLine("UpdateReservationTest updateoriginal.autoid: " + updateOriginal.AutoId);
            //Console.WriteLine("UpdateReservationTest updateoriginal.kundeid: " + updateOriginal.KundeId);
            //Console.WriteLine("UpdateReservationTest updateoriginal.autoid: " + updateOriginal.Von);
            //Console.WriteLine("UpdateReservationTest updateoriginal.autoid: " + updateOriginal.Bis);

            ars.UpdateReservation(DtoConverter.ConvertToDto(updateTest), DtoConverter.ConvertToDto(updateOriginal));

            foreach (Reservation reservation in reservationList)
            {
                if (reservation.ReservationsNr == updateTest.ReservationsNr)
                {
                    Assert.AreEqual(updateOriginal.ReservationsNr, updateTest.ReservationsNr);
                }
            }
        }

        //Autos Kunden Reservationen: Updates mit Optimistic Concurrency Verletzung 
        //#########################################################################
        [TestMethod]
        public void UpdateAutoTestWithOptimisticConcurrency()
        {
            TestEnvironmentHelper.InitializeTestData();
            throw new NotImplementedException();
        }

        [TestMethod]
        public void UpdateKundeTestWithOptimisticConcurrency()
        {
            TestEnvironmentHelper.InitializeTestData();
            throw new NotImplementedException();
        }

        [TestMethod]
        public void UpdateReservationTestWithOptimisticConcurrency()
        {
            TestEnvironmentHelper.InitializeTestData();
            throw new NotImplementedException();
        }

        //Autos Kunden Reservationen: Löschen
        //###################################
        [TestMethod]
        public void DeleteKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            List<Kunde> kundeListTestData = TestEnvironmentHelper.InitializeKundenListTestData();

            IAutoReservationService ars = Target;
            List<Kunde> originalKundenList = DtoConverter.ConvertToEntities(ars.Kunden);
            Kunde deleteTest = originalKundenList[1];
            
            ars.DeleteKunde(DtoConverter.ConvertToDto(deleteTest));
            List<Kunde> modifiedKundenList = DtoConverter.ConvertToEntities(ars.Kunden);

            Assert.AreNotEqual(originalKundenList, modifiedKundenList);
        }

        [TestMethod]
        public void DeleteAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            List<Auto> autoListTestData = TestEnvironmentHelper.InitializeAutoListTestData();

            IAutoReservationService ars = Target;
            List<Auto> originalAutoList = DtoConverter.ConvertToEntities(ars.Autos);
            Auto deleteTest = originalAutoList[1];
            //Console.WriteLine("delAuto.id :" + deleteTest.Id);
            //Console.WriteLine("delAuto.marke: " + deleteTest.Marke);
            //Console.WriteLine("delAuto.tagestarif: " + deleteTest.Tagestarif);
            //Console.WriteLine("delAuto.reservation: " + deleteTest.Reservation);

            ars.DeleteAuto(DtoConverter.ConvertToDto(deleteTest));
            List<Auto> modifiedAutoList = DtoConverter.ConvertToEntities(ars.Autos);

            //foreach (Auto auto in modifiedAutoList)
            //{
            //    Console.WriteLine("Auto.id :" + auto.Id);
            //    Console.WriteLine("Auto.marke: " + auto.Marke);
            //    Console.WriteLine("Auto.tagestarif: " + auto.Tagestarif);
            //    Console.WriteLine("Auto.reservation: " + auto.Reservation);
            //}

            Assert.AreNotEqual(originalAutoList, modifiedAutoList);
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            List<Reservation> reservationListTestData = TestEnvironmentHelper.InitializeReservationTestData();

            IAutoReservationService ars = Target;
            List<Reservation> originalReservationList = DtoConverter.ConvertToEntities(ars.Reservationen);
            Reservation deleteTest = originalReservationList[0];

            ars.DeleteReservation(DtoConverter.ConvertToDto(deleteTest));
            List<Reservation> modifiedReservationList = DtoConverter.ConvertToEntities(ars.Reservationen);

            Assert.AreNotEqual(originalReservationList, modifiedReservationList);
        }
    }
}
