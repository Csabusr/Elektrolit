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

        beszerKondenzator selectedKondenzator = new beszerKondenzator();
        List<beszerKondenzator> Kondensators = new List<beszerKondenzator>();
        string connectionString = "server=t610nas.ddns.net;uid=t610nas;port=3306;pwd=FuCsab_1298;OldGuids=True;Initial Catalog=t610nas;";


        public IgenyPage(List<Kondenzator> kondenzatorList, List<beszerKondenzator> beszerKondenzatorList)
        {
            InitializeComponent();
            foreach (beszerKondenzator item2 in beszerKondenzatorList)
            {
                foreach (Kondenzator item in kondenzatorList)
                {

                    if (item.feszultseg == item2.feszultseg && item.kapacitas == item2.kapacitas && item2.kell)
                    {
                        beszerKondenzator temp = new beszerKondenzator();

                        temp.id = item2.id;
                        temp.kapacitas = item2.kapacitas;
                        temp.feszultseg = item2.feszultseg;
                        temp.megjegyzes = item2.megjegyzes;
                        temp.darabkell = item2.darabkell;
                        temp.darabvan = item.darab;
                        Kondensators.Add(temp);
                        break;
                    }
                }
            }
            List_Kondi.ItemsSource = Kondensators.Distinct().ToList();
        }

        private void ListItemSelected(object sender, ItemTappedEventArgs e)
        {
            
            var myItem = e.Item;

            foreach (var item in Kondensators)
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
            sql = "UPDATE beszerzendo_kondenzatorok " +
                "SET kell = false " +
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
            sql = "UPDATE beszerzendo_kondenzatorok " +
                "SET kell = false , megjegyzes = 'TÖRÖLVE_"+selectedKondenzator.megjegyzes+"'" +
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