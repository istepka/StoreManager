﻿#pragma checksum "..\..\..\..\..\..\Views\Admin\Products\ProductsManagementView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8C2B17202EBC279A2809880DDF48D5CFD48AA72F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using StoreManagerUI.Views;
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


namespace StoreManagerUI.Views {
    
    
    /// <summary>
    /// ProductsManagementView
    /// </summary>
    public partial class ProductsManagementView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\..\..\..\..\Views\Admin\Products\ProductsManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchedProduct;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\..\Views\Admin\Products\ProductsManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ProductsList;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\..\Views\Admin\Products\ProductsManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SelectedProduct_ProductOverview;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\..\Views\Admin\Products\ProductsManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoveProduct;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\..\Views\Admin\Products\ProductsManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox QuantityToAdd;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\..\..\Views\Admin\Products\ProductsManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubmitQuantityChange;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\..\..\Views\Admin\Products\ProductsManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubmitNewPrice;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\..\Views\Admin\Products\ProductsManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewProduct;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\..\..\Views\Admin\Products\ProductsManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReloadProducts;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\..\..\Views\Admin\Products\ProductsManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl ActiveItem;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StoreManagerUI;component/views/admin/products/productsmanagementview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Views\Admin\Products\ProductsManagementView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SearchedProduct = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ProductsList = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.SelectedProduct_ProductOverview = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.RemoveProduct = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.QuantityToAdd = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.SubmitQuantityChange = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.SubmitNewPrice = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.AddNewProduct = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.ReloadProducts = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.ActiveItem = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
