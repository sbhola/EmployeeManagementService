using System.Collections.Generic;
using System.ServiceModel;

namespace EmployeeService
{
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

}

