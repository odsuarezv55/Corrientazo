using Corrientazo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Corrientazo.Model.Dron;

namespace Corrientazo
{
    public class Ruta
    {
        //private readonly string[] instructions;
        /*
        public Ruta(string[] instructions)
        {
            this.instructions = instructions;
        }*/

        public DictionaryInstructions dictionary = new DictionaryInstructions();
        public Dron CalcularRuta(char[] instructions, Dron dron, int range)
        {
            //string initial = "N";
            char[] allowed = { 'A', 'I', 'D' };

            if (instructions.Any(c=>!allowed.Contains(c)))
            {
                dron.error = "Caracter no permitido";
                return dron;
            }
            
            foreach (var item in instructions)
            {
         

                Console.WriteLine("Procesando " + item);

                if (item.ToString() == "A")
                    dron = ProcessStep(dron);
                else if (item.ToString() == "I" || item.ToString() == "D")
                {
                    dron.PuntoCardinal = ProcessOrientationChange(dron.PuntoCardinal, item.ToString());
                    Console.WriteLine("Cambio a sentido "+dron.PuntoCardinal);
                }
                    
                else
                    Console.WriteLine("Not valid instruction");

            }

            if (dron.XPosition > range || dron.XPosition < -(range) || dron.YPosition > range || dron.YPosition < -(range))
            {
                
                string error = "Ruta fuera del rango permitido en punto ("+dron.XPosition+","+dron.YPosition+")";
                dron.error = error;
            }
                

            return dron;
           
        }

        public Orientacion ProcessOrientationChange(Orientacion intialOrientation, string instruction)
        {   
         
            return dictionary.instructionResult2[intialOrientation + instruction];
        }
        public Dron ProcessStep(Dron dron)
        {
            switch (dron.PuntoCardinal)
            {
                case Dron.Orientacion.N:
                    dron.YPosition = dron.YPosition+1;
                    Console.WriteLine("Avanzo en Y "+"("+dron.XPosition+","+dron.YPosition+")");
                    break;
                case Dron.Orientacion.E:
                    dron.XPosition = dron.XPosition + 1;
                    Console.WriteLine("Avanzo en X " + "(" + dron.XPosition + "," + dron.YPosition + ")");
                    break;
                case Dron.Orientacion.S:
                    dron.YPosition = dron.YPosition - 1;
                    Console.WriteLine("Retrocedo en Y " + "(" + dron.XPosition + "," + dron.YPosition + ")");
                    break;
                case Dron.Orientacion.W:
                    dron.XPosition = dron.XPosition - 1;
                    Console.WriteLine("Retrocedo en X " + "(" + dron.XPosition + "," + dron.YPosition + ")");
                    break;
            }
            return dron;
        }
    }
}
