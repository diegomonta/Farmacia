using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario
    {
        //LOGIN USUARIO
        public Usuario LoginUsuario(string usu, string pass)
        {
            try
            {
                //VERIFICAR EXISTENCIA USUARIO
                Persistencia.PersistenciaUsuario persistenciaUsuario = new PersistenciaUsuario();
                Usuario usuario = persistenciaUsuario.BuscarUsuario(usu, pass);
                if (usuario != null)
                {
                    //VERIFICAR EXISTENCIA EMPLEADO
                    Persistencia.PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
                    Empleado empleado = persistenciaEmpleado.LogInEmpleado(usu, pass);
                    if (empleado == null)
                    {
                        //VERIFICAR EXISTENCIA CLIENTE
                        Persistencia.PersistenciaCliente persistenciaCliente = new PersistenciaCliente();
                        Cliente cliente = persistenciaCliente.LogInCliente(usu, pass);

                        if (cliente == null)
                            return null;
                        else
                            return cliente;
                    }
                    else
                        return empleado;
                }
                else
                    return null;
            }
            catch
            {
                throw new Exception("Ha ocurrido un error vuelva a intentarlo mas tarde.");
            }
        }
    }
}
