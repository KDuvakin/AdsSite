namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdvertDiscription")]
    public partial class AdvertDiscription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdvertDiscription()
        {
            Ads = new HashSet<Ad>();
        }

        [Key]
        public int ID_AdvertDiscription { get; set; }

        public int ID_AdvertSubgroup { get; set; }

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
        public virtual ICollection<Ad> Ads { get; set; }

        public virtual AdvertSubgroup AdvertSubgroup { get; set; }
    }
}
