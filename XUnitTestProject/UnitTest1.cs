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

        public void IsValidRoute(int XpositionDron1, int YPositionDron1, int orientacionDron1, string[] instructions, int range, int XpositionDron2, int YPositionDron2, int orientacionDron2)
        {
            Ruta ruta = new Ruta();

            Dron dron = new Dron(XpositionDron1, YPositionDron1, (Dron.Orientacion)orientacionDron1);

            Dron dron2 = new Dron(XpositionDron2, YPositionDron2, (Dron.Orientacion)orientacionDron2);
            int x = 0;
            for(int i=0; i<instructions.Length;i++)
            {
                dron = ruta.CalcularRuta(instructions[i], dron, range);
                x++;
            }
            var obj1Str = JsonConvert.SerializeObject(dron);
            var obj2Str = JsonConvert.SerializeObject(dron2);
            Assert.Equal(obj1Str, obj2Str);
        }

    }
}
