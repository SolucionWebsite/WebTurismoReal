using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebTurismoReal.BLL;

namespace WebTurismoReal.Tests
{
    [TestClass]
    public class ReservaTest
    { 
        [TestMethod]
        public void AgregarCliente_DatosVálidos_RegistroGuardadoBD()
        {
            //Requerimiento: Crear y mantener registro de clientes
            //Entrada: datos correctos
            //Salida: Registro almacenado en la base de datos, retorno 1

            //Arrange
            ClienteBLL cliente = new ClienteBLL();
            cliente.Rut = "22.340.444-3";
            cliente.Nombre = "Juan Ignacio";
            cliente.ApellidoP = "Pérez";
            cliente.ApellidoM = "Rojas";
            cliente.Telefono = "+56912345678";
            cliente.Correo = "JuanPerez@gmail.com";
            cliente.FechaNac = "06-04-1992";
            cliente.Clave = "1234Juan";
            cliente.GeneroC = 2; //Masculino
            cliente.NacionalidadC = 32; //Chilena

            //Act
            int resultado = cliente.RegistroCliente(cliente);
            
            //Assert
            Assert.IsTrue(resultado == 0);
        }
        
        [TestMethod]
        public void DisponibilidadDeptos_DatosVálidos_RellenoTabla()
        {
            //Requerimiento: Crear un sistema de reservas en donde el usuario pueda acceder fácilmente para arrendar departamentos y agregar servicios extra, además de función de pago.
            //Entrada: Localidad con departamentos disponibles
            //Salida: Relleno de tabla de deptos disponibles

            //Arrange
            DepartamentoBLL departamento = new DepartamentoBLL();
            
            int comuna = 1; //Arica
            
            //Act
            List<DepartamentoBLL> registros = departamento.ListaDepartamentosBuscar(comuna);
            
            //Assert
            Assert.IsTrue(registros.Count >= 1);
        }

        [TestMethod]
        public void LoginCliente_DatosVálidos_IngresoExitoso()
        {
            //Requerimiento: Crear un sistema de reservas en donde el usuario pueda acceder fácilmente para arrendar departamentos y agregar servicios extra, además de función de pago.
            //Entrada: Credenciales válidas
            //Salida: Encontrar credenciales en la BD

            //Arrange
            string usuario = "Marcoantoniorojas@gmail.com";
            string claveEsperada = "1234Marco";
            string claveRegistrada = "";

            //Act
            ClienteBLL cliente = new ClienteBLL();
            List<ClienteBLL> lista = cliente.ListaUsuarios();

            bool existeUsuario = lista.Any(x => x.Correo == usuario);

            if (existeUsuario == true)
            {
                foreach (ClienteBLL c in lista)
                {
                    if (c.Correo == usuario)
                    {
                        claveRegistrada = c.Clave.ToString();
                    }
                }
            }

            //Assert
            Assert.AreEqual(claveEsperada, claveRegistrada);
        }

        [TestMethod]
        public void AgregarAcompañante_DatosVálidos_RegistroGuardadoBD()
        {
            //Requerimiento: Crear y mantener registro de clientes
            //Entrada: datos correctos
            //Salida: Registro almacenado en la base de datos, retorno 1

            //Arrange
            AcompañanteBLL acompañante = new AcompañanteBLL();
            acompañante.Rut = "17.340.444-3";
            acompañante.Nombre = "Marcelo";
            acompañante.ApellidoP = "Pérez";
            acompañante.ApellidoM = "Rojas";
            acompañante.Telefono = "+56934245678";
            acompañante.Correo = "Marcelo@gmail.com";
            acompañante.FechaNac = "13-04-1978";
            acompañante.GeneroC = 2; //Masculino 
            acompañante.NacionalidadC = 32; //Chilena
            acompañante.IdCliente = 1;
            acompañante.IdReserva = 1;

            //Act
            int resultado = acompañante.AgregarAcompañante(acompañante);


            //Assert
            Assert.IsTrue(resultado == 1);
        }

        [TestMethod]
        public void AgregarReserva_DatosVálidos_RegistroGuardadoBD()
        {
            //Requerimiento: Crear un sistema de reservas en donde el usuario pueda acceder fácilmente para arrendar departamentos y agregar servicios extra, además de función de pago.
            //Entrada: datos correctos
            //Salida: Registro almacenado en la base de datos, retorno 1

            //Arrange
            ReservaBLL reserva = new ReservaBLL();

            reserva.FechaEntrada = "02/12/2022";
            reserva.FechaSalida = "12/12/2022";
            reserva.Estado = "Pagada";
            reserva.FechaReserva = "18/10/2021";
            reserva.Abono = "99990";
            reserva.ValorFinal = "199990";
            reserva.IdCliente = 1;
            reserva.IdDepto = 1;
            
            //Act
            reserva.CrearReserva(reserva);


            //Assert
            Assert.IsTrue(reserva.CrearReserva(reserva) == 1);
        }

    }
}
