using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage ="Nama Custumer Tidak Boleh Kosong")]
        public string NamaCutumer { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "NIK Hanya Boleh Diisi dengan angka")]
        [Required(ErrorMessage = "NIK Wajib Diisi!")]
        public string Nik { get; set; }

        [Required(ErrorMessage = "Alamat tidak boleh kosong")]
        public string Alamat { get; set; }

        [MinLength(10, ErrorMessage = "NO HP minimal 10 Angka")]
        [MaxLength(13, ErrorMessage = "NO HP maksimal 13 Angka")]
        public string NoHp { get; set; }
        public int? IdGender { get; set; }

        public virtual Gender IdGenderNavigation { get; set; }
        public virtual ICollection<Peminjaman> Peminjamen { get; set; }
    }
}
