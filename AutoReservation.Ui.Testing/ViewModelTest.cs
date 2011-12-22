using AutoReservation.Testing;
using AutoReservation.Ui.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoReservation.Ui.Testing
{
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void AutosLoadTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoViewModel view = new AutoViewModel();
            Assert.IsTrue(view.LoadCommand.CanExecute(null));
            Assert.AreEqual(3, view.Autos.Count);
        }

        [TestMethod]
        public void KundenLoadTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            KundeViewModel view = new KundeViewModel();
            Assert.IsTrue(view.LoadCommand.CanExecute(null));
            Assert.AreEqual(4, view.Kunden.Count);
        }

        [TestMethod]
        public void ReservationenLoadTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            ReservationViewModel view = new ReservationViewModel();
            Assert.IsTrue(view.LoadCommand.CanExecute(null));
            Assert.AreEqual(1, view.Reservations.Count);
        }
    }
}