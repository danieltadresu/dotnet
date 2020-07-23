using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    public class ModalidadServicioController : AbstractController<ModalidadServicio>
    {
        public override int AddEntity(ModalidadServicio entity)
        {
            throw new NotImplementedException();
        }

        public override int DeleteEntity(object key)
        {
            throw new NotImplementedException();
        }

        public override List<ModalidadServicio> GetEntities()
        {
            return em.ModalidadServicio.ToList<ModalidadServicio>();
        }

        public override ModalidadServicio GetEntity(object key)
        {
            if((String)key != null)
            {
                return em.ModalidadServicio.Where(p => p.IdModalidad == (String)key).FirstOrDefault<ModalidadServicio>();
            }
            else
            {
                throw new ArgumentException("Debes Ingresar un Id Modalidad Válido.");
            }
        }

        public override int UpdateEntity(ModalidadServicio entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Object> buscarModalidad(int idTipoEvento)
        {
            try
            {
                var query = ( 
                    from m 
                    in em.ModalidadServicio
                    where m.IdTipoEvento == idTipoEvento
                    select m).ToList();
                return query;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
