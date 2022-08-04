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

            List<Kondenzator> notNullKondensators = new List<Kondenzator>();

            foreach (Kondenzator item in kondenzatorList)
            {
                if(item.darab > 0)
                {
                    notNullKondensators.Add(item);
                }
            }
            List_Kondi.ItemsSource = notNullKondensators.Distinct().ToList();
        }
    }
}