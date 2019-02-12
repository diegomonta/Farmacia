using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Medicamento
    {
        /*ATRIBUTOS*/
        private int Codigo;
        private Farmaceutica Farmaceutica;
        private string Nombre;
        private string Descripcion;
        private float Precio;

        /*PROPIEDADES*/
        public int pCodigo
        {
            get { return Codigo; }
            set { Codigo = value; }
        }

        public Farmaceutica pFarmaceutica
        {
            get { return Farmaceutica; }
            set
            {
                /*VERIFICAR NULL*/
                if (value != null)
                    Farmaceutica = value;
                else
                    throw new Exception("La farmaceutica no existe.");
            }
        }

        public string pNombre
        {
            get { return Nombre; }
            set
            {
                /*VERIFICAR LONGITUD*/
                if (value.Trim().Length <= 50 && value.Trim().Length >= 2)
                    Nombre = value.Trim().ToUpper();
                else
                    throw new Exception("El nombre debe tener entre 2 y 50 caracteres.");
            }
        }

        public string pDescripcion
        {
            get { return Descripcion; }
            set
            {
                /*VERIFICAR LONGITUD*/
                if (value.Trim().Length <= 50 && value.Trim().Length >= 5)
                    Descripcion = value.Trim().ToUpper();
                else
                    throw new Exception("La descripcion debe tener entre 5 y 50 caracteres.");

            }
        }

        public float pPrecio
        {
            get { return Precio; }
            set { Precio = value; }
        }

        /*CONSTRUCTOR*/
        public Medicamento(int _Codigo, Farmaceutica _Farmaceutica, string _Nombre, string _Descripcion, float _Precio)
        {
            pCodigo = _Codigo;
            pFarmaceutica = _Farmaceutica;
            pNombre = _Nombre;
            pDescripcion = _Descripcion;
            pPrecio = _Precio;
        }
    }
}
