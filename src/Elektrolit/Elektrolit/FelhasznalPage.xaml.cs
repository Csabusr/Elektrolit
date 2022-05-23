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
    public partial class FelhasznalPage : ContentPage
    {
        public FelhasznalPage(List<Kondenzator> kondenzatorList)
        {
            InitializeComponent();

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

        }

            private void refreshEgyed()
        {
            try
            {
                lbl_Egyed.Text = entry_Kapacitas.Text + picker_Kapacitas.SelectedItem.ToString() + " " + entry_Feszultseg.Text + picker_Feszultseg.SelectedItem.ToString() + " " + entry_darab.Text + "db ";
            }
            catch (Exception) { }
        }
    }
}