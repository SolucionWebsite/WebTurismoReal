using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebTurismoReal.BLL;

namespace WebTurismoReal.Tests
{
    [TestClass]
    public class CuentaTest
    {
        [TestMethod]
        public void ModificarCliente_DatosVálidos_RegistroGuardadoBD()
        {
            //Requerimiento: Crear y mantener registro de clientes
            //Entrada: datos correctos
            //Salida: Registro almacenado en la base de datos, retorno 1

            //Arrange
            ClienteBLL cliente = new ClienteBLL();

            cliente.Rut = "17.340.444-3";
            cliente.Nombre = "Marco Antonio";
            cliente.ApellidoP = "Pérez";
            cliente.ApellidoM = "Rojas";
            cliente.Telefono = "+56911223344"; //Dato a modificar
            cliente.Correo = "Marcoantoniorojas@gmail.com";
            cliente.FechaNac = "06-04-1992";
            cliente.Clave = "1234Marco";
            cliente.GeneroC = 2;
            cliente.NacionalidadC = 32;

            string rutCliente = cliente.Rut;

            //Act
            cliente.ModificarCliente(rutCliente, cliente);


            //Assert
            Assert.IsTrue(cliente.ModificarCliente(rutCliente, cliente) == 1);
        }

        [TestMethod]
        public void LeerDatosCliente_TraerDatosDesdeBD()
        {
            //Requerimiento: Crear y mantener registro de clientes
            //Entrada: N/A
            //Salida: Traer registros almacenados en la BD

            //Arrange
            ClienteBLL cliente = new ClienteBLL();
            List<ClienteBLL> lista = new List<ClienteBLL>();

            //Act
            lista = cliente.ListaUsuarios();
            
            //Assert
            Assert.IsTrue(lista.Count > 0);
        }

        [TestMethod]
        public void ModificarReserva_DatosVálidos_RegistroGuardadoBD()
        {
            //Requerimiento: Crear y mantener registro de clientes
            //Entrada: datos correctos
            //Salida: Registro almacenado en la base de datos, retorno 1

            //Arrange
            ReservaBLL reserva = new ReservaBLL();

            reserva.Id = 1;
            reserva.Estado = "Pagada";
            reserva.IdCliente = 1;
            reserva.IdDepto = 1;
            
            //Act
            reserva.ModificarReserva(reserva);
            
            //Assert
            Assert.IsTrue(reserva.ModificarReserva(reserva) == 1);
        }
        

        [TestMethod]
        public void ModificarAcompañante_DatosVálidos_RegistroGuardadoBD()
        {
            //Requerimiento: Crear y mantener registro de clientes
            //Entrada: datos correctos
            //Salida: Registro almacenado en la base de datos, retorno 1

            //Arrange
            AcompañanteBLL acompañante = new AcompañanteBLL();

            string rut = "22.544.475-k";
            acompañante.Correo = "yeyo@gmail.com";

            //Act
            acompañante.ModificarAcompañante(rut, acompañante);

            //Assert
            Assert.IsTrue(acompañante.ModificarAcompañante(rut, acompañante) == 1);
        }

        [TestMethod]
        public void EliminarAcompañante_DatosVálidos_RegistroEliminadoBD()
        {
            //Requerimiento: Crear y mantener registro de clientes
            //Entrada: datos correctos
            //Salida: Registro almacenado en la base de datos, retorno 1

            //Arrange
            AcompañanteBLL acompañante = new AcompañanteBLL();

            string rut = "17.340.444-3";
            string idReserva = "1";

            //Act
            int resultado = acompañante.EliminarAcompañantes(rut, idReserva);

            //Assert
            Assert.IsTrue(resultado == 1);
        }

        [TestMethod]
        public void AgregarServicio_DatosVálidos_RegistroRegistradoBD()
        {
            //Requerimiento: Crear y mantener registro de clientes
            //Entrada: datos correctos
            //Salida: Registro almacenado en la base de datos, retorno 1

            //Arrange
            ServicioExtraBLL s = new ServicioExtraBLL();

            s.FechaAsistencia = "09/11/2021 09:00";
            s.Asistentes = 3;
            s.IdTour = 22;
            s.IdTransporte = null;
            s.IdReserva = 1;

            //Act
            int resultado = s.AgregarServicioExtra(s);

            //Assert
            Assert.IsTrue(resultado == 1);
        }

        [TestMethod]
        public void EliminarServicio_DatosVálidos_RegistroEliminadoBD()
        {
            //Requerimiento: Crear y mantener registro de clientes
            //Entrada: datos correctos
            //Salida: Registro almacenado en la base de datos, retorno 1

            //Arrange
            ServicioExtraBLL servicio = new ServicioExtraBLL();

            int idServicio = 1;
            int idReserva = 1;

            //Act
            int resultado = servicio.EliminarServicioExtra(idServicio, idReserva);

            //Assert
            Assert.IsTrue(resultado == 1);
        }
    }
}
