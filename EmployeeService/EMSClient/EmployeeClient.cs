using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMSClient.EMSReference;
using System.ServiceModel;
using System.ServiceModel.Channels;

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
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Code);
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
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Code);
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
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Code);
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
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Code);
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
                        Console.WriteLine("Employee ID : " + emp.EmpID);
                        Console.WriteLine("Employee Name : " + emp.EmpName);
                        Console.WriteLine("Employee Remarks : " + emp.Remark.text);
                        Console.WriteLine("Employee Remark TimeStamp : " + emp.Remark.remarkTimestamp);
                    }
                }

            }   
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Code);
            }                 
        }

    }
}
