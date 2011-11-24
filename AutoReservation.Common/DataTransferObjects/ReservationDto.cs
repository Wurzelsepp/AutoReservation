using System;
using System.Runtime.Serialization;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class ReservationDto : DtoBase
    {
        private int reservationNr;
        private DateTime von;
        private DateTime bis;
        private AutoDto auto;
        private KundeDto kunde;

        public int ReservationNr { get { return reservationNr; } set {
            if (reservationNr != value)
            {
                SendPropertyChanging(() => ReservationNr);
                reservationNr = value;
                SendPropertyChanged(() => ReservationNr);
            }
        } }
        public DateTime Von { get { return von; } set {
            if (von != value)
            {
                SendPropertyChanging(() => Von);
                von = value;
                SendPropertyChanged(() => Von);
            }
        } }
        public DateTime Bis { get { return bis; } set {
            if (bis != value)
            {
                SendPropertyChanging(() => Bis);
                bis = value;
                SendPropertyChanged(() => Bis);
            }
        } }
        public AutoDto Auto { get { return auto; } set {
            if (auto != value)
            {
                SendPropertyChanging(() => Auto);
                auto = value;
                SendPropertyChanged(() => Auto);
            }
        } }
        public KundeDto Kunde { get { return kunde; } set {
            if (kunde != value)
            {
                SendPropertyChanging(() => Kunde);
                kunde = value;
                SendPropertyChanged(() => Kunde);
            }
        } }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (Von == DateTime.MinValue)
            {
                error.AppendLine("- Von-Datum ist nicht gesetzt.");
            }
            if (Bis == DateTime.MinValue)
            {
                error.AppendLine("- Bis-Datum ist nicht gesetzt.");
            }
            if (Von > Bis)
            {
                error.AppendLine("- Von-Datum ist grösser als Bis-Datum.");
            }
            if (Auto == null)
            {
                error.AppendLine("- Auto ist nicht zugewiesen.");
            }
            else
            {
                string autoError = Auto.Validate();
                if (!string.IsNullOrEmpty(autoError))
                {
                    error.AppendLine(autoError);
                }
            }
            if (Kunde == null)
            {
                error.AppendLine("- Kunde ist nicht zugewiesen.");
            }
            else
            {
                string kundeError = Kunde.Validate();
                if (!string.IsNullOrEmpty(kundeError))
                {
                    error.AppendLine(kundeError);
                }
            }


            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override object Clone()
        {
            return new ReservationDto
            {
                ReservationNr = ReservationNr,
                Von = Von,
                Bis = Bis,
                Auto = (AutoDto)Auto.Clone(),
                Kunde = (KundeDto)Kunde.Clone()
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                ReservationNr,
                Von,
                Bis,
                Auto,
                Kunde);
        }

	}
}
