using System;
using System.Collections.Generic;

#nullable disable

namespace ConnexioPostgresql
{
    public partial class Cicle
    {
        public Cicle()
        {
            Alumnes = new HashSet<Alumne>();
            Asociada = new HashSet<Asociat>();
            CicleContactes = new HashSet<CicleContacte>();
            Usuaris = new HashSet<Usuari>();
        }

        public string NomCicle { get; set; }

        public virtual ICollection<Alumne> Alumnes { get; set; }
        public virtual ICollection<Asociat> Asociada { get; set; }
        public virtual ICollection<CicleContacte> CicleContactes { get; set; }
        public virtual ICollection<Usuari> Usuaris { get; set; }
    }
}
