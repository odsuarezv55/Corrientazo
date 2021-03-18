using Corrientazo.Model;
using System;
using System.IO;

namespace Corrientazo
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int iterations = Int32.Parse(args[0]);
            string inputNumber, inputFileName, inputPath, outputPath, outputFileName;

            

            Console.WriteLine(args[0]);
            

            
            Ruta ruta = new Ruta();
            FileHandler fileHandler = new FileHandler();
            

            for (int i=0; i<iterations; i++)
            {
                Dron dron = new Dron(0, 0, 0);
                if ((iterations) < 9)
                    inputNumber = "0" + (i+1);
                else
                    inputNumber = (i+1).ToString();
                inputFileName = "entrega" + inputNumber + ".txt.txt";
                outputFileName = "out" + inputNumber + ".txt";
                inputPath = Path.Combine(Environment.CurrentDirectory, inputFileName);
                outputPath = Path.Combine(Environment.CurrentDirectory, outputFileName);
                if (File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }
                //using StreamWriter outputFile = new StreamWriter(outputPath, append: true);

                using (var reader = new StreamReader(inputPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Do stuff with your line here, it will be called for each 
                        // line of text in your file.
                        Console.WriteLine(line);
                        char[] line2 = line.ToCharArray();
                        dron = ruta.CalcularRuta(line2, dron);
                        Console.WriteLine("Punto Cardinal: " + dron.PuntoCardinal);
                        Console.WriteLine("Posicion en X: " + dron.XPosition);
                        Console.WriteLine("Posicion en Y: " + dron.YPosition);


                        fileHandler.CreateOutputFile(i + 1, dron, outputPath);
                    }

                }
                

            }

            

            

            


            
        }
    }
}
