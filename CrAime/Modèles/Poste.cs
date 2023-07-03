using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CrAime
{
    class Poste
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public Poste(int id, string name, string description, int status)
        {
            Id = id;
            Name = name;
            Description = description;
            Status = status;
        }

        public List<Poste> GetAllPoste()
        {
            try
            {
                List<Poste> postes = new List<Poste>();
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Poste WHERE Status = 0";

                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Description = reader.GetString(2);
                                Status = Convert.ToInt32(reader.GetString(3));
                            };
                            Poste poste = new Poste(Id, Name, Description, Status);
                            postes.Add(poste);
                        }
                    }
                    CRMDatabase.CloseConnection();
                }                
                return postes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void AddPoste(string name, string description)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "INSERT INTO Poste (Name, Description, Status) VALUES (@Name, @Description, @Status)";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
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

        public Poste GetPoste(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Poste WHERE Poste_id = " + id + " AND Status = 0";

                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Description = reader.GetString(2);
                                Status = Convert.ToInt32(reader.GetString(3));
                            };
                        }
                    }
                    CRMDatabase.CloseConnection();
                    Poste poste = new Poste(Id, Name, Description, Status);
                    return poste;
                }
                return null;            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void UpdatePoste(string id, string name, string description)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Poste SET Name = @Name, Description = @Description, Status = @Status WHERE Poste_id = @Poste_id";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@Status", 0);
                        command.Parameters.AddWithValue("@Poste_id", id);

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
        public void DeletePoste(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Poste SET Status = @Status WHERE Poste_id = @Poste_id";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Status", 1);
                        command.Parameters.AddWithValue("@Poste_id", id);

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
