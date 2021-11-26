using System;
using System.Collections.Generic;

#nullable disable

namespace ConnexioPostgresql
{
    public partial class Empresa
    {
        public Empresa()
        {
            Asociada = new HashSet<Asociat>();
            Contactes = new HashSet<Contacte>();
        }

        public string Nif { get; set; }
        public string Telèfon { get; set; }
        public string Ubicació { get; set; }
        public string Mail { get; set; }

        public virtual ICollection<Asociat> Asociada { get; set; }
        public virtual ICollection<Contacte> Contactes { get; set; }
    }
}
