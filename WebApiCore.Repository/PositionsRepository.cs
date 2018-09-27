using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebApiCore.Models;

namespace WebApiCore.Repository
{
    public class PositionsRepository:IPositionsRepository
    {
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;

        //---get and open conection to database---
        public PositionsRepository(IDatabaseConnectionProvider databaseConnectionProvider)
        {
            _databaseConnectionProvider = databaseConnectionProvider;
        }

        public List<Position> GetPositionsAll()
        {
            //---method to get positions names from the SQL database---
            using (var _sqlConnection = _databaseConnectionProvider.GetOpenConnection())
            {
                var sqlCommand = new SqlCommand(StoredProcedures.GetPositionsAll, _sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var reader = sqlCommand.ExecuteReader())
                {
                    var positions = new List<Position>();

                    while (reader.Read())
                    {
                        positions.Add(new Position
                        {
                            Id = Convert.ToInt32(reader["id"].ToString()),
                            Name = Convert.ToString(reader["position"]),
                        });
                    }
                    return positions;
                }
            }
        }

        public void AddPosition(Position position)
        {
            //---method to add new position to the SQL database---
            using (var _sqlConnection = _databaseConnectionProvider.GetOpenConnection())
            {
                var sqlCommand = new SqlCommand(StoredProcedures.AddPosition, _sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@id", position.Id));
                sqlCommand.Parameters.Add(new SqlParameter("@position", position.Name));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeletePosition(int id)
        {
            //---method to delete position from database---
            using (var _sqlConnection = _databaseConnectionProvider.GetOpenConnection())
            {
                var sqlCommand = new SqlCommand(StoredProcedures.DeletePosition, _sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
            }
        }

        public int GetLastIndexOfPosition()
        {
            //---method to get last position index from the SQL database---
            using (var _sqlConnection = _databaseConnectionProvider.GetOpenConnection())
            {
                var sqlCommand = new SqlCommand(StoredProcedures.GetLastIndexOfPosition, _sqlConnection);
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
