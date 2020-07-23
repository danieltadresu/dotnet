using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class TipoEmpresaController : AbstractController<TipoEmpresa>
    {
        public override int AddEntity(TipoEmpresa entity)
        {
            TipoEmpresa t = GetEntity(entity.IdTipoEmpresa);
            if (t == null)
            {
                em.TipoEmpresa.Add(entity);
                return em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("No se puede registrar el Tipo de Empresa");
            }
        }

        public override int DeleteEntity(object key)
        {
            throw new NotImplementedException();
        }

        public override List<TipoEmpresa> GetEntities()
        {
            return em.TipoEmpresa.ToList<TipoEmpresa>();
        }

        public override TipoEmpresa GetEntity(object key)
        {
            return em.TipoEmpresa.Where(p => p.IdTipoEmpresa == (int)key).FirstOrDefault<TipoEmpresa>();
        }

        public override int UpdateEntity(TipoEmpresa entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
