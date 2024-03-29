﻿using System;
using System.Collections.Generic;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoReservation.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }

        #region Abfragen einer Liste
        [TestMethod]
        public void AutosTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            //List<AutoDto> autoListTestData = TestEnvironmentHelper.InitializeAutoListTestData().ConvertToDtos();

            IAutoReservationService ars = Target;

            //Console.WriteLine("ServiceTestBase Vor GetAutos");

            List<AutoDto> autoList = ars.GetAutos();
            //Console.WriteLine("ServiceTestBase Marke: " + autoList[0].Marke);
            //Console.WriteLine("ServiceTestBase Nach GetAutos");

            //foreach (AutoDto auto in autoList)
            //{
            //    Console.WriteLine("Auto: " + auto.Marke);
            //    AutoDto found = autoListTestData.Find(delegate(AutoDto a) { return a.Marke == auto.Marke; });

            //    Console.WriteLine("Das wurde gefunden: " + found.Marke);
            Assert.AreEqual(3, autoList.Count);
            //}
        }

        [TestMethod]
        public void KundenTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            //List<KundeDto> kundenListTestData = TestEnvironmentHelper.InitializeKundenListTestData().ConvertToDtos();

            IAutoReservationService ars = Target;

            List<KundeDto> kundenList = ars.GetKunden();
            //foreach (KundeDto kunde in kundenList)
            //{
                //KundeDto found = kundenListTestData.Find(delegate(KundeDto k) { return k.Nachname == kunde.Nachname; });
                Assert.AreEqual(4, kundenList.Count);
            //}
        }

        [TestMethod]
        public void ReservationenTest()
        {

            TestEnvironmentHelper.InitializeTestData();
            //    List<ReservationDto> reservationListTestData = TestEnvironmentHelper.InitializeReservationTestData().ConvertToDtos();
            //    List<KundeDto> kundenListTestData = TestEnvironmentHelper.InitializeKundenListTestData().ConvertToDtos();
            //    List<AutoDto> autoListTestData = TestEnvironmentHelper.InitializeAutoListTestData().ConvertToDtos();

            //AutoDto foundAuto=null;
            //    KundeDto foundKunde=null;
            //    ReservationDto found = null;
                
            IAutoReservationService ars = Target;
                
                //Console.WriteLine("###reservationList abfüllen");
            List<ReservationDto> reservationList = ars.GetReservationen();

                //Console.WriteLine("###autoList abfüllen");
                //List<AutoDto> autoList = ars.GetAutos();

                //Console.WriteLine("###kundenList abfüllen");
                //List<KundeDto> kundenList= ars.GetKunden();

                //Console.WriteLine("###foreach Reservation");
                //foreach (ReservationDto reservation in reservationList)
                //{
                    //Console.WriteLine("###foreach Reservation suche von reservation." + reservation.ReservationsNr);
                    //found = reservationListTestData.Find(delegate(ReservationDto r) { return r.Von == reservation.Von; });

                    //Console.WriteLine("###foreach Auto suche von reservation.auto.id: " + reservation.AutoId);                    
                    //foreach (AutoDto auto in autoList)
                    //{
                    //    if (auto.Id == reservation.Auto.Id)
                    //    {
                            //Console.WriteLine("AutoId: " + auto.Id);
                            //Console.WriteLine("AutoMarke: " + auto.Marke);
                            //foundAuto = autoListTestData.Find(delegate(AutoDto a) { return a.Marke == auto.Marke; });
                        //}
                    //}

                    //Console.WriteLine("###foreach Kunde suche von reservation.kunde.id: " + reservation.KundeId);
                    //foreach (KundeDto kunde in kundenList)
                    //{
                    //    if (kunde.Id == reservation.Kunde.Id)
                    //    {
                            //Console.WriteLine("KundeId: " + kunde.Id);
                            //Console.WriteLine("KundeNachname: " + kunde.Nachname);
                            //foundKunde = kundenListTestData.Find(delegate(KundeDto k) { return k.Nachname == kunde.Nachname; });
                        //}
                    //}

                    //Console.WriteLine("Found Reservation: " + (found != null));
                    //Console.WriteLine("AutoId "+ reservation.AutoId + " Found Auto: " + (foundAuto != null));
                    //Console.WriteLine("KundeId " + reservation.KundeId + " Found Kunde: " + (foundKunde != null));

                    //Assert.IsTrue(found != null, "Reservation mit der Nr.: " + reservation.ReservationNr + " wurde nicht gefunden.");
                    //Assert.IsTrue(foundKunde != null, "Zugehöriger Kunde wurde nicht gefunden.");
                    //Assert.IsTrue(foundAuto != null, "Zugehöriges Auto wurde nicht gefunden.");
            Assert.AreEqual(1, reservationList.Count);
                    //Console.WriteLine("###foreach Reservation Ende");
            //}
        }
        #endregion Abfragen einer Liste
        #region Suche anhand des Primärschlüssels
        [TestMethod]
        public void GetAutoByIdTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;

            List<AutoDto> autoList = ars.GetAutos();
            foreach (AutoDto auto in autoList)
            {
                AutoDto found = ars.GetAuto(auto.Id);

                //Console.WriteLine("Das wurde gefunden: " + found.Id);
                Assert.AreEqual(auto.Id, found.Id, auto.Id + " wurde nicht gefunden.");
            }
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;

            List<KundeDto> kundeList = ars.GetKunden();
            foreach (KundeDto kunde in kundeList)
            {
                KundeDto found = ars.GetKunde(kunde.Id);

                //Console.WriteLine("Das wurde gefunden: " + found.Id);
                Assert.AreEqual(kunde.Id, found.Id, kunde.Id+ " wurde nicht gefunden.");
            }
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;

            List<ReservationDto> reservationList = ars.GetReservationen();
            foreach (ReservationDto reservation in reservationList)
            {
                ReservationDto found = ars.GetReservation(reservation.ReservationNr);

                //Console.WriteLine("Das wurde gefunden: " + found.ReservationNr);
                Assert.AreEqual(reservation.ReservationNr, found.ReservationNr, reservation.ReservationNr + " wurde nicht gefunden.");
            }
        }

        [TestMethod]
        public void GetReservationByIllegalNr()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;

            List<ReservationDto> reservationList = ars.GetReservationen();
            foreach (ReservationDto reservation in reservationList)
            {
                Assert.IsNull(ars.GetReservation(reservation.ReservationNr+reservationList.Count+1));
            }
        }
        #endregion Suche anhand des Primärschlüssels
        #region Einfügen
        [TestMethod]
        public void InsertAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;

            AutoDto addtest = new AutoDto();
            addtest.Marke = "Fiat Punto Abart";
            addtest.Tagestarif = 90;

            ars.AddAuto(addtest);

            List<AutoDto> autoList = ars.GetAutos();
            Assert.AreEqual(4, autoList.Count);
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;

            KundeDto addTest = new KundeDto();

            addTest.Nachname = "Person";
            addTest.Vorname = "Testoni";
            addTest.Geburtsdatum = new DateTime(1984,7, 21);

            ars.AddKunde(addTest);

            Assert.AreEqual(5, ars.GetKunden().Count);
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;

            ReservationDto addTest = new ReservationDto();

            addTest.Von = new DateTime(2020, 1, 10);
            addTest.Bis = new DateTime(2020, 1, 20);

            List<AutoDto> autoList = ars.GetAutos();
            addTest.Auto = autoList[1];
            
            List<KundeDto> kundeList = ars.GetKunden();
            addTest.Kunde = kundeList[1];

            ars.AddReservation(addTest);

            List<ReservationDto> reservationList = ars.GetReservationen();
            Assert.AreEqual(2, reservationList.Count);
        }
        #endregion Einfügen
        #region Updates
        [TestMethod]
        public void UpdateAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;

            List<AutoDto> autoListOriginale = ars.GetAutos();

            AutoDto updateOriginal = autoListOriginale[0];
            AutoDto updateModified = (AutoDto)updateOriginal.Clone();

            updateModified.Marke = "Fiat Punto Abart";

            ars.UpdateAuto(updateModified, updateOriginal);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;

            List<KundeDto> kundeListOriginale = ars.GetKunden();

            KundeDto updateOriginal = kundeListOriginale[0];
            KundeDto updateModified = (KundeDto)updateOriginal.Clone();
            
            updateModified.Vorname = "Annarosa";

            ars.UpdateKunde(updateModified, updateOriginal);

            List<KundeDto> kundeList = ars.GetKunden();
            foreach (KundeDto kunde in kundeList)
            {
                if (kunde.Nachname == updateModified.Nachname)
                {
                    Assert.AreEqual(updateModified.Vorname, kunde.Vorname);
                }
            }
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;

            List<ReservationDto> reservationList = ars.GetReservationen();
            ReservationDto updateOriginal = reservationList[0];
            ReservationDto updateModified = (ReservationDto) updateOriginal.Clone();

            List<AutoDto> autoList = ars.GetAutos();
            List<KundeDto> kundeList = ars.GetKunden();

            updateModified.Kunde.Id = kundeList[0].Id;
            updateModified.Auto.Id = autoList[0].Id;

            //Console.WriteLine("UpdateReservationTest updatetest.autoid: " + updateTest.AutoId);
            //Console.WriteLine("UpdateReservationTest updatetest.kundeid: " + updateTest.KundeId);
            //Console.WriteLine("UpdateReservationTest updatetest.autoid: " + updateTest.Von);
            //Console.WriteLine("UpdateReservationTest updatetest.autoid: " + updateTest.Bis);

            //Console.WriteLine("UpdateReservationTest updateoriginal.autoid: " + updateOriginal.AutoId);
            //Console.WriteLine("UpdateReservationTest updateoriginal.kundeid: " + updateOriginal.KundeId);
            //Console.WriteLine("UpdateReservationTest updateoriginal.autoid: " + updateOriginal.Von);
            //Console.WriteLine("UpdateReservationTest updateoriginal.autoid: " + updateOriginal.Bis);

            ars.UpdateReservation(updateModified, updateOriginal);

            reservationList = ars.GetReservationen();
            foreach (ReservationDto reservation in reservationList)
            {
                if (reservation.ReservationNr == updateModified.ReservationNr)
                {
                    Assert.AreEqual(updateOriginal.ReservationNr, updateModified.ReservationNr);
                }
            }
        }
        #endregion Updates
        
        #region Updates mit Optimistic Concurrency Verletzung
        [TestMethod]
        //[ExpectedException(typeof(OptimisticConcurrencyException<AutoDto>))]
        public void UpdateAutoTestWithOptimisticConcurrency()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;
            List<AutoDto> autoListOriginale = ars.GetAutos();

            AutoDto updateOriginal = (AutoDto)autoListOriginale[0].Clone();
            var updateModified1 = updateOriginal.Clone() as AutoDto;
            var updateModified2 = updateOriginal.Clone() as AutoDto;

            updateModified1.Marke = "Fiat Punto Abart";
            updateModified2.Marke = "Lamborghini Countach";

            try
            {
                ars.UpdateAuto(updateModified1, updateOriginal);
                ars.UpdateAuto(updateModified2, updateOriginal);
                Assert.Fail("No exception thrown");
            }
            catch (Exception concurrencyException)
            {
                Console.WriteLine("Message: " + concurrencyException.Message);
                var updatedFirst = Target.GetAutos().Find(m => m.Id == updateModified1.Id);
                var updatedSecond = Target.GetAutos().Find(m => m.Id == updateModified2.Id);
                Assert.AreEqual(updateModified1.Marke, updatedFirst.Marke);
                Assert.AreEqual(updateModified1.Marke, updatedSecond.Marke);
            }
        }

        [TestMethod]
        public void UpdateKundeTestWithOptimisticConcurrency()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;
            List<KundeDto> kundenListOriginale = ars.GetKunden();

            KundeDto updateOriginal = (KundeDto)kundenListOriginale[0].Clone();
            KundeDto updateModified1 = updateOriginal.Clone() as KundeDto;
            KundeDto updateModified2 = updateOriginal.Clone() as KundeDto;

            updateModified1.Vorname = "Peter";
            updateModified2.Vorname = "Markus";

            try
            {
                ars.UpdateKunde(updateModified1, updateOriginal);
                ars.UpdateKunde(updateModified2, updateOriginal);
                Assert.Fail("No exception thrown");
            }
            catch (Exception concurrencyException)
            {
                Console.WriteLine("Message: " + concurrencyException.Message);
                var updatedFirst = Target.GetKunden().Find(m => m.Id == updateModified1.Id);
                var updatedSecond = Target.GetKunden().Find(m => m.Id == updateModified2.Id);
                Assert.AreEqual(updateModified1.Nachname, updatedFirst.Nachname);
                Assert.AreEqual(updateModified1.Nachname, updatedSecond.Nachname);
            }
        }

        [TestMethod]
        public void UpdateReservationTestWithOptimisticConcurrency()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;
            List<ReservationDto> reservationListOriginale = ars.GetReservationen();

            ReservationDto updateOriginal = (ReservationDto)reservationListOriginale[0].Clone();
            ReservationDto updateModified1 = updateOriginal.Clone() as ReservationDto;
            ReservationDto updateModified2 = updateOriginal.Clone() as ReservationDto;

            updateModified1.Bis = new DateTime(2114, 7, 21);
            updateModified2.Bis = new DateTime(2014, 7, 21);

            try
            {
                ars.UpdateReservation(updateModified1, updateOriginal);
                ars.UpdateReservation(updateModified2, updateOriginal);
                Assert.Fail("No exception thrown");
            }
            catch (Exception concurrencyException)
            {
                Console.WriteLine("Message: " + concurrencyException.Message);
                var updatedFirst = Target.GetReservationen().Find(m => m.ReservationNr == updateModified1.ReservationNr);
                var updatedSecond = Target.GetReservationen().Find(m => m.ReservationNr == updateModified2.ReservationNr);
                Assert.AreEqual(updateModified1.Bis, updatedFirst.Bis);
                Assert.AreEqual(updateModified1.Bis, updatedSecond.Bis);
            }
        }
        #endregion Updates mit Optimistic Concurrency Verletzung
        #region Löschen
        //###################################
        [TestMethod]
        public void DeleteKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;

            List<KundeDto> kundenList = ars.GetKunden();
            KundeDto deleteTest = kundenList[0];
            
            ars.DeleteKunde(deleteTest);

            kundenList = ars.GetKunden();
            Assert.AreEqual(3, kundenList.Count);
        }

        [TestMethod]
        public void DeleteAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;

            List<AutoDto> autoList = ars.GetAutos();
            AutoDto deleteTest = autoList[1];

            ars.DeleteAuto(deleteTest);

            autoList = ars.GetAutos();
            Assert.AreEqual(2, autoList.Count);
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            IAutoReservationService ars = Target;

            List<ReservationDto> reservationList = ars.GetReservationen();
            ReservationDto deleteTest = reservationList[0];

            ars.DeleteReservation(deleteTest);
            
            reservationList = ars.GetReservationen();
            Assert.AreEqual(0, reservationList.Count);
        }
        #endregion Löschen
    }
}
