//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Garage2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Watchman
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Watchman()
        {
            this.Garage = new HashSet<Garage>();
            this.Garage1 = new HashSet<Garage>();
        }
    
        public int idWatchman_pk_ { get; set; }
        public string nameWatchman { get; set; }
        public string surnameWatchman { get; set; }
        public string patronymicWatchman { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Garage> Garage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Garage> Garage1 { get; set; }
    }
}