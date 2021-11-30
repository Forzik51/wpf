using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public uint Id { get; set; }
        [MaxLength(40)]
        public string FName { get; set; }
        [MaxLength(50)]
        public string LName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
