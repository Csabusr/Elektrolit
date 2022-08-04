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
    public partial class FelviszPage : ContentPage
    {
        string connectionString = "server=t610nas.ddns.net;uid=t610nas;port=3306;pwd=FuCsab_1298;OldGuids=True;Initial Catalog=t610nas;";
        List<Kondenzator> kondenzatorList = new List<Kondenzator>();
        int darab = 0;
        int id = 0;

        public FelviszPage(List<Kondenzator> kondenzatorListin)
        {
            InitializeComponent();
            lbl_product.FontSize = 22;
            kondenzatorList = kondenzatorListin;
        }

       

        void en_kapacitas_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            lbl_refresh();
        }

        void en_feszultseg_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            lbl_refresh();
        }

        void pi_feszultseg_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            lbl_refresh();
        }

        void pi_kapacitas_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            lbl_refresh();
        }

        void en_darab_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            lbl_refresh();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
           
            if (cb_beszerzendo.IsChecked)
            {
                try { kondiBeszerDbUpload(); }
                catch (Exception ex) { lbl_product.FontSize = 6; lbl_product.Text = ex.Message; }

                try { kondiDbUploadWBeszer(); }
                catch(Exception ex) { lbl_product.FontSize = 6; lbl_product.Text = ex.Message; }
            }
            else
            {
                kondiDbUpload();
            }
        }
        private void kondiDbUpload()
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
                    "SET darab = " + (darab + int.Parse(en_darab.Text)) +
                    "WHERE id = " + id;
                try
                {
                    connection.Open();

                    command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();

                    connection.Close();
                    lbl_product.Text = lbl_product.Text + "_Rögzítve";
                }
                catch (Exception) { }
            }
            else
            {
                sql = "insert into kondenzatorok (kapacitas, feszultseg, darab)" +
                                "values('" + (en_kapacitas.Text + pi_kapacitas.SelectedItem) + "','" +
                                (en_feszultseg.Text + pi_feszultseg.SelectedItem) + "', " +
                                en_darab.Text + " )";
                try
                {
                    connection.Open();

                    command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();

                    connection.Close();
                    lbl_product.Text = lbl_product.Text + "_Rögzítve";
                }
                catch (Exception ex) { lbl_product.FontSize = 6; lbl_product.Text = ex.Message; }
            }
        }

        private void kondiDbUploadWBeszer()
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

            if (!exist)
            {
                sql = "insert into kondenzatorok (kapacitas, feszultseg, darab)" +
                                "values('" + (en_kapacitas.Text + pi_kapacitas.SelectedItem) + "','" +
                                (en_feszultseg.Text + pi_feszultseg.SelectedItem) + "', 0 )";
                try
                {
                    connection.Open();

                    command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();

                    connection.Close();
                    lbl_product.Text = lbl_product.Text + "_Rögzítve";
                }
                catch (Exception ex) { lbl_product.FontSize = 6; lbl_product.Text = ex.Message; }
            }
        }

        private void kondiBeszerDbUpload()
        {
            MySqlConnection connection;
            MySqlCommand command;
            string sql = null;
            connection = new MySqlConnection(connectionString);

            sql = "insert into beszerzendo_kondenzatorok (kapacitas, feszultseg, darab_kell, megjegyzes, kell)" +
                                    "values('" + (en_kapacitas.Text + pi_kapacitas.SelectedItem) + "','" +
                                    (en_feszultseg.Text + pi_feszultseg.SelectedItem) + "', " +
                                    en_darab.Text + ",'" +
                                    en_megjegyzes.Text + "', true )";
            try
            {
                connection.Open();

                command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();

                connection.Close();
                lbl_product.Text = lbl_product.Text + "_Rögzítve";
            }
            catch (Exception) { }
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
    }
}