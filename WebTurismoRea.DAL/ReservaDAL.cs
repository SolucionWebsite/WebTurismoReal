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
    public class ReservaDAL
    {
        DataAccess da = new DataAccess();

        public int Id { get; set; }
        public string FechaEntrada { get; set; }
        public string FechaSalida { get; set; }
        public string Estado { get; set; }
        public string FechaReserva { get; set; }
        public string Abono { get; set; }
        public string ValorFinal { get; set; }
        public int IdCliente { get; set; }
        public int IdDepto { get; set; }

        public int AgregarReserva(ReservaDAL reserva)
        {
            using (da.Connection())
            {
                int retorno;
                try
                {
                    OracleCommand cmd = new OracleCommand("SP_ADDRESERVA", da.Connection())
                    {
                        CommandText = "SP_ADDRESERVA",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("V_FEC_IN_RSV", reserva.FechaEntrada);
                    cmd.Parameters.Add("V_FEC_SA_RSV", reserva.FechaSalida);
                    cmd.Parameters.Add("V_ESTADO_RSV", reserva.Estado);
                    cmd.Parameters.Add("V_FECHA_RSV", reserva.FechaReserva);
                    cmd.Parameters.Add("V_CLIENTE_ID", reserva.IdCliente);
                    cmd.Parameters.Add("V_DPTO_ID", reserva.IdDepto);
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

        public List<ReservaDAL> Reservas(int id_usuario)
        {
            List<ReservaDAL> Lista = new List<ReservaDAL>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("LISTARRESERVAS", da.Connection());
                    cmd.CommandText = "LISTARRESERVAS";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter();
                    prm.OracleDbType = OracleDbType.RefCursor;
                    prm.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("id_usuario", id_usuario);
                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        ReservaDAL reserva = new ReservaDAL();
                        reserva.Id = Int32.Parse(reader["ID_RSV"].ToString());
                        reserva.FechaEntrada = reader["FECHA_INGRESO_RSV"].ToString();
                        reserva.FechaSalida = reader["FECHA_SALIDA_RSV"].ToString();
                        reserva.Estado = reader["ESTADO_RSV"].ToString();
                        reserva.FechaReserva = reader["FECHA_RSV"].ToString();
                        reserva.Abono = reader["VALOR_INI_RSV"].ToString();
                        reserva.ValorFinal = reader["VALOR_FIN_RSV"].ToString();
                        reserva.IdCliente = Convert.ToInt32(reader["CLIENTE_ID_CLI"]);
                        reserva.IdDepto = Convert.ToInt32(reader["DEPARTAMENTO_ID_DPTO"]);

                        Lista.Add(reserva);
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
