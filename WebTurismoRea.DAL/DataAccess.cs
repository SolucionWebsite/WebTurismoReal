using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTurismoRea.DAL
{
    public class DataAccess
    {
        public OracleConnection Connection()
        {
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=ADMINTURISMOREAL;Password=adminpass123";
            
            return new OracleConnection(connectionString);
        }
    }
}
