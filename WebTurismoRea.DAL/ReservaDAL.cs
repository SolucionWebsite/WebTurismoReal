using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
                        reserva.FechaEntrada = reader["FECHA_INGRESO_RSV"].ToString().Remove(10,8);
                        reserva.FechaSalida = reader["FECHA_SALIDA_RSV"].ToString().Remove(10, 8);
                        reserva.Estado = reader["ESTADO_RSV"].ToString();
                        reserva.FechaReserva = reader["FECHA_RSV"].ToString().Remove(10, 8);
                        reserva.Abono = Convert.ToInt32(reader["VALOR_INI_RSV"]).ToString("C", CultureInfo.CurrentCulture);
                        reserva.ValorFinal = Convert.ToInt32(reader["VALOR_FIN_RSV"]).ToString("C", CultureInfo.CurrentCulture);
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

        public int ModificarReserva(ReservaDAL reserva)
        {
            using (da.Connection())
            {
                int retorno;
                try
                {
                    OracleCommand cmd = new OracleCommand("SP_UPDATERESERVA", da.Connection())
                    {
                        CommandText = "SP_UPDATERESERVA",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("V_ID_RSV", reserva.Id);
                    cmd.Parameters.Add("V_FECHA_INGRESO_RSV", reserva.FechaEntrada);
                    cmd.Parameters.Add("V_FECHA_SALIDA_RSV", reserva.FechaSalida);
                    cmd.Parameters.Add("V_ESTADO_RSV", reserva.Estado);
                    cmd.Parameters.Add("V_FECHA_RSV", null);
                    cmd.Parameters.Add("V_VALOR_INI_RSV", reserva.Abono);
                    cmd.Parameters.Add("V_VALOR_FIN_RSV", reserva.ValorFinal);
                    cmd.Parameters.Add("V_CLIENTE_ID_CLI", reserva.IdCliente);
                    cmd.Parameters.Add("V_DEPARTAMENTO_ID_DPTO", reserva.IdDepto);
                    cmd.Parameters.Add("V_CHECK_IN_ID_CHECKIN", null);
                    cmd.Parameters.Add("V_CHECK_OUT_ID_CHECKOUT", null);

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
