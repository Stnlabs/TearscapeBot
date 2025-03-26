using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace TearscapeBot.Welcome_Module
{
    /// <summary>
    /// Interaktionslogik für Step3.xaml
    /// </summary>
    public partial class Step4 : Window
    {
        private string UserName;
        private string Token;
        private string Channelname;
        private string ClientID;
        public Step4(string devname,string clientid ,string authtoken)
        {
            InitializeComponent();
            UserName = devname;
            Token = authtoken;
            ClientID = clientid;
        }
        private void BTNStartClick(object sender, RoutedEventArgs e)
        {
            //Die Dateien mit den nötigen Login müssen hier in einer Datei gespeichert werden und es muss die Main geladen werden
            Channelname = TwitchChannel.Text;
            MainWindow Mainwindow = new MainWindow(UserName,ClientID,Token, Channelname);
            Mainwindow.Show();
            this.Close();

            // Den Konstruktor überprüfen auf das er die Werte übergibt.
        }

        private void Twitch_Channel(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
