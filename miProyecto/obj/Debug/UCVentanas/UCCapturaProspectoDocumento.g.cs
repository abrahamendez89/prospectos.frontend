#pragma checksum "..\..\..\UCVentanas\UCCapturaProspectoDocumento.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EE28C8B8052C525F2833061E523A333AF349FA2D5B0725BB1E78FD2031F0F855"
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
using UI.UserControls;
using miProyecto.UCVentanas;


namespace miProyecto.UCVentanas {
    
    
    /// <summary>
    /// UCCapturaProspectoDocumento
    /// </summary>
    public partial class UCCapturaProspectoDocumento : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\UCVentanas\UCCapturaProspectoDocumento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblNombreDocumento;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UCVentanas\UCCapturaProspectoDocumento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UI.UserControls.UCButton btnCargar;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\UCVentanas\UCCapturaProspectoDocumento.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UI.UserControls.UCButton btnDescargar;
        
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
            System.Uri resourceLocater = new System.Uri("/miProyecto;component/ucventanas/uccapturaprospectodocumento.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UCVentanas\UCCapturaProspectoDocumento.xaml"
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
            this.lblNombreDocumento = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.btnCargar = ((UI.UserControls.UCButton)(target));
            return;
            case 3:
            this.btnDescargar = ((UI.UserControls.UCButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

