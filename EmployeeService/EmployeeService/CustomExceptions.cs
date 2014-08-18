using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EmployeeService
{
    [DataContract]
    public class EmployeeAlreadyExistsFault
    {
        [DataMember]
        public int FaultId { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}