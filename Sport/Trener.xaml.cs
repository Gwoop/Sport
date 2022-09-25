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
    /// Логика взаимодействия для Trener.xaml
    /// </summary>
    public partial class Trener : Window
    {
        public Trener()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            Type_SportTableAdapter a = new Type_SportTableAdapter();
            DataSet1.Type_SportDataTable b = new DataSet1.Type_SportDataTable();
            a.Fill(b);
            Tablichka.ItemsSource = b;


            StaffTableAdapter A1 = new StaffTableAdapter();
            DataSet1.StaffDataTable B1 = new DataSet1.StaffDataTable();
            A1.Fill(B1);
            cm.ItemsSource = B1;
            cm.DisplayMemberPath = "Email";
            cm.SelectedValuePath = "ID_Staff";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (cm.SelectedValue != null && cm1.Text != null)
                    new Type_SportTableAdapter().InsertQuery(cm1.Text,(int)cm.SelectedValue);
                else
                    throw new Exception();
                GetData();
            }
            catch
            {
                MessageBox.Show("Вы сделали что-то не так и произошла ошибка. Просмотри ещё раз, что ты сделал :/");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                if (cm.SelectedValue != null && cm1.Text != null)
                    new Type_SportTableAdapter().UpdateQuery(cm1.Text, (int)cm.SelectedValue, Convert.ToInt32((Tablichka.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                else
                    throw new Exception();

                GetData();
            }
            catch
            {
                MessageBox.Show("Вы сделали что-то не так и произошла ошибка. Просмотри ещё раз, что ты сделал :/");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                new Type_SportTableAdapter().DeleteQuery(Convert.ToInt32((Tablichka.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
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
                cm.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
            if (Tablichka.SelectedItem != null)
                cm1.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
   
        }
    }
}
