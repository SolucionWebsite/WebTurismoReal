using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTurismoRea.DAL;

namespace WebTurismoReal.BLL
{
    public class DepartamentoBLL
    {
        public string Id { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Provincia { get; set; }
        public string Region { get; set; }
        public string Habitaciones { get; set; }
        public string Baños { get; set; }
        public string Valor_Dia { get; set; }

        DepartamentoDAL depto = new DepartamentoDAL();

        public DataTable Departamentos(int id_region, int id_provincia, int id_comuna)
        {
            DataTable registrosDeptos = depto.Departamentos(id_region, id_provincia, id_comuna);

            return registrosDeptos;
        }

        public bool BuscarDepartamento(int codigo)
        {
            if (depto.DetalleDepartamento(codigo) == true)
            {
                Id = depto.Id;
                Direccion = depto.Direccion;
                Comuna = depto.Comuna;
                Provincia = depto.Provincia;
                Region = depto.Region;
                Habitaciones = depto.Habitaciones;
                Baños = depto.Baños;
                Valor_Dia = depto.Valor_Dia;
            }
            return true;
        }
    }
}

