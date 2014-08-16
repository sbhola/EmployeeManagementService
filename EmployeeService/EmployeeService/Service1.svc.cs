using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeService
{
    public class EmployeeManagementService : ICreateOrModifyEmployee
    {
        List<Employee> Employees = new List<Employee>();

        public void CreateEmployee(int id, string name, string remarks)
        {
            Employee emp = new Employee();
            emp.EmpID = id;
            emp.EmpName = name;

            Remarks remark = new Remarks();
            remark.text = remarks;
            remark.remarkTimestamp = DateTime.Now;

            emp.Remark = remark;

            Employees.Add(emp);

        }

        public bool AddRemarks(int id, string remarks)
        {
            return false;
        }
    }
}
