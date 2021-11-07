using System;
using System.Collections.Generic;

#nullable disable

namespace RentalKendaraan_101.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Custumers = new HashSet<Custumer>();
        }

        public int IdGender { get; set; }
        public string NamaGender { get; set; }

        public virtual ICollection<Custumer> Custumers { get; set; }
    }
}
