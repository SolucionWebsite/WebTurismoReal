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
        public Byte[] Imagen { get; set; }

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

        public List<DepartamentoBLL> ListaDepartamentosBuscar(int codigo)
        {
            DepartamentoDAL dal = new DepartamentoDAL();

            List<DepartamentoDAL> lista = dal.ListaDepartamentosBuscar(codigo);
            List<DepartamentoBLL> lista2 = new List<DepartamentoBLL>();

            foreach (DepartamentoDAL c in lista)
            {
                DepartamentoBLL depto = new DepartamentoBLL();

                depto.Id = c.Id;
                depto.Valor_Dia = c.Valor_Dia;
                depto.Comuna = c.Comuna;

                lista2.Add(depto);
            }

            return lista2;
        }

        public List<DepartamentoBLL> ListaDepartamentos(int id_comuna)
        {
            DepartamentoDAL dal = new DepartamentoDAL();

            List<DepartamentoDAL> lista = dal.ListaDepartamentos(id_comuna);
            List<DepartamentoBLL> lista2 = new List<DepartamentoBLL>();

            foreach (DepartamentoDAL c in lista)
            {
                DepartamentoBLL depto = new DepartamentoBLL();

                depto.Id = c.Id;
                depto.Direccion = c.Direccion;
                depto.Comuna = c.Comuna;
                depto.Provincia = c.Provincia;
                depto.Region = c.Region;
                depto.Habitaciones = c.Habitaciones;
                depto.Baños = c.Baños;
                depto.Valor_Dia = c.Valor_Dia;
                depto.Imagen = c.Imagen;

                lista2.Add(depto);
            }

            return lista2;
        }
    }
}

