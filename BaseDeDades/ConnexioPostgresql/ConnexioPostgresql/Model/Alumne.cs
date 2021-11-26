using System;
using System.Collections.Generic;

#nullable disable

namespace ConnexioPostgresql
{
    public partial class Alumne
    {
        public Alumne()
        {
            Pertanys = new HashSet<Pertany>();
        }

        public string Dni { get; set; }
        public string NomAlumne { get; set; }
        public string CognomAlumne { get; set; }
        public string TipusPractica { get; set; }
        public string NomCicle { get; set; }

        public virtual Cicle Nom_Cicle { get; set; }
        public virtual ICollection<Pertany> Pertanys { get; set; }
    }
}
