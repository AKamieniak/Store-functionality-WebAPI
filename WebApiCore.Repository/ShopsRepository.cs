using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebApiCore.Models;

namespace WebApiCore.Repository
{
    public class ShopsRepository:IShopsRepository
    {
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;

        //---get and open conection to database---
        public ShopsRepository(IDatabaseConnectionProvider databaseConnectionProvider)
        {
            _databaseConnectionProvider = databaseConnectionProvider;
        }

        public List<Shop> GetShopsAll()
        {
            //---method to get shops names from the SQL database---
            using (var _sqlConnection = _databaseConnectionProvider.GetOpenConnection())
            {
                var sqlCommand = new SqlCommand(StoredProcedures.GetShopsAll, _sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var reader = sqlCommand.ExecuteReader())
                {
                    var shops = new List<Shop>();

                    while (reader.Read())
                    {
                        shops.Add(new Shop
                        {
                            Id = Convert.ToInt32(reader["id"].ToString()),
                            Name = Convert.ToString(reader["name"]),
                            City = Convert.ToString(reader["city"]),
                        });
                    }
                    return shops;
                }
            }
        }

        public void AddShop(Shop shop)
        {
            //---method to add new shop to the SQL database---
            using (var _sqlConnection = _databaseConnectionProvider.GetOpenConnection())
            {
                var sqlCommand = new SqlCommand(StoredProcedures.AddShop, _sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@id", shop.Id));
                sqlCommand.Parameters.Add(new SqlParameter("@name", shop.Name));
                sqlCommand.Parameters.Add(new SqlParameter("@city", shop.City));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeleteShop(int id)
        {
            //---method to delete shop from database---
            using (var _sqlConnection = _databaseConnectionProvider.GetOpenConnection())
            {
                var sqlCommand = new SqlCommand(StoredProcedures.DeleteShop, _sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
            }
        }

        public int GetLastIndexOfShop()
        {
            //---method to get last shop index from the SQL database---
            using (var _sqlConnection = _databaseConnectionProvider.GetOpenConnection())
            {
                var sqlCommand = new SqlCommand(StoredProcedures.GetLastIndexOfShop, _sqlConnection);
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

        public List<Shop> GetShopsByCity(string city)
        {
            //---method to get shops from the SQL database by it city name---
            using (var _sqlConnection = _databaseConnectionProvider.GetOpenConnection())
            {
                var sqlCommand = new SqlCommand(StoredProcedures.GetShopsByCity, _sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@city", city));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using (var reader = sqlCommand.ExecuteReader())
                {
                    var shops = new List<Shop>();

                    while (reader.Read())
                    {
                        shops.Add(new Shop
                        {
                            Id = Convert.ToInt32(reader["id"].ToString()),
                            Name = Convert.ToString(reader["name"]),
                            City = Convert.ToString(reader["city"]),
                        });
                    }
                    return shops;
                }
            }
        }


    }
}
