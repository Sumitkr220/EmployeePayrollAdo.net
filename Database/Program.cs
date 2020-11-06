using System;
using System.Collections.Generic;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel employee = new EmployeeModel();
            employee.EmployeeID = 10;
            employee.EmployeeName = "Samul";
            employee.StartDate = DateTime.Now;
            employee.Gender = 'F';
            employee.PhoneNumber = "9012872727";
            employee.Department = "Tech";
            employee.City = "Kolkata";
            employee.BasicPay = 8000;
            employee.EmployeeID = 121;
            employee.Address = "India";
            employee.Deductions = 500;
            employee.TaxablePay = 200;
            employee.Tax = 899;
            employee.NetPay = 200000;
            employee.Country = 70002;

            //repo.GetAllEmployee();
            //bool res = repo.AddEmployee(employee);
            //if (res)
            //{
            //    Console.WriteLine("Employee Added Successfully");
            //    repo.GetAllEmployee();
            //}
            //else
            //{
            //    Console.WriteLine("Employee isn't Added");
            //}
            //repo.UpdateTables();
            //List<string> models = new List<string>();
            //models = repo.GetEmployeesJoiningAfterADate();
            //foreach (var element in models)
            //{
            //    Console.WriteLine(element);
            //}
            repo.SumOfSalaryGenderWise();
        }
    }
}
