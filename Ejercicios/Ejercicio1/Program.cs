using System;
using System.Net;
using System.IO;

using Newtonsoft.Json.Linq;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el nombre de la pelicula");

            string nombre = Console.ReadLine();
            WebRequest req = WebRequest.Create("http://www.omdbapi.com/?t="+nombre);

            WebResponse respuesta = req.GetResponse();

            Stream stream = respuesta.GetResponseStream();

            StreamReader sr = new StreamReader(stream);

            JObject data = JObject.Parse(sr.ReadToEnd());

            string titulo = (string)data["Year"];

            Console.WriteLine("Esta pelicula salio en "+ titulo);

            Console.ReadKey(true);
        }

    }
}
