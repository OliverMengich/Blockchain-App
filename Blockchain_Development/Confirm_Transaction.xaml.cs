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
using System.Threading;
using Windows.UI.Xaml.Navigation;


// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Blockchain_Development
{
    
    public sealed partial class Confirm_Transaction : ContentDialog
    {
        
        public Confirm_Transaction()
        {
            this.InitializeComponent();
            Make_Transaction make_Transaction = new Make_Transaction();
            var x = make_Transaction.To_Dict();
            sender_publicKeyBox.Text = x["Sender_Public_Key"];
            recipient_publicKeyBox.Text =x["Recipient_Public_Key"];
            amountTransact.Text = x["Amount"];
        }
        
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Confirm_Transaction confirm_ = new Confirm_Transaction();
            confirm_.Hide();
            //DisplayTransactionAdded();
        }
        private async void DisplayTransactionAdded()
        {
            
            
            ContentDialog noDialog = new ContentDialog
            {
                Title = "Transaction Success",
                Content = "Transaction will be added to the other nodes.",
                CloseButtonText = "Ok"
            };
            
            Thread.Sleep(3000);
            //await noDialog.ShowAsync();
            
        }
    }
}
