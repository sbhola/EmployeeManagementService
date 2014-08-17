using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeFixtures.EmployeeServiceReference;
using System.Diagnostics;

/*
Test Scenarios :
Add and Retrieve
Add it again
Add remark for existing employee
Add remark where employee is not present in memory object(database)
Retrieve employee who has remarks
Add employee with incorrect request
Retrieve employee list
Retrieve employee by name

 */
namespace EmployeeFixtures
{
    /// <summary>
    /// Test Class for Employee Management Service
    /// </summary>
    [TestClass]
    public class EmployeeManagementServiceFixtures
    {
        /// <summary>
        /// Test to Create an employee and add it to the list
        /// </summary>
        [TestMethod]
        public void TestCreateEmployee()
        {
            try
            {
                using (var client = new CreateOrModifyEmployeeClient())
                {
                    var emp1 = client.CreateEmployee(1, "sid", "good boy");
                    Assert.AreEqual(emp1.EmpID, 1);
                    Assert.AreEqual(emp1.EmpName, "sid");
                    Assert.AreEqual(emp1.Remark.text, "good boy");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Test for : Modifying remark for an existing employee 
        /// </summary>
        [TestMethod]
        public void TestAddRemarkForExistingEmployee()
        {
            try
            {
                using (var client = new CreateOrModifyEmployeeClient())
                {
                    client.AddRemarks(1, "sad boy");

                    using (var retrieveClient = new RetrieveEmpDetailsClient())
                    {
                        var empModified = retrieveClient.GetEmployeeDetailsByID(1);
                        Assert.AreEqual(empModified.Remark.text, "sad boy");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Test for : Adding remarks for an Employee which is not present in the list
        /// It should return false
        /// </summary>
        [TestMethod]        
        public void TestAddRemarkWhenEmployeeNotPresent()
        {
            try
            {

                using (var client = new CreateOrModifyEmployeeClient())
                {
                    client.AddRemarks(6, "watta boy");
                    using (var retrieveClient = new RetrieveEmpDetailsClient())
                    {
                        var empTried = retrieveClient.GetEmployeeDetailsByID(6);
                        Assert.AreNotEqual(empTried.Remark.text, "watta boy");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Test for : Add an employee and retrieve it
        /// </summary>
        [TestMethod]
        public void TestAddAndRetrieveEmployee()
        {
            try
            {
                using (var createClient = new CreateOrModifyEmployeeClient())
                {
                    var emp1 = createClient.CreateEmployee(2, "vinayak", "hello boy");

                    using (var retrieveClient = new RetrieveEmpDetailsClient())
                    {
                        var emp2 = retrieveClient.GetEmployeeDetailsByID(2);
                        Assert.AreEqual(emp1.EmpID, emp2.EmpID);

                        Assert.AreEqual(emp1.EmpName, emp2.EmpName);

                        Assert.AreEqual(emp1.Remark.text, emp2.Remark.text);
                        Debug.WriteLine(emp1.Remark.text);
                        Debug.WriteLine(emp2.Remark.text);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Test for : Add new employee
        /// </summary>
        [TestMethod]
        public void TestAddNewEmployee()
        {
            try
            {

                using (var client = new CreateOrModifyEmployeeClient())
                {
                    var emp = client.CreateEmployee(4, "Rajnikant", "yenna rascala");
                    Assert.AreEqual(emp.EmpID, 4);
                    Assert.AreEqual(emp.EmpName, "Rajnikant");
                    Assert.AreEqual(emp.Remark.text, "yenna rascala");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// test for : retrieve the complete employee list
        /// </summary>
        [TestMethod]
        public void TestRetrieveEmployeeList()
        {
            using (var client = new RetrieveEmpDetailsClient())
            {
                var employees = client.GetAllEmployeeList();
                Console.WriteLine(employees.Length);
                foreach (var emp in employees)
                {
                    Console.WriteLine(emp.EmpID);
                    Console.WriteLine(emp.EmpName);
                    Console.WriteLine(emp.Remark.text);
                    Console.WriteLine(emp.Remark.remarkTimestamp);
                }
            }
        }

        [TestMethod]
        public void TestGetEmployeeDetailsByName()
        {
            using (var client = new RetrieveEmpDetailsClient())
            {
                try
                {
                    var emp = client.GetEmployeeDetailsByName("Rajnikant");
                    Assert.AreEqual(emp.EmpID, 4);
                    Assert.AreEqual(emp.EmpName, "Rajnikant");
                    Assert.AreEqual(emp.Remark.text, "yenna rascala");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                
            }

        }
    }
}
