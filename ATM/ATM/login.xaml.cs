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
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace ATM
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        SqlConnection connection;
        SqlCommand command;
        bool open = false;
        bool isLocked = false;
        string clientC;


        public login()
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            //txtUser.Focus();
            open = true;




        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            //check if is admin
            if (txtPin.Password == "1111")
            {
                AdminMenu adminMenu = new AdminMenu();
                adminMenu.Show();
                Hide();
            }
            else
            {
                //Check the user pin
                try
                {
                    string authentication = "SELECT * FROM client WHERE NIP = '" + txtPin.Password + "'";
                    command = new SqlCommand(authentication, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    //Check to see if a record was found
                    if (reader.Read())
                    {
                        //Creates the CurrentUser object

                    CurrentUser user = new CurrentUser();
                    user.fullName = reader["fullName"].ToString();
                    user.clientCode = reader["clientCode"].ToString();
                    user.isLock = Convert.ToInt32 (reader["lock"]);

                        //Check user is locked
                        if(user.isLock == 0) {
                            MessageBox.Show("Welcome " + user.fullName + user.clientCode);
                            MainWindow mainWindow = new MainWindow(user);


                            //Show the mainWindow                  
                            mainWindow.Show();

                            open = false;

                            //Close the Login form
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("YOU ARE LOCKED");
                        }
         
                        
                    }
                    else  
                    {
                        //Login failed
                        MessageBox.Show("Wrong Password Try Again");
                        txtPin.Password = String.Empty;
                        txtPin.Focus();
                    }
                    /* //Check the Established connection
                     connection.Open();
                     MessageBox.Show("Connection to the database  established.");
                     */
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtPin.Clear();

        }
    }
}
