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
    public partial class ListPage : ContentPage
    {
        public ListPage(List<Kondenzator> kondenzatorList)
        {
            InitializeComponent();

            List<Kondenzator> DuplicatedList = new List<Kondenzator>();

            foreach (Kondenzator item in kondenzatorList)
            {

                item.darab = kondenzatorList.FindAll(e => (e.kapacitas == item.kapacitas && e.feszultseg == item.feszultseg)).Count();


                //DuplicatedList.Add(kondenzatorList.Find(e =>(e.kapacitas == item.kapacitas && e.feszultseg == item.feszultseg && e.id != item.id)));
            }
           
           

            foreach (Kondenzator item in DuplicatedList)
            {

                kondenzatorList.Remove(item);
            }


            List_Kondi.ItemsSource = kondenzatorList.Distinct().ToList();
        }
    }
}