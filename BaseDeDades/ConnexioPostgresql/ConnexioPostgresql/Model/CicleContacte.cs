using System;
using System.Collections.Generic;

#nullable disable

namespace ConnexioPostgresql
{
    public partial class CicleContacte
    {
        public string CicleNom { get; set; }
        public string ContacteDni { get; set; }

        public virtual Cicle Cicle_Nom { get; set; }
        public virtual Contacte Contacte_Dni { get; set; }
    }
}
