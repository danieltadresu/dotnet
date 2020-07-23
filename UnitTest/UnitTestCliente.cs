using System;
using System.Collections.Generic;
using Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace UnitTest
{
    [TestClass]
    public class UnitTestCliente
    {
        #region Pruebas Satisfactorias y No Satisfactorias para el Método Registrar Cliente
        [TestMethod]
        public void TestMethod1()
        {
            // Prueba Satisfactoria -> Probaremos que se puede registrar un Cliente
            ClienteController cc = new ClienteController();
            Cliente c = new Cliente
            {
                RutCliente = "20158799-9",
                RazonSocial = "TestSoft TI",
                NombreContacto = "Daniel Pizarro",
                MailContacto = "dpizarro@testsoft.cl",
                Direccion = "Los Álamos 1279",
                Telefono = "930290330",
                IdActividadEmpresa = 5,
                IdTipoEmpresa = 40
            };
            var esperado = 1;
            var resultado = cc.AddEntity(c);
            Assert.AreEqual(resultado, esperado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod2()
        {
            // Prueba No Satisfactoria -> Manejo de excepciones, probaremos que al tratar de registrar a un Cliente que ya se encuentra
            // registrado en la Base de Datos, el sistema nos retorne la excepción esperada
            ClienteController cc = new ClienteController();
            Cliente c = new Cliente
            {
                RutCliente = "20158799-9",
                RazonSocial = "TestSoft TI",
                NombreContacto = "Daniel Pizarro",
                MailContacto = "dpizarro@testsoft.cl",
                Direccion = "Los Álamos 1279",
                Telefono = "930290330",
                IdActividadEmpresa = 5,
                IdTipoEmpresa = 40
            };
            var esperado = 1;
            var resultado = cc.AddEntity(c);
            Assert.AreNotEqual(resultado, esperado);
        }
        #endregion

        #region Pruebas Satisfactorias y No Satisfactorias para el Método Buscar Cliente

        [TestMethod]
        public void TestMethod3()
        {
            // Prueba Satisfactoria -> Probaremos que se puede buscar a un Cliente
            String rut_cliente = "20158799-9";
            ClienteController cc = new ClienteController();
            Cliente c = cc.GetEntity(rut_cliente);
            String nombreContactoEsperado = "Daniel Pizarro";
            Assert.AreEqual(c.NombreContacto, nombreContactoEsperado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod4()
        {
            // Prueba No Satisfactoria -> Manejo de excepciones, probaremos que al tratar de buscar a un Cliente, cuyo rut es vacío
            // el sistema nos retorne la excepción esperada
            String rut_cliente = null;
            ClienteController cc = new ClienteController();
            Cliente c = cc.GetEntity(rut_cliente);
            String nombreContactoEsperado = "Daniel Pizarro";
            Assert.AreNotEqual(c.NombreContacto, nombreContactoEsperado);
        }

        #endregion

        #region Pruebas Satisfactorias y No Satisfactorias para el Método Actualizar Cliente
        [TestMethod]
        public void TestMethod5()
        {
            // Prueba Satisfactoria -> Probaremos modificar las propiedades del Cliente Rut 20158799-9 Insertado en el Primer TestMethod.
            ClienteController cc = new ClienteController();
            Cliente c = new Cliente
            {
                RutCliente = "20158799-9",
                RazonSocial = "Nueva Razon",
                NombreContacto = "Nicolas",
                MailContacto = "npizarro@nuevr.cl",
                Direccion = "Las Parcelas",
                Telefono = "930290330",
                IdActividadEmpresa = 5,
                IdTipoEmpresa = 40
            };
            var esperado = 1;
            var resultado = cc.UpdateEntity(c);
            Assert.AreEqual(resultado, esperado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod6()
        {
            // Prueba No Satisfactoria -> Manejo de excepciones, probaremos que al tratar de modificar a un Cliente, pasando un Rut erroneo,
            // No registrado en la Base de Datos, el sistema nos retorne la excepción esperada.
            ClienteController cc = new ClienteController();
            Cliente c = new Cliente
            {
                RutCliente = "RUT NO EXISTE",
                RazonSocial = "Nueva Razon",
                NombreContacto = "Nicolas",
                MailContacto = "npizarro@nuevr.cl",
                Direccion = "Las Parcelas",
                Telefono = "930290330",
                IdActividadEmpresa = 5,
                IdTipoEmpresa = 40
            };
            var esperado = 1;
            var resultado = cc.UpdateEntity(c);
            Assert.AreNotEqual(resultado, esperado);
        }
        #endregion

        #region Pruebas Satisfactorias y No Satisactorias para el Método Eliminar Cliente
        [TestMethod]
        public void TestMethod7()
        {
            // Prueba Satisfactoria -> Probaremos eliminar al Cliente Rut 20158799-9 Insertado en el Primer TestMethod.
            ClienteController cc = new ClienteController();
            String rut_cliente = "20158799-9";
            var esperado = 1;
            var resultado = cc.DeleteEntity(rut_cliente);
            Assert.AreEqual(resultado, esperado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod8()
        {
            // Prueba No Satisfactoria -> Manejo de excepciones, probaremos que al tratar de eliminar a un Cliente, pasando un Rut erroneo,
            // No registrado en la Base de Datos, el sistema nos retorne la excepción esperada.
            ClienteController cc = new ClienteController();
            String rut_cliente = null;
            var esperado = 1;
            var resultado = cc.DeleteEntity(rut_cliente);
            Assert.AreNotEqual(resultado, esperado);
        }
        #endregion

        #region Pruebas Satisfactorias y No Satisfactorias para el Método Filtrar por Rut
        [TestMethod]
        public void TestMethod9()
        {
            // Prueba Satisfactoria -> Probaremos que se puede registrar un Cliente a fin de corroborar que la prueba TestMethod10
            // permite filtrar por Rut Cliente.
            ClienteController cc = new ClienteController();
            Cliente c = new Cliente
            {
                RutCliente = "20158799-9",
                RazonSocial = "TestSoft TI",
                NombreContacto = "Daniel Pizarro",
                MailContacto = "dpizarro@testsoft.cl",
                Direccion = "Los Álamos 1279",
                Telefono = "930290330",
                IdActividadEmpresa = 5,
                IdTipoEmpresa = 40
            };
            var esperado = 1;
            var resultado = cc.AddEntity(c);
            Assert.AreEqual(resultado, esperado);
        }

        [TestMethod]
        public void TestMethod10()
        {
            // Prueba Satisfactoria -> Probaremos que se puede filtrar por un Rut registrado en la Base de Datos.
            // permite filtrar por Rut Cliente.
            ClienteController cc = new ClienteController();
            String rut_cliente = "20158799-9";
            var esperado = 1;
            var resultado = cc.WhereRutCliente(rut_cliente).Count;
            Assert.AreEqual(resultado, esperado);
        }

        
        [TestMethod]
        public void TestMethod11()
        {
            // Prueba No Satisfactoria -> Probaremos que al tratar de buscar un Rut de Empleado el metodo
            // nos devuelva 1 que corresponde al Cliente que encuentra con el rut que se le pasa por Parámetro, al ser distintos,
            // la prueba es exitosa.
            ClienteController cc = new ClienteController();
            String rut_cliente = null;
            var esperado = 1;
            var resultado = cc.WhereRutCliente(rut_cliente).Count;
            Assert.AreNotEqual(resultado, esperado);
        }
        #endregion

        #region Pruebas Satisfactorias y No Satisfactorias para el Método Filtrar por Tipo de Empresa
        [TestMethod]
        public void TestMethod12()
        {
            // Prueba Satisfactoria -> Probaremos que se puede filtrar por Tipo de Empresa.
            // Instanciamos al controlador TipoEmpresaController, generamos un objeto TipoEmpresa y 
            // el objeto TipoEmpresa recibe al tipo de Empresa ID 40, Sociedad Anonima.
            // Se declara una variable esperado que recibe al objeto tipoEmpresa
            // 
            ClienteController cc = new ClienteController();
            TipoEmpresaController tpc = new TipoEmpresaController();
            int idTipoEmpresa = 40;
            TipoEmpresa tipoEmpresa = tpc.GetEntity(idTipoEmpresa);
            var esperado = tipoEmpresa.Cliente.Count;
            var resultado = cc.WhereIdTipoEmpresa(idTipoEmpresa).Count;
            Assert.AreEqual(resultado, esperado);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void TestMethod13()
        {
            // Prueba No Satisfactoria -> Manejo de excepciones, probaremos que al tratar de generar un objeto Tipo Empresa con
            // Id inválido, no registrado en la Base de Datos, a fin de filtrar por Tipo de Empresa Ingresada,
            // el sistema nos retorne la excepcion esperada.
            ClienteController cc = new ClienteController();
            TipoEmpresaController tpc = new TipoEmpresaController();
            int idTipoEmpresa = 0;                                   // Id Invalido, no registrado en BD. Se captura la excepción
            TipoEmpresa tipoEmpresa = tpc.GetEntity(idTipoEmpresa);
            var esperado = tipoEmpresa.Cliente.Count;
            var resultado = cc.WhereIdTipoEmpresa(idTipoEmpresa).Count;
            Assert.AreNotEqual(resultado, esperado);
        }
        #endregion

        #region Pruebas Satisfactorias y No Satisfactorias para el Método Buscar por Actividad
        [TestMethod]
        public void TestMethod14()
        {
            // Prueba Satisfactoria -> Probaremos que se puede filtrar por Tipo de Empresa.
            // Instanciamos al controlador TipoEmpresaController, generamos un objeto TipoEmpresa y 
            // el objeto TipoEmpresa recibe al tipo de Empresa ID 40, Sociedad Anonima.
            // Se declara una variable esperado que recibe al objeto tipoEmpresa
            
            ClienteController cc = new ClienteController();
            ActividadEmpresaController aec = new ActividadEmpresaController();
            int idActividadEmpresa = 1;
            ActividadEmpresa actividadEmpresa = aec.GetEntity(idActividadEmpresa);
            var esperado = actividadEmpresa.Cliente.Count;
            var resultado = cc.WhereIdActividadEmpresa(idActividadEmpresa).Count;
            Assert.AreEqual(resultado, esperado);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void TestMethod15()
        {
            // Prueba No Satisfactoria -> Manejo de excepciones, probaremos que al tratar de generar un objeto ActividadEmpresa con
            // Id inválido, no registrado en la Base de Datos, a fin de filtrar por Tipo de Empresa Ingresada,
            // el sistema nos retorne la excepcion esperada.
            ClienteController cc = new ClienteController();
            ActividadEmpresaController aec = new ActividadEmpresaController();
            int idActividadEmpresa = 0;                                   // Id Invalido, no registrado en BD. Se captura la excepción
            ActividadEmpresa actividadEmpresa = aec.GetEntity(idActividadEmpresa);
            var esperado = actividadEmpresa.Cliente.Count;
            var resultado = cc.WhereIdTipoEmpresa(idActividadEmpresa).Count;
            Assert.AreNotEqual(resultado, esperado);
        }
        #endregion

        #region Pruebas No Satisfactorias: Se prueba que no se pueda ingresar campos vacíos.
        // Prueba No Satisfactoria, Intentamos registrar a un Cliente con Razon Social null.
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod16()
        {
            ClienteController cc = new ClienteController();
            Cliente c = new Cliente()
            {
                RutCliente = "7-9",
                RazonSocial = null,
                NombreContacto = "Nombre",
                MailContacto = "mail@gmail.com",
                Direccion = "la direccion 1279",
                Telefono = "22255805",
                IdActividadEmpresa = 5,
                IdTipoEmpresa = 40
            };
            var esperado = 1;
            var resultado = cc.AddEntity(c);
            Assert.AreNotEqual(resultado, esperado);
        }

        // Prueba No Satisfactoria, Intentamos registrar a un cliente con Razon Social Nombre de Contacto null.
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod17()
        {
            ClienteController cc = new ClienteController();
            Cliente c = new Cliente()
            {
                RutCliente = "7-9",
                RazonSocial = "Juanito",
                NombreContacto = null,
                MailContacto = "mail@gmail.com",
                Direccion = "la direccion 1279",
                Telefono = "22255805",
                IdActividadEmpresa = 5,
                IdTipoEmpresa = 40
            };
            var esperado = 1;
            var resultado = cc.AddEntity(c);
            Assert.AreNotEqual(resultado, esperado);
        }

        // Prueba No Satisfactoria, Intentamos registrar a un cliente con Correo electrónico nulo.

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod18()
        {
            ClienteController cc = new ClienteController();
            Cliente c = new Cliente()
            {
                RutCliente = "7-9",
                RazonSocial = "Juanito",
                NombreContacto = "Anguilar",
                MailContacto = null,
                Direccion = "la direccion 1279",
                Telefono = "22255805",
                IdActividadEmpresa = 5,
                IdTipoEmpresa = 40
            };
            var esperado = 1;
            var resultado = cc.AddEntity(c);
            Assert.AreNotEqual(resultado, esperado);
        }

        // Prueba No Satisfactoria, Intentamos registrar a un cliente con Dirección nulo.
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod19()
        {
            ClienteController cc = new ClienteController();
            Cliente c = new Cliente()
            {
                RutCliente = "7-9",
                RazonSocial = "Juanito",
                NombreContacto = "Anguilar",
                MailContacto = "jaguilar@gmail.com",
                Direccion = null,
                Telefono = "22255805",
                IdActividadEmpresa = 5,
                IdTipoEmpresa = 40
            };
            var esperado = 1;
            var resultado = cc.AddEntity(c);
            Assert.AreNotEqual(resultado, esperado);
        }
        #endregion

    }

}
