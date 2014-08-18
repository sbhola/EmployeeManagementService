using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;


namespace EmployeeService
{

    [ServiceContract]    
   
    public interface ICreateOrModifyEmployee
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))]        
        Employee CreateEmployee(int id, string name, string remarks);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void AddRemarks(int id, string remarks);
    }

    [ServiceContract]   
    public interface IRetrieveEmpDetails
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        Employee GetEmployeeDetailsById(int id);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        List<Employee> GetAllEmployeeList();

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        Employee GetEmployeeDetailsByName(string name);
    }

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

