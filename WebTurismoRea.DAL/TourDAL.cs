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
    public class TourDAL
    {
        DataAccess da = new DataAccess();

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ValorP { get; set; }
        public string Descripcion { get; set; }
        public string Comuna { get; set; }
        public string Zona { get; set; }

        public List<TourDAL> ListaTours(int id_comuna)
        {
            List<TourDAL> Lista = new List<TourDAL>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("LISTARTOURS", da.Connection());
                    cmd.CommandText = "LISTARTOURS";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter();
                    prm.OracleDbType = OracleDbType.RefCursor;
                    prm.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("comuna_id", id_comuna);

                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        TourDAL tour = new TourDAL();
                        tour.Id = Convert.ToInt32(reader["ID_TOUR"].ToString());
                        tour.Nombre = reader["NOMBRE_TOUR"].ToString();
                        tour.ValorP = Convert.ToInt32(reader["VALOR_PERSONAL_TOUR"]).ToString("C", CultureInfo.CurrentCulture);
                        tour.Descripcion = reader["DESC_TOUR"].ToString();
                        tour.Comuna = reader["ID_COMUNA"].ToString();
                        tour.Zona = reader["NOMBRE_REGION"].ToString();

                        Lista.Add(tour);
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
