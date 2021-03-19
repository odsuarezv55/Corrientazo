using Corrientazo.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Corrientazo
{
    class FileHandler
    {
        public Boolean CreateOutputFile(int iteration, Dron dron, string outpuPath)
        {
            
            string outputNumber;
            string direccion="";
            

            if (iteration < 10)
                outputNumber = "0" + iteration;
            else
                outputNumber = iteration.ToString();


            using StreamWriter outputFile = new StreamWriter(outpuPath, append: true);


            if (dron.error != null)
            {
                outputFile.WriteLine(dron.error);
                Console.WriteLine(dron.error);
                outputFile.Close();
                return false;
            }


            switch (dron.PuntoCardinal)
            {
                case Dron.Orientacion.N:
                    direccion = "Norte";
                    break;
                case Dron.Orientacion.E:
                    direccion = "Oriente";
                    break;
                case Dron.Orientacion.S:
                    direccion = "Sur";
                    break;
                case Dron.Orientacion.W:
                    direccion = "Oeste";
                    break;
            }


            


            Console.WriteLine("Punto Cardinal: " + dron.PuntoCardinal);
            Console.WriteLine("Posicion en X: " + dron.XPosition);
            Console.WriteLine("Posicion en Y: " + dron.YPosition);
            //outpuPath = "C:\\Users\\suaosc01\\source\\repos\\Corrientazo\\Corrientazo\\bin\\Debug\\netcoreapp3.1\\out" + outputNumber + ".txt";
            

            
            //outputFile.WriteLineAsync("(" + dron.XPosition + "," + dron.YPosition + ") direccion " + direccion);
            outputFile.WriteLine("(" + dron.XPosition + "," + dron.YPosition + ") direccion " + direccion);
            outputFile.Close();

            return true;
        }
    }
}
