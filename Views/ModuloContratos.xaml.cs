using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Models;
using Controllers;
using MahApps.Metro.Controls.Dialogs;

namespace Views
{
    public partial class ModuloContratos : MetroWindow
    {
        DateTime local = DateTime.Now.AddDays(+1);
        Double uf = 28.693;

        #region Instancia de Controladores
        ClienteController clienteController = new ClienteController();
        TipoEventoController tipoEventoController = new TipoEventoController();
        ModalidadServicioController mdc = new ModalidadServicioController();
        ContratoController contratoController = new ContratoController();
        #endregion

        #region Patron SINGLETON
        public static ModuloContratos view = null;
        public static ModuloContratos getInstance()
        {
            if (view == null)
            {
                view = new ModuloContratos();
            }
            return view;
        }
        private void wpf_contratos_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            view = null;
        }
        #endregion

        #region Estructura Inicial

        

        private void btnAbrirListadoContratos_Click(object sender, RoutedEventArgs e)
        {
            ModuloListadoContratos.getInstance().Show();
            ModuloListadoContratos.getInstance().Activate();
            ModuloListadoContratos mlc = new ModuloListadoContratos();
            mlc.Owner = Window.GetWindow(this);
            mlc.Owner.Name = "wpf_contratos";
        }

        private void btnAbrirListadoClientes_Click(object sender, RoutedEventArgs e)
        {
            ModuloListadoClientes.getInstance().Show();
            ModuloListadoClientes.getInstance().Activate();
            ModuloListadoClientes mlc = new ModuloListadoClientes();
            mlc.Owner = Window.GetWindow(this);
            mlc.Owner.Name = "wpf_contratos";
        }

        public async void CargarDatosContrato(Contrato contrato)
        {
            try
            {
                if (contrato != null)
                {
                    cboRutCliente.SelectedValue = contrato.RutCliente;
                    cboTipoEvento.SelectedValue = contrato.IdTipoEvento;
                    cargarTipos();
                    cboModalidadServicio.SelectedValue = contrato.IdModalidad;
                    dtpFechaHoraCreacionContrato.Value = contrato.Creacion;
                    dtpFechaHoraTerminoContrato.Value = contrato.Termino;
                    dtpFechaHoraInicioEvento.Value = contrato.FechaHoraInicio;
                    dtpFechaHoraTerminoEvento.Value = contrato.FechaHoraTermino;
                    txtCantidadAsistentes.Text = contrato.Asistentes.ToString();
                    txtCantidadPersonalAdicional.Text = contrato.PersonalAdicional.ToString();

                    if(contrato.Realizado == true)
                    {
                        chkEstadoContrato.IsChecked = false;
                    }
                    else if(contrato.Realizado == false)
                    {
                        chkEstadoContrato.IsChecked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Se ha producido un error.\n" + ex.Message);
            }
        }

        #endregion

        #region CARGAR ESTRUCTURA INICIAL
        public ModuloContratos()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cargarEstructuraInicial();
        }

        private void cargarEstructuraInicial()
        {
            cboTipoEvento.SelectedIndex = 0;
            cboRutCliente.SelectedIndex = 0;
            CargarRutCliente();
            CargarTipoEvento();
            dtpFechaHoraCreacionContrato.Value = DateTime.Now;
            dtpFechaHoraTerminoContrato.Value = DateTime.Now.AddDays(+1);
            dtpFechaHoraInicioEvento.Value = DateTime.Now;
            dtpFechaHoraTerminoEvento.Value = DateTime.Now.AddMinutes(+560);
            txtCantidadAsistentes.Text = String.Empty;
            txtCantidadPersonalAdicional.Text = String.Empty;
            lblValidarFechaCreacionContrato.Visibility = Visibility.Hidden;
            lblValidarFechaTerminoContrato.Visibility = Visibility.Hidden;
            lblValidarHoraInicioDeEvento.Visibility = Visibility.Hidden;
            lblValidarHoraTerminoDeEvento.Visibility = Visibility.Hidden;
            lblValidarHoraTerminoDeEvento.Visibility = Visibility.Hidden;
            lblInforEstadoContrato001.Visibility = Visibility.Hidden;
            lblInforEstadoContrato002.Visibility = Visibility.Hidden;
        }

        private async void CargarRutCliente()
        {
            try
            {
                List<Cliente> clientes = clienteController.GetEntities();
                cboRutCliente.ItemsSource = clientes;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Error desconocido\n" + ex.Message);
            }
        }

        private async void CargarTipoEvento()
        {
            try
            {
                List<TipoEvento> eventos = tipoEventoController.GetEntities();
                cboTipoEvento.ItemsSource = eventos;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Error desconocido\n" + ex.Message);
            }
        }
        #endregion

        #region PROCESOS
        private void btnCreateContrato_Click(object sender, RoutedEventArgs e)
        {
            RegistrarContrato();
        }

        private void btnReadContrato_Click(object sender, RoutedEventArgs e)
        {
            BuscarContrato(); 
        }

        private void btnUpdateContrato_Click(object sender, RoutedEventArgs e)
        {
            ModificarContrato();
        }

        private void btnDeleteContrato_Click(object sender, RoutedEventArgs e)
        {
            TerminoContrato();
        }

        private async void cboRutCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                String rutCliente = cboRutCliente.SelectedValue.ToString();
                Cliente c = clienteController.GetEntity(rutCliente);
                if (c != null)
                {
                    txtNombreCliente.Text = c.NombreContacto;
                    txtDireccionCliente.Text = c.Direccion;
                    txtEmailCliente.Text = c.MailContacto;
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Error desconocido\n" + ex.Message);
            }

        }

