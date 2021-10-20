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
        public void ActualizaciónCliente_DatosVálidos_RegistroGuardadoBD()
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


    }
}
