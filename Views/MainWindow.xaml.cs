using MahApps.Metro;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Views
{
    public partial class MainWindow : MetroWindow
    {

        public static MainWindow view = null;

        public static MainWindow getInstance()
        {
            if (view == null)
            {
                view = new MainWindow();
            }
            return view;
        }

        private void wpf_menu_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            view = null;
            // Al cerrar el menu, se fuerza el cierre de la app. completa.
            Environment.Exit(0);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void tlAdministracionContratos_Click(object sender, RoutedEventArgs e)
        {
            ModuloContratos mct = new ModuloContratos();
            mct.Owner = Window.GetWindow(this);
            mct.Owner.Name = "wpf_menu";
            ModuloContratos.getInstance().Show();
            ModuloContratos.getInstance().Activate();
        }

        private void tlAdministradorClientes_Click(object sender, RoutedEventArgs e)
        {
            ModuloClientes mc = new ModuloClientes();
            mc.Owner = Window.GetWindow(this);
            mc.Owner.Name = "wpf_menu";
            ModuloClientes.getInstance().Show();
            ModuloClientes.getInstance().Activate();
        }

        private void tlListadoClientes_Click(object sender, RoutedEventArgs e)
        {
            ModuloListadoClientes mlc = new ModuloListadoClientes();
            mlc.Owner = Window.GetWindow(this);
            mlc.Owner.Name = "wpf_menu";
            mlc.ShowDialog();
        }

        private void tlListadoContratos_Click(object sender, RoutedEventArgs e)
        {
            ModuloListadoContratos mlscn = new ModuloListadoContratos();
            mlscn.Owner = Window.GetWindow(this);
            mlscn.Owner.Name = "wpf_menu";
            mlscn.ShowDialog();
        }

        private void tlModoLight_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Steel"), ThemeManager.GetAppTheme("BaseLight"));
        }

        private void tlModoLightDark_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Blue"), ThemeManager.GetAppTheme("BaseDark"));
        }

        private void AcercaDe_Click(object sender, RoutedEventArgs e)
        {
            if(flAcercaDe.IsOpen == false)
            {
                flAcercaDe.IsOpen = true;
            }
            else if(flAcercaDe.IsOpen == true)
            {
                flAcercaDe.IsOpen = false;
            }
        }
    }
}
