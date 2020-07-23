using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class ClienteController : AbstractController<Cliente>
    {
        public override int AddEntity(Cliente entity)
        {
            Cliente cliente = GetEntity(entity.RutCliente);
            if (cliente == null)
            {
                em.Cliente.Add(entity);
                return em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("No se puede registrar al Cliente, el rut ya se encuentra registrado.");
            }
        }

        public override List<Cliente> GetEntities()
        {
            return em.Cliente.ToList<Cliente>();
        }

        public override Cliente GetEntity(object key)
        {
            if((String)key != null)
            {
                return em.Cliente.Where(p => p.RutCliente == (String)key).FirstOrDefault<Cliente>();
            }
            else
            {
                throw new ArgumentException("Debes Ingresar un Rut válido para Buscar al Cliente.");
            }
        }

        public override int UpdateEntity(Cliente entity)
        {
            Cliente c = GetEntity(entity.RutCliente);
            if (c != null)
            {
                c.RutCliente = entity.RutCliente;
                c.RazonSocial = entity.RazonSocial;
                c.NombreContacto = entity.NombreContacto;
                c.MailContacto = entity.MailContacto;
                c.Direccion = entity.Direccion;
                c.Telefono = entity.Telefono;
                c.IdActividadEmpresa = entity.IdActividadEmpresa;
                c.IdTipoEmpresa = entity.IdTipoEmpresa;
                return em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("No se logró realizar los cambios");
            }
        }

        public override int DeleteEntity(object key)
        {
            Cliente cliente = GetEntity(key);
            if (cliente != null)
            {
                em.Cliente.Remove(cliente);
                return em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("No se puede eliminar al Cliente");
            }
        }

        public List<Cliente> WhereRutCliente(String rutCliente)
        {
            List<Cliente> clientes = (
                                        from c in em.Cliente
                                        where c.RutCliente.Contains(rutCliente)
                                        select c
                                        ).ToList();
            return clientes;
        }

        public List<Cliente> WhereDescripcionEmpresa(String descripcion)
        {
            List<Cliente> clientes_tiposEmp = (
                                               from cliente in em.Cliente
                                               join tipoEmpresa in em.TipoEmpresa 
                                               on cliente.IdTipoEmpresa equals tipoEmpresa.IdTipoEmpresa
                                               where tipoEmpresa.Descripcion.Contains(descripcion) 
                                               select cliente
                                               ).ToList();
            return clientes_tiposEmp;
        }

        public List<Cliente> WhereActividadEmpresa(String descripcion)
        {
            List<Cliente> clientes_actividadEmp = (
                                                    from cliente in em.Cliente
                                                    join  actividadEmpresa in em.ActividadEmpresa
                                                    on cliente.IdActividadEmpresa equals actividadEmpresa.IdActividadEmpresa
                                                    where actividadEmpresa.Descripcion.Contains(descripcion)
                                                    select cliente
                                                  ).ToList();
            return clientes_actividadEmp;
        }

        public List<Cliente> BuscarRut(String rutCliente)
        {
            List<Cliente> clientes = (
                                        from c in em.Cliente
                                        where c.RutCliente.Contains(rutCliente)
                                        select c
                                     ).ToList();
            return clientes;
        }

        public List<Cliente> BuscarNombre(String nombreCliente)
        {
            List<Cliente> clientes = (
                                        from c in em.Cliente
                                        where c.NombreContacto.Contains(nombreCliente)
                                        select c
                                     ).ToList();
            return clientes;
        }

        public List<Cliente> WhereIdTipoEmpresa(int idTipoEmpresa)
        {
            List<Cliente> clientes_tiposEmp = (
                                               from cliente in em.Cliente
                                               join tipoEmpresa in em.TipoEmpresa
                                               on cliente.IdTipoEmpresa equals tipoEmpresa.IdTipoEmpresa
                                               where tipoEmpresa.IdTipoEmpresa == idTipoEmpresa
                                               select cliente
                                               ).ToList();
            return clientes_tiposEmp;
        }

        public List<Cliente> WhereIdActividadEmpresa(int idActividadEmpresa)
        {
            List<Cliente> clientes_actividadEmp = (
                                                    from cliente in em.Cliente
                                                    join actividadEmpresa in em.ActividadEmpresa
                                                    on cliente.IdActividadEmpresa equals actividadEmpresa.IdActividadEmpresa
                                                    where actividadEmpresa.IdActividadEmpresa == idActividadEmpresa
                                                    select cliente
                                                  ).ToList();
            return clientes_actividadEmp;
        }
    }
}
