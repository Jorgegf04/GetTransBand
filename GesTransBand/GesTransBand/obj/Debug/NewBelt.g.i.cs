﻿#pragma checksum "..\..\NewBelt.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "337CF408B76A804AD0562FE284765C1718F54DF590CB9F1D111B75B8832988EA"
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
    /// NewBelt
    /// </summary>
    public partial class NewBelt : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 69 "..\..\NewBelt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox codigoCintaTextBox;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\NewBelt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox descripcionCintaTextBox;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\NewBelt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buscarButton;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\NewBelt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fichaTecnicaCintaTextBox;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\NewBelt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image fichaTecnicaImage;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\NewBelt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox certificadoCintaTextBox;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\NewBelt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CetificadoImage;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\NewBelt.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button insertarButton;
        
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
            System.Uri resourceLocater = new System.Uri("/GesTransBand;component/newbelt.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewBelt.xaml"
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
            this.codigoCintaTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.descripcionCintaTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.buscarButton = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\NewBelt.xaml"
            this.buscarButton.Click += new System.Windows.RoutedEventHandler(this.BuscarButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.fichaTecnicaCintaTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.fichaTecnicaImage = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.certificadoCintaTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.CetificadoImage = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.insertarButton = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\NewBelt.xaml"
            this.insertarButton.Click += new System.Windows.RoutedEventHandler(this.InsertarButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 100 "..\..\NewBelt.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

