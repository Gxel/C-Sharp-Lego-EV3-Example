﻿#pragma checksum "..\..\FailDialog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2869FCE65F682560053E719D1A947618CC0361F9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
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
using WpfApplicationLegoEV3Ansteuerung1;


namespace WpfApplicationLegoEV3Ansteuerung1 {
    
    
    /// <summary>
    /// FailDialog
    /// </summary>
    public partial class FailDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\FailDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelMessage1;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\FailDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imageScreenShot1;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\FailDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkBoxSendScreenShot;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\FailDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSave1;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\FailDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSend1;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\FailDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonProgrammAbbruch1;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\FailDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonTrotzdemWeiter1;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\FailDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabAdmin;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\FailDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtboxErrorMsg;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplicationLegoEV3Ansteuerung1;component/faildialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FailDialog.xaml"
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
            this.labelMessage1 = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.imageScreenShot1 = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.chkBoxSendScreenShot = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.buttonSave1 = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\FailDialog.xaml"
            this.buttonSave1.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonSend1 = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\FailDialog.xaml"
            this.buttonSend1.Click += new System.Windows.RoutedEventHandler(this.buttonSend1_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.buttonProgrammAbbruch1 = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\FailDialog.xaml"
            this.buttonProgrammAbbruch1.Click += new System.Windows.RoutedEventHandler(this.buttonProgrammAbbruch1_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.buttonTrotzdemWeiter1 = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\FailDialog.xaml"
            this.buttonTrotzdemWeiter1.Click += new System.Windows.RoutedEventHandler(this.buttonTrotzdemWeiter1_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tabAdmin = ((System.Windows.Controls.TabItem)(target));
            return;
            case 9:
            this.txtboxErrorMsg = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

