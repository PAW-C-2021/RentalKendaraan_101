using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RentalKendaraan_101.Models
{
    public partial class Kendaraan
    {
        public Kendaraan()
        {
            Peminjamen = new HashSet<Peminjaman>();
        }

        [Required(ErrorMessage = "ID Kendaraan Tidak Boleh Kosong")]
        public int IdKendaraan { get; set; }

        [Required(ErrorMessage = "Nama Kendaraan Tidak Boleh Kosong")]
        public string NamaKendaraan { get; set; }

        [Required(ErrorMessage = "NoPolisi Tidak Boleh Kosong")]
        public string NoPolisi { get; set; }

        [Required(ErrorMessage = "NoStnk Tidak Boleh Kosong")]
        public string NoStnk { get; set; }

        [Required(ErrorMessage = "ID Jenis Kendaraan Tidak Boleh Kosong")]
        public int? IdJenisKendaraan { get; set; }

        [Required(ErrorMessage = "Ketersediaan Tidak Boleh Kosong")]
        public string Ketersediaan { get; set; }

        public virtual JenisKendaraan IdJenisKendaraanNavigation { get; set; }
        public virtual ICollection<Peminjaman> Peminjamen { get; set; }
    }
}
