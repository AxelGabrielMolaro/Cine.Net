//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class CARTELERA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CARTELERA()
        {
            this.SEDE = new HashSet<SEDE>();
        }
    
        public int ID { get; set; }
        public string HORA_DE_INICIO { get; set; }
        public string DIAS_DE_SEMANA { get; set; }
        public System.DateTime FECHA_DE_INICIO { get; set; }
        public System.DateTime FECHA_DE_FIN { get; set; }
        public string NUMERO_DE_SALA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SEDE> SEDE { get; set; }
    }
}