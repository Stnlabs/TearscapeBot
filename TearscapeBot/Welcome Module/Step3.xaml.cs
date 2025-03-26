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
using TwitchLib.Api.Core.Exceptions;
using static System.Net.WebRequestMethods;

namespace TearscapeBot.Welcome_Module
{
    /// <summary>
    /// Interaktionslogik für Step_2.xaml
    /// </summary>
    public partial class Step3 : Window
    {
        private string devname; // Lokale Variable für den Namen
        public string authtoken;
        public string CDID;

        public Step3(string devnameValue, string clientID)
        {
            InitializeComponent();
            devname = devnameValue; // Speichert den Wert aus Step1
            CDID = clientID;
        }

        private void Changeurl(object sender, RequestNavigateEventArgs e)
        {
            string url2 = "https://id.twitch.tv/oauth2/authorize?client_id=&redirect_uri=http://localhost&response_type=token&scope=chat:read+chat:edit";

            string part1 = url2.Substring(0, 48);
            string part2 = url2.Substring(48);
            string url = part1 + CDID + part2;

            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            e.Handled = true;
        }
        private void Authtoken(object sender, TextChangedEventArgs e)
        {
            //LLM Large language Model
        }
        
        private void Tostep3(object sender, RoutedEventArgs e)
        {
            string url = TxtBauthtoken.Text;
            //Der authtoken ist nicht der ganze link er muss gesplittet werden. Nur ein teil davon
            string oauthtoken = url.Substring(31, 30);
            authtoken = oauthtoken;
            Step4 step4 = new Step4(devname,CDID,authtoken); // Übergibt den Wert an Step_2
            step4.Show();
            this.Close();
        }
    }
}
