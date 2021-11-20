using ContactList.Data.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ContactList
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        List<User> user;
        public LoginWindow()
        {
            user = new List<User>();
            InitializeComponent();
            GetUsers();
        }

        void GetUsers()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<User>();
                user = connection.Table<User>().ToList();

            }
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach(User item in user)
            {
                if (item.Login == loginTextBox.Text)
                {
                    if (item.Password == passwordTextBox.Text)
                    {
                        Close();
                        MessageBox.Show("Login ok");
                    }

                }
                

            }
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            bool addUser = true;
            foreach (User item in user)
            {
                if (item.Login == loginTextBox.Text )
                    addUser = false;

            }
            if (addUser == true)
            {
                User User = new User
                {
                    Login = loginTextBox.Text,
                    Password = passwordTextBox.Text
                };
                using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
                {
                    connection.CreateTable<User>();
                    connection.Insert(User);
                }

                Close();
            }
            else
            {
                MessageBox.Show("Error Login");
            }
        }
    }
}
