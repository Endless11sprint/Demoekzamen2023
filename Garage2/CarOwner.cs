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
    
    public partial class CarOwner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarOwner()
        {
            this.OwnersAndTheirCars = new HashSet<OwnersAndTheirCars>();
        }
    
        public int idCarOwner_pk_ { get; set; }
        public string nameOfTheCarOwner { get; set; }
        public string patronymicOfTheCarOwner { get; set; }
        public string surnameOfTheCarOwner { get; set; }
        public string phoneNumberOfTheCarOwner { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OwnersAndTheirCars> OwnersAndTheirCars { get; set; }
    }
}
