using System;
using System.Runtime.Serialization;

namespace EmployeeService
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmpId { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public Remarks Remark { get; set; }
    }

    public class Remarks
    {
        public string Text { get; set; }
        public DateTime RemarkTimestamp { get; set; }
    }
}