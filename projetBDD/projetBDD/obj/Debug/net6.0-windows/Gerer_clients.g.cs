﻿#pragma checksum "..\..\..\Gerer_clients.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51031FE6E0A4B96067427004515D5A4D70A9B141"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using projetBDD;


namespace projetBDD {
    
    
    /// <summary>
    /// Gerer_clients
    /// </summary>
    public partial class Gerer_clients : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Gerer_clients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_exit;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Gerer_clients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_retour;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Gerer_clients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_nvxProduit;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Gerer_clients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_searchProduit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/projetBDD;component/gerer_clients.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Gerer_clients.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.bt_exit = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Gerer_clients.xaml"
            this.bt_exit.Click += new System.Windows.RoutedEventHandler(this.bt_exit_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bt_retour = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Gerer_clients.xaml"
            this.bt_retour.Click += new System.Windows.RoutedEventHandler(this.bt_retour_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.bt_nvxProduit = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Gerer_clients.xaml"
            this.bt_nvxProduit.Click += new System.Windows.RoutedEventHandler(this.bt_nvxClient_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.bt_searchProduit = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Gerer_clients.xaml"
            this.bt_searchProduit.Click += new System.Windows.RoutedEventHandler(this.bt_searchClient_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

