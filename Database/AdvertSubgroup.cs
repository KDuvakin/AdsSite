namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdvertSubgroup")]
    public partial class AdvertSubgroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdvertSubgroup()
        {
            AdvertDiscriptions = new HashSet<AdvertDiscription>();
        }

        [Key]
        public int ID_AdvertSubgroup { get; set; }

        public int ID_Advert { get; set; }

        [Required]
        [StringLength(30)]
        public string Name_RU { get; set; }

        [Required]
        [StringLength(30)]
        public string Name_LV { get; set; }

        [Required]
        [StringLength(30)]
        public string Name_EN { get; set; }

        public virtual Advert Advert { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvertDiscription> AdvertDiscriptions { get; set; }
    }
}
