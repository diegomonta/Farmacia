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
        //BUSCAR USUARIO
        public Usuario BuscarUsuario(string usuario)
        {
            try
            {
                Usuario usu = null;
                //BUSCAR EMPLEADO
                PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
                usu = persistenciaEmpleado.BuscarEmpleado(usuario);
                if (usu == null)
                {
                    //BUSCAR CLIENTE
                    PersistenciaCliente persisteniaCliente = new PersistenciaCliente();
                    usu = persisteniaCliente.BuscarCliente(usuario);
                }
                return usu;
            }
            catch { throw; }
        }

        //LOGIN USUARIO
        public Usuario LoginUsuario(string usuario, string pass)
        {
            try
            {
                Usuario usu = null;
                //VERIFICAR EXISTENCIA EMPLEADO
                PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
                usu = persistenciaEmpleado.LogInEmpleado(usuario, pass);
                if (usu == null)
                {
                    //VERIFICAR EXISTENCIA CLIENTE
                    PersistenciaCliente persistenciaCliente = new PersistenciaCliente();
                    usu = persistenciaCliente.LogInCliente(usuario, pass);
                }
                return usu;
            }
            catch
            {
                throw new Exception("Ha ocurrido un error vuelva a intentarlo mas tarde.");
            }
        }

        //ALTA USUARIO
        public void AltaUsuario(Usuario usuario)
        {
            try
            {
                if (usuario is Empleado)
                {
                    PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
                    persistenciaEmpleado.AltaEmpleado((Empleado)usuario);
                }
                else
                {
                    PersistenciaCliente persistenciaCliente = new PersistenciaCliente();
                    persistenciaCliente.AltaCliente((Cliente)usuario);
                }
            }
            catch { throw; }
        }

        //MODIFCAR USUARIO
        public void ModificarUsuario(Usuario usuario)
        {
            try
            {
                if (usuario is Empleado)
                {
                    PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
                    persistenciaEmpleado.ModificarEmpleado((Empleado)usuario);
                }
            }
            catch { throw; }
        }
        public void ModificarClave(string usuario, string claveRecuperacion)
        {
            try
            {
                //VERIFICAR EXISTENCIA EMPLEADO
                PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
                persistenciaEmpleado.ModificarClave(usuario, claveRecuperacion);
            }
            catch
            {
                throw new Exception("Ha ocurrido un error vuelva a intentarlo mas tarde.");
            }
        }
        //BAJA USUARIO
        public void BajaUsuario(Usuario usuario)
        {
            try
            {
                if (usuario is Empleado)
                {
                    PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
                    persistenciaEmpleado.BajaEmpleado((Empleado)usuario);
                }
            }
            catch { throw; }
        }
    }
}
