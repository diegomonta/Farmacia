using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    class Medicamento
    {
        /*ATRIBUTOS*/
        private int Codigo;
        private int Farmaceutica;
        private string Nombre;
        private string Descripcion;
        private float Precio;

        /*PROPIEDADES*/
        public int pCodigo
        {
            get { return Codigo; }
            set { Codigo = value; }
        }

        public int pFarmaceutica
        {
            get { return Farmaceutica; }
            set { Farmaceutica = value; }
        }

        public string pNombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string pDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public float pPrecio
        {
            get { return Precio; }
            set { Precio = value; }
        }

        /*CONSTRUCTOR*/
        public Medicamento(int _Codigo, int _Farmaceutica, string _Nombre, string _Descripcion, float _Precio)
        {
            pCodigo = _Codigo;
            pFarmaceutica = _Farmaceutica;
            pNombre = _Nombre;
            pDescripcion = _Descripcion;
            pPrecio = _Precio;
        }
    }
}
