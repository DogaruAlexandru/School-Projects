#pragma checksum "..\..\..\..\MVVM\View\MarksProfessorW.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DB7F3D0489EF9A0A534CDF547F4233B56E9B7F6DB266A1824EBDDAA0072F2780"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AttachedCommandBehavior;
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
using Tema3.Converters;
using Tema3.MVVM.View;
using Tema3.MVVM.ViewModel;


namespace Tema3.MVVM.View {
    
    
    /// <summary>
    /// MarksProfessorW
    /// </summary>
    public partial class MarksProfessorW : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 139 "..\..\..\..\MVVM\View\MarksProfessorW.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox subjectCB;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\..\MVVM\View\MarksProfessorW.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox pupilCB;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\..\MVVM\View\MarksProfessorW.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox finalExamMarkCB;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\..\MVVM\View\MarksProfessorW.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateDP;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\..\..\MVVM\View\MarksProfessorW.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox markScoreTB;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\..\..\MVVM\View\MarksProfessorW.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid infoGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/Tema3;component/mvvm/view/marksprofessorw.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVVM\View\MarksProfessorW.xaml"
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
            this.subjectCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.pupilCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.finalExamMarkCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.dateDP = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.markScoreTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.infoGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

