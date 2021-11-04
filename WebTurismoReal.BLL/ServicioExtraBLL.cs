using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTurismoRea.DAL;

namespace WebTurismoReal.BLL
{
    public class ServicioExtraBLL
    {
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

        ServicioExtraDAL dal = new ServicioExtraDAL();

        public int AgregarServicioExtra(ServicioExtraBLL servicio)
        {
            int retorno;
            
            dal.FechaAsistencia = FechaAsistencia;
            dal.Asistentes = Asistentes;
            dal.IdTour = IdTour;
            dal.IdTransporte = IdTransporte;
            dal.IdReserva = IdReserva;

            retorno = dal.AgregarServicioExtra(dal);

            return retorno;
        }

        public List<ServicioExtraBLL> ListaServiciosExtra(int id_reserva)
        {
            List<ServicioExtraDAL> lista = dal.ListaServicioExtra(id_reserva);
            List<ServicioExtraBLL> lista2 = new List<ServicioExtraBLL>();

            foreach (ServicioExtraDAL c in lista)
            {
                ServicioExtraBLL s = new ServicioExtraBLL();

                s.Id = c.Id;
                s.ValorTotal = c.ValorTotal;
                s.FechaAsistencia = c.FechaAsistencia;
                s.Hora = c.Hora;
                s.Asistentes = c.Asistentes;
                s.IdTour = c.IdTour;
                s.NombreTour = c.NombreTour;
                s.ValorPTour = c.ValorPTour;
                s.IdTransporte = c.IdTransporte;
                s.Trayecto = c.Trayecto;
                s.Vehiculo = c.Vehiculo;
                s.Asientos = c.Asientos;
                s.ValorPTransporte = c.ValorPTransporte;
                s.IdReserva = c.IdReserva;
                
                lista2.Add(s);
            }

            return lista2;
        }

        public int ModificarServicioExtra(ServicioExtraBLL servicio)
        {
            int retorno;

            dal.Id = Id;
            dal.FechaAsistencia = FechaAsistencia;
            dal.Asistentes = Asistentes;
            dal.IdTour = IdTour;
            dal.IdTransporte = IdTransporte;
            dal.IdReserva = IdReserva;

            retorno = dal.ModificarServicioExtra(dal);

            return retorno;
        }

        public int EliminarServicioExtra(int id_servicio, int id_reserva)
        {
            int retorno;

            ServicioExtraDAL a = new ServicioExtraDAL();

            retorno = a.EliminarServicioExtra(id_servicio, id_reserva);

            return retorno;
        }
    }
}
