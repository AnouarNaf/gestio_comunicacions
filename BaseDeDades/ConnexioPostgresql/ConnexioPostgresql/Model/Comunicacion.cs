using System;
using System.Collections.Generic;

#nullable disable

namespace ConnexioPostgresql
{
    public partial class Comunicacio
    {
        public string UsuariNom { get; set; }
        public string ContacteDni { get; set; }

        public virtual Contacte Contacte_Dni { get; set; }
        public virtual Usuari Usuari_Nom { get; set; }
    }
}
