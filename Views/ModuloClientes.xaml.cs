using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Models;
using Controllers;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace Views
{
    public partial class ModuloClientes : MetroWindow
    {
        #region INSTANCIA DE OBJETOS CONTROLLERS
        ActividadEmpresaController actividadEmpresaController = new ActividadEmpresaController();
        TipoEmpresaController tipoEmpresaController = new TipoEmpresaController();
        ClienteController clienteController = new ClienteController();
        #endregion

        #region PATRON SINGLETON
        public static ModuloClientes view = null;
        public static ModuloClientes getInstance()
        {
            if (view == null)
            {
                view = new ModuloClientes();
            }
            return view;
        }

        private void wpf_clientes_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            view = null;
        }
        #endregion

        #region CARGAR ESTRUCTURA INICIAL
        public ModuloClientes()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CargarEstructuraInicial();
        }

        private void CargarEstructuraInicial()
        {
            txtRutCliente.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtNombreContacto.Text = string.Empty;
            txtMailContacto.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtnumeroContacto.Text = string.Empty;
            txtFiltrarPorRut.Text = string.Empty;
            rbtnRutCliente.IsChecked = true;
            CargarActividadEmpresa();
            CargarTipoEmpresa();
            CargarListadoClientes();
            CargarRutClientes();
            cboTipoEmpresa.SelectedIndex = 0;
            cboActividadEmpresa.SelectedIndex = 0;
        }

        private async void CargarListadoClientes()
        {
            try
            {
                dtgListadoClientes.ItemsSource = clienteController.GetEntities();
                dtgListadoClientes.Items.Refresh();
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Se ha producido un error desconocido.\n" + ex.Message);
            }
        }

        private async void CargarRutClientes()
        {
            try
            {
                cboCargarClientes.ItemsSource = clienteController.GetEntities();
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Se ha producido un error desconocido.\n" + ex.Message);
            }
        }

        private async void CargarActividadEmpresa()
        {
            try
            {
                List<ActividadEmpresa> actividades = actividadEmpresaController.GetEntities();
                cboActividadEmpresa.ItemsSource = actividades;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Error desconocido\n" + ex.Message);
            }
        }

        private async void CargarTipoEmpresa()
        {
            try
            {
                List<TipoEmpresa> tipos = tipoEmpresaController.GetEntities();
                cboTipoEmpresa.ItemsSource = tipos;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Error desconocido\n" + ex.Message);
            }
        }
        #endregion

        #region PROCESOS
        private void btnCreateCliente_Click(object sender, RoutedEventArgs e)
        {
            RegistrarCliente();
        }

        private void btnReadCliente_Click(object sender, RoutedEventArgs e)
        {
            BuscarCliente();
        }

        private void btnUpdateCliente_Click(object sender, RoutedEventArgs e)
        {
            ModificarCliente();
        }

        private void btnDeleteCliente_Click(object sender, RoutedEventArgs e)
        {
            EliminarCliente();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            CargarEstructuraInicial();
        }

        private void txtnumeroContacto_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (!((Char.IsDigit(ch))))
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        // Abro la ventana ListadoClientes, y le digo wpf_clientes Es tu Padre y la llamo.
        private void abrirListadoClientes_Click(object sender, RoutedEventArgs e)
        {
            ModuloListadoClientes.getInstance().Show();
            ModuloListadoClientes.getInstance().Activate();
            ModuloListadoClientes mlc = new ModuloListadoClientes();
            mlc.Owner = Window.GetWindow(this);
            mlc.Owner.Name = "wpf_clientes";
            //mlc.Show();
        }

        public async void CargarDatosCliente(Cliente cliente)
        {
            try
            {
                if (cliente != null)
                {
                    txtRutCliente.Text = cliente.RutCliente;
                    txtRazonSocial.Text = cliente.RazonSocial;
                    txtNombreContacto.Text = cliente.NombreContacto;
                    txtMailContacto.Text = cliente.MailContacto;
                    txtDireccion.Text = cliente.Direccion;
                    txtnumeroContacto.Text = cliente.Telefono;
                    cboTipoEmpresa.SelectedValue = cliente.IdTipoEmpresa;
                    cboActividadEmpresa.SelectedValue = cliente.IdActividadEmpresa;
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Se ha producido un error.\n" + ex.Message);
            }
        }
        #endregion

        #region CREATE READ UPDATE DELETE
        private async void RegistrarCliente()
        {
            try
            {
                String rutCliente;
                // Validar Rut, formula fuente: QualityInfoSolutions.com
                if (validarRut(txtRutCliente.Text))
                {
                    rutCliente = txtRutCliente.Text;
                }
                else
                {
                    await this.ShowMessageAsync("Información", "El rut de cliente no es válido. Favor verificar e ingresar otro Rut Formato 99999999-9");
                    return;
                }
                String razonSocial = txtRazonSocial.Text;
                String nombreContacto = txtNombreContacto.Text;
                String mailContacto = txtMailContacto.Text;
                String direccion = txtDireccion.Text;
                String telefono = txtnumeroContacto.Text;
                TipoEmpresa idTipoEmpresa = new TipoEmpresa()
                {
                    IdTipoEmpresa = int.Parse(cboTipoEmpresa.SelectedValue.ToString())
                };
                ActividadEmpresa idActividadEmpresa = new ActividadEmpresa()
                {
                    IdActividadEmpresa = int.Parse(cboActividadEmpresa.SelectedValue.ToString())
                };
                // Se genera la instancia del objeto Cliente.
                Cliente cliente = new Cliente()
                {
                    RutCliente = rutCliente,
                    RazonSocial = razonSocial,
                    NombreContacto = nombreContacto,
                    MailContacto = mailContacto,
                    Direccion = direccion,
                    Telefono = telefono,
                    IdActividadEmpresa = idActividadEmpresa.IdActividadEmpresa,
                    IdTipoEmpresa = idTipoEmpresa.IdTipoEmpresa
                };
                clienteController.AddEntity(cliente);
                await this.ShowMessageAsync("Información", "Cliente " + cliente.RutCliente + " Agregado correctamente");
                NotificationCenter.Notify("entidad");
                CargarEstructuraInicial();
            }
            catch (ArgumentException ex)
            {
                await this.ShowMessageAsync("Error:", ex.Message);
            }
            catch (System.NullReferenceException ex)
            {
                await this.ShowMessageAsync("Información", ex.Message);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Información", ex.Message);
            }
        }

        private async void BuscarCliente()
        {
            try
            {
                String rut = await this.ShowInputAsync("Búsqueda", "Ingresa el rut del cliente");
                if (string.IsNullOrEmpty(rut))
                {
                    return;
                }

                Cliente c = clienteController.GetEntity(rut);
                if (c != null)
                {
                    txtRutCliente.Text = c.RutCliente;
                    txtRazonSocial.Text = c.RazonSocial;
                    txtNombreContacto.Text = c.NombreContacto;
                    txtMailContacto.Text = c.MailContacto;
                    txtDireccion.Text = c.Direccion;
                    txtnumeroContacto.Text = c.Telefono;
                    cboTipoEmpresa.SelectedValue = c.IdTipoEmpresa;
                    cboActividadEmpresa.SelectedValue = c.IdActividadEmpresa;
                }
                else
                {
                    await this.ShowMessageAsync("Información", "La personas que buscas no existe en nuestros registros");
                }
            }
            catch(ArgumentException ex)
            {
                await this.ShowMessageAsync("Información", ex.Message + "\nContacte al administrador");
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Información", ex.Message + "\nContacte al administrador");
            }
        }

        private async void ModificarCliente()
        {
            try
            {
                String rutCliente = txtRutCliente.Text;
                String razonSocial = txtRazonSocial.Text;
                String nombreContacto = txtNombreContacto.Text;
                String mailContacto = txtMailContacto.Text;
                String direccion = txtDireccion.Text;
                String telefono = txtnumeroContacto.Text;


                int idTipoEmpresa = int.Parse(cboTipoEmpresa.SelectedValue.ToString());


                int idActividadEmpresa = int.Parse(cboActividadEmpresa.SelectedValue.ToString());

                Cliente c = new Cliente()
                {
                    RutCliente = rutCliente,
                    RazonSocial = razonSocial,
                    NombreContacto = nombreContacto,
                    MailContacto = mailContacto,
                    Direccion = direccion,
                    Telefono = telefono,
                    IdActividadEmpresa = idActividadEmpresa,
                    IdTipoEmpresa = idTipoEmpresa
                };

                await this.ShowMessageAsync("Información", "Modificado correctamente");
                clienteController.UpdateEntity(c);
                NotificationCenter.Notify("entidad");
                CargarEstructuraInicial();
            }
            catch(ArgumentException ex)
            {
                await this.ShowMessageAsync("Información", "Error " + ex.Message);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Información", "Para modificar al cliente, debes completar todos los datos del formulario.");
            }
        }

        private async void EliminarCliente()
        {
            try
            {
                String rut = await this.ShowInputAsync("Búsqueda", "Ingresa el rut del cliente");
                if (string.IsNullOrEmpty(rut))
                {
                    return;
                }


                MessageDialogResult result = await this.ShowMessageAsync("Confirmación", "¿Estás seguro de eliminar al Cliente?",
                                                                            MessageDialogStyle.AffirmativeAndNegative);

                if (result == MessageDialogResult.Affirmative)
                {
                    clienteController.DeleteEntity(rut);
                    await this.ShowMessageAsync("Información", "Eliminado correctamente");
                    NotificationCenter.Notify("entidad");
                    CargarEstructuraInicial();
                }
            }
            catch (DbUpdateException e)
            {
                SqlException s = e.InnerException.InnerException as SqlException;
                if (s != null)
                {
                    await this.ShowMessageAsync("Información", "No es posible eliminar. Cliente tiene contrato registrado");
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Información", ex.Message);
            }
        }
        #endregion

        #region VALIDACIONES
        private void txtRutCliente_LostFocus(object sender, RoutedEventArgs e)
        {
            String rutCl = txtRutCliente.Text;

            if (validarRut(rutCl))
            {
                txtRutCliente.Background = Brushes.AliceBlue;
                txtRutCliente.Foreground = Brushes.Black;
            }
            else
            {
                txtRutCliente.BorderBrush = Brushes.Red;
                txtRutCliente.Foreground = Brushes.Black;
            }
        }

        public bool validarRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));
                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));
                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Hubo un problema en la validación del rut.");
            }
            return validacion;
        }

        private void txtFiltrarPorRut_KeyUp(object sender, KeyEventArgs e)
        {
            if(rbtnRutCliente.IsChecked == true)
            {
                dtgListadoClientes.ItemsSource = clienteController.BuscarRut(txtFiltrarPorRut.Text);
            }
            else if(rbtnNombreCliente.IsChecked == true)
            {
                dtgListadoClientes.ItemsSource = clienteController.BuscarNombre(txtFiltrarPorRut.Text);
            }
        }

        private void rbtnNombreCliente_Checked(object sender, RoutedEventArgs e)
        {
            CargarListadoClientes();
            txtFiltrarPorRut.Text = String.Empty;
            txtFiltrarPorRut.Focus();
        }

        private void rbtnRutCliente_Checked(object sender, RoutedEventArgs e)
        {
            CargarListadoClientes();
            txtFiltrarPorRut.Text = String.Empty;
            txtFiltrarPorRut.Focus();
        }

        private void btnProcesos_Click(object sender, RoutedEventArgs e)
        {
            if (flProcesos.IsOpen == false)
            {
                flProcesos.IsOpen = true;
            }
            else if (flProcesos.IsOpen == true)
            {
                flProcesos.IsOpen = false;
            }
        }

        private void cboCargarClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String rut = cboCargarClientes.SelectedValue.ToString();
            Cliente c = clienteController.GetEntity(rut);
            if(c != null)
            {
                CargarDatosCliente(c);
            }
        }

        private void cboTipoEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mtbMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    #endregion
}
