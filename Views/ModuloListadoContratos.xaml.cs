using Controllers;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Models;
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
using System.Windows.Shapes;

namespace Views
{
    public partial class ModuloListadoContratos : MetroWindow
    {
        #region INSTANCIA DE CONTROLADORES
        ContratoController contratoController = new ContratoController();
        TipoEventoController tipoEventoController = new TipoEventoController();
        #endregion

        #region SINGLETON 
        public static ModuloListadoContratos view;

        public static ModuloListadoContratos getInstance()
        {
            if (view == null)
            {
                view = new ModuloListadoContratos();
            }
            return view;
        }

        private void wpf_listado_contratos_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            view = null;
        }
        #endregion

        #region CARGAR ESTRUCTURA INICIAL
        public ModuloListadoContratos()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cargarEstructuraInicial();
        }

        private void cargarEstructuraInicial()
        {
            CargarListadoContratos();
            cboOpcionesFiltro.SelectedIndex = -1;
            txtTextoFiltro.Text = string.Empty;
        }

        // Se cargan en el Combo Box.
        
        private async void CargarListadoContratos()
        {
            try
            {
                dtgListadoContratos.ItemsSource = contratoController.GetEntities();

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Se ha producido un error desconocido.\n" + ex.Message);
            }
        }

        private void dtgListadoContratos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CargarDatosContrato();
        }

        private async void CargarDatosContrato()
        {
            try
            {
                Contrato c = (Contrato)dtgListadoContratos.SelectedItem;
                ModuloContratos.getInstance().Show();
                ModuloContratos.getInstance().Activate();
                ModuloContratos.getInstance().CargarDatosContrato(c);
                /*
                Contrato c = (Contrato)dtgListadoContratos.SelectedItem;
                String parent = this.Owner.Name;
                if (parent == "wpf_menu")
                {
                    ModuloContratos mlscn = new ModuloContratos();
                    mlscn.Show();
                    mlscn.CargarDatosContrato(c);
                }
                else if (parent == "wpf_contratos")
                {
                    ModuloContratos mlscn = (ModuloContratos)this.Owner;
                    mlscn.Show();
                    mlscn.CargarDatosContrato(c);
                }
                */
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Se ha producido un error.\n" + ex.Message);
            }
        }
        #endregion

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            cboOpcionesFiltro.SelectedIndex = -1;
            txtTextoFiltro.Text = string.Empty;
            CargarListadoContratos();
        }

        private void cboOpcionesFiltro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FiltrarListadoContratos();
        }

        private async void FiltrarListadoContratos()
        {
            try
            {

                int opcion = cboOpcionesFiltro.SelectedIndex;
                string filtro = txtTextoFiltro.Text;

                if (opcion == 0)
                {
                    dtgListadoContratos.ItemsSource = contratoController.WhereNumeroContrato(filtro);
                    txtTextoFiltro.Focus();
                }
                else if (opcion == 1)
                {
                    dtgListadoContratos.ItemsSource = contratoController.WhereTipoEvento(filtro);
                    txtTextoFiltro.Focus();
                }
                else if (opcion == 2)
                {
                    dtgListadoContratos.ItemsSource = contratoController.WhereModalidadServicio(filtro);
                    txtTextoFiltro.Focus();
                }
                else if (opcion == 3)
                {
                    dtgListadoContratos.ItemsSource = contratoController.WhereRutCliente(filtro);
                    txtTextoFiltro.Focus();
                }    
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Se ha producido un error desconocido.\n" + ex.Message);
            }
        }

        private void txtTextoFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            FiltrarListadoContratos();
        }
    }
}
