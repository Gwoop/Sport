using Sport.DataSet1TableAdapters;
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

namespace Sport
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            StaffTableAdapter a = new StaffTableAdapter();
            DataSet1.StaffDataTable b = new DataSet1.StaffDataTable();
            a.Fill(b);
            Tablichka.ItemsSource = b;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Trener trener = new Trener();
            trener.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Role role = new Role();
            role.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Meropriat meropriat = new Meropriat();
            meropriat.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Club club = new Club();
            club.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                new StaffTableAdapter().DeleteQuery(Convert.ToInt32((Tablichka.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                GetData();
            }
            catch
            {
                MessageBox.Show("Вы сделали что-то не так и произошла ошибка. Просмотри ещё раз, что ты сделал :/ (DeleteEx)");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(fam.Text) || String.IsNullOrWhiteSpace(Name.Text) || String.IsNullOrWhiteSpace(otv.Text) || String.IsNullOrWhiteSpace(num.Text) || String.IsNullOrWhiteSpace(em.Text) || String.IsNullOrWhiteSpace(pas.Text)
                        || String.IsNullOrWhiteSpace(cm.Text))
                    throw new Exception();
                if (Name.Text != null && fam.Text != null && cm.Text!= null)
                    new StaffTableAdapter().InsertQuery(fam.Text,Name.Text,otv.Text,Convert.ToInt32(num.Text),em.Text,pas.Text,(int)cm.SelectedValue);
                else
                    throw new Exception();
                GetData();
            }
            catch
            {
                MessageBox.Show("Вы сделали что-то не так и произошла ошибка. Просмотри ещё раз, что ты сделал :/");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {

                if (String.IsNullOrWhiteSpace(fam.Text) || String.IsNullOrWhiteSpace(Name.Text) || String.IsNullOrWhiteSpace(otv.Text) || String.IsNullOrWhiteSpace(num.Text) || String.IsNullOrWhiteSpace(em.Text) || String.IsNullOrWhiteSpace(pas.Text)
                        || String.IsNullOrWhiteSpace(cm.Text))
                    throw new Exception();
                if (Name.Text != null && fam.Text != null && cm.Text != null)
                    new StaffTableAdapter().UpdateQuery(fam.Text, Name.Text, otv.Text, Convert.ToInt32(num.Text), em.Text, pas.Text, (int)cm.SelectedValue, Convert.ToInt32((Tablichka.SelectedItems[0] as DataRowView).Row.ItemArray[0]));

                else
                    throw new Exception();
                GetData();
            }
            catch
            {
                MessageBox.Show("Вы сделали что-то не так и произошла ошибка. Просмотри ещё раз, что ты сделал :/");
            }
        }

        private void Tablichka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (Tablichka.SelectedItem != null)
                fam.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
            if (Tablichka.SelectedItem != null)
                Name.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
            if (Tablichka.SelectedItem != null)
                otv.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
            if (Tablichka.SelectedItem != null)
                num.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[4].ToString();
            if (Tablichka.SelectedItem != null)
                em.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[5].ToString();
            if (Tablichka.SelectedItem != null)
                pas.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[6].ToString();
            if (Tablichka.SelectedItem != null)
                cm.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[7].ToString();


        }
    }
}
