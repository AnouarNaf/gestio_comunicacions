using System;
using System.Collections.Generic;

#nullable disable

namespace ConnexioPostgresql
{
    public partial class Pertany
    {
        public string AlumnesDni { get; set; }
        public string AsociadaCicleNom { get; set; }
        public string AsociadaEmpresaNif { get; set; }

        public virtual Alumne Alumnes_Dni { get; set; }
        public virtual Asociat Asociada { get; set; }
    }
}
