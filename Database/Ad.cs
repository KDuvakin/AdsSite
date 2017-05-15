namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ad
    {
        [Key]
        public int ID_Ads { get; set; }

        [Required]
        [StringLength(128)]
        public string User_ID { get; set; }

        public int ID_AdvertDiscription { get; set; }

        public int? ID_AdvertDiscriptionSubGroupe { get; set; }

        [Required]
        [StringLength(50)]
        public string Ads_Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public DateTime DateTimeStart { get; set; }

        public DateTime DateTimeEND { get; set; }

        [StringLength(100)]
        public string photo1 { get; set; }

        [StringLength(100)]
        public string photo2 { get; set; }

        [StringLength(100)]
        public string photo3 { get; set; }

        [StringLength(100)]
        public string photo4 { get; set; }

        [StringLength(100)]
        public string photo5 { get; set; }

        [StringLength(100)]
        public string photo6 { get; set; }

        [StringLength(100)]
        public string photo7 { get; set; }

        [StringLength(100)]
        public string photo8 { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        [StringLength(50)]
        public string WorkDay { get; set; }

        [StringLength(50)]
        public string WorkTime { get; set; }

        [StringLength(50)]
        public string WorkSchedule { get; set; }

        [StringLength(100)]
        public string District { get; set; }

        [StringLength(20)]
        public string Category { get; set; }

        [StringLength(20)]
        public string Drive { get; set; }

        [StringLength(20)]
        public string Theory { get; set; }

        [StringLength(200)]
        public string Education { get; set; }

        [StringLength(10)]
        public string LanguageSkills { get; set; }

        [Column(TypeName = "money")]
        public decimal? Pice { get; set; }

        [StringLength(5)]
        public string Year { get; set; }

        [StringLength(20)]
        public string Volume { get; set; }

        [StringLength(20)]
        public string Engine { get; set; }

        [StringLength(20)]
        public string Transmission { get; set; }

        [StringLength(20)]
        public string Body { get; set; }

        [StringLength(20)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(20)]
        public string Mileage { get; set; }

        [StringLength(20)]
        public string Transaction_type { get; set; }

        [StringLength(10)]
        public string Rooms { get; set; }

        [StringLength(10)]
        public string Area { get; set; }

        [StringLength(10)]
        public string Floor { get; set; }

        [StringLength(10)]
        public string Series { get; set; }

        [StringLength(100)]
        public string Street { get; set; }

        [StringLength(50)]
        public string City_Parish { get; set; }

        [StringLength(2000)]
        public string Text { get; set; }

        public virtual AdvertDiscription AdvertDiscription { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
