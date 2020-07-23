namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActividadEmpresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActividadEmpresa()
        {
            this.Cliente = new HashSet<Cliente>();
        }
    
        public int IdActividadEmpresa { get; set; }
        public string Descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
