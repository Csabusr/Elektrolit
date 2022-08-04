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
    public partial class FelhasznalPage : ContentPage
    {
        string connectionString = "server=t610nas.ddns.net;uid=t610nas;port=3306;pwd=FuCsab_1298;OldGuids=True;Initial Catalog=t610nas;";
        List<Kondenzator> kondenzatorList = new List<Kondenzator>();
        int darab = 0;
        int id = 0;

        public FelhasznalPage(List<Kondenzator> kondenzatorListin)
        {
            InitializeComponent();
            lbl_product.FontSize = 28;
            kondenzatorList = kondenzatorListin;
        }

        void Button_Clicked_Felhasznal(System.Object sender, System.EventArgs e)
        {
            try { kondiDbFelhasznal(); }
            catch(Exception ex) { lbl_product.FontSize = 6; lbl_product.Text = ex.Message; }

        }

        void en_darab_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            lbl_refresh();
        }

        void pi_feszultseg_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            lbl_refresh();
        }

        void en_feszultseg_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            lbl_refresh();
        }

        void pi_kapacitas_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            lbl_refresh();
        }

        void en_kapacitas_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            lbl_refresh();
        }

        public void lbl_refresh()
        {
            try
            {
                lbl_product.Text = en_darab.Text + "db - " + en_kapacitas.Text + pi_kapacitas.SelectedItem + " " +
                    en_feszultseg.Text + pi_feszultseg.SelectedItem;
            }
            catch (Exception) { lbl_product.Text = "#####"; }
        }

        private void kondiDbFelhasznal()
        {
            MySqlConnection connection;
            MySqlCommand command;
            string sql = null;
            connection = new MySqlConnection(connectionString);
            bool exist = false;

            foreach (Kondenzator item in kondenzatorList)
            {
                if (item.kapacitas == (en_kapacitas.Text + pi_kapacitas.SelectedItem) &&
                    item.feszultseg == (en_feszultseg.Text + pi_feszultseg.SelectedItem))
                {
                    exist = true; darab = item.darab; id = item.id; break;
                }
            }
            if (exist)
            {
                sql = "UPDATE kondenzatorok" +
                    " SET darab = " + (darab - int.Parse(en_darab.Text)) +
                    " WHERE id = " + id;
                try
                {
                    connection.Open();

                    command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();

                    connection.Close();
                    lbl_product.Text = lbl_product.Text + "_Felhasználva";
                }
                catch (Exception) { }
            }
        }
    }
}