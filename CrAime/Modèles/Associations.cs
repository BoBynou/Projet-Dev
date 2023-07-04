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
    }
}
