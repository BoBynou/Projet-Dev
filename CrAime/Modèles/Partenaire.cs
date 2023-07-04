using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CrAime
{
    public class Partenaire
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Contact_phone { get; set; }
        public string Contact_email { get; set; }
        public string Date_ajout { get; set; }
        public int Status { get; set; }

        public Partenaire(int id, string name, string type, string contact_phone, string contact_email, string date_ajout, int status)
        {
            Id = id;
            Name = name;
            Type = type;
            Contact_phone = contact_phone;
            Contact_email = contact_email;
            Date_ajout = date_ajout;
            Status = status;
        }

        public List<Partenaire> GetAllPartenaire()
        {
            try
            {
                List<Partenaire> partenaires = new List<Partenaire>();
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Partenaire WHERE Status = 0";

                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Type = reader.GetString(2);
                                Contact_phone = reader.GetString(3);
                                Contact_email = reader.GetString(4);
                                Date_ajout = reader.GetString(5);
                                Status = Convert.ToInt32(reader.GetString(6));
                            };
                            Partenaire partenaire = new Partenaire(Id, Name, Type, Contact_phone, Contact_email, Date_ajout, Status);
                            partenaires.Add(partenaire);
                        }
                    }
                    CRMDatabase.CloseConnection();
                }
                return partenaires;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void AddPartenaire(string name, string type, string contact_phone, string contact_email)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "INSERT INTO Partenaire (Name, Type, Contact_phone, Contact_email, Date_ajout, Status) VALUES (@Name, @Type, @Contact_phone, @Contact_email, @Date_ajout, @Status)";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Type", type);
                        command.Parameters.AddWithValue("@Contact_phone", contact_phone);
                        command.Parameters.AddWithValue("@Contact_email", contact_email);
                        command.Parameters.AddWithValue("@Date_ajout", Convert.ToString(DateTime.Now));
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

        public Partenaire GetPartenaire(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Partenaire WHERE Partner_id = " + id + " AND Status = 0";

                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Type = reader.GetString(2);
                                Contact_phone = reader.GetString(3);
                                Contact_email = reader.GetString(4);
                                Date_ajout = reader.GetString(5);
                                Status = Convert.ToInt32(reader.GetString(6));
                            };
                        }
                    }
                    CRMDatabase.CloseConnection();
                    Partenaire partenaire = new Partenaire(Id, Name, Type, Contact_phone, Contact_email, Date_ajout, Status);
                    return partenaire;
                }
                return null;                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void UpdatePartenaire(int id, string name, string type, string contact_phone, string contact_email)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Partenaire SET Name = @Name, Type = @Type, Contact_phone = @Contact_phone, Contact_email = @Contact_email, Status = @Status WHERE Partner_id = @Partner_id";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Type", type);
                        command.Parameters.AddWithValue("@Contact_phone", contact_phone);
                        command.Parameters.AddWithValue("@Contact_email", contact_email);
                        command.Parameters.AddWithValue("@Status", 0);
                        command.Parameters.AddWithValue("@Partner_id", id);

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
        public void DeletePartenaire(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Partenaire SET Status = @Status WHERE Partner_id = @Partner_id";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Status", 1);
                        command.Parameters.AddWithValue("@Partner_id", id);

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
