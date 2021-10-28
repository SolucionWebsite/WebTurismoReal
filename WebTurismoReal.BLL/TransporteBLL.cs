using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTurismoRea.DAL;

namespace WebTurismoReal.BLL
{
    public class TransporteBLL
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public int IdTipoVehiculo { get; set; }
        public string TipoVehiculo { get; set; }
        public string Asientos { get; set; }
        public int IdTrayecto { get; set; }
        public string Trayecto { get; set; }

        TransporteDAL dal = new TransporteDAL();

        public List<TransporteBLL> ListaTransporte(int id_tipo_trayecto)
        {
            List<TransporteDAL> lista = dal.ListaTransporte(id_tipo_trayecto);
            List<TransporteBLL> lista2 = new List<TransporteBLL>();

            foreach (TransporteDAL c in lista)
            {
                TransporteBLL transporte = new TransporteBLL();

                transporte.Id = c.Id;
                transporte.Valor = c.Valor;
                transporte.IdTipoVehiculo = c.IdTipoVehiculo;
                transporte.TipoVehiculo = c.TipoVehiculo;
                transporte.Asientos = c.Asientos;
                transporte.IdTrayecto = c.IdTrayecto;
                transporte.Trayecto = c.Trayecto;

                lista2.Add(transporte);
            }

            return lista2;
        }
    }
}
