using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaFarmaceutica
    {
        //ALTA FARMACEUTICA
        public void AltaFarmaceutica(Farmaceutica farmaceutica)
        {
            try
            {
                Persistencia.PersistenciaFarmaceutica persistenciaFarmaceutica = new PersistenciaFarmaceutica();
                persistenciaFarmaceutica.AltaFarmaceutica(farmaceutica);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //BAJA FARMACEUTICA
        public void BajaFarmaceutica(Farmaceutica farmaceutica)
        {
            try
            {
                Persistencia.PersistenciaFarmaceutica persistenciaFarmaceutica = new PersistenciaFarmaceutica();
                persistenciaFarmaceutica.BajaFarmaceutica(farmaceutica);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //MODIFICAR FARMACEUTICA
        public void ModificarFarmaceutica(Farmaceutica farmaceutica)
        {
            try
            {
                Persistencia.PersistenciaFarmaceutica persistenciaFarmaceutica = new PersistenciaFarmaceutica();
                persistenciaFarmaceutica.ModificarFarmaceutica(farmaceutica);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //BUSCAR FARMACEUTICA
        public Farmaceutica BuscarFarmaceutica(string RUC)
        {
            try
            {
                Persistencia.PersistenciaFarmaceutica persistenciaFarmaceutica = new PersistenciaFarmaceutica();
                return persistenciaFarmaceutica.BuscarFarmaceutica(RUC);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<Farmaceutica> ListarFarmaceutica()
        {
            return null;
        }
    }
}
