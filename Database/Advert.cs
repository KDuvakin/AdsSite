namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Advert")]
    public partial class Advert
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Advert()
        {
            AdvertSubgroups = new HashSet<AdvertSubgroup>();
        }

        [Key]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvertSubgroup> AdvertSubgroups { get; set; }
    }
}
