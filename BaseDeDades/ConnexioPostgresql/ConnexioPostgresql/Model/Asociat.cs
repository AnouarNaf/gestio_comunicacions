using System;
using System.Collections.Generic;

#nullable disable

namespace ConnexioPostgresql
{
    public partial class Asociat
    {
        public Asociat()
        {
            Pertanys = new HashSet<Pertany>();
        }

        public string CicleNom { get; set; }
        public string EmpresaNif { get; set; }

        public virtual Cicle Cicle_Nom { get; set; }
        public virtual Empresa Empresa_Nif { get; set; }
        public virtual ICollection<Pertany> Pertanys { get; set; }
    }
}
