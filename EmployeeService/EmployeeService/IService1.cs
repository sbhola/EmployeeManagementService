using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeService
{

    [ServiceContract]
    public interface ICreateOrModifyEmployee
    {
        [OperationContract]
        Employee CreateEmployee(int id, string name, string remarks);

        [OperationContract]
        bool AddRemarks(int id, string remarks);
    }

    [ServiceContract]
    public interface IRetrieveEmpDetails
    {
        [OperationContract]
        Employee GetEmployeeDetailsByID(int id);

        [OperationContract]
        List<Employee> GetAllEmployeeList();
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

