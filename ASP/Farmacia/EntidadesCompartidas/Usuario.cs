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
            set
            {
                /*VERIFICAR LONGITUD*/
                if (value.Trim().Length <= 20)
                    NombreUsuario = value.Trim().ToUpper();
                else
                    throw new Exception("El nombre usuario debe contener menos de 20 caracteres.");
            }
        }

        public string pPass
        {
            get { return Pass; }
            set
            {
                /*VERIFICAR LONGITUD*/
                if (value.Trim().Length <= 10)
                    Pass = value.Trim().ToUpper();
                else
                    throw new Exception("La password debe contener menos de 10 caracteres.");
            }
        }

        public string pNombreCompleto
        {
            get { return NombreCompleto; }
            set
            {
                /*VERIFICAR LONGITUD*/
                if (value.Trim().Length <= 50)
                    NombreCompleto = value.Trim().ToUpper();
                else
                    throw new Exception("El nombre debe contener menos de 50 caracteres.");
            }
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
