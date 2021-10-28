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
    public class ServicioExtraDAL
    {
        DataAccess da = new DataAccess();

        public int Id { get; set; }
        public int? IdTour { get; set; }
        public string NombreTour { get; set; }
        public string ValorPTour { get; set; }
        public int? IdTransporte { get; set; }
        public string Trayecto { get; set; }
        public string Vehiculo { get; set; }
        public string Asientos { get; set; }
        public string ValorPTransporte { get; set; }
        public int Asistentes { get; set; }
        public string ValorTotal { get; set; }
        public string FechaAsistencia { get; set; }
        public string Hora { get; set; }
        public int IdReserva { get; set; }

        public int AgregarServicioExtra(ServicioExtraDAL servicio)
        {
            using (da.Connection())
            {
                int retorno;
                try
                {
                    OracleCommand cmd = new OracleCommand("SP_ADDSERVICIO", da.Connection())
                    {
                        CommandText = "SP_ADDSERVICIO",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("V_FECHA_HORA_SERV", servicio.FechaAsistencia);
                    cmd.Parameters.Add("V_CANT_ASISTENTES_SERV", servicio.Asistentes);
                    cmd.Parameters.Add("V_TOUR_ID_TOUR", servicio.IdTour);
                    cmd.Parameters.Add("V_TRANSPORTE_ID_TRANS", servicio.IdTransporte);
                    cmd.Parameters.Add("V_RESERVA_ID_RSV", servicio.IdReserva);
                    cmd.Parameters.Add("RETORNO", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    retorno = Convert.ToInt32(cmd.Parameters["RETORNO"].Value.ToString().Trim());

                    cmd.Connection.Close();

                    if (retorno == 1)
                    {
                        return 1;
                    }
                    else if (retorno == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return retorno;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public List<ServicioExtraDAL> ListaServicioExtra(int id_reserva)
        {
            List<ServicioExtraDAL> Lista = new List<ServicioExtraDAL>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("LISTARSERVICIOSEXTRA", da.Connection());
                    cmd.CommandText = "LISTARSERVICIOSEXTRA";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter();
                    prm.OracleDbType = OracleDbType.RefCursor;
                    prm.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("id_reserva", id_reserva);

                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        ServicioExtraDAL servicio = new ServicioExtraDAL();

                        servicio.Id = Convert.ToInt32(reader["ID_SERV"].ToString());
                        if (reader["TOUR_ID_TOUR"].ToString() != "")
                        {
                            servicio.IdTour = Convert.ToInt32(reader["TOUR_ID_TOUR"].ToString());
                            servicio.NombreTour = reader["NOMBRE_TOUR"].ToString();
                            servicio.ValorPTour = Convert.ToInt32(reader["VALOR_PERSONAL_TOUR"]).ToString("C", CultureInfo.CurrentCulture);
                        }
                        else if (reader["TOUR_ID_TOUR"].ToString() == "")
                        {
                            servicio.IdTransporte = Convert.ToInt32(reader["TRANSPORTE_ID_TRANS"].ToString());
                            servicio.Trayecto = reader["DESC_TIPO_TRA"].ToString();
                            servicio.Vehiculo = reader["DESC_TIPO"].ToString();
                            servicio.Asientos = reader["CANT_ASIENTOS_TIPO"].ToString();
                            servicio.ValorPTransporte = Convert.ToInt32(reader["VALOR_TRANS"]).ToString("C", CultureInfo.CurrentCulture);
                        }
                        servicio.Asistentes = Convert.ToInt32(reader["CANT_ASISTENTES_SERV"]);
                        servicio.ValorTotal = Convert.ToInt32(reader["VALOR_SERV"]).ToString("C", CultureInfo.CurrentCulture);
                        servicio.FechaAsistencia = reader["FECHA"].ToString();
                        servicio.Hora = reader["HORA"].ToString();
                        servicio.IdReserva = Convert.ToInt32(reader["RESERVA_ID_RSV"]);
                        Lista.Add(servicio);
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

        public int EliminarServicioExtra(int id_servicio, int id_reserva)
        {
            using (da.Connection())
            {
                int retorno;
                try
                {
                    OracleCommand cmd = new OracleCommand("SP_DELETESERVICIO", da.Connection())
                    {
                        CommandText = "SP_DELETESERVICIO",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("V_ID_SERV", id_servicio);
                    cmd.Parameters.Add("V_RESERVA_ID_RSV", id_reserva);
                    cmd.Parameters.Add("RETORNO", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    retorno = Convert.ToInt32(cmd.Parameters["RETORNO"].Value.ToString().Trim());

                    cmd.Connection.Close();

                    if (retorno == 1)
                    {
                        return 1;
                    }
                    else if (retorno == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return retorno;
                    }
                    
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
