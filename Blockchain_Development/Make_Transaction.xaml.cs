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
using Blockchain_App;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Blockchain_Development
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    
    public sealed partial class Make_Transaction : Page
    {
        public static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters _privateKey; // instanciate private key
        private RSAParameters _publicKey; // instanciate public key*/

        public Make_Transaction()
        {
            this.InitializeComponent();
            
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

            return sw.ToString(); // produce the public key
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var value = (RSACryptoServiceProvider)e.Parameter;
            _privateKey = value.ExportParameters(true);
            _publicKey = value.ExportParameters(false);
            sender_address.Text = PublicKeyString();
            sender_privateBox.Text = PrivateKeyString();
            receipient_address.Text = PublicKeyString();
        }
        public Dictionary<string,string>  To_Dict()
        {
            var ordered_Dict = new Dictionary<string, string>();
            
            ordered_Dict.Add("Sender_Public_Key", sender_address.Text);
            ordered_Dict.Add("Sender_Private_Key", sender_privateBox.Text);
            ordered_Dict.Add("Recipient_Public_Key", receipient_address.Text);
            ordered_Dict.Add("Amount", amount_box.Text);
            return ordered_Dict;
        }
        public async void Generate_transaction_Click(object sender, RoutedEventArgs e)
        {
            string recipient_address = receipient_address.Text;
            string sender_publicKey = sender_address.Text;
            string sender_privateKey = sender_privateBox.Text;
            decimal amount_ToSend = decimal.Parse(amount_box.Text);
            Blockchain b = new Blockchain();

            //instantiate the transaction class
            To_Dict();
            
            Transaction transaction = new Transaction(sender_publicKey,sender_privateKey,recipient_address,decimal.Parse(amount_box.Text));

            
            Confirm_Transaction confirm_ = new Confirm_Transaction();
            
            await confirm_.ShowAsync();
        }
        
    }
}
