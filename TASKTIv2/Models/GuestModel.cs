namespace TASKTIv2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GuestModel : DbContext
    {
        public GuestModel()
            : base("name=GuestModel")
        {
        }

        public virtual DbSet<DataGuest> DataGuests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataGuest>()
                .Property(e => e.NamaGuest)
                .IsUnicode(false);

            modelBuilder.Entity<DataGuest>()
                .Property(e => e.Alamat)
                .IsUnicode(false);

            modelBuilder.Entity<DataGuest>()
                .Property(e => e.Ucapan)
                .IsUnicode(false);

            modelBuilder.Entity<DataGuest>()
                .Property(e => e.IDAdmin)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
