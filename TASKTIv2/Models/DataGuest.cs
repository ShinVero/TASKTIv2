namespace TASKTIv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DataGuest")]
    public partial class DataGuest
    {
        [Key]
        public int IdGuest { get; set; }

        [StringLength(50)]
        public string NamaGuest { get; set; }

        [StringLength(50)]
        public string Alamat { get; set; }

        [StringLength(100)]
        public string Ucapan { get; set; }

        [StringLength(8)]
        public string IDAdmin { get; set; }
    }
}
