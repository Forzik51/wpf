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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly UserDbService _userDbService;

        public RegisterWindow() : this(new UserDbService()) { }
        public RegisterWindow(UserDbService userDbService)
        {
            InitializeComponent();
            _userDbService = userDbService;
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            User User = new User
            {
                FName = FnameTextBox.Text,
                LName = LnameTextBox.Text,
                Username = UserameTextBox.Text,
                Password = passwordTextBox.Text
            };

            var login = _userDbService.RegisterUser(User);
            if (login == true)
            {
                NotesWindow notesWindow = new NotesWindow();
                notesWindow.Show();
                Close();
            }
            else
                MessageBox.Show("error login");
                
        }
    }
}
