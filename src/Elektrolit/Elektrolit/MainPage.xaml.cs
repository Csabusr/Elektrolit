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
        //string connectionString = "User ID=t610nas; password=FuCsab_1298; Data Source=t610nas.ddns.net; Initial Catalog=t610nas; connection timeout=30";
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
                    kondenzator.hozzaadas_ideje = reader["hozzaadas_ideje"].ToString();
                    kondenzatorList.Add(kondenzator);
                }
                catch (Exception) { }
            }
                connection.Close();
            }
            catch (Exception) { }


            //sql = "insert into kondenzatorok (kapacitas,feszultseg,hozzaadas_ideje) values ('470µF','25V','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

            //try
            //{
            //    connection.Open();

            //    command = new MySqlCommand(sql, connection);
            //    command.ExecuteNonQuery();

            //    connection.Close();

            //}
            //catch (Exception) { }

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
