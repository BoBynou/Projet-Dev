using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CrAime
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Min_Quantity { get; set; }
        public int Max_Quantity { get; set; }
        public string Measure_Unit { get; set; }
        public int Status { get; set; }

        public Stock(int id, string name, int quantity, int min_quantity, int max_quantity, string measure_unit,  int status)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Min_Quantity = min_quantity;
            Max_Quantity = max_quantity;
            Measure_Unit = measure_unit;
            Status = status;
        }

        public List<Stock> GetAllStocks()
        {
            try
            {
                List<Stock> stocks = new List<Stock>();
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Stock WHERE Status = 0";

                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Quantity = reader.GetInt32(2);
                                Min_Quantity = reader.GetInt32(3);
                                Max_Quantity = reader.GetInt32(4);
                                Measure_Unit = reader.GetString(5);
                                Status = Convert.ToInt32(reader.GetString(6));
                            };
                            Stock stock = new Stock(Id, Name, Quantity, Min_Quantity, Max_Quantity, Measure_Unit, Status);
                            stocks.Add(stock);
                        }
                    }
                    CRMDatabase.CloseConnection();
                }    
                return stocks;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void AddStock(string name, int quantity, int min_quantity, int max_quantity, string measure_unit)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "INSERT INTO Stock (Name, Quantity, Min_Quantity, Max_Quantity, Measure_Unit, Status) VALUES (@Name, @Quantity, @Min_Quantity, @Max_Quantity, @Measure_Unit, @Status)";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@Min_Quantity", min_quantity);
                        command.Parameters.AddWithValue("@Max_Quantity", max_quantity);
                        command.Parameters.AddWithValue("@Measure_Unit", measure_unit);
                        command.Parameters.AddWithValue("@Status", 0);

                        command.ExecuteNonQuery();
                        CRMDatabase.CloseConnection();
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public Stock GetStock(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Stock WHERE Stock_id = " + id + " AND Status = 0";

                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Quantity = reader.GetInt32(2);
                                Min_Quantity = reader.GetInt32(3);
                                Max_Quantity = reader.GetInt32(4);
                                Measure_Unit = reader.GetString(5);
                                Status = Convert.ToInt32(reader.GetString(6));
                            };
                        }
                    }
                    CRMDatabase.CloseConnection();
                    Stock stock = new Stock(Id, Name, Quantity, Min_Quantity, Max_Quantity, Measure_Unit, Status);
                    return stock;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void UpdateStock(string id, string name, int quantity, int min_quantity, int max_quantity, string measure_unit)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Stock SET Name = @Name, Quantity = @Quantity, Min_Quantity = @Min_Quantity, Max_Quantity = @Max_Quantity, Measure_Unit = @Measure_Unit Status = @Status WHERE Stock_id = @Stock_id";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@Min_Quantity", min_quantity);
                        command.Parameters.AddWithValue("@Max_Quantity", max_quantity);
                        command.Parameters.AddWithValue("@Measure_Unit", measure_unit);
                        command.Parameters.AddWithValue("@Status", 0);
                        command.Parameters.AddWithValue("@Stock_id", id);

                        command.ExecuteNonQuery();
                    }
                    CRMDatabase.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void DeleteStock(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Stock SET Status = @Status WHERE Stock_id = @Stock_id";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Status", 1);
                        command.Parameters.AddWithValue("@Stock_id", id);

                        command.ExecuteNonQuery();
                    }
                    CRMDatabase.CloseConnection();
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
