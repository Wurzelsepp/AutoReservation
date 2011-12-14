﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("AutoReservationModel", "FK_Reservation_Auto", "Auto", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(AutoReservation.Dal.Auto), "Reservation", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(AutoReservation.Dal.Reservation), true)]
[assembly: EdmRelationshipAttribute("AutoReservationModel", "FK_Reservation_Kunde", "Kunde", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(AutoReservation.Dal.Kunde), "Reservation", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(AutoReservation.Dal.Reservation), true)]

#endregion

namespace AutoReservation.Dal
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class AutoReservationEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new AutoReservationEntities object using the connection string found in the 'AutoReservationEntities' section of the application configuration file.
        /// </summary>
        public AutoReservationEntities() : base("name=AutoReservationEntities", "AutoReservationEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new AutoReservationEntities object.
        /// </summary>
        public AutoReservationEntities(string connectionString) : base(connectionString, "AutoReservationEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new AutoReservationEntities object.
        /// </summary>
        public AutoReservationEntities(EntityConnection connection) : base(connection, "AutoReservationEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Auto> Autos
        {
            get
            {
                if ((_Autos == null))
                {
                    _Autos = base.CreateObjectSet<Auto>("Autos");
                }
                return _Autos;
            }
        }
        private ObjectSet<Auto> _Autos;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Kunde> Kunden
        {
            get
            {
                if ((_Kunden == null))
                {
                    _Kunden = base.CreateObjectSet<Kunde>("Kunden");
                }
                return _Kunden;
            }
        }
        private ObjectSet<Kunde> _Kunden;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Reservation> Reservationen
        {
            get
            {
                if ((_Reservationen == null))
                {
                    _Reservationen = base.CreateObjectSet<Reservation>("Reservationen");
                }
                return _Reservationen;
            }
        }
        private ObjectSet<Reservation> _Reservationen;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Autos EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToAutos(Auto auto)
        {
            base.AddObject("Autos", auto);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Kunden EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToKunden(Kunde kunde)
        {
            base.AddObject("Kunden", kunde);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Reservationen EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToReservationen(Reservation reservation)
        {
            base.AddObject("Reservationen", reservation);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AutoReservationModel", Name="Auto")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    [KnownTypeAttribute(typeof(LuxusklasseAuto))]
    [KnownTypeAttribute(typeof(MittelklasseAuto))]
    [KnownTypeAttribute(typeof(StandardAuto))]
    public abstract partial class Auto : EntityObject
    {
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Marke
        {
            get
            {
                return _Marke;
            }
            set
            {
                OnMarkeChanging(value);
                ReportPropertyChanging("Marke");
                _Marke = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Marke");
                OnMarkeChanged();
            }
        }
        private global::System.String _Marke;
        partial void OnMarkeChanging(global::System.String value);
        partial void OnMarkeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Tagestarif
        {
            get
            {
                return _Tagestarif;
            }
            set
            {
                OnTagestarifChanging(value);
                ReportPropertyChanging("Tagestarif");
                _Tagestarif = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Tagestarif");
                OnTagestarifChanged();
            }
        }
        private global::System.Int32 _Tagestarif;
        partial void OnTagestarifChanging(global::System.Int32 value);
        partial void OnTagestarifChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("AutoReservationModel", "FK_Reservation_Auto", "Reservation")]
        public EntityCollection<Reservation> Reservation
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Reservation>("AutoReservationModel.FK_Reservation_Auto", "Reservation");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Reservation>("AutoReservationModel.FK_Reservation_Auto", "Reservation", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AutoReservationModel", Name="Kunde")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Kunde : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Kunde object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="nachname">Initial value of the Nachname property.</param>
        /// <param name="vorname">Initial value of the Vorname property.</param>
        /// <param name="geburtsdatum">Initial value of the Geburtsdatum property.</param>
        public static Kunde CreateKunde(global::System.Int32 id, global::System.String nachname, global::System.String vorname, global::System.DateTime geburtsdatum)
        {
            Kunde kunde = new Kunde();
            kunde.Id = id;
            kunde.Nachname = nachname;
            kunde.Vorname = vorname;
            kunde.Geburtsdatum = geburtsdatum;
            return kunde;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Nachname
        {
            get
            {
                return _Nachname;
            }
            set
            {
                OnNachnameChanging(value);
                ReportPropertyChanging("Nachname");
                _Nachname = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Nachname");
                OnNachnameChanged();
            }
        }
        private global::System.String _Nachname;
        partial void OnNachnameChanging(global::System.String value);
        partial void OnNachnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Vorname
        {
            get
            {
                return _Vorname;
            }
            set
            {
                OnVornameChanging(value);
                ReportPropertyChanging("Vorname");
                _Vorname = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Vorname");
                OnVornameChanged();
            }
        }
        private global::System.String _Vorname;
        partial void OnVornameChanging(global::System.String value);
        partial void OnVornameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Geburtsdatum
        {
            get
            {
                return _Geburtsdatum;
            }
            set
            {
                OnGeburtsdatumChanging(value);
                ReportPropertyChanging("Geburtsdatum");
                _Geburtsdatum = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Geburtsdatum");
                OnGeburtsdatumChanged();
            }
        }
        private global::System.DateTime _Geburtsdatum;
        partial void OnGeburtsdatumChanging(global::System.DateTime value);
        partial void OnGeburtsdatumChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("AutoReservationModel", "FK_Reservation_Kunde", "Reservation")]
        public EntityCollection<Reservation> Reservation
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Reservation>("AutoReservationModel.FK_Reservation_Kunde", "Reservation");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Reservation>("AutoReservationModel.FK_Reservation_Kunde", "Reservation", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AutoReservationModel", Name="LuxusklasseAuto")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class LuxusklasseAuto : Auto
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new LuxusklasseAuto object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="marke">Initial value of the Marke property.</param>
        /// <param name="tagestarif">Initial value of the Tagestarif property.</param>
        public static LuxusklasseAuto CreateLuxusklasseAuto(global::System.Int32 id, global::System.String marke, global::System.Int32 tagestarif)
        {
            LuxusklasseAuto luxusklasseAuto = new LuxusklasseAuto();
            luxusklasseAuto.Id = id;
            luxusklasseAuto.Marke = marke;
            luxusklasseAuto.Tagestarif = tagestarif;
            return luxusklasseAuto;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Basistarif
        {
            get
            {
                return _Basistarif;
            }
            set
            {
                OnBasistarifChanging(value);
                ReportPropertyChanging("Basistarif");
                _Basistarif = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Basistarif");
                OnBasistarifChanged();
            }
        }
        private Nullable<global::System.Int32> _Basistarif;
        partial void OnBasistarifChanging(Nullable<global::System.Int32> value);
        partial void OnBasistarifChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AutoReservationModel", Name="MittelklasseAuto")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class MittelklasseAuto : Auto
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new MittelklasseAuto object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="marke">Initial value of the Marke property.</param>
        /// <param name="tagestarif">Initial value of the Tagestarif property.</param>
        public static MittelklasseAuto CreateMittelklasseAuto(global::System.Int32 id, global::System.String marke, global::System.Int32 tagestarif)
        {
            MittelklasseAuto mittelklasseAuto = new MittelklasseAuto();
            mittelklasseAuto.Id = id;
            mittelklasseAuto.Marke = marke;
            mittelklasseAuto.Tagestarif = tagestarif;
            return mittelklasseAuto;
        }

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AutoReservationModel", Name="Reservation")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Reservation : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Reservation object.
        /// </summary>
        /// <param name="reservationsNr">Initial value of the ReservationsNr property.</param>
        /// <param name="autoId">Initial value of the AutoId property.</param>
        /// <param name="kundeId">Initial value of the KundeId property.</param>
        /// <param name="von">Initial value of the Von property.</param>
        /// <param name="bis">Initial value of the Bis property.</param>
        public static Reservation CreateReservation(global::System.Int32 reservationsNr, global::System.Int32 autoId, global::System.Int32 kundeId, global::System.DateTime von, global::System.DateTime bis)
        {
            Reservation reservation = new Reservation();
            reservation.ReservationsNr = reservationsNr;
            reservation.AutoId = autoId;
            reservation.KundeId = kundeId;
            reservation.Von = von;
            reservation.Bis = bis;
            return reservation;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ReservationsNr
        {
            get
            {
                return _ReservationsNr;
            }
            set
            {
                if (_ReservationsNr != value)
                {
                    OnReservationsNrChanging(value);
                    ReportPropertyChanging("ReservationsNr");
                    _ReservationsNr = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ReservationsNr");
                    OnReservationsNrChanged();
                }
            }
        }
        private global::System.Int32 _ReservationsNr;
        partial void OnReservationsNrChanging(global::System.Int32 value);
        partial void OnReservationsNrChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 AutoId
        {
            get
            {
                return _AutoId;
            }
            set
            {
                OnAutoIdChanging(value);
                ReportPropertyChanging("AutoId");
                _AutoId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("AutoId");
                OnAutoIdChanged();
            }
        }
        private global::System.Int32 _AutoId;
        partial void OnAutoIdChanging(global::System.Int32 value);
        partial void OnAutoIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 KundeId
        {
            get
            {
                return _KundeId;
            }
            set
            {
                OnKundeIdChanging(value);
                ReportPropertyChanging("KundeId");
                _KundeId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("KundeId");
                OnKundeIdChanged();
            }
        }
        private global::System.Int32 _KundeId;
        partial void OnKundeIdChanging(global::System.Int32 value);
        partial void OnKundeIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Von
        {
            get
            {
                return _Von;
            }
            set
            {
                OnVonChanging(value);
                ReportPropertyChanging("Von");
                _Von = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Von");
                OnVonChanged();
            }
        }
        private global::System.DateTime _Von;
        partial void OnVonChanging(global::System.DateTime value);
        partial void OnVonChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Bis
        {
            get
            {
                return _Bis;
            }
            set
            {
                OnBisChanging(value);
                ReportPropertyChanging("Bis");
                _Bis = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Bis");
                OnBisChanged();
            }
        }
        private global::System.DateTime _Bis;
        partial void OnBisChanging(global::System.DateTime value);
        partial void OnBisChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("AutoReservationModel", "FK_Reservation_Auto", "Auto")]
        public Auto Auto
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Auto>("AutoReservationModel.FK_Reservation_Auto", "Auto").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Auto>("AutoReservationModel.FK_Reservation_Auto", "Auto").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Auto> AutoReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Auto>("AutoReservationModel.FK_Reservation_Auto", "Auto");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Auto>("AutoReservationModel.FK_Reservation_Auto", "Auto", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("AutoReservationModel", "FK_Reservation_Kunde", "Kunde")]
        public Kunde Kunde
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Kunde>("AutoReservationModel.FK_Reservation_Kunde", "Kunde").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Kunde>("AutoReservationModel.FK_Reservation_Kunde", "Kunde").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Kunde> KundeReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Kunde>("AutoReservationModel.FK_Reservation_Kunde", "Kunde");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Kunde>("AutoReservationModel.FK_Reservation_Kunde", "Kunde", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AutoReservationModel", Name="StandardAuto")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class StandardAuto : Auto
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new StandardAuto object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="marke">Initial value of the Marke property.</param>
        /// <param name="tagestarif">Initial value of the Tagestarif property.</param>
        public static StandardAuto CreateStandardAuto(global::System.Int32 id, global::System.String marke, global::System.Int32 tagestarif)
        {
            StandardAuto standardAuto = new StandardAuto();
            standardAuto.Id = id;
            standardAuto.Marke = marke;
            standardAuto.Tagestarif = tagestarif;
            return standardAuto;
        }

        #endregion
    
    }

    #endregion
    
}
