using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTurismoRea.DAL;

namespace WebTurismoReal.BLL
{
    public class ClienteBLL
    {
        public string Id { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string FechaNac { get; set; }
        public string Clave { get; set; }
        public int GeneroC { get; set; }
        public int NacionalidadC { get; set; }

        public DataSet Nacionalidad()
        {
            ClienteDAL registros = new ClienteDAL();

            DataSet registrosNacionalidad = registros.Nacionalidad();

            return registrosNacionalidad;
        }

        public DataSet Genero()
        {
            ClienteDAL registros = new ClienteDAL();

            DataSet registrosGenero = registros.Genero();

            return registrosGenero;
        }

        public int RegistroCliente(ClienteBLL cliente)
        {
            int retorno;

            ClienteDAL registros = new ClienteDAL();

            registros.Id = Id;
            registros.Rut = Rut;
            registros.Nombre = Nombre;
            registros.ApellidoP = ApellidoP;
            registros.ApellidoM = ApellidoM;
            registros.Telefono = Telefono;
            registros.Correo = Correo;
            registros.FechaNac = FechaNac;
            registros.Clave = Clave;
            registros.GeneroC = GeneroC;
            registros.NacionalidadC = NacionalidadC;

            retorno = registros.AgregarCliente(registros);

            return retorno;
        }

        public List<ClienteBLL> ListaUsuarios()
        {
            ClienteDAL dal = new ClienteDAL();

            List<ClienteDAL> lista = dal.RegistrosClientes();
            List<ClienteBLL> lista2 = new List<ClienteBLL>();

            foreach (ClienteDAL c in lista)
            {
                ClienteBLL cliente = new ClienteBLL();

                cliente.Id = c.Id;
                cliente.Rut = c.Rut;
                cliente.Nombre = c.Nombre;
                cliente.ApellidoP = c.ApellidoP;
                cliente.ApellidoM = c.ApellidoM;
                cliente.Telefono = c.Telefono;
                cliente.Correo = c.Correo;
                cliente.FechaNac = c.FechaNac;
                cliente.Clave = c.Clave;
                cliente.GeneroC = c.GeneroC;
                cliente.NacionalidadC = c.NacionalidadC;

                lista2.Add(cliente);
            }

            return lista2;
        }

        public int ModificarCliente(string rutCliente, ClienteBLL cliente)
        {
            int retorno;

            ClienteDAL registros = new ClienteDAL();
            
            registros.Rut = Rut;
            registros.Nombre = Nombre;
            registros.ApellidoP = ApellidoP;
            registros.ApellidoM = ApellidoM;
            registros.Telefono = Telefono;
            registros.Correo = Correo;
            registros.FechaNac = FechaNac;
            registros.Clave = Clave;
            registros.GeneroC = GeneroC;
            registros.NacionalidadC = NacionalidadC;

            retorno = registros.ModificarCliente(rutCliente, registros);

            return retorno;
        }


    }
}
