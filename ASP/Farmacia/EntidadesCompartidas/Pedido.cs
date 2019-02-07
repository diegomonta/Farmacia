using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    class Pedido
    {
        /*ATRIBUTOS*/
        private int Numero;
        private Cliente ClienteComprador;
        private Medicamento MedicamentoPedido;
        private int Cantidad;
        private string Estado;

        /*PROPIEDADES*/
        public int pNumero
        {
            get { return Numero; }
            set { Numero = value; }
        }

        public Cliente pClienteComprador
        {
            get { return ClienteComprador; }
            set { ClienteComprador = value; }
        }

        public Medicamento pMedicamentoPedido
        {
            get { return MedicamentoPedido; }
            set { MedicamentoPedido = value; }
        }

        public int pCantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }

        public string pEstado
        {
            get { return Estado; }
            set
            {
                switch (value.Trim().ToUpper())
                {
                    /*ESTADOS CORRECTOS*/
                    case "CANCELADO":
                    case "ACTIVO":
                    case "ENTREGADO":
                        Estado = value;
                        break;

                    default:
                        throw new Exception("El estado no es correcto.");
                }
            }
        }

        /*CONSTRUCTOR*/
        public Pedido(int _Numero, Cliente _ClienteComprador, Medicamento _MedicamentoPedido, int _Cantidad, string _Estado)
        {
            pNumero = _Numero;
            pClienteComprador = _ClienteComprador;
            pMedicamentoPedido = _MedicamentoPedido;
            pCantidad = _Cantidad;
            pEstado = _Estado;
        }

    }
}
