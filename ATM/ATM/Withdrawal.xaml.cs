using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace ATM
{
    /// <summary>
    /// Interaction logic for Withdrawal.xaml
    /// </summary>
    public partial class Withdrawal : Window
    {
        CurrentUser user;
        SqlConnection connection;
        SqlCommand command;
        List<string> accountName = new List<string>();
        ClientBalance clientBalance;
        List<ClientBalance> balanceList = new List<ClientBalance>();
        bool open = false;
        Random rnd = new Random();
        
        public Withdrawal(CurrentUser current, ClientBalance currentBalance)
        {
            InitializeComponent();
            open = true;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            user = current;
            clientBalance = currentBalance;
            FillList();
            int randomNumber = rnd.Next(1000, 2000);


        }

        public void FillList()
        {
            balanceList.Clear();
            accountList.DataContext = balanceList.ToList();


            //Check the Established connection
            try
            {

                string authentication = "SELECT  accountTypeCode,Balance FROM accounts WHERE clientCode = '" + user.clientCode + "'";
                command = new SqlCommand(authentication, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Check to see if a record was found
                while (reader.Read())
                {
                    //Creates the CurrentUser object

                    clientBalance = new ClientBalance();
                    clientBalance.accountTypeCode = reader["accountTypeCode"].ToString();
                    clientBalance.Balance = (int)reader["Balance"];
                    balanceList.Add(clientBalance);

                }



                accountList.DataContext = balanceList.ToList();


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

        public void withdraw()
        {
            if (accountList.SelectedIndex == -1)
            {
                return;
            }



            int amountInput = Convert.ToInt32(amountTxt.Text);
            int total;
            ClientBalance currentAccount = balanceList[accountList.SelectedIndex];
            int currentBalance = currentAccount.Balance;
            if(currentBalance <= amountInput)
            {
                MessageBox.Show("The request is more than Balance", "Try again", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
            else if(amountInput % 10 != 0)
            {
                MessageBox.Show("Please Enter multiple of 10 ! ", "Try again", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (amountInput > 1000)
            {
                MessageBox.Show("Withdraw cant be more than 1000 $ ", "Try again", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
               
                connection.Open();
                total = currentBalance - amountInput;

                string balanceUpdate = "UPDATE accounts SET Balance = '" + total + "' WHERE clientCode = '" + user.clientCode + "' AND accountTypeCode = '" + currentAccount.accountTypeCode + "'";

                string transactionRecord = $"INSERT INTO transactionR(clientCode,time) Values('{user.clientCode}', '{DateTime.Now.TimeOfDay}')";

                try
                {
                    command = new SqlCommand(balanceUpdate, connection);
                    command.ExecuteNonQuery();
                    command = new SqlCommand(transactionRecord, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("The balance has been updated.", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
            Hide();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            withdraw();
        }
    }
}
