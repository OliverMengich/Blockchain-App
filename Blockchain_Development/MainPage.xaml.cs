using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Security.Cryptography;
using System.Xml.Serialization;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Blockchain_Development
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters _privateKey; // instanciate private key
        private RSAParameters _publicKey; // instanciate public key*/

        public MainPage()
        {
            this.InitializeComponent();
            _privateKey = csp.ExportParameters(true); // setting to true produces private key 
            _publicKey = csp.ExportParameters(false); // setting to false produces public key
        }
        
        
        public string PublicKeyString()
        {
            
            // working with string function
            var sw = new StringWriter();
            // public key is produced as an XML file. to change it to a string 
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, _publicKey);
            return sw.ToString(); // produce the public key
        }
        public string PrivateKeyString()
        {
            var sw = new StringWriter();
            // public key is produced as an XML file. to change it to a string 
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, _privateKey);
            return sw.ToString();
        }
        private void Generate_Wallet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                privateKeyTextBox.Text = PublicKeyString();
                publicKeyTextBox.Text = PrivateKeyString();
            }
            catch(Exception ex)
            {
                privateKeyTextBox.Text = ex.Message;
                publicKeyTextBox.Text = ex.Message;
            }
        }

        private void view_transaction_Click(object sender, RoutedEventArgs e)
        {
            Navigation_frame.Navigate(typeof(View_Transation));
        }

        private void Wallet_generator_Click(object sender, RoutedEventArgs e)
        {
            Navigation_frame.Navigate(typeof(MainPage));
        }

        private void make_transaction_Click(object sender, RoutedEventArgs e)
        {
            Navigation_frame.Navigate(typeof(Make_Transaction),csp);
        }
    }
}
