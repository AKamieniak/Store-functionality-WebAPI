using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebApiCore.Models;

namespace WebApiCore.Repository
{
    public class EmployeesRepository:IEmployeesRepository
    {
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;

        //---get and open conection to database---
        public EmployeesRepository(IDatabaseConnectionProvider databaseConnectionProvider)
        {
            _databaseConnectionProvider = databaseConnectionProvider;
        }

        public List<Employee> GetEmployeesByShopId(int shopId)
        {
            //---method to get employee from the SQL database by it shopId---
            using (var _sqlConnection = _databaseConnectionProvider.GetOpenConnection())
            {
                var sqlCommand = new SqlCommand(StoredProcedures.GetEmployeesByShopId, _sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@shopId", shopId));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var reader = sqlCommand.ExecuteReader())
                {
                    var employees = new List<Employee>();

                    while(reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            Id = Convert.ToInt32(reader["id"].ToString()),
                            Name = Convert.ToString(reader["name"]),
                            Surname = Convert.ToString(reader["surname"]),
                            PositionId = Convert.ToInt32(reader["positionID"].ToString()),
                            ShopId = Convert.ToInt32(reader["shopID"].ToString())
                        });
                    }
                    return employees;
                }
            }
        }

        public List<Employee> GetEmployeesByPositionId(int positionId)
        {
            //---method to get employee from the SQL database by it positionId---
            using (var _sqlConnection = _databaseConnectionProvider.GetOpenConnection())
            {
                var sqlCommand = new SqlCommand(StoredProcedures.GetEmployeesByPositionId, _sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@positionId", positionId));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var reader = sqlCommand.ExecuteReader())
                {
                    var employees = new List<Employee>();

                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            Id = Convert.ToInt32(reader["id"].ToString()),
                            Name = Convert.ToString(reader["name"]),
                            Surname = Convert.ToString(reader["surname"]),
                            PositionId = Convert.ToInt32(reader["positionID"].ToString()),
                            ShopId = Convert.ToInt32(reader["shopID"].ToString())
                        });
                    }
                    return employees;
                }
            }
        }

        public void AddEmployee(Employee employee)
        {
            //---method to add new employee to the SQL database---
            using (var _sqlConnection = _databaseConnectionProvider.GetOpenConnection())
            {
                var sqlCommand = new SqlCommand(StoredProcedures.AddEmployee, _sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@id", employee.Id));
                sqlCommand.Parameters.Add(new SqlParameter("@name", employee.Name));
                sqlCommand.Parameters.Add(new SqlParameter("@surname", employee.Surname));
                sqlCommand.Parameters.Add(new SqlParameter("@shopID", employee.ShopId));
                sqlCommand.Parameters.Add(new SqlParameter("@positionID", employee.PositionId));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            //---method to delete employee from database---
            using (var _sqlConnection = _databaseConnectionProvider.GetOpenConnection())
            {
                var sqlCommand = new SqlCommand(StoredProcedures.DeleteEmployee, _sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
            }
        }
       
        public int GetLastIndexOfEmployee()
        {
            //---method to get last employee index from the SQL database---
            using (var _sqlConnection = _databaseConnectionProvider.GetOpenConnection())
            {
                var sqlCommand = new SqlCommand(StoredProcedures.GetLastIndexOfEmployee, _sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var reader = sqlCommand.ExecuteReader())
                {
                    int index = 0;

                    while (reader.Read())
                    {
                        index = Convert.ToInt32(reader["LastID"].ToString());
                        
                    }
                    return index;

                }
            }
        }
    }
}
