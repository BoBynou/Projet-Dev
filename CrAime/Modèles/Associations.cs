using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CrAime
{
    public class Associations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }

        public Associations(int id, string name, int status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public List<Associations> GetAllAsso()
        {
            try
            {
                List<Associations> associations = new List<Associations>();
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Associations WHERE Status = 0";

                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Status = Convert.ToInt32(reader.GetString(2));
                            };
                            Associations association = new Associations(Id, Name, Status);
                            associations.Add(association);
                        }
                    }
                    CRMDatabase.CloseConnection();
                }            
                return associations;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void AddAnAsso(string name)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "INSERT INTO Associations (Name, Status) VALUES (@Name, @Status)";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Status", 0);

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

        public Associations GetAnAsso(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Associations WHERE Association_id = " + id + " AND Status = 0";

                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Status = Convert.ToInt32(reader.GetString(2));
                            };
                        }
                    }
                    CRMDatabase.CloseConnection();
                    Associations association = new Associations(Id, Name, Status);
                    return association;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void UpdateAnAsso(string id, string name)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Associations SET Name = @Name, Status = @Status WHERE Association_id = @Association_id";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Status", 0);
                        command.Parameters.AddWithValue("@Association_id", id);

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
        public void DeleteAnAsso(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Associations SET Status = @Status WHERE Association_id = @Association_id";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Status", 1);
                        command.Parameters.AddWithValue("@Association_id", id);

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
