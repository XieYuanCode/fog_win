﻿#pragma checksum "G:\document\fog_win\Fog\Fog\Test\Git\GitClonePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "79174D30AD7A26CEE83FAB8A57FC225758E9D7DCC74AAC28E0327688EFD30F75"
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
    partial class GitClonePage : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_UI_Xaml_Controls_TextBox_Text(global::Microsoft.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(global::Microsoft.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class GitClonePage_obj1_Bindings :
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IGitClonePage_Bindings
        {
            private global::Fog.Pages.GitClonePage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.UI.Xaml.Controls.TextBox obj2;
            private global::Microsoft.UI.Xaml.Controls.TextBlock obj5;
            private global::Microsoft.UI.Xaml.Controls.TextBlock obj7;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2TextDisabled = false;
            private static bool isobj5TextDisabled = false;
            private static bool isobj7TextDisabled = false;

            private GitClonePage_obj1_BindingsTracking bindingsTracking;

            public GitClonePage_obj1_Bindings()
            {
                this.bindingsTracking = new GitClonePage_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 14 && columnNumber == 59)
                {
                    isobj2TextDisabled = true;
                }
                else if (lineNumber == 21 && columnNumber == 24)
                {
                    isobj5TextDisabled = true;
                }
                else if (lineNumber == 12 && columnNumber == 24)
                {
                    isobj7TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Test\Git\GitClonePage.xaml line 14
                        this.obj2 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                        this.bindingsTracking.RegisterTwoWayListener_2(this.obj2);
                        break;
                    case 5: // Test\Git\GitClonePage.xaml line 21
                        this.obj5 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                        break;
                    case 7: // Test\Git\GitClonePage.xaml line 12
                        this.obj7 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
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

            // IGitClonePage_Bindings

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
                    this.dataRoot = global::WinRT.CastExtensions.As<global::Fog.Pages.GitClonePage>(newDataRoot);
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
            private void Update_(global::Fog.Pages.GitClonePage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_CloneData(obj.CloneData, phase);
                    }
                }
            }
            private void Update_CloneData(global::Fog.Pages.CloneGitDataModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_CloneData(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_CloneData_Remote(obj.Remote, phase);
                        this.Update_CloneData_Message(obj.Message, phase);
                        this.Update_CloneData_ClonePath(obj.ClonePath, phase);
                    }
                }
            }
            private void Update_CloneData_Remote(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Test\Git\GitClonePage.xaml line 14
                    if (!isobj2TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBox_Text(this.obj2, obj, null);
                    }
                }
            }
            private void Update_CloneData_Message(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Test\Git\GitClonePage.xaml line 21
                    if (!isobj5TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(this.obj5, obj, null);
                    }
                }
            }
            private void Update_CloneData_ClonePath(global::Windows.Storage.StorageFolder obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_CloneData_ClonePath_Path(obj.Path, phase);
                    }
                }
            }
            private void Update_CloneData_ClonePath_Path(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Test\Git\GitClonePage.xaml line 12
                    if (!isobj7TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(this.obj7, obj, null);
                    }
                }
            }
            private void UpdateTwoWay_2_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.CloneData != null)
                        {
                            this.dataRoot.CloneData.Remote = this.obj2.Text;
                        }
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class GitClonePage_obj1_BindingsTracking
            {
                private global::System.WeakReference<GitClonePage_obj1_Bindings> weakRefToBindingObj; 

                public GitClonePage_obj1_BindingsTracking(GitClonePage_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<GitClonePage_obj1_Bindings>(obj);
                }

                public GitClonePage_obj1_Bindings TryGetBindingObject()
                {
                    GitClonePage_obj1_Bindings bindingObject = null;
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
                    UpdateChildListeners_CloneData(null);
                }

                public void PropertyChanged_CloneData(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    GitClonePage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::Fog.Pages.CloneGitDataModel obj = sender as global::Fog.Pages.CloneGitDataModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_CloneData_Remote(obj.Remote, DATA_CHANGED);
                                bindings.Update_CloneData_Message(obj.Message, DATA_CHANGED);
                                bindings.Update_CloneData_ClonePath(obj.ClonePath, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "Remote":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_CloneData_Remote(obj.Remote, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Message":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_CloneData_Message(obj.Message, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "ClonePath":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_CloneData_ClonePath(obj.ClonePath, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::Fog.Pages.CloneGitDataModel cache_CloneData = null;
                public void UpdateChildListeners_CloneData(global::Fog.Pages.CloneGitDataModel obj)
                {
                    if (obj != cache_CloneData)
                    {
                        if (cache_CloneData != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_CloneData).PropertyChanged -= PropertyChanged_CloneData;
                            cache_CloneData = null;
                        }
                        if (obj != null)
                        {
                            cache_CloneData = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_CloneData;
                        }
                    }
                }
                public void RegisterTwoWayListener_2(global::Microsoft.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.LostFocus += (sender, e) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_2_Text();
                        }
                    };
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
            case 3: // Test\Git\GitClonePage.xaml line 17
                {
                    global::Microsoft.UI.Xaml.Controls.CheckBox element3 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.CheckBox>(target);
                    ((global::Microsoft.UI.Xaml.Controls.CheckBox)element3).Checked += this.Bare_Checked;
                    ((global::Microsoft.UI.Xaml.Controls.CheckBox)element3).Unchecked += this.Bare_Unchecked;
                }
                break;
            case 4: // Test\Git\GitClonePage.xaml line 20
                {
                    global::Microsoft.UI.Xaml.Controls.Button element4 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element4).Click += this.Clone;
                }
                break;
            case 6: // Test\Git\GitClonePage.xaml line 11
                {
                    global::Microsoft.UI.Xaml.Controls.Button element6 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element6).Click += this.Select_folder;
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
            case 1: // Test\Git\GitClonePage.xaml line 1
                {                    
                    global::Microsoft.UI.Xaml.Controls.Page element1 = (global::Microsoft.UI.Xaml.Controls.Page)target;
                    GitClonePage_obj1_Bindings bindings = new GitClonePage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

