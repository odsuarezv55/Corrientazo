using Corrientazo;
using Corrientazo.Model;
using Newtonsoft.Json;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {

        [Theory]
        [InlineData(0, 0, 0, new string[] {"AAAAIAA", "DDDAIAD", "AAIADAD"}, 10,0,0,3)]
        [InlineData(0, 0, 0, new string[] { "AAAAIAA", "DDDAIAD", "AAIADAD" }, 10, 0, 2, 3)]

        public void IsValidRoute(int XpositionDron1, int YPositionDron1, int orientacionDron1, string[] instructions, int range, int XpositionDron2, int YPositionDron2, int orientacionDron2)
        {
            Ruta ruta = new Ruta();

            Dron dron = new Dron(XpositionDron1, YPositionDron1, (Dron.Orientacion)orientacionDron1);

            Dron dron2 = new Dron(XpositionDron2, YPositionDron2, (Dron.Orientacion)orientacionDron2);
   
            for(int i=0; i<instructions.Length;i++)
            {
                if (dron == null)
                    break;
                dron = ruta.CalcularRuta(instructions[i], dron, range);
              
            }
            var obj1Str = JsonConvert.SerializeObject(dron);
            var obj2Str = JsonConvert.SerializeObject(dron2);
            Assert.Equal(obj1Str, obj2Str);
        }


        [Theory]
        //[InlineData(0, 0, 0, new string[] { "AAAAIAA", "DDDAIAD", "AAIADAD" }, 10, 0, 0, 3)]
        [InlineData(0, 0, 0, new string[] { "AAAAAAAAAAAAIAA", "DDDAIAD", "AAIADAD" }, 10)]
        public void OutOfRangeError(int XpositionDron1, int YPositionDron1, int orientacionDron1, string[] instructions, int range)
        {
            Ruta ruta = new Ruta();

            Dron dron = new Dron(XpositionDron1, YPositionDron1, (Dron.Orientacion)orientacionDron1);

            
            string errorMessage = "";
            
            for (int i = 0; i < instructions.Length; i++)
            {
                if (dron.error != null)
                {
                    errorMessage = "Ruta fuera del rango permitido en punto (" + dron.XPosition + "," + dron.YPosition + ")";
                    break;
                }
                    
                dron = ruta.CalcularRuta(instructions[i], dron, range);
          
            }
            
            Assert.Equal(errorMessage,dron.error);
        }


        [Theory]
        //[InlineData(0, 0, 0, new string[] { "AAAAIAA", "DDDAIAD", "AAIADAD" }, 10, 0, 0, 3)]
        [InlineData(0, 0, 0, new string[] { "AAAAAAAH", "DDDAIAD", "AAIADAD" }, 10)]
        public void InvalidCharacterError(int XpositionDron1, int YPositionDron1, int orientacionDron1, string[] instructions, int range)
        {
            Ruta ruta = new Ruta();

            Dron dron = new Dron(XpositionDron1, YPositionDron1, (Dron.Orientacion)orientacionDron1);

           
        
            for (int i = 0; i < instructions.Length; i++)
            {
                if (dron.error != null)
                {
                    break;
                }
                    
                dron = ruta.CalcularRuta(instructions[i], dron, range);
               
            }
        
            Assert.Equal("Caracter no permitido",dron.error);
        }


    }
}
