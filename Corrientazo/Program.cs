﻿using Corrientazo.Model;
using System;
using System.IO;
using System.Linq;

namespace Corrientazo
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int cuadras = Int32.Parse(args[0]);
            int almuerzos = Int32.Parse(args[1]);
            string inputNumber, inputFileName, inputPath, outputPath, outputFileName;

            bool rutaValida;

            

            Console.WriteLine(args[0]);
            

            
            Ruta ruta = new Ruta();
            FileHandler fileHandler = new FileHandler();
            

            for (int i=0; i<20; i++)
            {
                Dron dron = new Dron(0, 0, 0);

                if ((i) < 9)
                    inputNumber = "0" + (i+1);
                else
                    inputNumber = (i+1).ToString();
                inputFileName = "in" + inputNumber + ".txt";
                outputFileName = "out" + inputNumber + ".txt";
                inputPath = Path.Combine(Environment.CurrentDirectory, inputFileName);
                outputPath = Path.Combine(Environment.CurrentDirectory, outputFileName);
                if (File.Exists(outputPath))
                {
                    File.Delete(outputPath);
                }
                using StreamWriter outputFile = new StreamWriter(outputPath, append: true);
                outputFile.WriteLine("== Reporte de Entregas ==");
                outputFile.Close();

                using (var reader = new StreamReader(inputPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (File.ReadAllLines(inputPath).Length!=almuerzos)
                        {
                            using StreamWriter outputFile2 = new StreamWriter(outputPath, append: true);
                            outputFile2.WriteLine("La cantidad de almuerzos no corresponde a la capacidad del restaurante");
                            outputFile2.Close();
                            break;
                        }


                        
                        Console.WriteLine(line);
                        char[] line2 = line.ToCharArray();
                        dron = ruta.CalcularRuta(line2, dron, cuadras);

                        rutaValida = fileHandler.CreateOutputFile(i + 1, dron, outputPath);
                        if (rutaValida == false)
                        {
                            break;
                        }
                            


                        Console.WriteLine("Punto Cardinal: " + dron.PuntoCardinal);
                        Console.WriteLine("Posicion en X: " + dron.XPosition);
                        Console.WriteLine("Posicion en Y: " + dron.YPosition);
                        outputFile.Close();


                    }

                }
                

            }

            

            

            


            
        }
    }
}
