namespace Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataRepo : DbContext
    {
        public DataRepo()
            : base("name=DataRepo")
        {
        }

        public virtual DbSet<Ad> Ads { get; set; }
        public virtual DbSet<Advert> Adverts { get; set; }
        public virtual DbSet<AdvertDiscription> AdvertDiscriptions { get; set; }
        public virtual DbSet<AdvertSubgroup> AdvertSubgroups { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ad>()
                .Property(e => e.Ads_Name)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.photo1)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.photo2)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.photo3)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.photo4)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.photo5)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.photo6)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.photo7)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.photo8)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Company)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.WorkDay)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.WorkTime)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.WorkSchedule)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.District)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Category)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Drive)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Theory)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Education)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.LanguageSkills)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Pice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Ad>()
                .Property(e => e.Year)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Volume)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Engine)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Transmission)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Body)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Color)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Brand)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Model)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Mileage)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Transaction_type)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Rooms)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Area)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Floor)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Series)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Street)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.City_Parish)
                .IsFixedLength();

            modelBuilder.Entity<Ad>()
                .Property(e => e.Text)
                .IsFixedLength();

            modelBuilder.Entity<Advert>()
                .Property(e => e.Name_RU)
                .IsFixedLength();

            modelBuilder.Entity<Advert>()
                .Property(e => e.Name_LV)
                .IsFixedLength();

            modelBuilder.Entity<Advert>()
                .Property(e => e.Name_EN)
                .IsFixedLength();

            modelBuilder.Entity<Advert>()
                .HasMany(e => e.AdvertSubgroups)
                .WithRequired(e => e.Advert)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdvertDiscription>()
                .Property(e => e.Name_RU)
                .IsFixedLength();

            modelBuilder.Entity<AdvertDiscription>()
                .Property(e => e.Name_LV)
                .IsFixedLength();

            modelBuilder.Entity<AdvertDiscription>()
                .Property(e => e.Name_EN)
                .IsFixedLength();

            modelBuilder.Entity<AdvertDiscription>()
                .HasMany(e => e.Ads)
                .WithRequired(e => e.AdvertDiscription)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdvertSubgroup>()
                .Property(e => e.Name_RU)
                .IsFixedLength();

            modelBuilder.Entity<AdvertSubgroup>()
                .Property(e => e.Name_LV)
                .IsFixedLength();

            modelBuilder.Entity<AdvertSubgroup>()
                .Property(e => e.Name_EN)
                .IsFixedLength();

            modelBuilder.Entity<AdvertSubgroup>()
                .HasMany(e => e.AdvertDiscriptions)
                .WithRequired(e => e.AdvertSubgroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Ads)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.User_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);
        }
    }
}
