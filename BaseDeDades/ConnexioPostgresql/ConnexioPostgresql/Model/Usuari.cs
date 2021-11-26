using System;
using System.Collections.Generic;

#nullable disable

namespace ConnexioPostgresql
{
    public partial class Usuari
    {
        public Usuari()
        {
            Comunicacions = new HashSet<Comunicacio>();
        }

        public string Nom { get; set; }
        public string Mail { get; set; }
        public string Contrasenya { get; set; }
        public string Administrador { get; set; }
        public string NomCicle { get; set; }

        public virtual Cicle Nom_Cicle { get; set; }
        public virtual ICollection<Comunicacio> Comunicacions { get; set; }
    }
}
