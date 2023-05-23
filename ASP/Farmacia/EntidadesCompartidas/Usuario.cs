using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuario
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
                if (value.Trim().Length <= 20 && value.Trim().Length >= 5)
                    NombreUsuario = value.Trim().ToUpper();
                else
                    throw new Exception("El nombre usuario debe tener entre 5 y 20 caracteres.");
            }
        }

        public string pPass
        {
            get { return Pass; }
            set
            {
               
                    Pass = value.Trim().ToUpper();
            }
        }

        public string pNombreCompleto
        {
            get { return NombreCompleto; }
            set
            {
                /*VERIFICAR LONGITUD*/
                if (value.Trim().Length <= 50 && value.Trim().Length >= 3)
                    NombreCompleto = value.Trim().ToUpper();
                else
                    throw new Exception("El nombre debe tener entre 3 y 50 caracteres.");
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
