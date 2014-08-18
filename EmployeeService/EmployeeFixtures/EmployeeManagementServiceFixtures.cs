﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeFixtures.EmployeeServiceReference;
using System.Diagnostics;
using System.ServiceModel;

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
        public void TestCreateNewEmployee()
        {
            using (var client = new CreateOrModifyEmployeeClient())
            {
                Employee newEmployee = client.CreateEmployee(1, "sid", "good boy");
                Assert.AreEqual(newEmployee.EmpId, 1);
                Assert.AreEqual(newEmployee.EmpName, "sid");
                Assert.AreEqual(newEmployee.Remark.Text, "good boy");
            }
        }

        /// <summary>
        /// Test for : Modifying remark for an existing employee 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void TestAddRemarkForExistingEmployee()
        {
            using (var client = new CreateOrModifyEmployeeClient())
            {
                client.AddRemarks(1, "sad boy");

                using (var retrieveClient = new RetrieveEmpDetailsClient())
                {
                    var empModified = retrieveClient.GetEmployeeDetailsById(1);
                    Assert.AreEqual(empModified.Remark.Text, "sad boy");
                }
            }
        }

        /// <summary>
        /// Test for : Adding remarks for an Employee which is not present in the list
        /// Expected FaultException with message "Employee does not exist"
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void TestAddRemarkWhenEmployeeNotPresent()
        {
            using (var client = new CreateOrModifyEmployeeClient())
            {
                client.AddRemarks(6, "watta boy");
                using (var retrieveClient = new RetrieveEmpDetailsClient())
                {
                    var empTried = retrieveClient.GetEmployeeDetailsById(6);
                    Assert.AreNotEqual(empTried.Remark.Text, "watta boy");
                }
            }
        }

        /// <summary>
        /// Test for : Add an employee and retrieve it
        /// </summary>
        [TestMethod]
        public void TestAddAndRetrieveEmployee()
        {
            using (var createClient = new CreateOrModifyEmployeeClient())
            {
                var emp1 = createClient.CreateEmployee(2, "vinayak", "hello boy");

                using (var retrieveClient = new RetrieveEmpDetailsClient())
                {
                    var emp2 = retrieveClient.GetEmployeeDetailsById(2);
                    Assert.AreEqual(emp1.EmpId, emp2.EmpId);

                    Assert.AreEqual(emp1.EmpName, emp2.EmpName);

                    Assert.AreEqual(emp1.Remark.Text, emp2.Remark.Text);
                    Debug.WriteLine(emp1.Remark.Text);
                    Debug.WriteLine(emp2.Remark.Text);
                }
            }
        }

        /// <summary>
        /// Test for : Add new employee
        /// </summary>
        [TestMethod]
        public void TestAddNewEmployee()
        {
                using (var client = new CreateOrModifyEmployeeClient())
                {
                    var emp = client.CreateEmployee(4, "Rajnikant", "yenna rascala");
                    Assert.AreEqual(emp.EmpId, 4);
                    Assert.AreEqual(emp.EmpName, "Rajnikant");
                    Assert.AreEqual(emp.Remark.Text, "yenna rascala");
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
                    Console.WriteLine(emp.EmpId);
                    Console.WriteLine(emp.EmpName);
                    Console.WriteLine(emp.Remark.Text);
                    Console.WriteLine(emp.Remark.RemarkTimestamp);
                }
            }
        }

        [TestMethod]
        public void TestGetEmployeeDetailsByName()
        {
            using (var client = new RetrieveEmpDetailsClient())
            {
                    var emp = client.GetEmployeeDetailsByName("Rajnikant");
                    Assert.AreEqual(emp.EmpId, 4);
                    Assert.AreEqual(emp.EmpName, "Rajnikant");
                    Assert.AreEqual(emp.Remark.Text, "yenna rascala");
            }
        }
    }
}
