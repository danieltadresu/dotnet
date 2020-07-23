namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.Contrato = new HashSet<Contrato>();
        }

        private String rutCliente;
        public String RutCliente
        {
            get
            {
                return rutCliente;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    rutCliente = value;
                }
                else
                {
                    throw new Exception("No es posible registrar al Cliente.\nEl campo rut es obligatorio.");
                }

            }
        }
        private String razonSocial;
        public String RazonSocial
        {
            get { return razonSocial; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    razonSocial = value;
                }
                else
                {
                    throw new ArgumentException("No es posible registrar al Cliente.\nEl campo Razón Social es obligatorio.");
                }
            }
        }
        private String nombreContacto;
        public String NombreContacto
        {
            get { return nombreContacto; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombreContacto = value;
                }
                else
                {
                    throw new ArgumentException("No es posible registrar al Cliente.\nEl campo Nombre es obligatorio.");
                }
            }
        }
        private String mailContacto;
        public String MailContacto
        {
            get { return mailContacto; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    mailContacto = value;
                }
                else
                {
                    throw new ArgumentException("No es posible registrar al Cliente.\nEl campo Email es obligatorio.");
                }
            }
        }
        private String direccion;
        public String Direccion
        {
            get { return direccion; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    direccion = value;
                }
                else
                {
                    throw new ArgumentException("No es posible registrar al Cliente.\nEl campo Dirección es obligatorio.");
                }
            }
        }

        public string Telefono { get; set; }




        public int IdActividadEmpresa { get; set; }
        public int IdTipoEmpresa { get; set; }
        public virtual ActividadEmpresa ActividadEmpresa { get; set; }
        public virtual TipoEmpresa TipoEmpresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}
