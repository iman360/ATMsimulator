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
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        SqlConnection connection;
        SqlCommand command;
        Authentication authentication1;
        List<Authentication> accountList = new List<Authentication>();
        ClientBalance balance = new ClientBalance();

        public AdminMenu()
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            accountTypeCombo.Items.Add("checking");
            accountTypeCombo.Items.Add("saving");
            accountTypeCombo.Items.Add("morgage");
            accountTypeCombo.Items.Add("LOC");
 

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            creatUser();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        public void creatUser()
        {
            connection.Open();

            string addClient = $"INSERT INTO client(clientCode,fullName,phone,email,NIP) Values('{clientCTxt.Text}', '{fullNameTxt.Text}', '{phoneTxt.Text}', '{emainTxt.Text}', '{nipTxt.Text}')";

            try
            {

                command = new SqlCommand(addClient, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("The client successfully added", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

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


        public void lockCLient()
        {
            connection.Open();

            string addClient = "UPDATE client SET lock = '" + 1 + "' WHERE  clientCode = '" + clientLockTxt.Text + "'";

            try
            {

                command = new SqlCommand(addClient, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("The client successfully locked", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

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

        public void unlockCLient()
        {
            connection.Open();

            string addClient = "UPDATE client SET lock = '" + 0 + "' WHERE  clientCode = '" + clientLockTxt.Text + "'";

            try
            {

                command = new SqlCommand(addClient, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("The client successfully Unlocked", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

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

        public void creatAccount()
        {
            connection.Open();

            string addClient = $"INSERT INTO accounts(clientCode,accountTypeCode,Balance) Values('{creatClientCodeTxt.Text}', '{accountTypeCombo.SelectedItem}', '{0}')";

            try
            {

                command = new SqlCommand(addClient, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("The Account successfully added", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

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


        public void fillList()
        {
            
            /*transactionIdTxt
                clientCodeRTxt
                timeRTxt
            balanceList.Clear();
            listBoxBalance.DataContext = balanceList.ToList();
            listBoxType.DataContext = balanceList.ToList();*/

            //Check the Established connection
            try
            {

                string authentication = "SELECT transactionId,clientCode,time FROM transactionR";
                command = new SqlCommand(authentication, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Check to see if a record was found
                while (reader.Read())
                {
                    //Creates the CurrentUser object
                    authentication1 = new Authentication();
                    authentication1.transactionId = reader["transactionId"].ToString();
                    authentication1.clientCode = reader["clientCode"].ToString();
                    authentication1.time = reader["clientCode"].ToString();
                    accountList.Add(authentication1);
                }
                transactionIdTxt.DataContext = accountList.ToList();
                transactionIdTxt1.DataContext = accountList.ToList();
                transactionIdTxt2.DataContext = accountList.ToList();


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

        public void addMoney()
        {
            int moneyBint = 0;
     
            moneyBint = Convert.ToInt32(moneyTxt.Text);
            
           

            if (moneyBint > 20000)
            {
                MessageBox.Show("You can not add more than 20 000 $");
            }
            else
            {
                connection.Open();

                string addMoney = "UPDATE money SET moneyBalance = '" + moneyTxt.Text + "'";

                try
                {

                    command = new SqlCommand(addMoney, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Money added", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

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

        public void payInterest()
        {
            MessageBox.Show("Interest has been added", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
        }




        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            lockCLient();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            unlockCLient();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            creatAccount();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            fillList();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            addMoney();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            payInterest();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            payInterest();
        }
    }
}
