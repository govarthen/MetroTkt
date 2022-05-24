using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Metro.Models;
using Metro.Views;
using Metro.ViewModels;

namespace Metro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            TicketScreen ticketScreen = new TicketScreen();            
            TicketVM ticketVM = new TicketVM();

            ticketScreen.DataContext = ticketVM;
            ticketScreen.Show();
        }
    }
}
