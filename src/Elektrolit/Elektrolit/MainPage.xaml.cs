using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Elektrolit
{
    public partial class MainPage : ContentPage
    {

        List<Kondenzator> kondenzatorList = new List<Kondenzator>();
        string connectionString = "server=t610nas.ddns.net;uid=t610nas;port=3306;pwd=FuCsab_1298;OldGuids=True;Initial Catalog=t610nas;";




        public MainPage()
        {
            InitializeComponent();

            MySqlConnection connection;
            MySqlCommand command;
            string sql = null;
            connection = new MySqlConnection(connectionString);
            sql = "Select * from kondenzatorok";

            try
            {
                connection.Open();

                command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Kondenzator kondenzator = new Kondenzator();
                    try
                    {
                        kondenzator.id = int.Parse(reader["id"].ToString());
                        kondenzator.kapacitas = reader["kapacitas"].ToString();
                        kondenzator.feszultseg = reader["feszultseg"].ToString();
                        kondenzator.darab = int.Parse(reader["darab"].ToString());
                        kondenzator.kell = (int.Parse(reader["kell"].ToString()) == 1) ? true : false;
                        kondenzator.megjegyzes = reader["megjegyzes"].ToString();

                        kondenzatorList.Add(kondenzator);
                    }
                    catch (Exception) { }
                }
                connection.Close();
            }
            catch (Exception) { }
        }

        private void btn_Refresh_Click(object sender, EventArgs args)
        {

            kondenzatorList.Clear();
            MySqlConnection connection;
            MySqlCommand command;
            string sql = null;
            connection = new MySqlConnection(connectionString);
            sql = "Select * from kondenzatorok";

            try
            {
                connection.Open();

                command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Kondenzator kondenzator = new Kondenzator();
                    try
                    {
                        kondenzator.id = int.Parse(reader["id"].ToString());
                        kondenzator.kapacitas = reader["kapacitas"].ToString();
                        kondenzator.feszultseg = reader["feszultseg"].ToString();
                        kondenzator.darab = int.Parse(reader["darab"].ToString());
                        kondenzator.kell = (int.Parse(reader["kell"].ToString()) == 1) ? true : false;
                        kondenzator.megjegyzes = reader["megjegyzes"].ToString();

                        kondenzatorList.Add(kondenzator);
                    }
                    catch (Exception) { }
                }
                connection.Close();
            }
            catch (Exception) { }
        }

        private async void btn_List_Click(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NavigationPage(new ListPage(kondenzatorList)));
        }
        private async void btn_Igeny_Click(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NavigationPage(new IgenyPage(kondenzatorList)));
        }
        private async void btn_Felvisz_Click(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NavigationPage(new FelviszPage(kondenzatorList)));
        }
        private async void btn_Felhasznal_Click(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NavigationPage(new FelhasznalPage(kondenzatorList)));
        }

    }
}
