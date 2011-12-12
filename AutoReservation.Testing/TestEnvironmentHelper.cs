using System.Data.SqlClient;
using System.Collections.Generic;
using AutoReservation.Dal;
using System;

namespace AutoReservation.Testing
{
    public static class TestEnvironmentHelper
    {
        private const string ConnectionString = @"Data Source=.\SQLExpress;Initial Catalog=AutoReservation;Integrated Security=True";

        private static void InsertKunden()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                // Open the connection.
                myConnection.Open();

                myCommand.CommandText = "INSERT INTO Kunde (Nachname, Vorname, Geburtsdatum) VALUES ('Nass', 'Anna', '05/05/1961')";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Kunde (Nachname, Vorname, Geburtsdatum) VALUES ('Beil', 'Timo', '09/09/1980')";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Kunde (Nachname, Vorname, Geburtsdatum) VALUES ('Pfahl', 'Martha', '07/03/1950')";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Kunde (Nachname, Vorname, Geburtsdatum) VALUES ('Zufall', 'Rainer', '11/11/1944')";
                myCommand.ExecuteNonQuery();
            }
        }

        private static void InsertAutos()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                // Open the connection.
                myConnection.Open();

                myCommand.CommandText = "INSERT INTO Auto (Marke, AutoKlasse, Tagestarif, Basistarif) " +
                                        " VALUES ('Fiat Punto', 2, 50, 0)";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Auto (Marke, AutoKlasse, Tagestarif, Basistarif) " +
                                        " VALUES ('VW Golf', 1, 120, 0)";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Auto (Marke, AutoKlasse, Tagestarif, Basistarif) " +
                                        " VALUES ('Audi S6', 0, 180, 50)";
                myCommand.ExecuteNonQuery();
            }
        }

        private static void InsertReservationen()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                // Open the connection.
                myConnection.Open();

                myCommand.CommandText = "INSERT INTO Reservation (AutoId, KundeId, Von, Bis)  " +
                                        "   SELECT  a.Id  , k.Id, '1/10/2020', '1/20/2020' " +
                                        "   FROM    Auto a, Kunde k " +
                                        "   WHERE   a.Marke = 'Audi S6' AND k.Nachname = 'Nass'";
                myCommand.ExecuteNonQuery();
            }
        }

        private static void DeleteAll()
        {
            using (SqlConnection myConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;

                // Open the connection.
                myConnection.Open();

                myCommand.CommandText = "DELETE FROM Reservation";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "DELETE FROM Auto";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "DELETE FROM Kunde";
                myCommand.ExecuteNonQuery();
            }
        }

        public static void InitializeTestData()
        {
            DeleteAll();
            InsertAutos();
            InsertKunden();
            InsertReservationen();
        }

        public static List<Auto> InitializeAutoListTestData()
        {
            List<Auto> autoListTestData = new List<Auto>();

            StandardAuto test1 = new StandardAuto();
            MittelklasseAuto test2 = new MittelklasseAuto();
            LuxusklasseAuto test3 = new LuxusklasseAuto();

            test1.Marke = "Fiat Punto";
            test1.Tagestarif = 50;

            test2.Marke = "VW Golf";
            test2.Tagestarif = 120;

            test3.Marke = "Audi S6";
            test3.Tagestarif = 180;

            autoListTestData.Add(test1);
            autoListTestData.Add(test2);
            autoListTestData.Add(test3);
            return autoListTestData;
        }
        public static List<Kunde> InitializeKundenListTestData()
        {
            List<Kunde> kundenListTestData = new List<Kunde>();

            Kunde test1 = new Kunde();
            Kunde test2 = new Kunde();
            Kunde test3 = new Kunde();
            Kunde test4 = new Kunde();

            test1.Nachname = "Nass";
            test1.Vorname = "Anna";
            test1.Geburtsdatum = new DateTime(1961, 5, 5);

            test2.Nachname = "Beil";
            test2.Vorname = "Timo";
            test2.Geburtsdatum = new DateTime(1980, 9, 9);

            test3.Nachname = "Pfahl";
            test3.Vorname = "Martha";
            test3.Geburtsdatum = new DateTime(1950, 3, 7);

            test4.Nachname = "Zufall";
            test4.Vorname = "Rainer";
            test4.Geburtsdatum = new DateTime(1944, 11, 11);

            kundenListTestData.Add(test1);
            kundenListTestData.Add(test2);
            kundenListTestData.Add(test3);
            kundenListTestData.Add(test4);
            return kundenListTestData;
        }
        public static List<Reservation> InitializeReservationTestData()
        {
            List<Reservation> reservationListTestData = new List<Reservation>();
            Reservation test1 = new Reservation();

            test1.Von = new DateTime(2020, 1, 10);
            test1.Bis = new DateTime(2020, 1, 20);

            reservationListTestData.Add(test1);
            return reservationListTestData;
        }

    }
}
