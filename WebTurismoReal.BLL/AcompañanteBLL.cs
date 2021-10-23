using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTurismoRea.DAL;

namespace WebTurismoReal.BLL
{
    public class AcompañanteBLL
    {
        public string Id { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string FechaNac { get; set; }
        public int GeneroC { get; set; }
        public int NacionalidadC { get; set; }
        public int IdCliente { get; set; }
        public int IdReserva { get; set; }

        public List<AcompañanteBLL> ListaAcompañantes(int id_cliente, int id_reserva)
        {
            AcompañanteDAL dal = new AcompañanteDAL();

            List<AcompañanteDAL> lista = dal.RegistroAcompañantes(id_cliente, id_reserva);
            List<AcompañanteBLL> lista2 = new List<AcompañanteBLL>();

            foreach (AcompañanteDAL c in lista)
            {
                AcompañanteBLL acompañante = new AcompañanteBLL();

                acompañante.Id = c.Id;
                acompañante.Rut = c.Rut;
                acompañante.Nombre = c.Nombre;
                acompañante.ApellidoP = c.ApellidoP;
                acompañante.ApellidoM = c.ApellidoM;
                acompañante.Telefono = c.Telefono;
                acompañante.Correo = c.Correo;
                acompañante.FechaNac = c.FechaNac;
                acompañante.GeneroC = c.GeneroC;
                acompañante.NacionalidadC = c.NacionalidadC;
                acompañante.IdCliente = c.IdCliente;
                acompañante.IdReserva = c.IdReserva;

                lista2.Add(acompañante);
            }

            return lista2;
        }

        public int AgregarAcompañante(AcompañanteBLL acompañante)
        {
            int retorno;

            AcompañanteDAL registros = new AcompañanteDAL();

            registros.Id = Id;
            registros.Rut = Rut;
            registros.Nombre = Nombre;
            registros.ApellidoP = ApellidoP;
            registros.ApellidoM = ApellidoM;
            registros.Telefono = Telefono;
            registros.Correo = Correo;
            registros.FechaNac = FechaNac;
            registros.GeneroC = GeneroC;
            registros.NacionalidadC = NacionalidadC;
            registros.IdCliente = IdCliente;
            registros.IdReserva = IdReserva;

            retorno = registros.AgregarAcompañante(registros);

            return retorno;
        }

        public List<AcompañanteBLL> ListaA(int id_cliente, int id_reserva)
        {
            AcompañanteDAL dal = new AcompañanteDAL();


            List<AcompañanteDAL> lista = dal.RegistroAcompañantes(id_cliente, id_reserva);

            List<AcompañanteBLL> listaNueva = new List<AcompañanteBLL>();

            foreach (AcompañanteDAL a in lista)
            {
                AcompañanteBLL acompañante = new AcompañanteBLL();

                acompañante.Id = a.Id;
                acompañante.Nombre = a.Nombre;
                acompañante.ApellidoP = a.ApellidoP;
                acompañante.ApellidoM = a.ApellidoM;
                acompañante.Rut = a.Rut;
                acompañante.FechaNac = a.FechaNac.Substring(0, 10);
                acompañante.Telefono = a.Telefono;
                acompañante.Correo = a.Correo;

                listaNueva.Add(acompañante);
            }

            return listaNueva;
        }

        public int ModificarAcompañante(string rutAcompañante, AcompañanteBLL acompañante)
        {
            int retorno;

            AcompañanteDAL registros = new AcompañanteDAL();

            registros.Rut = Rut;
            registros.Nombre = Nombre;
            registros.ApellidoP = ApellidoP;
            registros.ApellidoM = ApellidoM;
            registros.Telefono = Telefono;
            registros.Correo = Correo;
            registros.FechaNac = FechaNac;
            registros.IdCliente = IdCliente;
            registros.GeneroC = GeneroC;
            registros.NacionalidadC = NacionalidadC;
            registros.IdReserva = IdReserva;
            
            retorno = registros.ModificarAcompañante(rutAcompañante, registros);

            return retorno;
        }

        public int EliminarAcompañantes(string rut, string idReserva)
        {
            int retorno;

            AcompañanteDAL a = new AcompañanteDAL();

            retorno = a.EliminarAcompañante(rut, idReserva);

            return retorno;
        }
    }
}
