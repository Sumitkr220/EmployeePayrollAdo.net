using System;

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
            employee.EmployeeName = "Sumit";
            employee.StartDate = DateTime.Now;
            employee.Gender = 'M';
            employee.PhoneNumber = "9012872727";
            employee.Department = "Tech";
            employee.City = "Kolkata";
            employee.BasicPay = 10000;
            employee.EmployeeID = 101;
            employee.Address = "8/1";
            employee.Deductions = 500;
            employee.TaxablePay = 200;
            employee.Tax = 899;
            employee.NetPay = 200000;
            employee.Country = 70002;

            repo.GetAllEmployee();
        }
    }
}
