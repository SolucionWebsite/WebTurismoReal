using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTurismoRea.DAL
{
    public class ClienteDAL
    {
        DataAccess da = new DataAccess();

        public string Id { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string FechaNac { get; set; }
        public string Clave { get; set; }
        public int GeneroC { get; set; }
        public int NacionalidadC { get; set; }

        public int AgregarCliente(ClienteDAL cliente)
        {
            using (da.Connection())
            {
                int retorno;
                try
                {
                    OracleCommand cmd = new OracleCommand("SP_ADDCLIENTE", da.Connection())
                    {
                        CommandText = "SP_ADDCLIENTE",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("V_RUT_CLI", cliente.Rut);
                    cmd.Parameters.Add("V_NOMBRE_CLI", cliente.Nombre);
                    cmd.Parameters.Add("V_AP_PATERNO_CLI", cliente.ApellidoP);
                    cmd.Parameters.Add("V_AP_MATERNO_CLI", cliente.ApellidoM);
                    cmd.Parameters.Add("V_NUM_TELEFONO_CLI", cliente.Telefono);
                    cmd.Parameters.Add("V_EMAIL_CLI", cliente.Correo);
                    cmd.Parameters.Add("V_FEC_NAC_CLI", cliente.FechaNac);
                    cmd.Parameters.Add("V_CONTRASEÑA_CLI", cliente.Clave);
                    cmd.Parameters.Add("V_GENERO_ID_GEN", cliente.GeneroC);
                    cmd.Parameters.Add("V_NACIONALIDAD_ID_NACIONALIDAD", cliente.NacionalidadC);
                    cmd.Parameters.Add("RETORNO", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    retorno = Convert.ToInt32(cmd.Parameters["RETORNO"].Value.ToString().Trim());

                    cmd.Connection.Close();

                    return 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public DataSet Nacionalidad()
        {
            using (da.Connection())
            {
                DataSet nacionalidad = null;

                try
                {
                    OracleCommand cmd = new OracleCommand("LISTARNACIONALIDAD", da.Connection());
                    cmd.CommandText = "LISTARNACIONALIDAD";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet tabla = new DataSet();
                    adapter.Fill(tabla, "datos");

                    nacionalidad = tabla;

                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al encontrar registros: " + ex.Message);
                }

                return nacionalidad;
            }
        }

        public DataSet Genero()
        {
            using (da.Connection())
            {
                DataSet genero = null;

                try
                {
                    OracleCommand cmd = new OracleCommand("LISTARGENERO", da.Connection());
                    cmd.CommandText = "LISTARGENERO";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet tabla = new DataSet();
                    adapter.Fill(tabla, "datos");

                    genero = tabla;

                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al encontrar registros: " + ex.Message);
                }

                return genero;
            }
        }

        public List<ClienteDAL> RegistrosClientes()
        {
            List<ClienteDAL> Lista = new List<ClienteDAL>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("LISTAUSUARIOS", da.Connection());
                    cmd.CommandText = "LISTAUSUARIOS";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter();
                    prm.OracleDbType = OracleDbType.RefCursor;
                    prm.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(prm);
                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        ClienteDAL cliente = new ClienteDAL();
                        cliente.Id = reader["ID_CLI"].ToString();
                        cliente.Rut = reader["RUT_CLI"].ToString();
                        cliente.Nombre = reader["NOMBRE_CLI"].ToString();
                        cliente.ApellidoP = reader["AP_PATERNO_CLI"].ToString();
                        cliente.ApellidoM = reader["AP_MATERNO_CLI"].ToString();
                        cliente.Telefono = reader["NUM_TELEFONO_CLI"].ToString();
                        cliente.Correo = reader["EMAIL_CLI"].ToString();
                        cliente.FechaNac = reader["FEC_NAC_CLI"].ToString();
                        cliente.Clave = reader["CONTRASEÑA_CLI"].ToString();
                        cliente.GeneroC = Convert.ToInt32(reader["GENERO_ID_GEN"]);
                        cliente.NacionalidadC = Convert.ToInt32(reader["NACIONALIDAD_ID_NACIONALIDAD"]);

                        Lista.Add(cliente);
                    }
                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return Lista;
            }
        }
    }
}
