namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoEvento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoEvento()
        {
            this.ModalidadServicio = new HashSet<ModalidadServicio>();
        }
    
        public int IdTipoEvento { get; set; }
        public string Descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModalidadServicio> ModalidadServicio { get; set; }
    }
}
