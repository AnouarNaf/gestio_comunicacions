using System;
using System.Collections.Generic;

#nullable disable

namespace ConnexioPostgresql
{
    public partial class Contacte
    {
        public Contacte()
        {
            CicleContactes = new HashSet<CicleContacte>();
            Comunicacions = new HashSet<Comunicacio>();
        }

        public string Dni { get; set; }
        public string Nom { get; set; }
        public string Telèfon { get; set; }
        public string Especialització { get; set; }
        public string NifEmpresa { get; set; }

        public virtual Empresa Nif_Empresa { get; set; }
        public virtual ICollection<CicleContacte> CicleContactes { get; set; }
        public virtual ICollection<Comunicacio> Comunicacions { get; set; }
    }
}
