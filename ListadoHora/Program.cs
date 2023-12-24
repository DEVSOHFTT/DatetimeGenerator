using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListadoHora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Se establece una fecha inicial para generar el listado de horas
            DateTime fecha = new DateTime(2023, 6, 1, 8, 0, 0);

            // Se crea un objeto Random para generar valores aleatorios
            Random random = new Random();

            // Lista para almacenar las fechas generadas
            List<string> dias = new List<string>();

            // Variable de control para salir del bucle
            bool ok = false;

            // Bucle principal para generar fechas hasta que se cumpla la condición
            while (!ok)
            {
                // Generar fechas hasta las 19:00
                while (fecha.Hour <= 19)
                {
                    // Agregar la fecha actual a la lista
                    dias.Add(fecha.ToString());

                    // Incrementar la fecha aleatoriamente
                    fecha = fecha.AddSeconds(random.Next(3, 56));
                    fecha = fecha.AddMinutes(random.Next(3, 13));
                }

                // Avanzar a la siguiente fecha
                fecha = fecha.AddDays(1);
                fecha = new DateTime(2023, fecha.Month, fecha.Day, 8, 0, 0);

                // Comprobar si el mes es mayor a junio para salir del bucle
                if (fecha.Month > 6)
                {
                    ok = true;
                }
            }

            // Ruta del archivo para guardar las fechas
            string rutaArchivo = "fechas.txt";

            // Escribir las fechas en un archivo de texto
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                foreach (string fechaTexto in dias)
                {
                    writer.WriteLine(fechaTexto);
                }
            }

            // Mostrar información al usuario
            Console.WriteLine("Las fechas se han guardado en el archivo 'fechas.txt'. Registros = " + dias.Count);
            Console.ReadLine();
        }
    }
}

