﻿#pragma checksum "G:\document\fog_win\Fog\Fog\Pages\ServiceAccountsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "32884360A5754FD99571415C7542BEAF780096A0413CF6A80CC94B0DFE8A66D5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fog.Pages
{
    partial class ServiceAccountsPage : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Microsoft.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(global::Microsoft.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_Image_Source(global::Microsoft.UI.Xaml.Controls.Image obj, global::Microsoft.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Microsoft.UI.Xaml.Media.ImageSource) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Microsoft.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.Source = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class ServiceAccountsPage_obj3_Bindings :
            global::Microsoft.UI.Xaml.IDataTemplateExtension,
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IServiceAccountsPage_Bindings
        {
            private global::Fog.ServiceAccount dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj3;
            private global::Microsoft.UI.Xaml.Controls.TextBlock obj4;
            private global::Microsoft.UI.Xaml.Controls.Image obj5;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj4TextDisabled = false;
            private static bool isobj5SourceDisabled = false;

            public ServiceAccountsPage_obj3_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 18 && columnNumber == 32)
                {
                    isobj4TextDisabled = true;
                }
                else if (lineNumber == 16 && columnNumber == 32)
                {
                    isobj5SourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3: // Pages\ServiceAccountsPage.xaml line 13
                        this.obj3 = new global::System.WeakReference(global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListViewItem>(target));
                        break;
                    case 4: // Pages\ServiceAccountsPage.xaml line 18
                        this.obj4 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                        break;
                    case 5: // Pages\ServiceAccountsPage.xaml line 16
                        this.obj5 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Image>(target);
                        break;
                    default:
                        break;
                }
            }
                        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
                        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
                        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target) 
                        {
                            return null;
                        }

            public void DataContextChangedHandler(global::Microsoft.UI.Xaml.FrameworkElement sender, global::Microsoft.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Microsoft.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj3.Target as global::Microsoft.UI.Xaml.Controls.ListViewItem).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_(global::WinRT.CastExtensions.As<global::Fog.ServiceAccount>(item), 1 << phase);
            }

            public void Recycle()
            {
            }

            // IServiceAccountsPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::Fog.ServiceAccount>(newDataRoot);
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Fog.ServiceAccount obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Name(obj.Name, phase);
                        this.Update_Avatar(obj.Avatar, phase);
                    }
                }
            }
            private void Update_Name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Pages\ServiceAccountsPage.xaml line 18
                    if (!isobj4TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(this.obj4, obj, null);
                    }
                }
            }
            private void Update_Avatar(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Pages\ServiceAccountsPage.xaml line 16
                    if (!isobj5SourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_Image_Source(this.obj5, (global::Microsoft.UI.Xaml.Media.ImageSource) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Microsoft.UI.Xaml.Media.ImageSource), obj), null);
                    }
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class ServiceAccountsPage_obj1_Bindings :
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IServiceAccountsPage_Bindings
        {
            private global::Fog.Pages.ServiceAccountsPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.UI.Xaml.Controls.ListView obj7;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj7ItemsSourceDisabled = false;

            private ServiceAccountsPage_obj1_BindingsTracking bindingsTracking;

            public ServiceAccountsPage_obj1_Bindings()
            {
                this.bindingsTracking = new ServiceAccountsPage_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 39 && columnNumber == 31)
                {
                    isobj7ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 7: // Pages\ServiceAccountsPage.xaml line 35
                        this.obj7 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListView>(target);
                        break;
                    default:
                        break;
                }
            }
                        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
                        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
                        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target) 
                        {
                            return null;
                        }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IServiceAccountsPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::Fog.Pages.ServiceAccountsPage>(newDataRoot);
                    return true;
                }
                return false;
            }

            public void Activated(object obj, global::Microsoft.UI.Xaml.WindowActivatedEventArgs data)
            {
                this.Initialize();
            }

            public void Loading(global::Microsoft.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Fog.Pages.ServiceAccountsPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ServiceAccounts(obj.ServiceAccounts, phase);
                    }
                }
            }
            private void Update_ServiceAccounts(global::System.Collections.ObjectModel.ObservableCollection<global::Fog.ServiceAccount> obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ServiceAccounts(obj);
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Pages\ServiceAccountsPage.xaml line 35
                    if (!isobj7ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj7, obj, null);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class ServiceAccountsPage_obj1_BindingsTracking
            {
                private global::System.WeakReference<ServiceAccountsPage_obj1_Bindings> weakRefToBindingObj; 

                public ServiceAccountsPage_obj1_BindingsTracking(ServiceAccountsPage_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<ServiceAccountsPage_obj1_Bindings>(obj);
                }

                public ServiceAccountsPage_obj1_Bindings TryGetBindingObject()
                {
                    ServiceAccountsPage_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ServiceAccounts(null);
                }

                public void PropertyChanged_ServiceAccounts(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ServiceAccountsPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::Fog.ServiceAccount> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::Fog.ServiceAccount>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_ServiceAccounts(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    ServiceAccountsPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::Fog.ServiceAccount> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::Fog.ServiceAccount>;
                    }
                }
                private global::System.Collections.ObjectModel.ObservableCollection<global::Fog.ServiceAccount> cache_ServiceAccounts = null;
                public void UpdateChildListeners_ServiceAccounts(global::System.Collections.ObjectModel.ObservableCollection<global::Fog.ServiceAccount> obj)
                {
                    if (obj != cache_ServiceAccounts)
                    {
                        if (cache_ServiceAccounts != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ServiceAccounts).PropertyChanged -= PropertyChanged_ServiceAccounts;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)cache_ServiceAccounts).CollectionChanged -= CollectionChanged_ServiceAccounts;
                            cache_ServiceAccounts = null;
                        }
                        if (obj != null)
                        {
                            cache_ServiceAccounts = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ServiceAccounts;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)obj).CollectionChanged += CollectionChanged_ServiceAccounts;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Pages\ServiceAccountsPage.xaml line 12
                {
                    this.ServiceAccount_TreeViewIten = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.DataTemplate>(target);
                }
                break;
            case 6: // Pages\ServiceAccountsPage.xaml line 25
                {
                    this.settingSplitView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.SplitView>(target);
                }
                break;
            case 8: // Pages\ServiceAccountsPage.xaml line 48
                {
                    this.SettingButton = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.HyperlinkButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.HyperlinkButton)this.SettingButton).Click += this.SwitchSettingPage;
                }
                break;
            case 9: // Pages\ServiceAccountsPage.xaml line 51
                {
                    global::Microsoft.UI.Xaml.Controls.Primitives.ToggleButton element9 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Primitives.ToggleButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Primitives.ToggleButton)element9).Click += this.CloseServiceAccountsPage;
                }
                break;
            case 10: // Pages\ServiceAccountsPage.xaml line 57
                {
                    this.SettingFrame = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Frame>(target);
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Pages\ServiceAccountsPage.xaml line 1
                {                    
                    global::Microsoft.UI.Xaml.Controls.Page element1 = (global::Microsoft.UI.Xaml.Controls.Page)target;
                    ServiceAccountsPage_obj1_Bindings bindings = new ServiceAccountsPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            case 3: // Pages\ServiceAccountsPage.xaml line 13
                {                    
                    global::Microsoft.UI.Xaml.Controls.ListViewItem element3 = (global::Microsoft.UI.Xaml.Controls.ListViewItem)target;
                    ServiceAccountsPage_obj3_Bindings bindings = new ServiceAccountsPage_obj3_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element3.DataContext);
                    element3.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Microsoft.UI.Xaml.DataTemplate.SetExtensionInstance(element3, bindings);
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element3, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

