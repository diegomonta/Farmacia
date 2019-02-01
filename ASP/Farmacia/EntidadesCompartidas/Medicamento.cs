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
            set
            {
                /*VERIFICAR LONGITUD*/
                if (value.Trim().Length <= 50)
                    Nombre = value.Trim().ToUpper();
                else
                    throw new Exception("El nombre debe contener menos de 50 caracteres.");
            }
        }

        public string pDescripcion
        {
            get { return Descripcion; }
            set
            {
                /*VERIFICAR LONGITUD*/
                if (value.Trim().Length <= 50)
                    Descripcion = value.Trim().ToUpper();
                else
                    throw new Exception("La descripcion debe contener menos de 50 caracteres.");

            }
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
