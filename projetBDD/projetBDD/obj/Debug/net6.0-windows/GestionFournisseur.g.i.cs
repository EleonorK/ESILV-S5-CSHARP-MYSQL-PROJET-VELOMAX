﻿#pragma checksum "..\..\..\GestionFournisseur.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50A6F65030D0C00A506BA54B841129C99D596976"
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
    /// GestionFournisseur
    /// </summary>
    public partial class GestionFournisseur : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_exit;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_retour;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbFournisseur;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgFournisseur;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lsid_siret;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lsid_adresse;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lsnom_entreprise;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lscontact_fournisseur;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\GestionFournisseur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lslibelle_fournisseur;
        
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
            System.Uri resourceLocater = new System.Uri("/projetBDD;component/gestionfournisseur.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GestionFournisseur.xaml"
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
            
            #line 21 "..\..\..\GestionFournisseur.xaml"
            this.bt_exit.Click += new System.Windows.RoutedEventHandler(this.bt_exit_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bt_retour = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\GestionFournisseur.xaml"
            this.bt_retour.Click += new System.Windows.RoutedEventHandler(this.bt_retour_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbFournisseur = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.dgFournisseur = ((System.Windows.Controls.DataGrid)(target));
            
            #line 32 "..\..\..\GestionFournisseur.xaml"
            this.dgFournisseur.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgFournisseur_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 35 "..\..\..\GestionFournisseur.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Rechercher_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lsid_siret = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.lsid_adresse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.lsnom_entreprise = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.lscontact_fournisseur = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.lslibelle_fournisseur = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            
            #line 44 "..\..\..\GestionFournisseur.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MAJ_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 45 "..\..\..\GestionFournisseur.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Supprimer_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 46 "..\..\..\GestionFournisseur.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exports_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

