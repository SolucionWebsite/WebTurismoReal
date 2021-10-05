using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTurismoRea.DAL;

namespace WebTurismoReal.BLL
{
    public class LocalidadBLL
    {
        LocalidadDAL registros = new LocalidadDAL();

        public DataSet Regiones()
        {
            DataSet registrosRegion = registros.Regiones();

            return registrosRegion;
        }

        public DataSet Provincias(int id_region)
        {
            DataSet registrosProv = registros.Provincias(id_region);

            return registrosProv;
        }

        public DataSet Comunas(int id_prov)
        {
            DataSet registrosComuna = registros.Comunas(id_prov);

            return registrosComuna;
        }


    }
}
