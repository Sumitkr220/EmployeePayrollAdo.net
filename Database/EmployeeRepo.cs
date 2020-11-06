using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Database
{
    public class EmployeeRepo
    {
        public static string connectionString = "Data Source= LAPTOP-HGH2MEKE\\CAPGEMINI ;Initial Catalog=payroll_service;" + "Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = @"Select * from employeePayroll;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.BasicPay = dr.GetDecimal(2);
                            employeeModel.StartDate = dr.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(4));
                            employeeModel.PhoneNumber = dr.GetString(5);
                            employeeModel.Address = dr.GetString(6);
                            employeeModel.Department = dr.GetString(7);
                            employeeModel.Deductions = dr.GetDouble(8);
                            employeeModel.TaxablePay = (double)dr.GetSqlSingle(9);
                            employeeModel.Tax = dr.GetDouble(10);
                            employeeModel.NetPay = (double)dr.GetSqlSingle(11);
                            System.Console.WriteLine(employeeModel.EmployeeName + "   " + employeeModel.BasicPay + "   " + employeeModel.StartDate + "   " + employeeModel.Gender + "   " + employeeModel.PhoneNumber + "   " + employeeModel.Address + "   " + employeeModel.Department + "   " + employeeModel.Deductions + "   " + employeeModel.TaxablePay + "   " + employeeModel.Tax + "   " + employeeModel.NetPay);
                            System.Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetail", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
        public bool UpdateTables()
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "update employeePayroll set Basic_Pay = 40000 where name='Samul'";
                    int numberOfEffectedRows = command.ExecuteNonQuery();
                    if (numberOfEffectedRows != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public List<string> GetEmployeesJoiningAfterADate()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            List<string> results = new List<string>();
            try
            {
                using (connection)
                {
                    string query = @"SELECT * FROM employeePayroll where start between CAST('2018-01-01' AS DATE) AND CAST('2020-11-05' AS DATE)";
                    SqlCommand command = new SqlCommand(query, connection);
                    this.connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.BasicPay = dr.GetDecimal(2);
                            employeeModel.StartDate = dr.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(4));
                            employeeModel.PhoneNumber = dr.GetString(5);
                            employeeModel.Address = dr.GetString(6);
                            employeeModel.Department = dr.GetString(7);
                            employeeModel.Deductions = dr.GetDouble(8);
                            employeeModel.TaxablePay = (double)dr.GetSqlSingle(9);
                            employeeModel.Tax = dr.GetDouble(10);
                            employeeModel.NetPay = (double)dr.GetSqlSingle(11);
                            Console.WriteLine("\n");
                            results.Add(employeeModel.EmployeeName);
                        }
                        dr.Close();
                        return results;
                    }
                    else
                    {
                        throw new Exception("No data found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public void SumOfSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"SELECT sum(basic_pay) as CombineSalary from employeePayroll where gender='M' group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.Write(dr.GetDecimal(0) + "\t");
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public void AverageOfSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"select gender, AVG(basic_pay) from employeePayroll group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.Write(dr.GetString(0) + "\t");
                            Console.Write(dr.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public void MinimumSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"select gender, MIN(basic_pay) from employeePayroll group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.Write(dr.GetString(0) + "\t");
                            Console.Write(dr.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public void MaximumSalaryGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"select gender, MAX(basic_pay) from employeePayroll group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.Write(dr.GetString(0) + "\t");
                            Console.Write(dr.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public void CountOfEmployeesGenderWise()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"select gender, COUNT(gender) from employeePayroll group by gender";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.Write(dr.GetString(0) + "\t");
                            Console.Write(dr.GetInt32(1));
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}