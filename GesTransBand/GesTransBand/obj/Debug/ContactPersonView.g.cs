﻿#pragma checksum "..\..\ContactPersonView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0E7B391180E128EBF3F92F3CE49ECDD275E1FFA7AD66D8504A03A68F8AAE2A17"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using GesTransBand;
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


namespace GesTransBand {
    
    
    /// <summary>
    /// ContactPersonView
    /// </summary>
    public partial class ContactPersonView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\ContactPersonView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\ContactPersonView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox surnameTextBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\ContactPersonView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox telephoneTextBox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\ContactPersonView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailTextBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\ContactPersonView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox companyComboBox;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\ContactPersonView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveButton;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\ContactPersonView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\ContactPersonView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clearButton;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\ContactPersonView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nuevoButton;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\ContactPersonView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvContactPerson;
        
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
            System.Uri resourceLocater = new System.Uri("/GesTransBand;component/contactpersonview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ContactPersonView.xaml"
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
            
            #line 34 "..\..\ContactPersonView.xaml"
            this.nameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NameTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.surnameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 40 "..\..\ContactPersonView.xaml"
            this.surnameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SurnameTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.telephoneTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 46 "..\..\ContactPersonView.xaml"
            this.telephoneTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TelephoneTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.emailTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\ContactPersonView.xaml"
            this.emailTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.EmailTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.companyComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 58 "..\..\ContactPersonView.xaml"
            this.companyComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CompanyComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.saveButton = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\ContactPersonView.xaml"
            this.saveButton.Click += new System.Windows.RoutedEventHandler(this.SaveContactPerson_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\ContactPersonView.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.DeleteContactPerson_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.clearButton = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\ContactPersonView.xaml"
            this.clearButton.Click += new System.Windows.RoutedEventHandler(this.ClearForm_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.nuevoButton = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\ContactPersonView.xaml"
            this.nuevoButton.Click += new System.Windows.RoutedEventHandler(this.NuevoButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.lvContactPerson = ((System.Windows.Controls.ListView)(target));
            
            #line 74 "..\..\ContactPersonView.xaml"
            this.lvContactPerson.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LvAssembler_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 89 "..\..\ContactPersonView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
