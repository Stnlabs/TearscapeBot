using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    public partial class Step1 : Window
    {
        public string devname;
        public Step1()
        {
           InitializeComponent();
        }

        // Event handler for the Hyperlink RequestNavigate event
        private void Twitchrequestnavigate(object sender, RequestNavigateEventArgs e)
        {
            // Open the hyperlink in the default web browser
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true; // Prevent default navigation behavior
        }


        private void Devname(object sender, TextChangedEventArgs e)
        {

        }

        private void Tostep2(object sender, RoutedEventArgs e)
        {
            devname = Username.Text;
            Step2 step2 = new Step2(devname); // Übergibt den Wert an Step_2
            step2.Show();
            this.Close();
        }

    }
}
