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
    public class TransporteDAL
    {
        DataAccess da = new DataAccess();

        public int Id { get; set; }
        public string Valor { get; set; }
        public int IdTipoVehiculo { get; set; }
        public string TipoVehiculo { get; set; }
        public string Asientos { get; set; }
        public int IdTrayecto { get; set; }
        public string Trayecto { get; set; }

        public List<TransporteDAL> ListaTransporte(int id_tipo_trayecto)
        {
            List<TransporteDAL> Lista = new List<TransporteDAL>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("LISTARTRANSPORTE", da.Connection());
                    cmd.CommandText = "LISTARTRANSPORTE";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter();
                    prm.OracleDbType = OracleDbType.RefCursor;
                    prm.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("id_tipo_trayecto", id_tipo_trayecto);

                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        TransporteDAL transporte = new TransporteDAL();

                        transporte.Id = Convert.ToInt32(reader["ID_TRANS"].ToString());
                        transporte.Valor = Convert.ToInt32(reader["VALOR_TRANS"]).ToString("C", CultureInfo.CurrentCulture);
                        transporte.IdTipoVehiculo = Convert.ToInt32(reader["TIPO_ID_TIPO"].ToString());
                        transporte.TipoVehiculo = reader["DESC_TIPO"].ToString();
                        transporte.Asientos = reader["CANT_ASIENTOS_TIPO"].ToString();
                        transporte.IdTrayecto = Convert.ToInt32(reader["TIPO_TRAYECTO_ID_TIPO_TRA"].ToString());
                        transporte.Trayecto = reader["DESC_TIPO_TRA"].ToString();

                        Lista.Add(transporte);
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
