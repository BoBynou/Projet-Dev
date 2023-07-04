using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CrAime
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Phone_number { get; set; }
        public int Is_admin { get; set; }
        public string Creation_date { get; set; }
        public int Status { get; set; }

        public User(int id, string email,string password, string first_name, string last_name, string phone_number, int is_admin, string creation_date, int status)
        {
            Id = id;
            Email = email;
            Password = password;
            First_name = first_name;
            Last_name = last_name;
            Phone_number = phone_number;
            Is_admin = is_admin;
            Creation_date = creation_date;
            Status = status;
        }

        public List<User> GetAllUsers()
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

        public void AddUser(string email, string password, string firstname, string lastname, string phonenumber, int isadmin)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "INSERT INTO User (Email, Password, First_name, Last_name, Phone_number, Is_admin, Creation_Date, Status) VALUES (@Email, @Password, @First_name, @Last_name, @Phone_number, @Is_admin, @Creation_Date, @Status)";
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
                Console.WriteLine(ex);
            }
        }

        public User GetUser(string id)
        {
            try
            {
                if (CRMDatabase.OpenConnection() == true)
                {
                    string query = "SELECT * FROM User WHERE User_id = " + id + " AND Status = 0";

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

        public void UpdateUser(string id, string email, string password, string firstname, string lastname, string phonenumber, int isadmin)
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
        public void DeleteUser(string id)
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
    }
}
