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
    public class AcompañanteDAL
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
        public int GeneroC { get; set; }
        public int NacionalidadC { get; set; }
        public int IdCliente { get; set; }
        public int IdReserva { get; set; }

        public List<AcompañanteDAL> RegistroAcompañantes(int id_cliente)
        {
            List<AcompañanteDAL> Lista = new List<AcompañanteDAL>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("LISTARACOMPANANTES", da.Connection());
                    cmd.CommandText = "LISTARACOMPANANTES";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter();
                    prm.OracleDbType = OracleDbType.RefCursor;
                    prm.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("id_cliente", id_cliente);
                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        AcompañanteDAL acompañante = new AcompañanteDAL();
                        acompañante.Id = reader["ID_ACOMP"].ToString();
                        acompañante.Nombre = reader["NOMBRE_ACOMP"].ToString();
                        acompañante.ApellidoP = reader["AP_PATERNO_ACOMP"].ToString();
                        acompañante.ApellidoM = reader["AP_MATERNO_ACOMP"].ToString();
                        acompañante.FechaNac = reader["FEC_NAC_ACOMP"].ToString();
                        acompañante.Telefono = reader["NUM_TEL_ACOMP"].ToString();
                        acompañante.Correo = reader["EMAIL_ACOMP"].ToString();
                        acompañante.GeneroC = Convert.ToInt32(reader["GENERO_ID_GEN"]);
                        acompañante.NacionalidadC = Convert.ToInt32(reader["NACIONALIDAD_ID_NACIONALIDAD"]);
                        acompañante.Rut = reader["RUT_ACOMP"].ToString();

                        Lista.Add(acompañante);
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

        public int AgregarAcompañante(AcompañanteDAL acompañante)
        {
            using (da.Connection())
            {
                int retorno;
                try
                {
                    OracleCommand cmd = new OracleCommand("SP_ADDACOMPAÑANTE", da.Connection())
                    {
                        CommandText = "SP_ADDACOMPAÑANTE",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("V_RUT_ACOMP", acompañante.Rut);
                    cmd.Parameters.Add("V_NOMBRE_ACOMP", acompañante.Nombre);
                    cmd.Parameters.Add("V_AP_PATERNO_ACOMP", acompañante.ApellidoP);
                    cmd.Parameters.Add("V_AP_MATERNO_ACOMP", acompañante.ApellidoM);
                    cmd.Parameters.Add("V_FEC_NAC_ACOMP", acompañante.FechaNac);
                    cmd.Parameters.Add("V_NUM__TEL_ACOMP", acompañante.Telefono);
                    cmd.Parameters.Add("V_EMAIL_ACOMP", acompañante.Correo);
                    cmd.Parameters.Add("V_CLIENTE_ID_CLI", acompañante.IdCliente);
                    cmd.Parameters.Add("V_GENERO_ID_GEN", acompañante.GeneroC);
                    cmd.Parameters.Add("V_NACIONALIDAD_ID_NACIONALIDAD", acompañante.NacionalidadC);
                    cmd.Parameters.Add("V_ID_RSV", acompañante.IdReserva);
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
    }
}
