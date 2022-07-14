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
    /// Interaction logic for TransferMoney.xaml
    /// </summary>
    public partial class TransferMoney : Window
    {
        CurrentUser user;
        SqlConnection connection;
        SqlCommand command;
        List<string> accountName = new List<string>();
        ClientBalance clientBalance;
        List<ClientBalance> balanceList = new List<ClientBalance>();
        bool open = false;

        public TransferMoney(CurrentUser current, ClientBalance currentBalance)
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
            accountList1.DataContext = balanceList.ToList();
            accountList2.DataContext = balanceList.ToList();
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



                accountList1.DataContext = balanceList.ToList();
                accountList2.DataContext = balanceList.ToList();


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

        public void transferMoney()
        {
            connection.Open();
            if (accountList1.SelectedIndex == -1 && accountList2.SelectedIndex == -1)
            {
                return;
            }




            int amountInput = Convert.ToInt32(amountTxt.Text);
            ClientBalance currentAccount = balanceList[accountList1.SelectedIndex];
            int currentBalance = currentAccount.Balance;
            int deducted;
            int addded;
            if (amountInput % 10 != 0 && amountInput <= 0)
            {
                MessageBox.Show("Please Enter multiple of 10 ! ", "Try again", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (currentBalance <= amountInput)
            {
                MessageBox.Show("The request is more than Balance", "Try again", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else { 
                
                ClientBalance currentAccount1 = balanceList[accountList1.SelectedIndex];
                int currentBalance1 = currentAccount1.Balance;                
                
                if (currentBalance1 != 0)
                {
                    deducted = currentBalance1 - amountInput;
                    ClientBalance currentAccount2 = balanceList[accountList2.SelectedIndex];
                    int currentBalance2 = currentAccount2.Balance;
                    addded = currentBalance2 + amountInput;

                    string balanceUpdate1 = "UPDATE accounts SET Balance = '" + deducted + "' WHERE clientCode = '" + user.clientCode + "' AND accountTypeCode = '" + currentAccount1.accountTypeCode + "'";
                    string balanceUpdate2 = "UPDATE accounts SET Balance = '" + addded + "' WHERE clientCode = '" + user.clientCode + "' AND accountTypeCode = '" + currentAccount2.accountTypeCode + "'";
                    string transactionRecord = $"INSERT INTO transactionR(clientCode,time) Values('{user.clientCode}', '{DateTime.Now.TimeOfDay}')";

                    try
                    {
                        command = new SqlCommand(balanceUpdate1, connection);
                        command.ExecuteNonQuery();
                        command = new SqlCommand(balanceUpdate2, connection);
                        command.ExecuteNonQuery();
                        command = new SqlCommand(transactionRecord, connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Money has been Transfered", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

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
                else
                {
                    MessageBox.Show("No Balance in this accaunt ", "Try !", MessageBoxButton.OK, MessageBoxImage.Information);
                }
    
            }
            connection.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            transferMoney();
        }
    }
}
