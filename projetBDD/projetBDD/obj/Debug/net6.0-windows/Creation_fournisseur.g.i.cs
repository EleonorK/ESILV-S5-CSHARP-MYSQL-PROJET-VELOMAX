﻿#pragma checksum "..\..\..\Creation_fournisseur.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D33D1CF85A9690FCCD001107C019BFF85202EE3E"
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
    /// Creation_fournisseur
    /// </summary>
    public partial class Creation_fournisseur : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Creation_fournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_exit;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Creation_fournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_retour;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Creation_fournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tx_nonEntreprise;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Creation_fournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tx_rue;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Creation_fournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tx_ville;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Creation_fournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tx_province;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Creation_fournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tx_CP;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Creation_fournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tx_numTel;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Creation_fournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox tx_mdp;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Creation_fournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tx_couriel;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Creation_fournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox tx_mdpConfir;
        
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
            System.Uri resourceLocater = new System.Uri("/projetBDD;component/creation_fournisseur.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Creation_fournisseur.xaml"
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
            
            #line 21 "..\..\..\Creation_fournisseur.xaml"
            this.bt_exit.Click += new System.Windows.RoutedEventHandler(this.bt_exit_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bt_retour = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Creation_fournisseur.xaml"
            this.bt_retour.Click += new System.Windows.RoutedEventHandler(this.bt_retour_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tx_nonEntreprise = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tx_rue = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tx_ville = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tx_province = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tx_CP = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\..\Creation_fournisseur.xaml"
            this.tx_CP.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tx_numTel = ((System.Windows.Controls.TextBox)(target));
            
            #line 63 "..\..\..\Creation_fournisseur.xaml"
            this.tx_numTel.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 9:
            this.tx_mdp = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 10:
            this.tx_couriel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.tx_mdpConfir = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 12:
            
            #line 87 "..\..\..\Creation_fournisseur.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

