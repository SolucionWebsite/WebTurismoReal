using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTurismoReal.BLL
{
    public class BodyCorreo
    {
        public string Body(string nombre)
        {
            string mensaje = "Hola," + " " + nombre + "<br/>" +
                "Estamos felices de que nos hayas preferido, por este medio confirmamos que su reserva a sido exitosa, adjuntamos su comprobante de abono el cual será requerido al momento del check-in." + "<br/>" + "<br/>" + 
                
                "¿Qué sigue ahora?,  antes que nada, es de suma importancia que registre los datos de sus acompañantes, esto lo debe hacer en la sección \"Mi cuenta\" -> \"Acompañantes\", este proceso lo puede hacer hasta 5 dias antes del ingreso al departamento." + "<br/>" + "<br/>" +
                "Debe guardar el comprobante adjunto para el día del ingreso al departamento, ya que será requerido en el Check-in, el cuál inicia a las 11:00hrs, y el Check-out a las 20:00hrs." + "<br/>" + "<br/>" +
                
                "Con respecto a Servicios Extra, ahora que ya tienes tu reserva, puedes dirigirte a nuestra página web" + " " + "<a href=\"http://localhost:55243/Index1\">Turismoreal.cl</a>" + " " +
                "en nuestra sección llamada \"Servicios\", donde te puedes enterar de los servicios que tenemos disponibles, sus valores y restricciones, luego puedes entrar a tu cuenta con tus credenciales y en la sección \"Mi cuenta\" -> \"Servicios Extra\" puedes agregar, modificar y cancelar todos los servicios extra que desees." + "<br/>" + "<br/>" +

                "Esperamos que disfrute su estadía en nuestros departamentos," + "<br/>" + "<br/>" +
                "Atentamente, El equipo de Turismo Real.";
            return mensaje;
        }
    }
}
