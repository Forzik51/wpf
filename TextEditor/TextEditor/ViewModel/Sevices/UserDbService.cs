using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Model;

namespace TextEditor.ViewModel.Sevices
{
    public class UserDbService
    {
        private const string dbName = "Database.db";
        public static string dbPath = Path.Combine(Environment.CurrentDirectory, dbName);

        public User LoginUser(string login, string passsword)
        {
            using (SQLiteConnection connection = new SQLiteConnection(dbPath))
            {
                connection.CreateTable<User>();
                User user = connection.Table<User>().Where(u => u.Username == login && u.Password == passsword).FirstOrDefault();
                return user;
            }
        }

        public bool RegisterUser(User NewUser)
        {
            using (SQLiteConnection connection = new SQLiteConnection(dbPath))
            {
                connection.CreateTable<User>();
                User user = new User(); user = connection.Table<User>().Where(u => u.Username == NewUser.Username).FirstOrDefault();
                if(user == null)
                {
                    connection.Insert(NewUser);
                    return true;
                }
                return false;
            }
        }
    }
}
