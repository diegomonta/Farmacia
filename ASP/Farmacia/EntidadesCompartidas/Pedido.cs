using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Pedido
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
            set
            {
                /*VERIFICAR NULL*/
                if (value != null)
                    ClienteComprador = value;
                else
                    throw new Exception("El cliente no existe.");
            }
        }

        public Medicamento pMedicamentoPedido
        {
            get { return MedicamentoPedido; }
            set
            {
                /*VERIFICAR NULL*/
                if (value != null)
                    MedicamentoPedido = value;
                else
                    throw new Exception("El medicamento no existe.");
            }
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
                    case "GENERADO":
                    case "ENVIADO":
                    case "ENTREGADO":
                        Estado = value.Trim().ToUpper();
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
