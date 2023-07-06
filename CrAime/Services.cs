using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CrAime
{
    public static class Services
    {
        #region User
        public static List<User> GetAllUsers()
        {
            try
            {
                List<User> users = new List<User>();
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM User WHERE Status = 0";

                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int Id;
                        string Email;
                        string Password;
                        string First_name;
                        string Last_name;
                        string Phone_number;
                        int Is_admin;
                        string Creation_date;
                        int Status;
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Email = reader.GetString(1);
                                Password = reader.GetString(2);
                                First_name = reader.GetString(3);
                                Last_name = reader.GetString(4);
                                Phone_number = reader.GetString(5);
                                Is_admin = reader.GetInt32(6);
                                Creation_date = reader.GetString(7);
                                Status = reader.GetInt32(8);
                            };
                            User user = new User(Id, Email, Password, First_name, Last_name, Phone_number, Is_admin, Creation_date, Status);
                            users.Add(user);
                        }
                    }
                    CRMDatabase.CloseConnection();
                }
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public static User GetUser(int id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM User WHERE User_id = " + id + " AND Status = 0";

                    int Id = 0;
                    string Email = null;
                    string Password = null;
                    string First_name = null;
                    string Last_name = null;
                    string Phone_number = null;
                    int Is_admin = 0;
                    string Creation_date = null;
                    int Status = 0;
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Email = reader.GetString(1);
                                Password = reader.GetString(2);
                                First_name = reader.GetString(3);
                                Last_name = reader.GetString(4);
                                Phone_number = reader.GetString(5);
                                Is_admin = reader.GetInt32(6);
                                Creation_date = reader.GetString(7);
                                Status = reader.GetInt32(8);
                            };
                        }
                    }
                    CRMDatabase.CloseConnection();
                    User user = new User(Id, Email, Password, First_name, Last_name, Phone_number, Is_admin, Creation_date, Status);
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static void AddUser(string email, string password, string firstname, string lastname, string phonenumber, string isadmin)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "INSERT INTO User (email, password, first_name, last_name, phone_number, is_admin, creation_Date, status) VALUES (@Email, @Password, @First_name, @Last_name, @Phone_number, @Is_admin, @Creation_Date, @Status)";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@First_name", firstname);
                        command.Parameters.AddWithValue("@Last_name", lastname);
                        command.Parameters.AddWithValue("@Phone_number", phonenumber);
                        command.Parameters.AddWithValue("@Is_admin", isadmin);
                        command.Parameters.AddWithValue("@Creation_Date", Convert.ToString(DateTime.Now));
                        command.Parameters.AddWithValue("@Status", 0);
                        command.ExecuteNonQuery();

                    }
                    CRMDatabase.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                Console.WriteLine(ex);
            }
        }
        public static void UpdateUser(string id, string email, string password, string firstname, string lastname, string phonenumber, string isadmin)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE User SET Email = @Email, Password = @Password, First_name = @First_name, Last_name = @Last_name, Phone_number = @Phone_number, Is_admin = @Is_admin, Status = @Status WHERE User_id = @User_id";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@User_id", id);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@First_name", firstname);
                        command.Parameters.AddWithValue("@Last_name", lastname);
                        command.Parameters.AddWithValue("@Phone_number", phonenumber);
                        command.Parameters.AddWithValue("@Is_admin", isadmin);
                        command.Parameters.AddWithValue("@Creation_Date", Convert.ToString(DateTime.Now));
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

        public static void DeleteUser(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE User SET Status = @Status WHERE User_id = @User_id";
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    {
                        command.Parameters.AddWithValue("@Status", 1);
                        command.Parameters.AddWithValue("@User_id", id);

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
        #endregion

        #region Association
        public static List<Associations> GetAllAsso()
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
                        int Id;
                        string Name;
                        int Status;
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Status = reader.GetInt32(2);
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

        public static void AddAnAsso(string name)
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

        public static Associations GetAnAsso(int id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Associations WHERE Association_id = " + id + " AND Status = 0";

                    int Id = 0;
                    string Name = null;
                    int Status = 0;
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Status = reader.GetInt32(2);
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

        public static void UpdateAnAsso(string id, string name)
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
        public static void DeleteAnAsso(string id)
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
        #endregion

        #region Poste

        public static List<Poste> GetAllPoste()
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
                        int Id;
                        string Name;
                        string Description;
                        int Status;
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Description = reader.GetString(2);
                                Status = reader.GetInt32(3);
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

        public static void AddPoste(string name, string description)
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

        public static Poste GetPoste(int id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Poste WHERE Poste_id = " + id + " AND Status = 0";

                    int Id = 0;
                    string Name = null;
                    string Description = null;
                    int Status = 0;
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Description = reader.GetString(2);
                                Status = reader.GetInt32(3);
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

        public static void UpdatePoste(string id, string name, string description)
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
        public static void DeletePoste(string id)
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

        #endregion

        #region Evenement

        public static List<Evenement> GetAllEvent()
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
                        int Id;
                        string Title;
                        string Type;
                        string Description;
                        string Start_date;
                        string End_date;
                        int Status;
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Title = reader.GetString(1);
                                Type = reader.GetString(2);
                                Description = reader.GetString(3);
                                Start_date = reader.GetString(4);
                                End_date = reader.GetString(5);
                                Status = reader.GetInt32(6);
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

        public static void AddAnEvent(string title, string type, string description, string start_date, string end_date)
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

        public static Evenement GetAnEvent(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Evenement WHERE Event_id = " + id + " AND Status = 0";

                    int Id = 0;
                    string Title = null;
                    string Type = null;
                    string Description = null;
                    string Start_date = null;
                    string End_date = null;
                    int Status = 0;
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
                                Status = reader.GetInt32(6);
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

        public static void UpdateAnEvent(string id, string title, string type, string description, string start_date, string end_date)
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
        public static void DeleteAnEvent(string id)
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

        #endregion

        #region Partenaire

        public static List<Partenaire> GetAllPartenaire()
        {
            try
            {
                List<Partenaire> partenaires = new List<Partenaire>();
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Partenire WHERE Status = 0";

                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int Id;
                        string Name;
                        string Type;
                        string Contact_phone;
                        string Contact_email;
                        string Date_ajout;
                        int Status;
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Type = reader.GetString(2);
                                Contact_phone = reader.GetString(3);
                                Contact_email = reader.GetString(4);
                                Date_ajout = reader.GetString(5);
                                Status = reader.GetInt32(6);
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

        public static void AddPartenaire(string name, string type, string contact_phone, string contact_email)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "INSERT INTO Partenire (Name, Type, Contact_phone, Contact_email, Date_ajout, Status) VALUES (@Name, @Type, @Contact_phone, @Contact_email, @Date_ajout, @Status)";
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

        public static Partenaire GetPartenaire(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Partenire WHERE Partner_id = " + id + " AND Status = 0";

                    int Id = 0;
                    string Name = null;
                    string Type = null;
                    string Contact_phone = null;
                    string Contact_email = null;
                    string Date_ajout = null;
                    int Status = 0;
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
                                Status = reader.GetInt32(6);
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

        public static void UpdatePartenaire(string id, string name, string type, string contact_phone, string contact_email)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Partenire SET Name = @Name, Type = @Type, Contact_phone = @Contact_phone, Contact_email = @Contact_email, Status = @Status WHERE Partner_id = @Partner_id";
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
        public static void DeletePartenaire(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Partenire SET Status = @Status WHERE Partner_id = @Partner_id";
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

        #endregion

        #region Regle

        public static List<Regle> GetAllRegle()
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
                        int Id;
                        string Description;
                        int Status;
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Description = reader.GetString(1);
                                Status = reader.GetInt32(2);
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

        public static void AddRegle(string description)
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

        public static Regle GetRegle(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Regles WHERE Regles_id = " + id + " AND Status = 0";

                    int Id = 0;
                    string Description = null;
                    int Status = 0;
                    using (MySqlCommand command = new MySqlCommand(query, CRMDatabase.connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Description = reader.GetString(1);
                                Status = reader.GetInt32(2);
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

        public static void UpdateRegle(string id, string description)
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
                        command.Parameters.AddWithValue("@Regles_id", id);

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
        public static void DeleteRegle(string id)
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

        #endregion

        #region Stock

        public static List<Stock> GetAllStocks()
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
                        int Id;
                        string Name;
                        int Quantity;
                        int Min_Quantity;
                        int Max_Quantity;
                        string Measure_Unit;
                        int Status;
                        while (reader.Read())
                        {
                            {
                                Id = reader.GetInt32(0);
                                Name = reader.GetString(1);
                                Quantity = reader.GetInt32(2);
                                Min_Quantity = reader.GetInt32(3);
                                Max_Quantity = reader.GetInt32(4);
                                Measure_Unit = reader.GetString(5);
                                Status = reader.GetInt32(6);
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

        public static void AddStock(string name, int quantity, int min_quantity, int max_quantity, string measure_unit)
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

        public static Stock GetStock(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM Stock WHERE Stock_id = " + id + " AND Status = 0";

                    int Id = 0;
                    string Name = null;
                    int Quantity = 0;
                    int Min_Quantity = 0;
                    int Max_Quantity = 0;
                    string Measure_Unit = null;
                    int Status = 0;
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
                                Status = reader.GetInt32(6);
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

        public static void UpdateStock(string id, string name, int quantity, int min_quantity, int max_quantity, string measure_unit)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "UPDATE Stock SET Name = @Name, Quantity = @Quantity, Min_Quantity = @Min_Quantity, Max_Quantity = @Max_Quantity, Measure_Unit = @Measure_Unit, Status = @Status WHERE Stock_id = @Stock_id";
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
        public static void DeleteStock(string id)
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

        #endregion
    }
}
