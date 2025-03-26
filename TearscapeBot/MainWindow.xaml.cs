using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TwitchLib.Client; // Bibliotheken einbinden
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace TearscapeBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string username;
        private string authtoken;
        private string channelname;
        private string ClientID;
        private TwitchClient client;
        private bool connected;
        

        public MainWindow()
        {
            
            var ExistsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string OrdnerExists = System.IO.Path.Combine(ExistsPath, "Tearscape");

            if(Directory.Exists(OrdnerExists))
            {
                InitializeComponent();
                //Hier Daten Laden aus der tet datei laden damit wir den Bot immer initialisieren können. Zeile für Zeile
                string Folderconfig = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string file = System.IO.Path.Combine(Folderconfig, "Tearscape", "Config.txt");
                StreamReader fs = new StreamReader(file);
                username = fs.ReadLine();
                authtoken = fs.ReadLine();
                channelname = fs.ReadLine();
                ClientID = fs.ReadLine();
                fs.Close();


            }
            else
            {
                var GetPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Neuen Unterordner "Tearscape" erstellen
                string newfolderpath = System.IO.Path.Combine(GetPath, "Tearscape");
                // Das Verzeichnis erstellen (falls es nicht existiert) mit der Textdatei
                Directory.CreateDirectory(newfolderpath);
                string filename = "Config.txt";
                string filepath = System.IO.Path.Combine(newfolderpath, filename);
                File.Create(filepath).Close();

                //Überprüfen ob die Fenster schon geöffnet sind, und alles Daten vorhanden sind, erst dann weiter machen.
                Welcome_Module.Welcome welcomeWindow = new Welcome_Module.Welcome();
                welcomeWindow.ShowDialog();
                this.Close();
            }  
        }
        public MainWindow(string Tdevname,string clientID ,string Tauthtoken, string Tchannelname)
        {
            
            InitializeComponent();
            username = Tdevname;
            authtoken = Tauthtoken;
            channelname = Tchannelname;
            ClientID = clientID;

            //Auf den Pfad zugreifen
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filepath = System.IO.Path.Combine(mydocpath, "Tearscape", "Config.txt");
            //Die Daten in das File schreiben.
            StreamWriter fs = new StreamWriter(filepath, false);
            fs.WriteLine(username);
            fs.WriteLine(authtoken);
            fs.WriteLine(channelname);
            fs.WriteLine(ClientID);
            fs.Close();

        }
        private void BTNConnect(object sender, RoutedEventArgs e)
        {
          
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(authtoken) || string.IsNullOrEmpty(channelname))
                {
                    MessageBox.Show("Bitte stellen Sie sicher, dass alle Anmeldedaten eingegeben wurden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            
                try
            { 
                if(!connected) {
                    ConnectionCredentials Conn = new ConnectionCredentials(username, authtoken);
                    client = new TwitchClient();
                    client.Initialize(Conn, channelname);
                    client.OnMessageReceived += Client_OnMessageReceived;
                    client.Connect();
                    MessageBox.Show("Erfolgreich mit Twitch verbunden!", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
                    BTN_Connect.Content = "Disconnect";
                    connected = true;
                   
                } else {

                    connected = false;
                    BTN_Connect.Content = "Connect";
                    client.Disconnect();
                    MessageBox.Show("Disconnected", "Succesfull", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Verbindungsfehler: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            


        }
        //Die Message ausgabe funktioniert nicht, Überprüfen woran es liegen kann.
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                // Nachricht im Chat-Textfeld anzeigen
                TXTBMessageWindow.AppendText($"{e.ChatMessage.Username}: {e.ChatMessage.Message}\n");
                
            });
        }

        private void Chatwindow(object sender, TextChangedEventArgs e)
        {

        }

        
        private void BTNSend(object sender, RoutedEventArgs e)
        {
             
            if (!string.IsNullOrEmpty(TXTBSend.Text))
            {
                client.SendMessage(channelname, TXTBSend.Text); // Nachricht senden
                TXTBMessageWindow.AppendText($"{username}: {TXTBSend.Text} \n");
                TXTBSend.Clear(); // Eingabefeld leeren
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTNSettings(object sender, RoutedEventArgs e)
        {
            //Hier die Channeldaten eingeben und verändern lassen können.
            Consettings.Consettings conset = new Consettings.Consettings();
            conset.ShowDialog();
        }
    }
}