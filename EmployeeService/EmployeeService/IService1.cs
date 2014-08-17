using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Channels;
using System.Text;


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
        Employee GetEmployeeDetailsByID(int id);

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
        public int EmpID { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public Remarks Remark { get; set; }

    }

    public class Remarks
    {
        public string text { get; set; }
        public DateTime remarkTimestamp { get; set; }
    }

}

