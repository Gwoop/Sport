using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Role.xaml
    /// </summary>
    public partial class Role : Window
    {
        public Role()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            RoleTableAdapter a = new RoleTableAdapter();
            DataSet1.RoleDataTable b = new DataSet1.RoleDataTable();
            a.Fill(b);
            Tablichka.ItemsSource = b;
        }

        private void Tablichka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tablichka.SelectedItem != null)
                Name.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
            if (Tablichka.SelectedItem != null)
                Salary.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
        }

        private void in_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                    new RoleTableAdapter().InsertQuery(Name.Text,Convert.ToDecimal(Salary.Text));
               
                GetData();
            }
            catch
            {
                MessageBox.Show("Вы сделали что-то не так и произошла ошибка. Просмотри ещё раз, что ты сделал :/");
            }
        }

        private void up_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(Name.Text) || String.IsNullOrWhiteSpace(Salary.Text))
                    throw new Exception();
                if (Name.Text != null && Salary.Text != null)
                    new RoleTableAdapter().UpdateQuery(Name.Text, Convert.ToDecimal(Salary.Text), Convert.ToInt32((Tablichka.SelectedItems[0] as DataRowView).Row.ItemArray[0]));

                else
                    throw new Exception();
                GetData();
            }
            catch
            {
                MessageBox.Show("Вы сделали что-то не так и произошла ошибка. Просмотри ещё раз, что ты сделал :/");
            }
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new RoleTableAdapter().DeleteQuery(Convert.ToInt32((Tablichka.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                GetData();
            }
            catch
            {
                MessageBox.Show("Вы сделали что-то не так и произошла ошибка. Просмотри ещё раз, что ты сделал :/");
            }
        }
    }
}
