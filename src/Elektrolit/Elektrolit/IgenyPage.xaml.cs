﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elektrolit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IgenyPage : ContentPage
    {
        public IgenyPage(List<Kondenzator> kondenzatorList)
        {
            InitializeComponent();
        }
    }
}