using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Ui.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        private readonly List<ReservationDto> reservationOriginal = new List<ReservationDto>();
        private ObservableCollection<ReservationDto> reservations;
        public ObservableCollection<ReservationDto> Reservations
        {
            get
            {
                if (reservations == null)
                {
                    reservations = new ObservableCollection<ReservationDto>();
                }
                return reservations;
            }
        }

        private ObservableCollection<AutoDto> autos;
        public ObservableCollection<AutoDto> Autos
        {
            get
            {
                if (autos == null)
                {
                    autos = new ObservableCollection<AutoDto>();
                }
                return autos;
            }
        }

        private ObservableCollection<KundeDto> kunden;
        public ObservableCollection<KundeDto> Kunden
        {
            get
            {
                if (kunden == null)
                {
                    kunden = new ObservableCollection<KundeDto>();
                }
                return kunden;
            }
        }

        private ReservationDto selectedReservation;
        public ReservationDto SelectedReservation
        {
            get { return selectedReservation; }
            set
            {
                if (selectedReservation != value)
                {
                    SendPropertyChanging(() => SelectedReservation);
                    selectedReservation = value;
                    SendPropertyChanged(() => SelectedReservation);
                }
            }
        }

        private ReservationDto selectedAuto;
        public ReservationDto SelectedAuto
        {
            get { return selectedAuto; }
            set
            {
                if (selectedAuto != value)
                {
                    SendPropertyChanging(() => SelectedAuto);
                    selectedAuto = value;
                    SendPropertyChanged(() => SelectedAuto);
                }
            }
        }

        private ReservationDto selectedKunde;
        public ReservationDto SelectedKunde
        {
            get { return selectedKunde; }
            set
            {
                if (selectedKunde != value)
                {
                    SendPropertyChanging(() => selectedKunde);
                    selectedKunde = value;
                    SendPropertyChanged(() => SelectedKunde);
                }
            }
        }


        #region Load-Command

        private RelayCommand loadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (loadCommand == null)
                {
                    loadCommand = new RelayCommand(
                        param => Load(),
                        param => CanLoad()
                    );
                }
                return loadCommand;
            }
        }

        protected override void Load()
        {
            Kunden.Clear();
            foreach (var kunde in Service.GetKunden())
            {
                Kunden.Add(kunde);
            }
            Autos.Clear();

            foreach (var auto in Service.GetAutos())
            {
                Autos.Add(auto);
            }
            Reservations.Clear();
            reservationOriginal.Clear();
            foreach (ReservationDto reservation in Service.GetReservationen())
            {
                Reservations.Add(reservation);
                reservationOriginal.Add((ReservationDto)reservation.Clone());
            }
            SelectedReservation = Reservations.FirstOrDefault();
        }

        private bool CanLoad()
        {
            return Service != null;
        }

        #endregion

        #region Save-Command

        private RelayCommand saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(
                        param => SaveData(),
                        param => CanSaveData()
                    );
                }
                return saveCommand;
            }
        }

        private void SaveData()
        {
            foreach (ReservationDto res in Reservations)
            {
                if (res.ReservationNr == default(int))
                {
                    Service.AddReservation(res);
                }
                else
                {
                    ReservationDto original = reservationOriginal.Where(ao => ao.ReservationNr == res.ReservationNr).FirstOrDefault();
                    Service.UpdateReservation(res, original);
                }
            }
            Load();
        }

        private bool CanSaveData()
        {
            if (Service == null)
            {
                return false;
            }

            StringBuilder errorText = new StringBuilder();
            foreach (ReservationDto auto in Reservations)
            {
                string error = auto.Validate();
                if (!string.IsNullOrEmpty(error))
                {
                    errorText.AppendLine(auto.ToString());
                    errorText.AppendLine(error);
                }
            }

            ErrorText = errorText.ToString();
            return string.IsNullOrEmpty(ErrorText);
        }

        #endregion

        #region New-Command

        private RelayCommand newCommand;

        public ICommand NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new RelayCommand(
                        param => New(),
                        param => CanNew()
                    );
                }
                return newCommand;
            }
        }

        private void New()
        {
            Reservations.Add(new ReservationDto());
        }

        private bool CanNew()
        {
            return Service != null;
        }

        #endregion

        #region Delete-Command

        private RelayCommand deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(
                        param => Delete(),
                        param => CanDelete()
                    );
                }
                return deleteCommand;
            }
        }

        private void Delete()
        {
            Service.DeleteReservation(SelectedReservation);
            Load();
        }

        private bool CanDelete()
        {
            return
                SelectedReservation != null &&
                SelectedReservation.ReservationNr != default(int) &&
                Service != null;
        }

        #endregion

    }
}