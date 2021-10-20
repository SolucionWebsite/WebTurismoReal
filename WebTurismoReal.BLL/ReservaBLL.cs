using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTurismoRea.DAL;

namespace WebTurismoReal.BLL
{
    public class ReservaBLL
    {
        public int Id { get; set; }
        public string FechaEntrada { get; set; }
        public string FechaSalida { get; set; }
        public string Estado { get; set; }
        public string FechaReserva { get; set; }
        public string Abono { get; set; }
        public string ValorFinal { get; set; }
        public int IdCliente { get; set; }
        public int IdDepto { get; set; }

        ReservaDAL reservaDAL = new ReservaDAL();

        public int CrearReserva(ReservaBLL reserva)
        {
            int retorno;

            reservaDAL.FechaEntrada = FechaEntrada;
            reservaDAL.FechaSalida = FechaSalida;
            reservaDAL.Estado = Estado;
            reservaDAL.FechaReserva= FechaReserva;
            reservaDAL.IdCliente = IdCliente;
            reservaDAL.IdDepto = IdDepto;

            retorno = reservaDAL.AgregarReserva(reservaDAL);

            return retorno;
        }

        public List<ReservaBLL> Reservas(int id_cliente)
        {
            List<ReservaDAL> lista = reservaDAL.Reservas(id_cliente);
            List<ReservaBLL> lista2 = new List<ReservaBLL>();

            foreach (ReservaDAL c in lista)
            {
                ReservaBLL reserva = new ReservaBLL();

                reserva.FechaEntrada = c.FechaEntrada;
                reserva.FechaSalida = c.FechaSalida;
                reserva.Estado = c.Estado;
                reserva.FechaReserva = c.FechaReserva;
                reserva.IdCliente = c.IdCliente;
                reserva.IdDepto = c.IdDepto;

                lista2.Add(reserva);
            }

            return lista2;
        }


    }
}
