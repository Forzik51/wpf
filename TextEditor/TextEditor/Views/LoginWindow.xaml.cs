using Serilog;
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
using TextEditor.Model;
using TextEditor.ViewModel.Sevices;

namespace TextEditor.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.
    public partial class LoginWindow : Window
    {

        private readonly UserDbService _userDbService;
        public LoginWindow() : this(new UserDbService()) { }
        public LoginWindow(UserDbService userDbService)
        {
            InitializeComponent();
            _userDbService = userDbService;
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordTextBox.Text;
            var user = _userDbService.LoginUser(login, password);
            if (user != null)
            {
                NotesWindow notesWindow = new NotesWindow();
                notesWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Login or password incorect");
                Log.Logger = new LoggerConfiguration()
                     .MinimumLevel.Debug()
                     .WriteTo.File("logs\\Log_SerilogDemoWPF.txt", rollingInterval: RollingInterval.Day)
                     .CreateLogger();

                Log.Information($"Error password from user {login} or {password}");

                Log.CloseAndFlush();

            }



        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow register = new RegisterWindow();
            register.Show();
            Close();
        }
    }
}

    