        private void cboTipoEvento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cargarTipos();
        }
        
        private async void cargarTipos()
        {
            try
            {
                cboModalidadServicio.ItemsSource = new ModalidadServicioController().buscarModalidad((int)cboTipoEvento.SelectedValue);
                cboModalidadServicio.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Error desconocido\n" + ex.Message);
            }
        }

        private async void cboModalidadServicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cboModalidadServicio.SelectedValue != null)
                {
                    String idModalidad = cboModalidadServicio.SelectedValue.ToString();
                    mdc.GetEntity(idModalidad);
                    ModalidadServicio ms = mdc.GetEntity(idModalidad);
                    if (ms != null)
                    {
                        txtValorBaseModalidadServicio.Text = ms.ValorBase.ToString() + " UF";
                        txtPersonalBase.Text = ms.PersonalBase.ToString() + " PERSONAS";
                        this.lblValorBaseUF.Content = ms.ValorBase + " UF";
                        this.lblValorBasePeso.Content = "$ " + (ms.ValorBase * uf);
                    }
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", "Error desconocido\n" + ex.Message);
            }
        }

        private void txtCantidadAsistentes_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void txtCantidadPersonalAdicional_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            cargarEstructuraInicial();
        }
        #endregion

        #region CREATE READ UPDATE DELETE
        private async void RegistrarContrato()
        {
            try
            {
                DateTime fechaCreacion = DateTime.Parse(dtpFechaHoraCreacionContrato.Value.ToString());
                DateTime termino = DateTime.Parse(dtpFechaHoraTerminoContrato.Value.ToString());
                String rutCliente = cboRutCliente.SelectedValue.ToString();
                String idModalidad = cboModalidadServicio.SelectedValue.ToString();
                int idTipoEvento = int.Parse(cboTipoEvento.SelectedValue.ToString());
                DateTime fechaHoraInicio = DateTime.Parse(dtpFechaHoraInicioEvento.Text);
                DateTime fechaHoraTermino = DateTime.Parse(dtpFechaHoraTerminoEvento.Text);
                int asistentes = int.Parse(txtCantidadAsistentes.Text);
                int personalAdicional = int.Parse(txtCantidadPersonalAdicional.Text);
                Boolean realizado = false;

                // Generamos Calculo del Contrato.
                Double valor_base = 0;
                mdc.GetEntity(idModalidad);
                ModalidadServicio ms = mdc.GetEntity(idModalidad);
                if (ms != null)
                {
                    valor_base = ms.ValorBase;
                }
                Double valorTotalContrato = valor_base + RecargoAsistentes(asistentes) + PersonalAdicional(personalAdicional);
                //end Calculo Contrato.

                String observaciones = "N/A";
                // Se genera la instancia del objeto Contrato. Se le asignan las propiedades capturadas en las variables declaradas anteriormente.
                Contrato c = new Contrato()
                {
                    Numero = fechaCreacion.ToString("yyyyMMddhhmm"),
                    Creacion = fechaCreacion,
                    Termino = termino,
                    RutCliente = rutCliente,
                    IdModalidad = idModalidad,
                    IdTipoEvento = idTipoEvento,
                    FechaHoraInicio = fechaHoraInicio,
                    FechaHoraTermino = fechaHoraTermino,
                    Asistentes = asistentes,
                    PersonalAdicional = personalAdicional,
                    Realizado = realizado,
                    ValorTotalContrato = valorTotalContrato,
                    Observaciones = observaciones
                };
                contratoController.AddEntity(c);
                await this.ShowMessageAsync("Información", "Contrato Numero " + c.Numero + " Registrado satisfactoriamente");
                cargarEstructuraInicial();
            }
            catch (ArgumentException ex)
            {
                await this.ShowMessageAsync("Error:", ex.Message);
            }
            catch (FormatException ex)
            {
                await this.ShowMessageAsync("Información", "Todos los Campos son obligatorios\nFavor verificar información ingresada.");
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Información", "Problemas con el proceso de Registro\n" + ex.Message);
            }
        }

        private async void BuscarContrato()
        {
            try
            {
                String numeroContrato = await this.ShowInputAsync("Búsqueda", "Ingresa el Número de Contrato");
                if (string.IsNullOrEmpty(numeroContrato))
                {
                    return;
                }
                Contrato c = contratoController.GetEntity(numeroContrato);
                if (c != null)
                {
                    cboTipoEvento.SelectedValue = c.IdTipoEvento;
                    cargarTipos();
                    cboModalidadServicio.SelectedValue = c.IdModalidad;
                    ModalidadServicio ms = mdc.GetEntity(c.IdModalidad);
                    if (ms != null)
                    {
                        txtValorBaseModalidadServicio.Text = ms.ValorBase.ToString() + " UF";
                        txtPersonalBase.Text = ms.PersonalBase.ToString() + " PERSONAS";
                    }
                    txtCantidadAsistentes.Text = c.Asistentes.ToString();
                    txtCantidadPersonalAdicional.Text = c.PersonalAdicional.ToString();
                    cboRutCliente.SelectedValue = c.RutCliente;
                    Cliente cl = clienteController.GetEntity(c.RutCliente);
                    if (cl != null)
                    {
                        txtNombreCliente.Text = cl.NombreContacto;
                    }
                    dtpFechaHoraCreacionContrato.Value = c.Creacion;
                    dtpFechaHoraTerminoContrato.Value = c.Termino;
                    dtpFechaHoraInicioEvento.Value = c.FechaHoraInicio;
                    dtpFechaHoraTerminoEvento.Value = c.FechaHoraTermino;
 
                    if (c.Realizado != true)
                    {
                        chkEstadoContrato.IsChecked = true;
                    }
                    else
                    {
                        chkEstadoContrato.IsChecked = false;
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Información", "El contrato que buscas no existe en nuestros registros");
                }
                
            }
            catch (ArgumentException ex)
            {
                await this.ShowMessageAsync("Error:", ex.Message);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Información", "Error\n" + ex.Message + "\nContacte al administrador");
            }
        }

        private async void ModificarContrato()
        {
            try
            {
                String numeroContrato = await this.ShowInputAsync("Información", "Ingresa el Número de Contrato");
                if (string.IsNullOrEmpty(numeroContrato))
                {
                    return;
                }

                Contrato cn = contratoController.GetEntity(numeroContrato);
                if (cn != null)
                {
                    if (cn.Realizado != true)
                    {
                        
                        String numero = cn.Numero;
                        DateTime creacion = cn.Creacion;
                        DateTime termino = DateTime.Parse(dtpFechaHoraTerminoContrato.Value.ToString());
                        String rutCliente = cboRutCliente.SelectedValue.ToString();
                        String idModalidad = cboModalidadServicio.SelectedValue.ToString();
                        int idTipoEvento = int.Parse(cboTipoEvento.SelectedValue.ToString());
                        DateTime fechaHoraInicio = DateTime.Parse(dtpFechaHoraInicioEvento.Text);
                        DateTime fechaHoraTermino = DateTime.Parse(dtpFechaHoraTerminoEvento.Text);
                        int asistentes = int.Parse(txtCantidadAsistentes.Text);
                        int personalAdicional = int.Parse(txtCantidadPersonalAdicional.Text);
                        Boolean realizado = false;
                        String observaciones = "N/A";

                        // Generamos Calculo del Contrato.

                        Double valor_base = 0;
                        mdc.GetEntity(idModalidad);
                        ModalidadServicio ms = mdc.GetEntity(idModalidad);
                        if (ms != null)
                        {
                            valor_base = ms.ValorBase;
                        }
                        Double valorTotalContrato = valor_base + RecargoAsistentes(asistentes) + PersonalAdicional(personalAdicional);
                        //end Calculo Contrato.

                        Contrato contratoUpdate = new Contrato()
                        {
                            Numero = numero,
                            Creacion = creacion,
                            Termino = termino,
                            RutCliente = rutCliente,
                            IdModalidad = idModalidad,
                            IdTipoEvento = idTipoEvento,
                            FechaHoraInicio = fechaHoraInicio,
                            FechaHoraTermino = fechaHoraTermino,
                            Asistentes = asistentes,
                            PersonalAdicional = personalAdicional,
                            Realizado = realizado,
                            ValorTotalContrato = valorTotalContrato,
                            Observaciones = observaciones
                        };

                        contratoController.UpdateEntity(contratoUpdate);
                        await this.ShowMessageAsync("Información", "Contrato Numero " + cn.Numero + " Modificado satisfactoriamente");
                        cargarEstructuraInicial();
                    }
                    else
                    {
                        await this.ShowMessageAsync("Información", "El Contrato número " + numeroContrato +
                                                        " See encuentra finalizado con fecha de término el día " +
                                                        string.Format("{0:dddd, dd 'de' MMMM 'de' yyyy}", cn.Termino) +
                                                        "\nNo es posible modificarlo debido a que se encuentra terminado.");
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Información", "El contrato que buscas no existe en nuestros registros");
                }
            }
            catch (ArgumentException ex)
            {
                await this.ShowMessageAsync("Información", "Error " + ex.Message);
            }
            catch (FormatException ex)
            {
                await this.ShowMessageAsync("Información", "Todos los Campos son obligatorios\nFavor verificar información ingresada.");
                
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Información", "Error\n" + ex.Message + "\nContacte al administrador");
            }
        }

        private async void TerminoContrato()
        {
            try
            {
                String numeroContrato = await this.ShowInputAsync("Proceso de Término de Contrato", "Ingresa el Número de Contrato");
                if (string.IsNullOrEmpty(numeroContrato))
                {
                    await this.ShowMessageAsync("Información", "Debes ingresar un numero de Contrato válido.");
                    return;
                }

                MessageDialogResult result = await this.ShowMessageAsync("Confirmación", "¿Estás seguro de poner termino al Contrato?",
                                                                           MessageDialogStyle.AffirmativeAndNegative);

                if (result == MessageDialogResult.Affirmative)
                {
                    Contrato c = contratoController.GetEntity(numeroContrato);
                    if (c != null)
                    {
                        // Si la columna Realizado = false instancio a un objeto contrato y le paso los atributos del antiguo objeto 
                        if (c.Realizado != true)
                        {
                            Contrato contrato = new Contrato()
                            {
                                Numero = c.Numero,
                                Creacion = c.Creacion,
                                Termino = c.Termino,
                                RutCliente = c.RutCliente,
                                IdModalidad = c.IdModalidad,
                                IdTipoEvento = c.IdTipoEvento,
                                FechaHoraInicio = c.FechaHoraInicio,
                                FechaHoraTermino = c.FechaHoraTermino,
                                Asistentes = c.Asistentes,
                                PersonalAdicional = c.PersonalAdicional,
                                Realizado = true,
                                ValorTotalContrato = c.ValorTotalContrato,
                                Observaciones = c.Observaciones
                            };

                            // Generamos la actualización del objeto contrato

                            contratoController.UpdateEntity(contrato);
                            await this.ShowMessageAsync("Información", "Contrato Finalizado con fecha de Término el Día " +
                                                        string.Format("{0:dddd, dd 'de' MMMM 'de' yyyy}", c.Termino));
                        }
                        else
                        {
                            await this.ShowMessageAsync("Información", "El Contrato número " + numeroContrato +
                                                        " Ya se encuentra finalizado con fecha de término el día " +
                                                        string.Format("{0:dddd, dd 'de' MMMM 'de' yyyy}", c.Termino) +
                                                        "\nNo es necesario finalizarlo nuevamente debido a que ya se encuentra terminado.");
                        }
                    }
                    else
                    {
                        await this.ShowMessageAsync("Información", "No tenemos registros asociados al Numero de Contrato " + numeroContrato);
                    }
                    cargarEstructuraInicial();
                }
            }
            catch(ArgumentException ex)
            {
                await this.ShowMessageAsync("Información", "Error " + ex.Message);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Información", ex.Message + "\nNo tenemos registros asociados al Número de Contrato");
            }
        }
        #endregion

        #region VALIDACIONES
        private Boolean validarFecha(DateTime fechaInicio, DateTime fechaTermino)
        {
            int result = 0;
            Boolean output = true;
            result = DateTime.Compare(fechaInicio, fechaTermino);
            if (result < 0)
            {
                output = true;
            }
            else if (result == 0)
            {
                output = true;
            }
            else
            {
                output = false;
            }
            return output;
        }

        private Boolean validarCantidadAsistentes(int cantidad_asistentes)
        {
            Boolean output = true;
            if(cantidad_asistentes <= 0)
            {
                output = false;
            }
            return output;
        }



        #endregion

        #region Validaciones de Fecha
        private void dtpFechaHoraTerminoContrato_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Validamos que la fecha no pueda ser menr a la fecha de Creacion de Contrato
            DateTime termino = DateTime.Parse(dtpFechaHoraTerminoContrato.Value.ToString());
            local = termino;
            DateTime inicio = DateTime.Parse(dtpFechaHoraCreacionContrato.Value.ToString());
            if (termino < inicio)
            {
                DateTime aux = inicio.AddDays(+1);
                dtpFechaHoraTerminoContrato.Value = aux;
            }
            else
            {
                dtpFechaHoraTerminoContrato.Value = termino;
            }

        }

        private void dtpFechaHoraCreacionContrato_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Validamos que la fecha no pueda ser mayor a la fecha de Termino de Contrato
            DateTime inicio = DateTime.Parse(dtpFechaHoraCreacionContrato.Value.ToString());
            if (inicio > local)
            {
                DateTime aux = inicio.AddDays(-1);
                dtpFechaHoraCreacionContrato.Value = aux;
            }

        }

        private void dtpFechaHoraInicioEvento_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            DateTime inicio = DateTime.Parse(dtpFechaHoraCreacionContrato.Value.ToString());
            DateTime termino = DateTime.Parse(dtpFechaHoraTerminoContrato.Value.ToString());
            DateTime hora_inicio_event = DateTime.Parse(dtpFechaHoraInicioEvento.Value.ToString());
            if (hora_inicio_event < inicio)
            {

                dtpFechaHoraInicioEvento.Value = inicio;
            }
            else if (hora_inicio_event > termino)
            {
                dtpFechaHoraInicioEvento.Value = termino;
            }

        }

        private void dtpFechaHoraTerminoEvento_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            DateTime inicio = DateTime.Parse(dtpFechaHoraCreacionContrato.Value.ToString());
            DateTime termino = DateTime.Parse(dtpFechaHoraTerminoContrato.Value.ToString());
            DateTime hora_fin_event = DateTime.Parse(dtpFechaHoraTerminoEvento.Value.ToString());
            if (hora_fin_event < inicio)
            {
                dtpFechaHoraTerminoEvento.Value = inicio;
            }
            else if (hora_fin_event > termino)
            {
                dtpFechaHoraTerminoEvento.Value = termino;
            }
        }
        #endregion

        #region Estructuras Adicionales

        
        private void btnProcesos_Click(object sender, RoutedEventArgs e)
        {
            if(flProcesos.IsOpen == false)
            {
                flProcesos.IsOpen = true;
            }
            else if(flProcesos.IsOpen == true)
            {
                flProcesos.IsOpen = false;
            }
        }

        private void btnGenerarCalculoValorContrato_Click(object sender, RoutedEventArgs e)
        {
            getCalculo();
        }

        private async void getCalculo()
        {
            if(flCalculoValorContrato.IsOpen == true)
            {
                flCalculoValorContrato.IsOpen = false;
            }
            else if(flCalculoValorContrato.IsOpen == false)
            {
                String aux = txtCantidadAsistentes.Text;
                String var = txtCantidadPersonalAdicional.Text;
                if (String.IsNullOrEmpty(aux))
                {
                    await this.ShowMessageAsync("Información", "No es posible realizar el calculo, se debe ingresar un valor a Cantidad de Asistentes");
                    return;
                }
                else if (String.IsNullOrEmpty(var))
                {
                    await this.ShowMessageAsync("Información", "No es posible realizar el calculo, se debe ingresar un valor a Personal Adicional");
                    return;
                }
                else
                {
                    if (flCalculoValorContrato.IsOpen == false)
                    {
                        flCalculoValorContrato.IsOpen = true;
                        CargarDatosCalculo();
                    }
                    else if (flCalculoValorContrato.IsOpen == true)
                    {
                        flCalculoValorContrato.IsOpen = false;
                    }
                }
            }
        }

        private void CargarDatosCalculo()
        {
            String aux = txtCantidadAsistentes.Text;
            String var = txtCantidadPersonalAdicional.Text;
            lblRecargoAsistentes.Content = RecargoAsistentes(int.Parse(aux)) + " UF";
            lblRecargoAsistentesPeso.Content = "$ " + RecargoAsistentes(int.Parse(aux)) * uf;
            lblRecargoPersonalAdicional.Content = PersonalAdicional(int.Parse(var)) + " UF";
        
            int idTipoEvento = int.Parse(cboTipoEvento.SelectedValue.ToString());
            tipoEventoController.GetEntity(idTipoEvento);
            TipoEvento tipoEvento = tipoEventoController.GetEntity(idTipoEvento);
            if (tipoEvento != null)
            {
                lblTipDeEvento.Content = tipoEvento.Descripcion;

            }
            Double valorBase = 0;
            String idModalidad = cboModalidadServicio.SelectedValue.ToString();
            mdc.GetEntity(idModalidad);
            ModalidadServicio ms = mdc.GetEntity(idModalidad);
            if (ms != null)
            {
                lblModalidadServicio.Content = ms.Nombre;
                valorBase = ms.ValorBase;
            }
            lblValorTotalEvento.Content = RecargoAsistentes(int.Parse(aux)) + PersonalAdicional(int.Parse(var)) + valorBase + " UF";
        }

        // Calculo Valor Contrato: Sebastian Ramirez
        // Funcion que retorna el recargo por Concepto de Asistentes
        private int RecargoAsistentes(int cantidadAsistentes)
        {
            int recargoEnUFA = 0;
            int recargoMasde20 = 0;
            int AsistenteAdicional = 0;
            int recargoAdicional = 0;
            decimal varAdicionalesx20 = 0;
            decimal varAdicionalesMayor20 = 0;

            String idModalidad = cboModalidadServicio.SelectedValue.ToString();
            ModalidadServicioController c = new ModalidadServicioController();
            ModalidadServicio ms = c.GetEntity(idModalidad);
            if (ms != null)
            {

                if (cantidadAsistentes >= 1 && cantidadAsistentes <= 20)
                {
                    recargoEnUFA = 3;

                }
                else if (cantidadAsistentes >= 21 && cantidadAsistentes <= 50)
                {
                    recargoEnUFA = 5;
                }
                else if (cantidadAsistentes > 50)
                {
                    AsistenteAdicional = cantidadAsistentes - 50;
                    varAdicionalesx20 = AsistenteAdicional / 20;
                    varAdicionalesMayor20 = (decimal)(AsistenteAdicional % 20) * 20;
                    varAdicionalesx20 = Math.Truncate(varAdicionalesx20);

                    if (varAdicionalesx20 != 0)
                    {
                        recargoAdicional = ((int)(varAdicionalesx20)) * 2;
                    }

                    if (varAdicionalesMayor20 >= 1 && varAdicionalesMayor20 <= 20)
                    {
                        recargoMasde20 = 3;

                    }
                    else if (varAdicionalesMayor20 >= 21 && varAdicionalesMayor20 <= 50)
                    {
                        recargoMasde20 = 5;
                    }

                    recargoEnUFA = 5 + recargoAdicional + recargoMasde20;

                }
            }
            return recargoEnUFA;
        }
        // Funcion que retorna el recargo por Concepto de Personal Adicional
        public double PersonalAdicional(int personalAdicional)
        {
            double recargoEnUFP = 0;
            int personalAdicionalExtra = 0;
            double recargoAdicional = 0;

            String idModalidad = cboModalidadServicio.SelectedValue.ToString();
            ModalidadServicioController c = new ModalidadServicioController();
            ModalidadServicio ms = c.GetEntity(idModalidad);
            if (ms != null)
            {
                if (personalAdicional == 2)
                {
                    recargoEnUFP = 2;

                }
                else if (personalAdicional == 3)
                {
                    recargoEnUFP = 3;
                }
                else if (personalAdicional == 4)
                {
                    recargoEnUFP = 3.5;
                }
                else if (personalAdicional > 4)
                {
                    personalAdicionalExtra = personalAdicional - 4;
                    recargoAdicional = personalAdicionalExtra * 0.5;
                    recargoEnUFP = 3.5 + recargoAdicional;
                }

            }
            return recargoEnUFP;
        }

        private void dtpFechaHoraCreacionContrato_MouseMove(object sender, MouseEventArgs e)
        {
            lblValidarFechaCreacionContrato.Visibility = Visibility.Visible;
        }

        private void dtpFechaHoraCreacionContrato_MouseLeave(object sender, MouseEventArgs e)
        {
            lblValidarFechaCreacionContrato.Visibility = Visibility.Hidden;
        }

        private void dtpFechaHoraTerminoContrato_MouseMove(object sender, MouseEventArgs e)
        {
            lblValidarFechaTerminoContrato.Visibility = Visibility.Visible;
        }

        private void dtpFechaHoraTerminoContrato_MouseLeave(object sender, MouseEventArgs e)
        {
            lblValidarFechaTerminoContrato.Visibility = Visibility.Hidden;
        }

        private void dtpFechaHoraInicioEvento_MouseMove(object sender, MouseEventArgs e)
        {
            lblValidarHoraInicioDeEvento.Visibility = Visibility.Visible;
        }

        private void dtpFechaHoraInicioEvento_MouseLeave(object sender, MouseEventArgs e)
        {
            lblValidarHoraInicioDeEvento.Visibility = Visibility.Hidden;
        }

        private void dtpFechaHoraTerminoEvento_MouseMove(object sender, MouseEventArgs e)
        {
            lblValidarHoraTerminoDeEvento.Visibility = Visibility.Visible;
        }

        private void dtpFechaHoraTerminoEvento_MouseLeave(object sender, MouseEventArgs e)
        {
            lblValidarHoraTerminoDeEvento.Visibility = Visibility.Hidden;
        }

        private void lblInstruccionesModuloCondiciones_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mtbMenu.SelectedIndex = 1;
        }

        private void lblInstruccionesModuloFechas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mtbMenu.SelectedIndex = 2;
        }

        private void lblInstruccionesModuloDetalleCargos_MouseUp(object sender, MouseButtonEventArgs e)
        {
            flCalculoValorContrato.IsOpen = false;
            mtbMenu.SelectedIndex = 1;
        }

        private void lblInstruccionesModulDatosCl_MouseUp(object sender, MouseButtonEventArgs e)
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

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            lblInforEstadoContrato001.Visibility = Visibility.Visible;
            lblInforEstadoContrato002.Visibility = Visibility.Visible;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            lblInforEstadoContrato001.Visibility = Visibility.Hidden;
            lblInforEstadoContrato002.Visibility = Visibility.Hidden;
        }

        private void lblFechaHoraCreacionContrato_MouseMove(object sender, MouseEventArgs e)
        {
            lblValidarFechaCreacionContrato.Visibility = Visibility.Visible;
        }

        private void lblFechaHoraCreacionContrato_MouseLeave(object sender, MouseEventArgs e)
        {
            lblValidarFechaCreacionContrato.Visibility = Visibility.Hidden;
        }

        private void lblFechaHoraTerminoContrato_MouseMove(object sender, MouseEventArgs e)
        {
            lblValidarFechaTerminoContrato.Visibility = Visibility.Visible;
        }

        private void lblFechaHoraTerminoContrato_MouseLeave(object sender, MouseEventArgs e)
        {
            lblValidarFechaTerminoContrato.Visibility = Visibility.Hidden;
        }

        private void lblFechaHoraInicioEvento_MouseMove(object sender, MouseEventArgs e)
        {
            lblValidarHoraInicioDeEvento.Visibility = Visibility.Visible;
        }

        private void lblFechaHoraInicioEvento_MouseLeave(object sender, MouseEventArgs e)
        {
            lblValidarHoraInicioDeEvento.Visibility = Visibility.Hidden;
        }

        private void lblFechaHoraTerminoEvento_MouseMove(object sender, MouseEventArgs e)
        {
            lblValidarHoraTerminoDeEvento.Visibility = Visibility.Visible;
        }

        private void lblFechaHoraTerminoEvento_MouseLeave(object sender, MouseEventArgs e)
        {
            lblValidarHoraTerminoDeEvento.Visibility = Visibility.Hidden;
        }

        private void btnGestionProcesosCondiciones_Click(object sender, RoutedEventArgs e)
        {

            if(flCalculoValorContrato.IsOpen == true)
            {
                flCalculoValorContrato.IsOpen = false;
            }

            if (flProcesos.IsOpen == false)
            {
                flProcesos.IsOpen = true;
            }
            else if (flProcesos.IsOpen == true)
            {
                flProcesos.IsOpen = false;
            }
        }

        private void btnGestionProcesosFechas_Click(object sender, RoutedEventArgs e)
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

        private void btnObtenerValor_Click(object sender, RoutedEventArgs e)
        {
            getCalculo();
        }

        #endregion
    }
}
