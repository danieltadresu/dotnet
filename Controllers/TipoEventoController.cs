using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    public class TipoEventoController : AbstractController<TipoEvento>
    {
        public override int AddEntity(TipoEvento entity)
        {
            TipoEvento tipoEvento = GetEntity(entity.IdTipoEvento);
            if (tipoEvento == null)
            {
                em.TipoEvento.Add(entity);
                return em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("No se puede registrar el Evento, el rut ya se encuentra registrado.");
            }
        }

        public override int DeleteEntity(object key)
        {
            throw new NotImplementedException();
        }

        public override List<TipoEvento> GetEntities()
        {
            return em.TipoEvento.ToList<TipoEvento>();
        }

        public override TipoEvento GetEntity(object key)
        {
            return em.TipoEvento.Where(p => p.IdTipoEvento == (int)key).FirstOrDefault<TipoEvento>();
        }

        public override int UpdateEntity(TipoEvento entity)
        {
            throw new NotImplementedException();
        }
    }
}
