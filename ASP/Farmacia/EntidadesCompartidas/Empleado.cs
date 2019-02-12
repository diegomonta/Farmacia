using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Empleado : Usuario
    {
        /*ATRIBUTOS*/
        private DateTime InicioJornadaLaboral;
        private DateTime FinJornadaLaboral;

        /*PROPIEDADES*/
        public DateTime pInicioJornadaLaboral
        {
            get { return InicioJornadaLaboral; }
            set { InicioJornadaLaboral = value; }
        }

        public DateTime pFinJornadaLaboral
        {
            get { return FinJornadaLaboral; }
            set {
                if (value > InicioJornadaLaboral)
                    FinJornadaLaboral = value;
                else
                    throw new Exception("El fin de la jornada debe ser mayor al inicio de la jornada.");
            }
        }

        /*CONSTRUCTOR*/
        public Empleado(string _NombreUsuario, string _Pass, string _NombreCompleto, DateTime _InicioJornadaLaboral, DateTime _FinJornadaLaboral) : base(_NombreUsuario, _Pass, _NombreCompleto) { }
    }
}
