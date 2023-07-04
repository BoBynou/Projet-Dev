using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CrAime
{
    public class Regle
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public Regle(int id, string description, int status)
        {
            Id = id;
            Description = description;
            Status = status;
        }

        public List<Regle> GetAllRegle()
        {
            try
            {
                List<Regle> regles = new List<Regle>();
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Regles WHERE Status = 0";

                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Description = reader.GetString(1);
                                Status = Convert.ToInt32(reader.GetString(2));
                            };
                            Regle regle = new Regle(Id, Description, Status);
                            regles.Add(regle);
                        }
                    }
                    CRMDatabase.CloseConnection();
                }
                return regles;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void AddRegle(string description)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "INSERT INTO Regles (Description, Status) VALUES (@Description, @Status)";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Description", description);
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

        public Regle GetAnAsso(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Regles WHERE Regles_id = " + id + " AND Status = 0";

                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Description = reader.GetString(1);
                                Status = Convert.ToInt32(reader.GetString(2));
                            };
                        }
                    }
                    CRMDatabase.CloseConnection();
                    Regle regle = new Regle(Id, Description, Status);
                    return regle;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void UpdateRegle(string id, string description)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Regles SET Description = @Description, Status = @Status WHERE Regles_id = @Regles_id";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Description", description);
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
        public void DeleteRegle(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Regles SET Status = @Status WHERE Regles_id = @Regles_id";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Status", 1);
                        command.Parameters.AddWithValue("@Regles_id", id);

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
    }
}
