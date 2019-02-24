﻿using System;
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
                Persistencia.PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
                Empleado empleado = persistenciaEmpleado.BuscarEmpleado(usuario);
                if (empleado == null)
                {
                    Persistencia.PersistenciaCliente persisteniaCliente = new PersistenciaCliente();
                    Cliente cliente = persisteniaCliente.BuscarCliente(usuario);
                    return cliente;
                }
                else
                    return empleado;
            }
            catch { throw; }
        }

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

        //ALTA USUARIO
        public void AltaUsuario(Usuario usuario)
        {
            try
            {
                if (usuario is Empleado)
                {
                    Persistencia.PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
                    persistenciaEmpleado.AltaEmpleado((Empleado)usuario);
                }
                else
                {
                    Persistencia.PersistenciaCliente persistenciaCliente = new PersistenciaCliente();
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
                    Persistencia.PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
                    persistenciaEmpleado.ModificarEmpleado((Empleado)usuario);
                }
                else
                {
                    //??????
                    //Persistencia.PersistenciaCliente persistenciaCliente = new PersistenciaCliente();
                    //persistenciaCliente.ModificarCliente((Cliente)usuario);
                }
            }
            catch { throw; }
        }

        //BAJA USUARIO
        public void BajaUsuario(Usuario usuario)
        {
            try
            {
                if (usuario is Empleado)
                {
                    Persistencia.PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
                    persistenciaEmpleado.BajaEmpleado((Empleado)usuario);
                }
                else
                {
                    //??????
                    //Persistencia.PersistenciaCliente persistenciaCliente = new PersistenciaCliente();
                    //persistenciaCliente.BajaCliente((Cliente)usuario);
                }
            }
            catch { throw; }
        }
    }
}