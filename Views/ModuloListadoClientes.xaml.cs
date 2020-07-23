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
    public partial class ModuloListadoClientes : MetroWindow
    {
        #region INSTANCIA DE CONTROLADORES
        ClienteController clienteController = new ClienteController();
        ActividadEmpresaController actividadEmpresaController = new ActividadEmpresaController();
        TipoEmpresaController tipoEmpresaController = new TipoEmpresaController();
        #endregion

        #region SINGLETON
        public static ModuloListadoClientes view;
        public static ModuloListadoClientes getInstance()
        {
            if (view == null)
            {
                view = new ModuloListadoClientes();
            }
            return view;
        }
        private void wpf_listado_clientes_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            view = null;
        }
        #endregion

        #region CARGAR ESTRUCTURA INICIAL
        public ModuloListadoClientes()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cargarEstructuraInicial();
        }

        private void cargarEstructuraInicial()
        {
            CargarListadoClientes();
            NotificationCenter.Subscribe("entidad", CargarListadoClientes);
        }

        private async void CargarListadoClientes()
        {
            try
            {
                Dispatcher.Invoke(
                    () => {
                        dtgListadoClientes.ItemsSource = clienteController.GetEntities();
                        dtgListadoClientes.Items.Refresh();
                    }
                 );
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Se ha producido un error desconocido.\n" + ex.Message);
            }
        }

        

        

        private async void CargarDatosCliente()
        {
            try
            {
                Cliente c = (Cliente)dtgListadoClientes.SelectedItem;
                ModuloClientes.getInstance().Show();
                ModuloClientes.getInstance().Activate();
                ModuloClientes.getInstance().CargarDatosCliente(c);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Se ha producido un error.\n" + ex.Message);
            }
        }

        private void dtgListadoClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            CargarDatosCliente();
            
        }

        #endregion
        private void cboOpcionesFiltro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FiltrarListadoClientes();
        }

        private async void FiltrarListadoClientes()
        {
            try
            {
                
                int opcion = cboOpcionesFiltro.SelectedIndex;
                string filtro = txtTextoFiltro.Text;

                if(opcion == 0)
                {
                    dtgListadoClientes.ItemsSource = clienteController.WhereRutCliente(filtro);
                    txtTextoFiltro.Focus();
                }
                else if(opcion == 1)
                {
                    dtgListadoClientes.ItemsSource = clienteController.WhereDescripcionEmpresa(filtro);
                    txtTextoFiltro.Focus();
                }
                else if(opcion == 2)
                {
                    dtgListadoClientes.ItemsSource = clienteController.WhereActividadEmpresa(filtro);
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

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            cboOpcionesFiltro.SelectedIndex = -1;
            txtTextoFiltro.Text = string.Empty;
            dtgListadoClientes.Items.Refresh();
        }

        private void txtTextoFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            FiltrarListadoClientes();
        }

       
    }
}