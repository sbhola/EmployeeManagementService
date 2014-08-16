using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeService
{
    public class EmployeeManagementService : ICreateOrModifyEmployee, IRetrieveEmpDetails
    {
        static List<Employee> Employees = new List<Employee>();

        public Employee CreateEmployee(int id, string name, string remarks)
        {
            if (Employees.Any(emp1 => emp1.EmpID == id))
            {
                throw new FaultException("Employee id Already present. Please try again");
            }

            Employee emp = new Employee();
            emp.EmpID = id;
            emp.EmpName = name;

            Remarks remark = new Remarks();
            remark.text = remarks;
            remark.remarkTimestamp = DateTime.Now;

            emp.Remark = remark;

            Employees.Add(emp);

            return emp;
        }

        public bool AddRemarks(int id, string remarks)
        {
            if (Employees.Any(emp => emp.EmpID == id))
            {
                //Employee selectedEmployee = Employees.Where(emp => emp.EmpID == id).First();
                //selectedEmployee.Remark.text = remarks;
                //Console.WriteLine("Remark changes");

                int index = Employees.IndexOf(Employees.Where(emp => emp.EmpID == id).First());
                Employees[index].Remark.text = remarks;
                Console.WriteLine("Remark changes");
                return true;
            }
            return false;
        }


        public Employee GetEmployeeDetailsByID(int id)
        {
            if (Employees.Any(emp => emp.EmpID == id))
            {
                Employee selectedEmployee = Employees.Where(emp => emp.EmpID == id).First();
                return selectedEmployee;
            }
            return null;
        }

        public List<Employee> GetAllEmployeeList()
        {
            return Employees;
        }

        public Employee GetEmployeeDetailsByName(string name)
        {
            if (Employees.Any(emp => emp.EmpName == name))
            {
                Employee selectedEmployee = Employees.Where(emp => emp.EmpName == name).First();
                return selectedEmployee;
            }
            return null;
        }


    }
}
