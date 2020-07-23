using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ActividadEmpresaController : AbstractController<ActividadEmpresa>
    {
        public override int AddEntity(ActividadEmpresa entity)
        {
            ActividadEmpresa a = GetEntity(entity.IdActividadEmpresa);
            if (a == null)
            {
                em.ActividadEmpresa.Add(entity);
                return em.SaveChanges();
            }
            else
            {
                throw new ArgumentException("No se puede registrar la Actividad de la Empresa");
            }
        }

        public override int DeleteEntity(object key)
        {
            throw new NotImplementedException();
        }

        public override List<ActividadEmpresa> GetEntities()
        {
            return em.ActividadEmpresa.ToList<ActividadEmpresa>();
        }

        public override ActividadEmpresa GetEntity(object key)
        {
            return em.ActividadEmpresa.Where(p => p.IdActividadEmpresa == (int)key).FirstOrDefault<ActividadEmpresa>();
        }

        public override int UpdateEntity(ActividadEmpresa entity)
        {
            throw new NotImplementedException();
        }


    }
}
