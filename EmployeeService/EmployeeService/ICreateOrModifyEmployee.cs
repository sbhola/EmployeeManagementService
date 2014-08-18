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

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void DeleteEmployeeById(int id);

        [OperationContract]
        void DisposeEmployeeList();
    }
}