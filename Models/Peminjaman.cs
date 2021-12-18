using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RentalKendaraan_101.Models
{
    public partial class Peminjaman
    {
        public Peminjaman()
        {
            Pengembalians = new HashSet<Pengembalian>();
        }

        [Required(ErrorMessage = "ID Peminjaman Tidak Boleh Kosong")]
        public int IdPeminjaman { get; set; }

        [Required(ErrorMessage = "Tanggal Tidak Boleh Kosong")]
        public DateTime? TglPeminjaman { get; set; }

        [Required(ErrorMessage = "ID Kendaraan Tidak Boleh Kosong")]
        public int? IdKendaraan { get; set; }

        [Required(ErrorMessage = "ID Custumer Tidak Boleh Kosong")]
        public int? IdCustumer { get; set; }

        [Required(ErrorMessage = "ID Jaminan Tidak Boleh Kosong")]
        public int? IdJaminan { get; set; }

        [Required(ErrorMessage = "Biaya Tidak Boleh Kosong")]
        public int? Biaya { get; set; }

        public virtual Custumer IdCustumerNavigation { get; set; }
        public virtual Jaminan IdJaminanNavigation { get; set; }
        public virtual Kendaraan IdKendaraanNavigation { get; set; }
        public virtual ICollection<Pengembalian> Pengembalians { get; set; }
    }
}
