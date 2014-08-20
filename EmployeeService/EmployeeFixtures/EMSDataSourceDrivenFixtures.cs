using EmployeeFixtures.EmployeeServiceReference;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeFixtures
{
    [TestClass]
    public class EmsDataSourceDrivenFixtures
    {
        private TestContext _testContextInstance;
        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        }

        
        [TestMethod]
        [DeploymentItem(@"D:\WCF\EMS\EmployeeManagementService\EmployeeService\EmployeeFixtures\EmployeeDataRepository.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"D:\WCF\EMS\EmployeeManagementService\EmployeeService\EmployeeFixtures\EmployeeDataRepository.xml", "Employee", DataAccessMethod.Sequential)]
        public void TestCreateNewEmployeeFromDataSource()
        {
            using (var client = new CreateOrModifyEmployeeClient())
            {
                var employeeName = _testContextInstance.DataRow["EmployeeName"].ToString();
                var employeeRemark = _testContextInstance.DataRow["EmployeeRemark"].ToString();


                Employee newEmployee = client.CreateEmployee(employeeName, employeeRemark);
                Assert.AreEqual(newEmployee.EmpName, "Siddharth");
                Assert.AreEqual(newEmployee.Remark.Text, "Rock n Roll!!");
            }
        }

    }
}
