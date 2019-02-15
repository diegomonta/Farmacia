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

        /*PROPIEDADES*/
        public string pInicioJornadaLaboral
        {
            get { return InicioJornadaLaboral; }
            set { InicioJornadaLaboral = value; }
        }

        public string pFinJornadaLaboral
        {
            get { return FinJornadaLaboral; }
            set { FinJornadaLaboral = value; }
        }

        /*CONSTRUCTOR*/
        public Empleado(string _NombreUsuario, string _Pass, string _NombreCompleto, string _InicioJornadaLaboral, string _FinJornadaLaboral) : base(_NombreUsuario, _Pass, _NombreCompleto) { }
    }
}
