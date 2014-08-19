using System.Collections.Generic;
using System.ServiceModel;

namespace EmployeeService
{
    [ServiceContract]   
    public interface IRetrieveEmpDetails
    {
        [OperationContract(Name = "GetEmployeeDetailsById")]
        [FaultContract(typeof(EmployeeDoesNotExists))]
        Employee GetEmployeeDetails(int id);

        [OperationContract(Name = "GetEmployeeDetailsByName")]
        [FaultContract(typeof(EmployeeDoesNotExists))]
        Employee GetEmployeeDetails(string name);


        [OperationContract]
        [FaultContract(typeof(EmployeeDoesNotExists))]
        List<Employee> GetAllEmployeeList();

        //[OperationContract]
        //[FaultContract(typeof(EmployeeDoesNotExists))]
        //Employee GetEmployeeDetailsByName(string name);
    }

}

