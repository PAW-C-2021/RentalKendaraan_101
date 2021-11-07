using System;
using System.Collections.Generic;

#nullable disable

namespace RentalKendaraan_101.Models
{
    public partial class Peminjaman
    {
        public Peminjaman()
        {
            Pengembalians = new HashSet<Pengembalian>();
        }

        public int IdPeminjaman { get; set; }
        public DateTime? TglPeminjaman { get; set; }
        public int? IdKendaraan { get; set; }
        public int? IdCustumer { get; set; }
        public int? IdJaminan { get; set; }
        public int? Biaya { get; set; }

        public virtual Custumer IdCustumerNavigation { get; set; }
        public virtual Jaminan IdJaminanNavigation { get; set; }
        public virtual Kendaraan IdKendaraanNavigation { get; set; }
        public virtual ICollection<Pengembalian> Pengembalians { get; set; }
    }
}
