namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contrato
    {
        public string Numero { get; set; }
        public System.DateTime Creacion { get; set; }
        public System.DateTime Termino { get; set; }
        public string RutCliente { get; set; }
        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public System.DateTime FechaHoraInicio { get; set; }
        public System.DateTime FechaHoraTermino { get; set; }

        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        //public bool Realizado { get; set; }

        private Boolean realizado;

        public Boolean Realizado
        {
            get { return realizado; }
            set { realizado = value; }
        }


        public double ValorTotalContrato { get; set; }
        public string Observaciones { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ModalidadServicio ModalidadServicio { get; set; }

        public String TipoEvento
        {
            get
            {
                String result = "undefined";
                if(IdTipoEvento == 10)
                {
                    result = "Coffee Break";
                }
                else if(IdTipoEvento == 20)
                {
                    result = "Cocktail";
                }
                else if(IdTipoEvento == 30)
                {
                    result = "Cenas";
                }
                return result;
            }
        }

        public String EstadoContrato
        {
            get
            {
                if(realizado != true)
                {
                    return "Contrato Activo";
                }
                return "Contrato Finalizado";
            }
        }


    }
}
