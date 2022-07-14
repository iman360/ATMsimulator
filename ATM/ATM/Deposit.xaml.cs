using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Deposit.xaml
    /// </summary>
    public partial class Deposit : Window


    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        CurrentUser user;
        SqlConnection connection;
        SqlCommand command;
        List<string> accountName = new List<string>();
        ClientBalance clientBalance;
        List<ClientBalance> balanceList = new List<ClientBalance>();
        bool open = false;

        public Deposit(CurrentUser current, ClientBalance currentBalance)
        {
            InitializeComponent();
            open = true;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            user = current;
            clientBalance = currentBalance;
            fillList();
        }

        public void fillList()
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            depositMoney();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
            Hide();




        }
        public void depositMoney()
        {
            if (accountList.SelectedIndex == -1)
            {
                return;
            }



                
            int amountInput = Convert.ToInt32(amountTxt.Text);
            int total;
            if (amountInput % 10 != 0)
            {
                MessageBox.Show("Please Enter multiple of 10 ! ", "Try again", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                connection.Open();
                ClientBalance currentAccount = balanceList[accountList.SelectedIndex];
                int currentBalance = currentAccount.Balance;
                total = amountInput + currentBalance;

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
    }
}
