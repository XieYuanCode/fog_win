// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fog.Pages.ContentDialogs
{
    public enum SignInResult
    {
        SignInOK,
        SignInFail,
        SignInCancel,
        Nothing
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddServiceAccountContentDialog : ContentDialog
    {
        public SignInResult Result { get; private set; }
        public AddServiceAccountContentDialog(XamlRoot xamlRoot)
        {
            this.InitializeComponent();

            this.XamlRoot = xamlRoot;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ContentDialogButtonClickDeferral deferral = args.GetDeferral();
            this.Result = SignInResult.SignInOK;
            deferral.Complete();
        }

        private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args) 
        {
            this.Result = SignInResult.SignInCancel;
        }


        void AddServiceAccountContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args) 
        {
            this.Result = SignInResult.Nothing;
        }
        void AddServiceAccountContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args) {
        }
    }
}
