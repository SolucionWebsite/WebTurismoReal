using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTurismoRea.DAL;

namespace WebTurismoReal.BLL
{
    public class TourBLL
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ValorP { get; set; }
        public string Descripcion { get; set; }
        public string Comuna { get; set; }
        public string Zona { get; set; }

        TourDAL dal = new TourDAL();

        public List<TourBLL> ListaTour(int id_comuna)
        {
            List<TourDAL> lista = dal.ListaTours(id_comuna);
            List<TourBLL> lista2 = new List<TourBLL>();

            foreach (TourDAL c in lista)
            {
                TourBLL tour = new TourBLL();

                tour.Id = c.Id;
                tour.Nombre = c.Nombre;
                tour.ValorP = c.ValorP;
                tour.Descripcion = c.Descripcion;
                tour.Comuna = c.Comuna;
                tour.Zona = c.Zona;
                
                lista2.Add(tour);
            }

            return lista2;
        }
        
    }
}
