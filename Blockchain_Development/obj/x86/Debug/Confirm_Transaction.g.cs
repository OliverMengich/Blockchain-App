﻿#pragma checksum "C:\Users\olive\source\repos\Blockchain_App\Blockchain_Development\Confirm_Transaction.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EAD2D883B6BA70594314C57246B9A4E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blockchain_Development
{
    partial class Confirm_Transaction : 
        global::Windows.UI.Xaml.Controls.ContentDialog, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Confirm_Transaction.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.ContentDialog element1 = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).PrimaryButtonClick += this.ContentDialog_PrimaryButtonClick;
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)element1).SecondaryButtonClick += this.ContentDialog_SecondaryButtonClick;
                }
                break;
            case 2: // Confirm_Transaction.xaml line 29
                {
                    this.sender_publicKeyBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // Confirm_Transaction.xaml line 35
                {
                    this.recipient_publicKeyBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // Confirm_Transaction.xaml line 41
                {
                    this.amountTransact = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Confirm_Transaction.xaml line 47
                {
                    this.recipient = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

