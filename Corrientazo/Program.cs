using Corrientazo.Model;
using System;
using System.IO;

namespace Corrientazo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dron dron = new Dron(0,0,0);
            //Console.WriteLine("----"+dron.PuntoCardinal+"----");
            string[] instrucciones = { "A", "A", "A", "A", "I", "A", "A" };
            //string[] instrucciones = { "I", "D", "I", "D", "I", "D", "I" };
            Ruta ruta = new Ruta();
            /*dron = ruta.CalcularRuta(instrucciones, dron);


            Console.WriteLine("Punto Cardinal: " + dron.PuntoCardinal );
            Console.WriteLine("Posicion en X: " + dron.XPosition);
            Console.WriteLine("Posicion en Y: " + dron.YPosition);*/


            string fileName = "prueba.txt.txt";

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            using StreamWriter outputFile = new StreamWriter(@"C:\Users\suaosc01\source\repos\Corrientazo\Corrientazo\bin\Debug\netcoreapp3.1\output.txt",append: true);


            using (var reader = new StreamReader(path))
                //using (FileStream writer = File.OpenWrite(@"C:\Users\suaosc01\source\repos\Corrientazo\Corrientazo\bin\Debug\netcoreapp3.1\output.txt"))
            

            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Do stuff with your line here, it will be called for each 
                    // line of text in your file.
                    Console.WriteLine(line);
                    char[] line2 = line.ToCharArray();
                    dron = ruta.CalcularRuta(line2,dron);
                    Console.WriteLine("Punto Cardinal: " + dron.PuntoCardinal);
                    Console.WriteLine("Posicion en X: " + dron.XPosition);
                    Console.WriteLine("Posicion en Y: " + dron.YPosition);
                    byte[] buffer = new Byte[1024];
                    //writer.writeLine("");
                    outputFile.WriteLineAsync("("+dron.XPosition+","+dron.YPosition+") direccion"+dron.PuntoCardinal);

                }
            }
        }
    }
}
