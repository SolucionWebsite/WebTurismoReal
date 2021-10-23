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
    public class DepartamentoDAL
    {
        DataAccess da = new DataAccess();

        public string Id { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Provincia { get; set; }
        public string Region { get; set; }
        public string Habitaciones { get; set; }
        public string Baños { get; set; }
        public string Valor_Dia { get; set; }
        public Byte[] Imagen { get; set; }

        public DataTable Departamentos(int id_region, int id_provincia, int id_comuna)
        {
            using (da.Connection())
            {
                DataTable departamentosDisponibles = null;

                try
                {
                    OracleCommand cmd = new OracleCommand("LISTARDEPARTAMENTOS", da.Connection());
                    cmd.CommandText = "LISTARDEPARTAMENTOS";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("region_id", id_region);
                    cmd.Parameters.Add("provincia_id", id_provincia);
                    cmd.Parameters.Add("comuna_id", id_comuna);

                    OracleDataAdapter adapter = new OracleDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    departamentosDisponibles = tabla;
                    int cantidad = tabla.Rows.Count;

                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al encontrar registros: " + ex.Message);
                }

                return departamentosDisponibles;
            }
        }

        public bool DetalleDepartamento(int codigo)
        {
            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("DETALLEDEPTO", da.Connection())
                    {
                        CommandText = "DETALLEDEPTO",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter
                    {
                        OracleDbType = OracleDbType.RefCursor,
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("codigo", codigo);

                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        Id = reader["ID"].ToString();
                        Direccion = reader["DIRECCION"].ToString();
                        Comuna = reader["COMUNA"].ToString();
                        Provincia = reader["PROVINCIA"].ToString();
                        Region = reader["REGION"].ToString();
                        Habitaciones = reader["HABITACIONES"].ToString();
                        Baños = reader["BAÑOS"].ToString();
                        Valor_Dia = reader["VALOR_DIA"].ToString();
                    }
                    cmd.Connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return true;
            }
        }

        public List<DepartamentoDAL> ListaDepartamentos(int idComuna)
        {
            List<DepartamentoDAL> Lista = new List<DepartamentoDAL>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("LISTARDEPARTAMENTOS", da.Connection());
                    cmd.CommandText = "LISTARDEPARTAMENTOS";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter();
                    prm.OracleDbType = OracleDbType.RefCursor;
                    prm.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("comuna_id", idComuna);
                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        DepartamentoDAL depto = new DepartamentoDAL();

                        depto.Id = reader["ID"].ToString();
                        depto.Direccion = reader["DIRECCION"].ToString();
                        depto.Comuna = reader["COMUNA"].ToString();
                        depto.Provincia = reader["PROVINCIA"].ToString();
                        depto.Region = reader["REGION"].ToString();
                        depto.Habitaciones = reader["HABITACIONES"].ToString();
                        depto.Baños = reader["BAÑOS"].ToString();
                        depto.Valor_Dia = Convert.ToInt32(reader["VALOR_DÍA"]).ToString("C", CultureInfo.CurrentCulture);
                        byte[] byteBLOBData = new Byte[0];
                        try
                        {
                            byteBLOBData = (Byte[])(reader["FOTO"]);
                            depto.Imagen = byteBLOBData;

                            Lista.Add(depto);
                        }
                        catch (Exception)
                        {
                            depto.Imagen = byteBLOBData;
                            Lista.Add(depto);
                        }
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

        public List<DepartamentoDAL> ListaDepartamentosBuscar(int codigo)
        {
            List<DepartamentoDAL> Lista = new List<DepartamentoDAL>();

            using (da.Connection())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("BUSCARDEPTOID", da.Connection());
                    cmd.CommandText = "BUSCARDEPTOID";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    OracleParameter prm = new OracleParameter();
                    prm.OracleDbType = OracleDbType.RefCursor;
                    prm.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(prm);
                    cmd.Parameters.Add("codigo", codigo);
                    cmd.ExecuteNonQuery();

                    OracleRefCursor cursor = (OracleRefCursor)prm.Value;
                    OracleDataReader reader = cursor.GetDataReader();

                    while (reader.Read())
                    {
                        DepartamentoDAL depto = new DepartamentoDAL();

                        depto.Id = reader["ID_DPTO"].ToString();
                        depto.Valor_Dia = reader["VALOR_DIARIO_DPTO"].ToString();
                        depto.Comuna = reader["COMUNA_ID_COMUNA"].ToString();
                        Lista.Add(depto);
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
