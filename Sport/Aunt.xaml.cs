using System;
using System.Collections.Generic;
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

namespace Sport
{
    /// <summary>
    /// Логика взаимодействия для Aunt.xaml
    /// </summary>
    public partial class Aunt : Window
    {
        public Aunt()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source = DESKTOP-HG6810U;Initial Catalog = Sport; Integrated Security = True;");
            using (conn1)
            {
                conn1.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM [Staff]", conn1);
                SqlDataReader read1 = cmd1.ExecuteReader();
                using (read1)
                {
                    while (true)
                    {
                        if (read1.Read() == false)
                        {
                            MessageBox.Show("Неверный логин или пароль!");
                            break;
                        }
                        if (read1["Email"].ToString() == Login.Text.Trim() && read1["Password"].ToString() == pas.Text.Trim())
                        {
                            if (read1["Role_ID"].ToString() == "1")
                            {
                                Admin _doctor = new Admin();
                                _doctor.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                                _doctor.Show();
                                this.Close();
                            }
                            else if (read1["Role_ID"].ToString() == "2")
                            {
                                Trener _registrator = new Trener();
                                _registrator.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                                _registrator.Show();
                                this.Close();
                            }
                            else if (read1["Role_ID"].ToString() == "3")
                            {
                                Club _admin = new Club();
                                _admin.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                                _admin.Show();
                                this.Close();
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
    

