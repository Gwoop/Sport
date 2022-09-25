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
    /// Логика взаимодействия для Club.xaml
    /// </summary>
    public partial class Club : Window
    {
        public Club()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            ClubTableAdapter a = new ClubTableAdapter();
            DataSet1.ClubDataTable b = new DataSet1.ClubDataTable();
            a.Fill(b);
            Tablichka.ItemsSource = b;



            StaffTableAdapter A1 = new StaffTableAdapter();
            DataSet1.StaffDataTable B1 = new DataSet1.StaffDataTable();
            A1.Fill(B1);
            cm.ItemsSource = B1;
            cm.DisplayMemberPath = "Email";
            cm.SelectedValuePath = "ID_Staff";


            MeropiatTableAdapter A2 = new MeropiatTableAdapter();
            DataSet1.MeropiatDataTable B2 = new DataSet1.MeropiatDataTable();
            A2.Fill(B2);
            cm1.ItemsSource = B2;
            cm1.DisplayMemberPath = "Name";
            cm1.SelectedValuePath = "ID_Meropiat";

        }

        private void Tablichka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tablichka.SelectedItem != null)
                cm.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
            if (Tablichka.SelectedItem != null)
                tex.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
            if (Tablichka.SelectedItem != null)
                cm1.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cm1.SelectedValue != null && cm.SelectedValue != null && tex.Text!= null)
                    new ClubTableAdapter().InsertQuery((int)cm.SelectedValue,tex.Text, (int)cm1.SelectedValue);
                else
                    throw new Exception();

                GetData();
            }
            catch
            {
                MessageBox.Show("Вы сделали что-то не так и произошла ошибка. Просмотри ещё раз, что ты сделал :/ (InsertEX)");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                if (cm1.SelectedValue != null && cm.SelectedValue != null && tex.Text != null)
                    new ClubTableAdapter().UpdateQuery((int)cm.SelectedValue,tex.Text, (int)cm1.SelectedValue, Convert.ToInt32((Tablichka.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                else
                    throw new Exception();

                GetData();
            }
            catch
            {
                MessageBox.Show("Вы сделали что-то не так и произошла ошибка. Просмотри ещё раз, что ты сделал :/ (UpdateEX)");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {

                new ClubTableAdapter().DeleteQuery(
                    Convert.ToInt32((Tablichka.SelectedItems[0] as DataRowView).Row.ItemArray[0]));

                GetData();
            }
            catch
            {
                MessageBox.Show("Вы сделали что-то не так и произошла ошибка. Просмотри ещё раз, что ты сделал :/");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Meropriat meropriat = new Meropriat();
            meropriat.Show();
        }
    }
}
