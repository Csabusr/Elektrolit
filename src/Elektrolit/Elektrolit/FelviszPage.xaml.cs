using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elektrolit
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FelviszPage : ContentPage
    {
        string connectionString;
        bool kell = false;

        public FelviszPage(List<Kondenzator> kondenzatorList, string connectionStringIn)
        {
            connectionString = connectionStringIn;
            InitializeComponent();
            entry_megjegyzes.IsEnabled = false;
        }

        void cb_Beszerzendo_Changed(object sender, CheckedChangedEventArgs e)
        {
            if (cb_Beszerzendo.IsChecked == true) { entry_darab.IsEnabled = false; entry_darab.Text = "0"; entry_megjegyzes.IsEnabled = true; kell = true; }
            if (cb_Beszerzendo.IsChecked == false) { entry_darab.IsEnabled = true; entry_megjegyzes.IsEnabled = false; kell = false; }
        }

        void entry_Kapacitas_TextChanged(object sender, TextChangedEventArgs e)
        {
            refreshEgyed();
        }
        void entry_Feszultseg_TextChanged(object sender, TextChangedEventArgs e)
        {
            refreshEgyed();
        }
        void entry_Megjegyzes_TextChanged(object sender, TextChangedEventArgs e)
        {
            refreshEgyed();
        }
        void entry_Darab_TextChanged(object sender, TextChangedEventArgs e)
        {
            refreshEgyed();
        }
        void picker_Feszultseg_SelectionChanged(object sender, EventArgs e)
        {
            refreshEgyed();
        }
        void picker_Kapacitas_SelectionChanged(object sender, EventArgs e)
        {
            refreshEgyed();
        }


        private void btn_Felvisz_Click(object sender, EventArgs args)
        {
            int darab = 0;
            int darabCheck = 0;
            //lekérdezés, hogy van-e, ha van hány darab
            MySqlConnection connection;
            MySqlCommand command;
            string sql = null;
            connection = new MySqlConnection(connectionString);
            sql = "Select * from kondenzatorok " +
                "WHERE kapacitas = '"+entry_Kapacitas.Text+picker_Kapacitas.SelectedItem.ToString()+"' and feszultseg = '"+ entry_Feszultseg.Text + picker_Feszultseg.SelectedItem.ToString() + "'";
            try
            {
                connection.Open();

                command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    darabCheck = int.Parse(reader["darab"].ToString());
                    
                }
                connection.Close();
            }
            catch (Exception) { }

            if(darabCheck != 0)
            {
                //Update
                try
                { 
                connection.Open();
                darab = darabCheck + int.Parse(entry_darab.Text.ToString());
                sql = "update kondenzatorok " +
                        "set darab = " + darab + " " +
                        "where kapacitas = '" + entry_Kapacitas.Text + picker_Kapacitas.SelectedItem.ToString() + "' and feszultseg = '"+ entry_Feszultseg.Text + picker_Feszultseg.SelectedItem.ToString() + "'";
                command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
                }catch (Exception) { }
            } 
            else 
            { 
                //Insert
                try
                {
                    int bit = (kell == true) ? 1 : 0;

                    connection.Open();
                    darab = int.Parse(entry_darab.Text.ToString());
                    sql = "insert into kondenzatorok(kapacitas,feszultseg,darab,kell,megjegyzes) " +
                            "values (" +
                            "'" + entry_Kapacitas.Text + picker_Kapacitas.SelectedItem.ToString() + "', " +
                            "'" + entry_Feszultseg.Text + picker_Feszultseg.SelectedItem.ToString() + "', " +
                            darab+", "+bit+", '"+entry_megjegyzes.Text+"');";
                    command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception) { }
            }
        }

        private void refreshEgyed()
        {
            try { 
                lbl_Egyed.Text = entry_Kapacitas.Text + picker_Kapacitas.SelectedItem.ToString() + " " + entry_Feszultseg.Text + picker_Feszultseg.SelectedItem.ToString() + " " + entry_darab.Text + "db " + entry_megjegyzes.Text;
            } catch(Exception) { }
        }
    }
}