using CommanLayer.ResponseModel;
using RepositoryLayer.InterFace;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class EmployeeRL: IEmployeeRL
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayrollAPIDB;User Id=root;Password=root";
        private List<EmployeeModel> groupEmployees(List<EmployeeModel> inputEmployees)
        {
            List<EmployeeModel> outputEmployees = new List<EmployeeModel>();
            EmployeeModel outputEmployee = new EmployeeModel();
            bool firstFlag = true;
            EmployeeModel previousEmployee = new EmployeeModel();
            foreach (EmployeeModel currentEmployee in inputEmployees)
            {
                if (firstFlag)
                {
                    previousEmployee = currentEmployee;
                    outputEmployee = currentEmployee;
                    firstFlag = false;
                    continue;
                }
                else
                {
                    outputEmployees.Add(outputEmployee);
                    outputEmployee = currentEmployee;
                }
                previousEmployee = currentEmployee;
            }
            outputEmployees.Add(outputEmployee);
            return outputEmployees;
        }
        private List<EmployeeModel> getEmployeeRecords()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "sp_GetEmployeePayrollAllData";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader dr = sqlCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EmployeeModel emp = new EmployeeModel();
                        emp.id = dr.GetInt32(0);
                        emp.Name = dr.GetString(1);
                        emp.Gender = Convert.ToChar(dr.GetString(2));
                        emp.Salary = dr.GetInt64(3);
                        emp.StartDate = dr.GetDateTime(4);
   
                        employees.Add(emp);
                    }//end while

                }//end if
                connection.Close();
            }//end using
            List<EmployeeModel> departmentGroupedEmployeeList = groupEmployees(employees);
            return departmentGroupedEmployeeList;
        }
        private string insertEmployeeRecord(EmployeeModel employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string storedProcedure = "sp_AddEmployeeRecord";
            using (connection)
            {
                connection.Open();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Insert Employee Transaction");
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(storedProcedure, connection, transaction);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                    sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
                    sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);

                    SqlParameter outPutVal = new SqlParameter("@ScopeIdentifier", SqlDbType.Int);
                    outPutVal.Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.Add(outPutVal);

                    transaction.Commit();
                    connection.Close();
                    return "Data Added Successfully";
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {

                        Console.WriteLine(ex2.Message);
                        return ex2.Message;

                    }
                    return ex.Message;
                }
            }


        }

        private bool deleteEmployeeRecord(int EmpId)
        {
            int recordsAffected = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            string storedProcedure = "sp_DeleteRecordForId";
            try
            {
                using (connection)
                {
                    SqlCommand sqlCommand = new SqlCommand(storedProcedure, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ID", EmpId);
                    connection.Open();
                    recordsAffected += sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return recordsAffected == 0 ? false : true;

        }

        private bool updateEmployeeRecord(EmployeeModel employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string storedProcedureUpdateEmployee = "sp_UpdateEmployeeRecord";
            using (connection)
            {
                connection.Open();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Update Employee Transaction");
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(storedProcedureUpdateEmployee, connection, transaction);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ID", employee.id);
                    sqlCommand.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
                    sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
                    sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
                    sqlCommand.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();
                    return true;
                }

                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        return false;
                    }
                    return false;
                }
            }


        }

        public List<EmployeeModel> ReturnEmployeeRecords()
        {
            return getEmployeeRecords();
        }

        public string AddEmployeeRecord(EmployeeModel employee)
        {
            return insertEmployeeRecord(employee);
        }

        public bool DeleteEmployeeRecord(int EmpId)
        {
            return deleteEmployeeRecord(EmpId);
        }

        public bool UpdateEmployeeRecord(EmployeeModel employee)
        {
            return updateEmployeeRecord(employee);
        }
    }
}
