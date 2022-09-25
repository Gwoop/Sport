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
    /// Логика взаимодействия для Meropriat.xaml
    /// </summary>
    public partial class Meropriat : Window
    {
        public Meropriat()
        {
            InitializeComponent();
            GetData();
        }

        private void GetData()
        {
            MeropiatTableAdapter a = new MeropiatTableAdapter();
            DataSet1.MeropiatDataTable b = new DataSet1.MeropiatDataTable();
            a.Fill(b);
            Tablichka.ItemsSource = b;
        }


            

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(Name.Text) || String.IsNullOrWhiteSpace(mesto.Text) || String.IsNullOrWhiteSpace(date.Text))
                    if (Name.Text != null && mesto.Text != null && date.Text!= null)
                    new MeropiatTableAdapter().InsertQuery(Name.Text, mesto.Text, Convert.ToString(date.DisplayDate));
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
                if (String.IsNullOrWhiteSpace(Name.Text) || String.IsNullOrWhiteSpace(mesto.Text) || String.IsNullOrWhiteSpace(date.Text))
                    if (Name.Text != null && mesto.Text != null && date.Text != null)
                        new MeropiatTableAdapter().UpdateQuery(Name.Text, mesto.Text, Convert.ToString(date.DisplayDate), Convert.ToInt32((Tablichka.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
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

                new MeropiatTableAdapter().DeleteQuery(
                    Convert.ToInt32((Tablichka.SelectedItems[0] as DataRowView).Row.ItemArray[0]));

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
                Name.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
            if (Tablichka.SelectedItem != null)
                mesto.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
            if (Tablichka.SelectedItem != null)
                date.Text = (Tablichka.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
        }
    }
}
