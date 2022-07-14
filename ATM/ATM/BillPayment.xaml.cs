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
    /// Interaction logic for BillPayment.xaml
    /// </summary>
    public partial class BillPayment : Window
    {
        CurrentUser user;
        SqlConnection connection;
        SqlCommand command;
        List<string> accountName = new List<string>();
        ClientBalance clientBalance;
        List<ClientBalance> balanceList = new List<ClientBalance>();
        bool open = false;


        public void FillList()
        {
            balanceList.Clear();
           


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



        public BillPayment(CurrentUser current, ClientBalance currentBalance)
        {
            InitializeComponent();
            open = true;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            user = current;
            clientBalance = currentBalance;
            FillList();
        }
        public void payBill()
        {

            int fee = 1;
            int indexOfBalanceList = 0;
            for (int i = 0; i < balanceList.Count; i++)
            {
                if (balanceList[i].accountTypeCode.Contains("checking"))
                {
                    indexOfBalanceList = i;
                }
            }
            ClientBalance currentAccount = balanceList[indexOfBalanceList];
            int currentBalance = currentAccount.Balance;
            int newB = currentBalance - fee;


            connection.Open();

            string balanceUpdate = "UPDATE accounts SET Balance = '" + newB + "' WHERE clientCode = '" + user.clientCode + "' AND accountTypeCode = 'checking'";
            string transactionRecord = $"INSERT INTO transactionR(clientCode,time) Values('{user.clientCode}', '{DateTime.Now.TimeOfDay}')";

            try
            {
                command = new SqlCommand(balanceUpdate, connection);
                command.ExecuteNonQuery();
                command = new SqlCommand(transactionRecord, connection);
                command.ExecuteNonQuery();

                MessageBox.Show("The Bill has been payed", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

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
            payBill();
        }

        private void Button_Click_exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(user);
            mainWindow.Show();
            Hide();
        }
    }
}

