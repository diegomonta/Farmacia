using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    class Cliente : Usuario
    {
        /*ATRIBUTOS*/
        private string DireccionFacturacion;
        private string Telefono;

        /*PROPIEDADES*/
        public string pDireccionFacturacion
        {
            get { return DireccionFacturacion; }
            set { DireccionFacturacion = value; }
        }

        public string pTelefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }

        /*CONSTRUCTOR*/
        public Cliente(string _NombreUsuario, string _Pass, string _NombreCompleto, string _DireccionFacturacion, string _Telefono)
            : base(_NombreUsuario, _Pass, _NombreCompleto)
        {
            pDireccionFacturacion = _DireccionFacturacion;
            pTelefono = _Telefono;
        }
    }
}
