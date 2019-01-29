using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    class Farmaceutica
    {
        /*ATRIBUTOS*/
        private int RUC;
        private string Nombre;
        private string CorreoElectronico;
        private string Direccion;

        /*PROPIEDADES*/
        public int pRUC
        {
            get { return RUC; }
            set { RUC = value; }
        }

        public string pNombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string pCorreoElectronico
        {
            get { return CorreoElectronico; }
            set { CorreoElectronico = value; }
        }

        public string pDireccion
        {
            get { return Direccion; }
            set { Direccion = value; }
        }

        /*CONSTRUCTOR*/
        public Farmaceutica(int _RUC, string _Nombre, string _CorreoElectronico, string _Direccion)
        {
            pRUC = _RUC;
            pNombre = _Nombre;
            pCorreoElectronico = _CorreoElectronico;
            pDireccion = _Direccion;
        }
    }
}
