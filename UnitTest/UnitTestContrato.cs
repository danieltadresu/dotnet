using System;
using Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Views;

namespace UnitTest
{

    [TestClass]
    public class UnitTestContrato
    {
        #region Pruebas Satisfactorias y No Satisfactorias para el Método Registrar Contrato
        [TestMethod]
        public void TestMethod1()
        {
            // Prueba Satisfactoria -> Probaremos que se puede registrar un Contrato
            ContratoController cc = new ContratoController();
            Contrato c = new Contrato()
            {
                Numero = DateTime.Now.ToString("yyyyMMddhhmm"),
                Creacion = DateTime.Now,
                Termino = DateTime.Now.AddDays(+1),
                RutCliente = "20158799-9",
                IdModalidad = "CB001",
                IdTipoEvento = 10,
                FechaHoraInicio = DateTime.Now.AddMinutes(+60),
                FechaHoraTermino = DateTime.Now.AddDays(+1),
                Asistentes = 20,
                PersonalAdicional = 10,
                Realizado = false,
                ValorTotalContrato = 1,
                Observaciones = "N/A"
            };
            var esperado = 1;
            var resultado = cc.AddEntity(c);
            Assert.AreEqual(resultado, esperado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod2()
        {
            // Prueba No Satisfactoria -> Manejo de excepciones, probaremos que al tratar de registrar a un Contrato que ya se encuentra
            // registrado en la Base de Datos, el sistema nos retorne la excepción esperada
            ContratoController cc = new ContratoController();
            Contrato c = new Contrato()
            {
                Numero = DateTime.Now.ToString("yyyyMMddhhmm"),
                Creacion = DateTime.Now,
                Termino = DateTime.Now.AddDays(+1),
                RutCliente = "20158799-9",
                IdModalidad = "CB001",
                IdTipoEvento = 10,
                FechaHoraInicio = DateTime.Now.AddMinutes(+60),
                FechaHoraTermino = DateTime.Now.AddDays(+1),
                Asistentes = 20,
                PersonalAdicional = 10,
                Realizado = false,
                ValorTotalContrato = 1,
                Observaciones = "N/A"
            };
            var esperado = 1;
            var resultado = cc.AddEntity(c);
            Assert.AreNotEqual(resultado, esperado);
        }
        #endregion

        #region Pruebas Satisfactorias y No Satisactorias para el Método Buscar Contrato
        [TestMethod]
        public void TestMethod3()
        {
            // Prueba Satisfactoria -> Probaremos que se puede buscar a un Contrato
            String numeroContrato = DateTime.Now.ToString("yyyyMMddhhmm");
            ContratoController cc = new ContratoController();
            Contrato c = cc.GetEntity(numeroContrato);
            String rutDueñoContrato = "20158799-9";
            Assert.AreEqual(c.RutCliente, rutDueñoContrato);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod4()
        {
            // Prueba No Satisfactoria -> Manejo de excepciones, probaremos que al tratar de buscar a un Contrato cuyo número de contrato es erroneo
            // o no se registrado en la Base de Datos, el sistema nos retorne la excepción esperada
            String numeroContrato = null;
            ContratoController cc = new ContratoController();
            Contrato c = cc.GetEntity(numeroContrato);
            String nroRutDueñoEsperado = "2015-9";
            Assert.AreNotEqual(c.RutCliente, nroRutDueñoEsperado);
        }
        #endregion

        #region Pruebas Satisfactorias y No Satisfactorias para el Método Actualizar Contrato
        [TestMethod]
        public void TestMethod5()
        {
            ContratoController cc = new ContratoController();
            Contrato c = new Contrato()
            {
                Numero = DateTime.Now.ToString("yyyyMMddhhmm"),
                Creacion = DateTime.Now,
                Termino = DateTime.Now.AddDays(+1),
                RutCliente = "20158799-9",
                IdModalidad = "CB001",
                IdTipoEvento = 10,
                FechaHoraInicio = DateTime.Now.AddMinutes(+60),
                FechaHoraTermino = DateTime.Now.AddDays(+1),
                Asistentes = 30,                                            // Se modifica la propiedad cantidad de Asistentes                               
                PersonalAdicional = 15,                                     // Se modifica la propiedad personal adicional
                Realizado = false,
                ValorTotalContrato = 1,
                Observaciones = "Contrato modificado"                       // Se modifica la propiedad Observaciones
            };
            var esperado = 1;
            var resultado = cc.UpdateEntity(c);
            Assert.AreEqual(resultado, esperado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod6()
        {
            // Prueba No Satisfactoria -> Manejo de excepciones, probaremos que al tratar de modificar a un Contrato, pasando un Numero de Contrato erroneo,
            // No registrado en la Base de Datos, el sistema nos retorne la excepción esperada.
            ContratoController cc = new ContratoController();
            Contrato c = new Contrato()
            {
                Numero = null,
                Creacion = DateTime.Now,
                Termino = DateTime.Now.AddDays(+1),
                RutCliente = "20158799-9",
                IdModalidad = "CB001",
                IdTipoEvento = 10,
                FechaHoraInicio = DateTime.Now.AddMinutes(+60),
                FechaHoraTermino = DateTime.Now.AddDays(+1),
                Asistentes = 20,
                PersonalAdicional = 10,
                Realizado = true,
                ValorTotalContrato = 1,
                Observaciones = "N/A"
            };
            var esperado = 1;
            var resultado = cc.UpdateEntity(c);
            Assert.AreNotEqual(resultado, esperado);
        }
        #endregion

        #region Pruebas Satisfactorias y No Satisfactorias para el Método Finalizar Contrato
        [TestMethod]
        public void TestMethod7()
        {
            // Prueba Satisfactoria -> Probaremos que se puede finalizar un Contrato.
            // El Contrato no se puede eliminar, se puede finalizar. Se modifica la prpiedad Realizado a true. Es decir, el contrato se encuentra Realizado.
            ContratoController cc = new ContratoController();
            Contrato c = new Contrato()
            {
                Numero = DateTime.Now.ToString("yyyyMMddhhmm"),
                Creacion = DateTime.Now,
                Termino = DateTime.Now.AddDays(+1),
                RutCliente = "20158799-9",
                IdModalidad = "CB001",
                IdTipoEvento = 10,
                FechaHoraInicio = DateTime.Now.AddMinutes(+60),
                FechaHoraTermino = DateTime.Now.AddDays(+1),
                Asistentes = 30,
                PersonalAdicional = 15,
                Realizado = true,           // Se modifica la propiedad Realizado del Objeto Contrato. Es decir, el contrato se encuentra Realizado.
                ValorTotalContrato = 1,
                Observaciones = "Contrato finalizado"
            };
            var esperado = 1;
            var resultado = cc.UpdateEntity(c);
            Assert.AreEqual(resultado, esperado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod8()
        {
            ContratoController cc = new ContratoController();
            Contrato c = new Contrato()
            {
                Numero = null,
                Creacion = DateTime.Now,
                Termino = DateTime.Now.AddDays(+1),
                RutCliente = "20158799-9",
                IdModalidad = "CB001",
                IdTipoEvento = 10,
                FechaHoraInicio = DateTime.Now.AddMinutes(+60),
                FechaHoraTermino = DateTime.Now.AddDays(+1),
                Asistentes = 20,
                PersonalAdicional = 10,
                Realizado = false,
                ValorTotalContrato = 1,
                Observaciones = "Contrato finalizado"
            };
            var esperado = 1;
            var resultado = cc.UpdateEntity(c);
            Assert.AreNotEqual(resultado, esperado);
        }
        #endregion

        #region Pruebas Satisfactorias y No Satisfactorias para el Método Filtrar por Número de Contrato
        [TestMethod]
        public void TestMethod9()
        {
            // Prueba Satisfactoria -> Probaremos que se puede filtrar por un Numero de Contrasto registrado en la Base de Datos.
            ContratoController cc = new ContratoController();
            String numeroContrato = DateTime.Now.ToString("yyyyMMddhhmm");
            var esperado = 1;
            var resultado = cc.WhereNumeroContrato(numeroContrato).Count;
            Assert.AreEqual(resultado, esperado);
        }

        [TestMethod]
        public void TestMethod10()
        {
            // Prueba No Satisfactoria -> Probaremos que al tratar de buscar un Numero de Contrato el metodo
            // nos devuelva 1 que corresponde al Contrato que encuentra con el String que se le pasa por Parámetro, al ser distintos,
            // la prueba es exitosa.

            ContratoController cc = new ContratoController();
            String numeroContrato = null;
            var esperado = 1;
            var resultado = cc.WhereNumeroContrato(numeroContrato).Count;
            Assert.AreNotEqual(resultado, esperado);
        }
        #endregion

        #region Pruebas Satisactorias y No Satisfactorias para el método Filtrar por Rut de Cliente
        [TestMethod]
        public void TestMethod11()
        {
            // Prueba Satisfactoria -> Probaremos que se puede filtrar un Contrato de acuerdo al Rut del Cliente asociado.
            ClienteController clienteController = new ClienteController();
            ContratoController contratoController = new ContratoController();
            String rut_cliente = "20158799-9";
            Cliente cliente = clienteController.GetEntity(rut_cliente);
            var esperado = cliente.Contrato.Count;
            var resultado = contratoController.WhereRutCliente(cliente.RutCliente).Count;
            Assert.AreEqual(resultado, esperado);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod12()
        {
            // Prueba No Satisfactoria -> Probaremos que al tratar de filtrar un Contrato por un Rut que no inválido, no registrado en la
            // Base de Datos, el sistema nos retorne la excepción.
            ClienteController clienteController = new ClienteController();
            ContratoController contratoController = new ContratoController();
            String rut_cliente = null;
            Cliente cliente = clienteController.GetEntity(rut_cliente);
            var esperado = cliente.Contrato.Count;
            var resultado = contratoController.WhereRutCliente(cliente.RutCliente).Count;
            Assert.AreNotEqual(resultado, esperado);
        }

        #endregion

        #region Pruebas Satisfactorias y No Satisfactorias para el método Filtrar por Modalidad Servicio del Contrato
        [TestMethod]
        public void TestMethod13()
        {
            // Prueba Satisfactoria -> Probaremos que se puede filtrar un Contrato de acuerdo a la Modalidad de Servicio.
            ContratoController contratoController = new ContratoController();
            ModalidadServicioController msc = new ModalidadServicioController();
            String idModalidad = "CB001";
            ModalidadServicio modalidadServicio = msc.GetEntity(idModalidad);
            var esperado = modalidadServicio.Contrato.Count;
            var resultado = contratoController.WhereModalidadServicio(modalidadServicio.Nombre).Count;
            Assert.AreEqual(resultado, esperado);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void TestMethod14()
        {

            // Prueba No Satisfactoria -> Manejo de excepciones, probaremos que al tratar de generar un objeto ModalidadServicio con
            // Id inválido, no registrado en la Base de Datos, a fin de filtrar por Modalidad de Servicio,
            // el sistema nos retorne la excepcion esperada, ya que no existe la Modalidad.
            ContratoController contratoController = new ContratoController();
            ModalidadServicioController msc = new ModalidadServicioController();
            String idModalidad = "Undefined";                                           // Id Invalido, no registrado en BD. Se captura la excepción    
            ModalidadServicio modalidadServicio = msc.GetEntity(idModalidad);
            var esperado = modalidadServicio.Contrato.Count;
            var resultado = contratoController.WhereModalidadServicio(modalidadServicio.Nombre).Count;
            Assert.AreNotEqual(resultado, esperado);
        }

       
        #endregion

        #region Pruebas Satisfactorias y No Satisfactorias para el método Filtrar por Tipo de Evento
        [TestMethod]
        public void TestMethod15()
        {
            ContratoController contratoController = new ContratoController();
            TipoEventoController tec = new TipoEventoController();
            String numeroContrato = DateTime.Now.ToString("yyyyMMddhhmm");
            int idTipoEvento = 10;
            Contrato contrato = contratoController.GetEntity(numeroContrato);
            TipoEvento tipoEvento = tec.GetEntity(idTipoEvento);
            var esperado = contrato.IdTipoEvento;
            var resultado = tipoEvento.IdTipoEvento;
            Assert.AreEqual(resultado, esperado);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void TestMethod16()
        {
            ContratoController contratoController = new ContratoController();
            TipoEventoController tec = new TipoEventoController();
            String numeroContrato = DateTime.Now.ToString("yyyyMMddhhmm");
            int idTipoEvento = 0;
            Contrato contrato = contratoController.GetEntity(numeroContrato);
            TipoEvento tipoEvento = tec.GetEntity(idTipoEvento);
            var esperado = contrato.IdTipoEvento;
            var resultado = tipoEvento.IdTipoEvento;
            Assert.AreNotEqual(resultado, esperado);
        }
        #endregion



    }
}


