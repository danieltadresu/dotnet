using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ContratoController : AbstractController<Contrato>
    {
        public override int AddEntity(Contrato entity)
        {
            Contrato contrato = GetEntity(entity.Numero);
            if (contrato == null)
            {
                em.Contrato.Add(entity);
                return em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("No se puede registrar el Contrato\nYa tenemos un registro asociado al número de Contrato " + entity.Numero + "\nLe sugerimos modificar la fecha de Creación del Contrato.");
            }
        }

        public override int DeleteEntity(object key)
        {
            Contrato contrato = GetEntity(key);
            if (contrato != null)
            {
                em.Contrato.Remove(contrato);
                return em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("No se puede finalizar el Contrato");
            }
        }

        public override List<Contrato> GetEntities()
        {
            return em.Contrato.ToList<Contrato>();
        }

        public override Contrato GetEntity(object key)
        {
            if((String)key != null)
            {
                return em.Contrato.Where(p => p.Numero == (String)key).FirstOrDefault<Contrato>();
            }
            else
            {
                throw new ArgumentException("Debes Ingresar un Numero de contrato válido para Buscar el Contrato.");
            }
        }

        public override int UpdateEntity(Contrato entity)
        {
            Contrato c = GetEntity(entity.Numero);
            if (c != null)
            {
                c.Numero = entity.Numero;
                c.Creacion = entity.Creacion;
                c.Termino = entity.Termino;
                c.RutCliente = entity.RutCliente;
                c.IdModalidad = entity.IdModalidad;
                c.IdTipoEvento = entity.IdTipoEvento;
                c.FechaHoraInicio = entity.FechaHoraInicio;
                c.FechaHoraTermino = entity.FechaHoraTermino;
                c.Asistentes = entity.Asistentes;
                c.PersonalAdicional = entity.PersonalAdicional;
                c.Realizado = entity.Realizado;
                c.ValorTotalContrato = entity.ValorTotalContrato;
                c.Observaciones = entity.Observaciones;
                return em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("No se logró realizar los cambios");
            }
        }

        public List<Contrato> WhereNumeroContrato(String numero_contrato)
        {
            List<Contrato> contratos = (
                                        from c in em.Contrato
                                        where c.Numero.Contains(numero_contrato)
                                        select c
                                       ).ToList();
            return contratos;
        }

        public List<Contrato> WhereTipoEvento(String tipo_evento)
        {
            List<Contrato> contratos = (
                                        from contrato in em.Contrato
                                        join tipoEvento in em.TipoEvento
                                        on contrato.IdTipoEvento equals tipoEvento.IdTipoEvento
                                        where tipoEvento.Descripcion.Contains(tipo_evento)
                                        select contrato
                                        ).ToList();
            return contratos;
        }

        public List<Contrato> WhereModalidadServicio(String nombre_modalidad)
        {
            List<Contrato> modalidades = (
                                            from contrato in em.Contrato
                                            join modalidadServicio in em.ModalidadServicio
                                            on contrato.IdModalidad equals modalidadServicio.IdModalidad
                                            where modalidadServicio.Nombre.Contains(nombre_modalidad)
                                            select contrato
                                         ).ToList();
            return modalidades;
        }

        public List<Contrato> WhereRutCliente(String rut_cliente)
        {
            List<Contrato> contratos = (
                                            from contrato in em.Contrato
                                            join cliente in em.Cliente
                                            on contrato.RutCliente equals cliente.RutCliente
                                            where cliente.RutCliente.Contains(rut_cliente)
                                            select contrato
                                         ).ToList();
            return contratos;
        }
    }
}
