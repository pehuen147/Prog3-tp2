using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el nombre de la ciudad");

            
            string nombre = Console.ReadLine();

            string tipo;

            int cont = 0;

            WebRequest req = WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address=" + nombre);

            WebResponse respuesta = req.GetResponse();

            Stream stream = respuesta.GetResponseStream();

            StreamReader sr = new StreamReader(stream);

            JObject data = JObject.Parse(sr.ReadToEnd());
            
            do
            {
                tipo = (string)data["results"][0]["address_components"][cont]["types"][0];
                if (tipo != "country")
                    cont++;
            } while (tipo != "country");
            

            string pais = (string)data["results"][0]["address_components"][cont]["long_name"];



            Console.WriteLine(pais);

            Console.ReadKey(true);

        }
    }
}
