using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TearscapeBot.Welcome_Module
{
    /// <summary>
    /// Interaktionslogik für Step2.xaml
    /// </summary>
    public partial class Step2 : Window
    {
        public string name;
        public string clientid;
        public Step2(string devname)
        {
            InitializeComponent();
            name = devname;
        }
        private void Clientidurl(object sender, RequestNavigateEventArgs e)
        {
            string url = "https://dev.twitch.tv/console/apps/create";

            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            e.Handled = true;
        }
        private void ClientIDfield(object sender, TextChangedEventArgs e)
        {

        }

        private void ToStep3(object sender, RoutedEventArgs e)
        {
            clientid = clientidfield.Text;
            Step3 step3 = new Step3(name,clientid);
            step3.Show();
            this.Close();
        }

    }
}
