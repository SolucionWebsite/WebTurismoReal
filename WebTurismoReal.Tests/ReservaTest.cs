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
        public void RegistroCliente_DatosVálidos_RegistroGuardadoBD()
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
            cliente.Telefono = "+56948497989";
            cliente.Correo = "Marcoantoniorojas@gmail.com";
            cliente.FechaNac = "06-04-1992";
            cliente.Clave = "1234Marco";
            cliente.GeneroC = 2;
            cliente.NacionalidadC = 32;

            //Act
            cliente.RegistroCliente(cliente);


            //Assert
            Assert.IsTrue(cliente.RegistroCliente(cliente) == 1);
        }
        
        [TestMethod]
        public void DisponibilidadDeptos_DatosVálidos_RellenoTabla()
        {
            //Requerimiento: Crear un sistema de reservas en donde el usuario pueda acceder fácilmente para arrendar departamentos y agregar servicios extra, además de función de pago.
            //Entrada: Localidad con departamentos disponibles
            //Salida: Relleno de tabla de deptos disponibles

            //Arrange
            DepartamentoBLL departamento = new DepartamentoBLL();

            int region = 1; //Arica y Parinacota
            int provincia = 1; //Arica
            int comuna = 1; //Arica
            
            //Act
            DataTable registros = departamento.Departamentos(region, provincia, comuna);
            
            //Assert
            Assert.IsTrue(registros.Rows.Count > 1);
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
        public void RegistroAcompañante_DatosVálidos_RegistroGuardadoBD()
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
            acompañante.GeneroC = 2;
            acompañante.NacionalidadC = 32;
            acompañante.IdCliente = 1;
            acompañante.IdReserva = 1;

            //Act
            acompañante.AgregarAcompañante(acompañante);


            //Assert
            Assert.IsTrue(acompañante.AgregarAcompañante(acompañante) == 1);
        }

    }
}
