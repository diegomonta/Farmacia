using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cliente : Usuario
    {
        /*ATRIBUTOS*/
        private string DireccionFacturacion;
        private string Telefono;

        /*PROPIEDADES*/
        public string pDireccionFacturacion
        {
            get { return DireccionFacturacion; }
            set
            {
                /*VERIFICAR LONGITUD*/
                if (value.Trim().Length <= 50 && value.Trim().Length >= 5)
                    DireccionFacturacion = value.Trim().ToUpper();
                else
                    throw new Exception("La direccion de facturacion debe tener entre 5 y 50 caracteres.");
            }
        }

        public string pTelefono
        {
            get { return Telefono; }
            set {
                /*VERIFICAR LONGITUD*/
                if (value.Trim().Length <= 15 && value.Trim().Length >= 5)
                    Telefono = value;
                else
                    throw new Exception("El numero de telefono debe tener entre 5 y 15 caracteres.");
            }
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
