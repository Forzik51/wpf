using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Data.Models
{
    class User
    {
            [PrimaryKey, AutoIncrement]
            public uint Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }

            public override string ToString()
            {
                return $"{Login} - {Password}";
            }
    }
}
