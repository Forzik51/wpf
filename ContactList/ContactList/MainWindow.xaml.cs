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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            GetContacts();
            LoginWindow createLoginWindow = new LoginWindow();
            createLoginWindow.ShowDialog();

        }

        void GetContacts()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList();

                if(contacts != null)
                {
                    contactsListView.ItemsSource = contacts;
                }
            }
            sortedCont();

        }

        void sortedCont()
        {
            contacts.Sort( (x,y) => x.Name.CompareTo(y.Name));
        }

        private void newContactBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateNewWindow createNewWindow = new CreateNewWindow();
            createNewWindow.ShowDialog();
            GetContacts();
            sortedCont();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = contactsListView.SelectedItem as Contact;
            if(selectedContact != null)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
                contactDetailsWindow.ShowDialog();
                GetContacts();
            }

        }
    }
}
