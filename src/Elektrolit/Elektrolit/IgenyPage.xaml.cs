using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elektrolit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IgenyPage : ContentPage
    {

        Kondenzator selectedKondenzator = new Kondenzator();
        List<Kondenzator> nullKondensators = new List<Kondenzator>();
        string connectionString = "server=t610nas.ddns.net;uid=t610nas;port=3306;pwd=FuCsab_1298;OldGuids=True;Initial Catalog=t610nas;";


        public IgenyPage(List<Kondenzator> kondenzatorList)
        {
            InitializeComponent();


            foreach (Kondenzator item in kondenzatorList)
            {
                if (item.kell == true)
                {
                    nullKondensators.Add(item);
                }
            }
            List_Kondi.ItemsSource = nullKondensators.Distinct().ToList();
        }

        private void ListItemSelected(object sender, ItemTappedEventArgs e)
        {
            var myItem = e.Item;

            foreach (var item in nullKondensators)
            {
                if(myItem == item)
                {
                    selectedKondenzator = item;
                }
            }
        }

        private void btn_Megvan_Click(object sender, EventArgs args)
        {
            MySqlConnection connection;
            MySqlCommand command;
            string sql = null;
            connection = new MySqlConnection(connectionString);
            sql = "UPDATE kondenzatorok " +
                "SET megjegyzes = 'Minden beszerezve' " +
                "WHERE id = "+ selectedKondenzator.id;
            try
            {
                connection.Open();

                command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception) { }
        }
        private void btn_IgenyTorol_Click(object sender, EventArgs args)
        {
            MySqlConnection connection;
            MySqlCommand command;
            string sql = null;
            connection = new MySqlConnection(connectionString);
            sql = "UPDATE kondenzatorok " +
                "SET kell = false " +
                "WHERE id = " + selectedKondenzator.id;
            try
            {
                connection.Open();

                command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception) { }
        }
        
    }

}