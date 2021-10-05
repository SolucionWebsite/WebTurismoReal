using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace WebTurismoRea.DAL
{
    public class LocalidadDAL
    {
        DataAccess da = new DataAccess();

        public DataSet Regiones()
        {
            using (da.Connection())
            {
                DataSet region = null;

                try
                {
                    OracleCommand cmd = new OracleCommand("LISTARREGION", da.Connection());
                    cmd.CommandText = "LISTARREGION";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet tabla = new DataSet();
                    adapter.Fill(tabla, "datos");

                    region = tabla;

                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al encontrar registros: " + ex.Message);
                }

                return region;
            }
        }

        public DataSet Provincias(int id_region)
        {
            using (da.Connection())
            {
                DataSet ciudad = null;

                try
                {
                    OracleCommand cmd = new OracleCommand("LISTARPROVINCIA", da.Connection());
                    cmd.CommandText = "LISTARPROVINCIA";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("codigo", id_region);

                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet tabla = new DataSet();
                    adapter.Fill(tabla, "datos");

                    ciudad = tabla;

                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al encontrar registros: " + ex.Message);
                }

                return ciudad;
            }
        }

        public DataSet Comunas(int id_prov)
        {
            using (da.Connection())
            {
                DataSet comuna = null;

                try
                {
                    OracleCommand cmd = new OracleCommand("LISTARCOMUNA", da.Connection());
                    cmd.CommandText = "LISTARCOMUNA";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("codigo", id_prov);

                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet tabla = new DataSet();
                    adapter.Fill(tabla, "datos");

                    comuna = tabla;

                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al encontrar registros: " + ex.Message);
                }

                return comuna;
            }
        }
    }
}

