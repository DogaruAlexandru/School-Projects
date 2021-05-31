﻿#pragma checksum "..\..\..\Views\AdminModeView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FF61C367A10301FEA8A72023EC5A2921A7C6553F79C51C2FE85BF86E008BD5E9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Tema1.Models;
using Tema1.Views;


namespace Tema1.Views {
    
    
    /// <summary>
    /// AdminMode
    /// </summary>
    public partial class AdminMode : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 61 "..\..\..\Views\AdminModeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Views\AdminModeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox descriptionTextBox;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Views\AdminModeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox categoryComboBox;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Views\AdminModeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox categoryCheckBox;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\Views\AdminModeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox categoryTextBox;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Views\AdminModeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button browseButton;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\Views\AdminModeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox imageTextBox;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\Views\AdminModeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView;
        
        #line default
        #line hidden
        
        
        #line 187 "..\..\..\Views\AdminModeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deselectButton;
        
        #line default
        #line hidden
        
        
        #line 210 "..\..\..\Views\AdminModeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addButton;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\..\Views\AdminModeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
        #line default
        #line hidden
        
        
        #line 226 "..\..\..\Views\AdminModeView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Tema1;component/views/adminmodeview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\AdminModeView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.descriptionTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.categoryComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.categoryCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 115 "..\..\..\Views\AdminModeView.xaml"
            this.categoryCheckBox.Click += new System.Windows.RoutedEventHandler(this.categoryCheckBox_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.categoryTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.browseButton = ((System.Windows.Controls.Button)(target));
            
            #line 141 "..\..\..\Views\AdminModeView.xaml"
            this.browseButton.Click += new System.Windows.RoutedEventHandler(this.browseButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.imageTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.listView = ((System.Windows.Controls.ListView)(target));
            
            #line 159 "..\..\..\Views\AdminModeView.xaml"
            this.listView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.deselectButton = ((System.Windows.Controls.Button)(target));
            
            #line 193 "..\..\..\Views\AdminModeView.xaml"
            this.deselectButton.Click += new System.Windows.RoutedEventHandler(this.deselectButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.addButton = ((System.Windows.Controls.Button)(target));
            
            #line 216 "..\..\..\Views\AdminModeView.xaml"
            this.addButton.Click += new System.Windows.RoutedEventHandler(this.addButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 224 "..\..\..\Views\AdminModeView.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.deleteButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.updateButton = ((System.Windows.Controls.Button)(target));
            
            #line 232 "..\..\..\Views\AdminModeView.xaml"
            this.updateButton.Click += new System.Windows.RoutedEventHandler(this.updateButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
