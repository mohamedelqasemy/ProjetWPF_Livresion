using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Syncfusion.Licensing;

namespace AppGestionEtudiant
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Enregistrez la clé de licence ici
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF5cXmBCfExxWmFZfVtgcF9GY1ZVRGY/P1ZhSXxWdkRjUX5YcHdRRGlVUkQ=");

            base.OnStartup(e);
        }
    }
}
