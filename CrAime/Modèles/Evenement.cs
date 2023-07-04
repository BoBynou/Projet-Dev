using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CrAime
{
    public class Evenement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Start_date { get; set; }
        public string End_date { get; set; }
        public int Status { get; set; }

        public Evenement(int id, string title, string type, string description, string start_date, string end_date, int status)
        {
            Id = id;
            Title = title;
            Type = type;
            Description = description;
            Start_date = start_date;
            End_date = end_date;
            Status = status;
        }

        public List<Evenement> GetAllEvent()
        {
            try
            {
                List<Evenement> evenements = new List<Evenement>();
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Evenement WHERE Status = 0";

                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Title = reader.GetString(1);
                                Type = reader.GetString(2);
                                Description = reader.GetString(3);
                                Start_date = reader.GetString(4);
                                End_date = reader.GetString(5);
                                Status = Convert.ToInt32(reader.GetString(6));
                            };
                            Evenement evenement = new Evenement(Id, Title, Type, Description, Start_date, End_date, Status);
                            evenements.Add(evenement);
                        }
                    }
                    CRMDatabase.CloseConnection();
                }
                return evenements;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void AddAnEvent(string title, string type, string description, string start_date, string end_date)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "INSERT INTO Evenement (Title, Type, Description, Start_date, End_date, Status) VALUES (@Title, @Type, @Description, @Start_date, @End_date, @Status)";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Type", type);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@Start_date", start_date);
                        command.Parameters.AddWithValue("@End_date", end_date);
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

        public Evenement GetAnEvent(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Evenement WHERE Event_id = " + id + " AND Status = 0";

                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Title = reader.GetString(1);
                                Type = reader.GetString(2);
                                Description = reader.GetString(3);
                                Start_date = reader.GetString(4);
                                End_date = reader.GetString(5);
                                Status = Convert.ToInt32(reader.GetString(6));
                            };
                        }
                    }
                    CRMDatabase.CloseConnection();
                    Evenement evenement = new Evenement(Id, Title, Type, Description, Start_date, End_date, Status);
                    return evenement;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void UpdateAnEvent(string id, string title, string type, string description, string start_date, string end_date)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Evenement SET Title = @Title, Type = @Type, Description = @Description, Start_date = @Start_date, End_date = @End_date, Status = @Status WHERE Event_id = @Event_id";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Type", type);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@Start_date", start_date);
                        command.Parameters.AddWithValue("@End_date", end_date);
                        command.Parameters.AddWithValue("@Status", 0);
                        command.Parameters.AddWithValue("@Event_id", id);

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
        public void DeleteAnEvent(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Evenement SET Status = @Status WHERE Event_id = @Event_id";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Status", 1);
                        command.Parameters.AddWithValue("@Event_id", id);

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
