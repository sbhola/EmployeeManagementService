using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMSClient.EMSReference;

namespace EMSClient
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 1;
            EmployeeClient emp = new EmployeeClient();
            while (choice != 9)
            {
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Welcome to Employee Management Service!");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Select your choice : ");
                Console.WriteLine("1.Create/Add new Employee");
                Console.WriteLine("2.Modify Existing Employee(Add Remarks)");
                Console.WriteLine("3.Get Employee Details by ID");
                Console.WriteLine("4. Get Emplyee Details by Name");
                Console.WriteLine("5. Get All Employees List");
                Console.WriteLine("9. Exit");

                choice = Int32.Parse(Console.ReadLine());
                Console.WriteLine(choice);

                switch (choice)
                {
                    case 1: 
                        emp.AddNewEmployee();                                                                       
                        break;
                    case 2:
                        Console.WriteLine("Enter Employee ID for which you want to add Remarks");
                        int addRemarkForID = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the remarks about Employee :");
                        string remarks = Console.ReadLine();
                        emp.AddRemarks(addRemarkForID, remarks);
                        break;
                    case 3:
                        Console.WriteLine("Enter employee id for which you want details :");
                        int getDetailsForID = Int32.Parse(Console.ReadLine());
                        emp.GetEmployeeDetailsByID(getDetailsForID);                        
                        break;
                    case 4:
                        Console.WriteLine("Enter Employee Name for which you want details : ");
                        string detailsForName = Console.ReadLine();
                        emp.GetEmployeeDetailsByName(detailsForName);
                        break;
                    case 5:
                        emp.GetAllEmployeeList();
                        break;
                    case 6:
                        break;


                }
            }
            //var createOrModifyClient = new CreateOrModifyEmployeeClient();
            //createOrModifyClient.Open();

            //var retrieveClient = new RetrieveEmpDetailsClient();
            //retrieveClient.Open();

        }
        
    }
}
