using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMSClient.EMSReference;

namespace EMSClient
{
    public class EmployeeClient
    {
        public void AddNewEmployee()
        {
            Console.WriteLine("Enter the Employee ID ");
            int empID = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Employee Name");
            string empName = Console.ReadLine();
            Console.WriteLine("Enter Remarks about the Employee :");
            string empRemarks = Console.ReadLine();
            try
            {
                using (var createOrModifyClient = new CreateOrModifyEmployeeClient())
                {
                    createOrModifyClient.CreateEmployee(empID, empName, empRemarks);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddRemarks(int id,string remarks)
        {
            try
            {
                using (var client = new CreateOrModifyEmployeeClient())
                {
                    client.AddRemarks(id,remarks);                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

        }

        public void GetEmployeeDetailsByID(int id)
        {
            try
            {
                using (var client = new RetrieveEmpDetailsClient())
                {
                    var emp = client.GetEmployeeDetailsByID(id);
                    Console.WriteLine(emp.EmpID);
                    Console.WriteLine(emp.EmpName);
                    Console.WriteLine(emp.Remark.text);
                    Console.WriteLine(emp.Remark.remarkTimestamp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetEmployeeDetailsByName(string name)
        {
            try
            {
                using (var client = new RetrieveEmpDetailsClient())
                {
                    var emp = client.GetEmployeeDetailsByName(name);
                    Console.WriteLine(emp.EmpID);
                    Console.WriteLine(emp.EmpName);
                    Console.WriteLine(emp.Remark.text);
                    Console.WriteLine(emp.Remark.remarkTimestamp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllEmployeeList()
        {
            try
            {
                using (var client = new RetrieveEmpDetailsClient())
                {
                    var empList = client.GetAllEmployeeList();
                    foreach(var emp in empList)
                    {
                        Console.WriteLine(emp.EmpID);
                        Console.WriteLine(emp.EmpName);
                        Console.WriteLine(emp.Remark.text);
                        Console.WriteLine(emp.Remark.remarkTimestamp);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
