using System.ServiceModel;

namespace EmployeeService
{
    [ServiceContract]
    public interface ICreateOrModifyEmployee
    {
        [OperationContract]
        [FaultContract(typeof(EmployeeAlreadyExistsFault))]
        Employee CreateEmployee(string name, string remarks);

        [OperationContract]
        [FaultContract(typeof(EmployeeDoesNotExists))]
        void AddRemarks(int id, string remarks);

        [OperationContract]
        [FaultContract(typeof(EmployeeDoesNotExists))]
        void DeleteEmployeeById(int id);

        [OperationContract]
        void DisposeEmployeeList();
    }
}