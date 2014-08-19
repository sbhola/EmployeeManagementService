using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeFixtures.EmployeeServiceReference;
using System.Diagnostics;
using System.ServiceModel;
using EmployeeAlreadyExistsFault = EmployeeFixtures.EmployeeServiceReference.EmployeeAlreadyExistsFault;
using EmployeeDoesNotExists = EmployeeFixtures.EmployeeServiceReference.EmployeeDoesNotExists;

//using Employee = EmployeeFixtures.EmployeeServiceReference.Employee;

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
        [TestInitialize]
        public void DisposeEmployeeList()
        {
            using (var client = new CreateOrModifyEmployeeClient())
            {
                client.DisposeEmployeeList();
            }
        }

        /// <summary>
        /// Test to Create an employee and add it to the list
        /// </summary>
        [TestMethod]
        public void TestCreateNewEmployee()
        {
            using (var client = new CreateOrModifyEmployeeClient())
            {
                Employee newEmployee = client.CreateEmployee("sid", "good boy");
                Assert.AreEqual(newEmployee.EmpId, 1);
                Assert.AreEqual(newEmployee.EmpName, "sid");
                Assert.AreEqual(newEmployee.Remark.Text, "good boy");
               // client.DisposeEmployeeList();
            }
        }

        /// <summary>
        /// Test for : Modifying remark for an existing employee 
        /// </summary>
        [TestMethod]
        public void TestAddRemarkForExistingEmployee()
        {
            using (var client = new CreateOrModifyEmployeeClient())
            {
                Employee newEmployee = client.CreateEmployee("sid", "good boy");
                client.AddRemarks(1, "sad boy");

                using (var retrieveClient = new RetrieveEmpDetailsClient())
                {
                    var empModified = retrieveClient.GetEmployeeDetailsById(1);
                    Assert.AreEqual(empModified.Remark.Text, "sad boy");
                }
               // client.DisposeEmployeeList();
            }
        }

        /// <summary>
        /// Test for : Adding remarks for an Employee which is not present in the list
        /// Expected FaultException with message "Employee does not exist"
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeDoesNotExists>))]
        public void TestAddRemarkWhenEmployeeNotPresent()
        {
            using (var client = new CreateOrModifyEmployeeClient())
            {
                client.CreateEmployee( "sid", "yoyo");
                client.AddRemarks(6, "watta boy");
                using (var retrieveClient = new RetrieveEmpDetailsClient())
                {
                    var empTried = retrieveClient.GetEmployeeDetailsById(6);
                    Assert.AreNotEqual(empTried.Remark.Text, "watta boy");
                }
              //  client.DisposeEmployeeList();
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
                var emp1 = createClient.CreateEmployee( "vinayak", "hello boy");

                using (var retrieveClient = new RetrieveEmpDetailsClient())
                {
                    var emp2 = retrieveClient.GetEmployeeDetailsById(1);

                    Assert.AreEqual(emp1.EmpName, emp2.EmpName);
                    Assert.AreEqual(emp1.Remark.Text, emp2.Remark.Text);
                }
             //   createClient.DisposeEmployeeList();
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
                var emp = client.CreateEmployee( "Rajnikant", "yenna rascala");
                Assert.AreEqual(emp.EmpName, "Rajnikant");
                Assert.AreEqual(emp.Remark.Text, "yenna rascala");
             //   client.DisposeEmployeeList();
            }
        }

        /// <summary>
        /// test for : retrieve the complete employee list
        /// </summary>
        [TestMethod]
        public void TestRetrieveEmployeeList()
        {
            using (var createClient = new CreateOrModifyEmployeeClient())
            {
                var emp1 = createClient.CreateEmployee( "sid", "watta boy");
                var emp2 = createClient.CreateEmployee( "vinayak", "awesome ");
                var emp3 = createClient.CreateEmployee("saif", "smelly cat");

                using (var client = new RetrieveEmpDetailsClient())
                {
                    var employees = client.GetAllEmployeeList();
                    Assert.AreEqual(employees.Length, 3);
                }
            //    createClient.DisposeEmployeeList();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeDoesNotExists>))]
        public void TestRetrieveEmptyEmployeeListShouldThrow()
        {
            using (var client = new RetrieveEmpDetailsClient())
            {
                var empList = client.GetAllEmployeeList();
            }
        }

        [TestMethod]
        public void TestGetCorrectEmployeeDetailsByName()
        {
            using (var createClient = new CreateOrModifyEmployeeClient())
            {
                var createEmployee = createClient.CreateEmployee("Rajnikant", "yenna rascala");

                using (var client = new RetrieveEmpDetailsClient())
                {
                    var emp = client.GetEmployeeDetailsByName("Rajnikant");
                    Assert.AreEqual(emp.EmpName, "Rajnikant");
                    Assert.AreEqual(emp.Remark.Text, "yenna rascala");
                }
              //  createClient.DisposeEmployeeList();
            }
        }

        ///<summary>
        ///Get the employee details by Name when the name is not present in the Database.
        ///Should Throw FaultException
        ///</summary>
        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeDoesNotExists>))]
        public void TestGetIncorrectEmployeeDetailsByName()
        {
            using (var createClient = new CreateOrModifyEmployeeClient())
            {
                createClient.DisposeEmployeeList();
                createClient.CreateEmployee("baby", "baby doll me sone di ye duniya pittal di");

                using (var client = new RetrieveEmpDetailsClient())
                {
                    string name = "maharaja";
                    var employee = client.GetEmployeeDetailsByName(name);
                }
            //    createClient.DisposeEmployeeList();
            }

        }

        [TestMethod]
        public void TestDeleteExistingEmployee()
        {
            using (var createClient = new CreateOrModifyEmployeeClient())
            {
                createClient.CreateEmployee("sid", "watta boy");
                createClient.CreateEmployee("vinayak", "awesome boy");
                createClient.CreateEmployee("saif", "smelly boy");

                using (var retrieveClient = new RetrieveEmpDetailsClient())
                {
                    var empList = retrieveClient.GetAllEmployeeList();
                    Assert.AreEqual(empList.Length,3);
                }

                createClient.DeleteEmployeeById(1);

                using (var retrieveClient = new RetrieveEmpDetailsClient())
                {
                    var empList = retrieveClient.GetAllEmployeeList();
                    Assert.AreEqual(empList.Length, 2);
                }
            //    createClient.DisposeEmployeeList();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<EmployeeDoesNotExists>))]
        public void TestDeleteNonExistingEmployeeShouldThrow()
        {
            using (var client = new CreateOrModifyEmployeeClient())
            {
                client.CreateEmployee("sid", "watta boy");
                client.CreateEmployee("vinayak", "shitty boy");
                client.CreateEmployee("saif", "smelly boy");

                client.DeleteEmployeeById(11);

            //    client.DisposeEmployeeList();
            }
        }
    }
}
