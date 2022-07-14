using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
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

namespace ATM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CurrentUser user;
        SqlConnection connection;
        SqlCommand command;
        List<string> accountName = new List<string>();
        ClientBalance clientBalance;
        List<ClientBalance> balanceList = new List<ClientBalance>();
        bool open = false;

        public MainWindow(CurrentUser current)
        {
            InitializeComponent();

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            user = current;
  

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            fillList();
        }

        public void fillList()
        {
            balanceList.Clear();
            listBoxBalance.DataContext = balanceList.ToList();
            listBoxType.DataContext = balanceList.ToList();

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
               

                
                listBoxBalance.DataContext = balanceList.ToList();
                listBoxType.DataContext = balanceList.ToList();
               
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Deposit deposit = new Deposit(user, clientBalance);
            deposit.Show();
            Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            BillPayment billPayment = new BillPayment(user, clientBalance);
            billPayment.Show();
            Hide();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Withdrawal withdrawal = new Withdrawal(user, clientBalance);
            withdrawal.Show();
            Hide();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            TransferMoney withdrawal = new TransferMoney(user, clientBalance);
            withdrawal.Show();
            Hide();

        }
    }




    
    }

