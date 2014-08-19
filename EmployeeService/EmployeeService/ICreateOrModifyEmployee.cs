using System.ServiceModel;

namespace EmployeeService
{
    [ServiceContract]
    public interface ICreateOrModifyEmployee
    {
        [OperationContract]
        [FaultContract(typeof(EmployeeAlreadyExistsFault))]
        Employee CreateEmployee(string name, string remarks);

        [OperationContract (Name = "AddRemarksById")]
        [FaultContract(typeof(EmployeeDoesNotExists))]
        void AddRemarks(int id, string remarks);

        [OperationContract(Name = "AddRemarksByName")]
        [FaultContract(typeof(EmployeeDoesNotExists))]
        void AddRemarks(string name, string remarks);

        [OperationContract (Name = "DeleteEmployeeById")]
        [FaultContract(typeof(EmployeeDoesNotExists))]
        void DeleteEmployee(int id);

        [OperationContract(Name = "DeleteEmployeeByName")]
        [FaultContract(typeof(EmployeeDoesNotExists))]
        void DeleteEmployee(string name);

        [OperationContract]
        void DisposeEmployeeList();
    }
}