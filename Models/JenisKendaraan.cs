using System;
using System.Collections.Generic;

#nullable disable

namespace RentalKendaraan_101.Models
{
    public partial class JenisKendaraan
    {
        public JenisKendaraan()
        {
            Kendaraans = new HashSet<Kendaraan>();
        }

        public int IdJenisKendaraan { get; set; }
        public string NamaJenisKendaraan { get; set; }

        public virtual ICollection<Kendaraan> Kendaraans { get; set; }
    }
}
