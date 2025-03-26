using System;
using System.Collections.Generic;
using System.IO;
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
using TwitchLib.Api.Auth;

namespace TearscapeBot.Consettings
{
    /// <summary>
    /// Interaktionslogik für Consettings.xaml
    /// </summary>
    
    public partial class Consettings : Window
    {
        public Consettings()
        {
            InitializeComponent();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = System.IO.Path.Combine(folder, "tearscape", "Config.txt");
            StreamReader sr = new StreamReader(path, false);
            string name = sr.ReadLine();
            string Authtoken = sr.ReadLine();
            string Channel = sr.ReadLine();
            sr.Close();
            user.Text = name;
            CNL.Text = Channel;
            authtoken.Text = Authtoken;
        }

        private void User(object sender, TextChangedEventArgs e)
        {

            
        }

        private void Channel(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Client_ID(object sender, TextChangedEventArgs e)
        {

        }

        private void Save(object sender, RoutedEventArgs e)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = System.IO.Path.Combine(folder, "tearscape", "Config.txt");
            string name = user.Text;
            string auth = authtoken.Text;
            string channel = CNL.Text;
            StreamWriter streamWriter = new StreamWriter(path, false);
            streamWriter.WriteLine(name);
            streamWriter.WriteLine(auth);
            streamWriter.WriteLine(channel);
            streamWriter.Close();
            string alert = "Changes where saved !";
            Alert.Content = alert;




        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            user.Text = "";
            CNL.Text = "";
            authtoken.Text = "";
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = System.IO.Path.Combine(folder, "tearscape", "Config.txt");
            StreamWriter streamWriter = new StreamWriter(path, false);
            streamWriter.WriteLine(user.Text);
            streamWriter.WriteLine(CNL.Text);
            streamWriter.WriteLine(authtoken.Text);
            streamWriter.Close();
            string alert = "Reset was done !";
            Alert.Content = alert;
        }

        private void Alert_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
