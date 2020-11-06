using Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeePayrollMSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenPayrollDetails_UpdatePayrollData()
        {
            EmployeeRepo repo = new EmployeeRepo();
            bool Emp_BasicPay = repo.UpdateTables();

            Assert.AreEqual(Emp_BasicPay, true);
        }

    }
}
