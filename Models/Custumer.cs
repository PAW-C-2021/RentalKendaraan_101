using System;
using System.Collections.Generic;

#nullable disable

namespace RentalKendaraan_101.Models
{
    public partial class Custumer
    {
        public Custumer()
        {
            Peminjamen = new HashSet<Peminjaman>();
        }

        public int IdCustumer { get; set; }
        public string NamaCutumer { get; set; }
        public string Nik { get; set; }
        public string Alamat { get; set; }
        public string NoHp { get; set; }
        public int? IdGender { get; set; }

        public virtual Gender IdGenderNavigation { get; set; }
        public virtual ICollection<Peminjaman> Peminjamen { get; set; }
    }
}
