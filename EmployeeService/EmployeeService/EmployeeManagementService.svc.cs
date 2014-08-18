using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace EmployeeService
{
    public class EmployeeManagementService : ICreateOrModifyEmployee, IRetrieveEmpDetails
    {
        /// <summary>
        /// _employees is a static employee list which contains records of all the employees.
        /// </summary>
        private static List<Employee> _employees = new List<Employee>();

        /// <summary>
        /// Throws if the employee id is already present in the _employees list
        /// Creates a new employee with given id,name and remarks.
        /// if successful, adds the new employee in the _employee list.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="name">string</param>
        /// <param name="remarks">string</param>
        /// <returns>Employee</returns>
        public Employee CreateEmployee(int id, string name, string remarks)
        {
            //Check if the employee id is already present in the list,is yes then throw.
            if (_employees.Any(emp1 => emp1.EmpId == id))
            {
                DisposeEmployeeList();

                EmployeeAlreadyExistsFault fault = new EmployeeAlreadyExistsFault
                {
                    FaultId = 101,
                    Message = "Employee Already Exists.Please try again"
                };
                throw new FaultException<EmployeeAlreadyExistsFault>
                    (fault, "Employee Already Exists.");
            }

            //Else create a new employee and add it in the list
            Employee emp = new Employee();
            emp.EmpId = id;
            emp.EmpName = name;

            Remarks remark = new Remarks();
            remark.Text = remarks;
            remark.RemarkTimestamp = DateTime.Now;

            emp.Remark = remark;

            _employees.Add(emp);

            return emp;
        }

        /// <summary>
        /// Adds remarks for an employee for a given employee ID.
        /// If remark successfully added for existing employee,Writes to the output(debug).
        /// Throws faultException if employee id is not present int the _employee list.
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="remarks">string</param>
        /// <returns>void</returns>
        public void AddRemarks(int id, string remarks)
        {
            if (_employees.Any(emp => emp.EmpId == id))
            {
                //Employee selectedEmployee = Employees.Where(emp => emp.EmpID == id).First();
                //selectedEmployee.Remark.text = remarks;
                //Console.WriteLine("Remark changes");

                int index = _employees.IndexOf(_employees.First(emp => emp.EmpId == id));
                _employees[index].Remark.Text = remarks;
                Debug.WriteLine("Remark changed");
            }
            else
            {
                DisposeEmployeeList();
                EmployeeDoesNotExists fault = new EmployeeDoesNotExists
                {
                    FaultId = 102,
                    Message = "Employee Does not exits"
                };
                throw new FaultException<EmployeeDoesNotExists>(fault, "Employee Does not exists.");
            }
        }

        public void DeleteEmployeeById(int id)
        {
            if (_employees.Any(emp => emp.EmpId == id))
            {
                int index = _employees.IndexOf(_employees.First(emp => emp.EmpId == id));
                //_employees.RemoveAt(index);
                _employees.Remove(_employees.First(emp => emp.EmpId == id));
                Debug.WriteLine("Employee removed");
            }
            else
            {
                DisposeEmployeeList();
                EmployeeDoesNotExists fault = new EmployeeDoesNotExists
                {
                    FaultId = 104,
                    Message = "Employee id you want to delete does not exists.Please try again."
                };
                throw new FaultException<EmployeeDoesNotExists>(fault, "Employee id you want to delete does not exists");
            }
        }

        /// <summary>
        /// Returns the employee object for a given employee ID.
        /// Throws is the requested employee ID is not present in the _employee list.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Employee</returns>
        public Employee GetEmployeeDetailsById(int id)
        {
            if (_employees.Any(emp => emp.EmpId == id))
            {
                Employee selectedEmployee = _employees.Where(emp => emp.EmpId == id).First();
                return selectedEmployee;
            }
            //throw new FaultException("Employee ID requested is not present.Please try again.", new FaultCode("Employee id requested is not present"));
            DisposeEmployeeList();
            throw FaultException.CreateFault(MessageFault.CreateFault(new FaultCode("103"), "Employee id requested is not present"));
        }

        /// <summary>
        /// Returns the list of all Employees.
        /// Throws fault if the list is empty.
        /// </summary>
        /// <returns>_employees</returns>
        public List<Employee> GetAllEmployeeList()
        {
            if (_employees.Count > 0)
                return _employees;


            //throw new FaultException("Employees List is empty. Please add some employees in the database and then try again", new FaultCode("Employees List is empty"));
            throw FaultException.CreateFault(MessageFault.CreateFault(new FaultCode("104"), "Employees List is empty"));
        }

        /// <summary>
        /// Returns Employee Details for a requested Employee Name
        /// Throws if the requested Emplyee Name does not exist in the list
        /// </summary>
        /// <param name="name">string</param>
        /// <returns>Employee</returns>
        public Employee GetEmployeeDetailsByName(string name)
        {
            if (_employees.Any(emp => emp.EmpName == name))
            {
                Employee selectedEmployee = _employees.Where(emp => emp.EmpName == name).First();
                return selectedEmployee;
            }
            else
            {
                DisposeEmployeeList();
                EmployeeDoesNotExists fault = new EmployeeDoesNotExists
                {
                    FaultId = 103,
                    Message = "Employee Name you searched does not Exist.Please try again"
                };
                throw new FaultException<EmployeeDoesNotExists>(fault, "Employee Name you searched does not Exist");

            }
        }

        public void DisposeEmployeeList()
        {
            //_employees.Clear();
            _employees = new List<Employee>();
        }

    }
}