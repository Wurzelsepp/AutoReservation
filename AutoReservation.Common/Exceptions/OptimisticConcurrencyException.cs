using System.Runtime.Serialization;
using AutoReservation.Common.DataTransferObjects;
using System;

namespace AutoReservation.Common.Exceptions
{
    [DataContract]
    public class OptimisticConcurrencyException<T>: Exception where T : DtoBase
    {
        public OptimisticConcurrencyException(string msg) : base(msg) { }

        [DataMember]
        public T Entity { get; set; }
    }
}