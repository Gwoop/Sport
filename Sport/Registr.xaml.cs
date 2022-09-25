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
using Sport.DataSet1TableAdapters;

namespace Sport
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            StaffTableAdapter a = new StaffTableAdapter();
            DataSet1.StaffDataTable b = new DataSet1.StaffDataTable();
            a.Fill(b);
            // Tablichka.ItemsSource = b;
        }

        private void Fam_TextChanged(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int i))
            {
                e.Handled = true;
            }
        }

        private void Name_TextChanged(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int i))
            {
                e.Handled = true;

            }
        }

        private void Mid_TextChanged(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int i))
            {
                e.Handled = true;

            }
        }

        private void num_TextChanged(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void email_TextChanged(object sender, TextCompositionEventArgs e)
        {

        }

        private void pas_TextChanged(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
                try
                {
                    if (String.IsNullOrWhiteSpace(Name.Text) || String.IsNullOrWhiteSpace(Fam.Text) || String.IsNullOrWhiteSpace(Mid.Text))
                        throw new Exception();
                    if (Name.Text != null && Fam.Text != null && Mid.Text != null && num.Text != null && email.Text != null )
                        new StaffTableAdapter().InsertQuery(Fam.Text,Name.Text,Mid.Text, Convert.ToInt32(num.Text),email.Text,pas.Text,0);
                    else
                        throw new Exception();
                    GetData();
                }
                catch
                {
                    MessageBox.Show("Вы сделали что-то не так и произошла ошибка. Просмотри ещё раз, что ты сделал :/");
                }
            
            MainWindow gg = new MainWindow();
            this.Hide();
            gg.Show();

        }
    }
}
