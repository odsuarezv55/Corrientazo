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

            string direccion="";
            


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
    
            outputFile.WriteLine("(" + dron.XPosition + "," + dron.YPosition + ") direccion " + direccion);
            outputFile.Close();

            return true;
        }
    }
}
