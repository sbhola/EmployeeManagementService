using System;
using EMSClient.EMSReference;
using System.ServiceModel;

namespace EMSClient
{
    public class EmployeeClient
    {
        public void AddNewEmployee()
        {
            Console.WriteLine("Enter the Employee Name");
            string empName = Console.ReadLine();
            Console.WriteLine("Enter Remarks about the Employee :");
            string empRemarks = Console.ReadLine();
            try
            {
                using (var createOrModifyClient = new CreateOrModifyEmployeeClient())
                {
                    createOrModifyClient.CreateEmployee(empName, empRemarks);
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

        public void GetEmployeeDetailsById(int id)
        {
            try
            {
                using (var client = new RetrieveEmpDetailsClient())
                {
                    var emp = client.GetEmployeeDetailsById(id);
                    Console.WriteLine(emp.EmpId);
                    Console.WriteLine(emp.EmpName);
                    Console.WriteLine(emp.Remark.Text);
                    Console.WriteLine(emp.Remark.RemarkTimestamp);
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
                    Console.WriteLine(emp.EmpId);
                    Console.WriteLine(emp.EmpName);
                    Console.WriteLine(emp.Remark.Text);
                    Console.WriteLine(emp.Remark.RemarkTimestamp);
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
                        Console.WriteLine("Employee Id : " + emp.EmpId);
                        Console.WriteLine("Employee Name : " + emp.EmpName);
                        Console.WriteLine("Employee Remarks : " + emp.Remark.Text);
                        Console.WriteLine("Employee Remark TimeStamp : " + emp.Remark.RemarkTimestamp);
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
