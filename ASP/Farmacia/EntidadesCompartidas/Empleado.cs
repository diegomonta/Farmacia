using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Empleado : Usuario
    {
        /*ATRIBUTOS*/
        private string InicioJornadaLaboral;
        private string FinJornadaLaboral;
        private string Correo;

        /*PROPIEDADES*/
        public string pInicioJornadaLaboral
        {
            get { return InicioJornadaLaboral; }
            set
            {
                if (value.Length == 5)
                    InicioJornadaLaboral = value;
                else
                    throw new Exception("Ha ocurrido un error intentelo mas tarde.");
            }
        }

        public string pFinJornadaLaboral
        {
            get { return FinJornadaLaboral; }
            set
            {
                if (value.Length == 5)
                    FinJornadaLaboral = value;
                else
                    throw new Exception("Ha ocurrido un error intentelo mas tarde.");
            }
        }
        public string pCorreo 
        {
            get { return Correo; }
        }

        /*CONSTRUCTOR*/
        public Empleado(string _NombreUsuario, string _Pass, string _NombreCompleto, string _InicioJornadaLaboral, string _FinJornadaLaboral, string _Correo)
            : base(_NombreUsuario, _Pass, _NombreCompleto)
        {
            pInicioJornadaLaboral = _InicioJornadaLaboral;
            pFinJornadaLaboral = _FinJornadaLaboral;
            Correo = _Correo;
        }
    }
}
