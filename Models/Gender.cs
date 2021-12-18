using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RentalKendaraan_101.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Custumers = new HashSet<Custumer>();
        }

        [Required(ErrorMessage = "ID Gender Tidak Boleh Kosong")]
        public int IdGender { get; set; }

        [Required(ErrorMessage = "Nama Gender Tidak Boleh Kosong")]
        public string NamaGender { get; set; }

        public virtual ICollection<Custumer> Custumers { get; set; }
    }
}
