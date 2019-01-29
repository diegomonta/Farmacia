using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    class Usuario
    {
        /*ATRIBUTOS*/
        private string NombreUsuario;
        private string Pass;
        private string NombreCompleto;

        /*PROPIEDADES*/
        public string pNombreUsuario
        {
            get { return NombreUsuario; }
            set { NombreUsuario = value; }
        }

        public string pPass
        {
            get { return Pass; }
            set { Pass = value; }
        }

        public string pNombreCompleto
        {
            get { return NombreCompleto; }
            set { NombreCompleto = value; }
        }

        /*CONSTRUCTOR*/
        public Usuario(string _NombreUsuario, string _Pass, string _NombreCompleto)
        {
            pNombreUsuario = _NombreUsuario;
            pPass = _Pass;
            pNombreCompleto = _NombreCompleto;
        }
    }
}
