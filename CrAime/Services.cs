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
    }
}
