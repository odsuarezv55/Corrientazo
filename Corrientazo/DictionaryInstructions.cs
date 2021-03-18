using System;
using System.Collections.Generic;
using System.Text;
using static Corrientazo.Model.Dron;

namespace Corrientazo
{
    public class DictionaryInstructions
    {
        public IDictionary<string, string> instructionResult = new Dictionary<string, string>() {
            {"ND","E" },
            {"NI","W" },
            {"WD","N" },
            {"WI","S" },
            {"ED","S" },
            {"EI","N" },
            {"SD","W" },
            {"SI","E" }
        };

        public IDictionary<string, Orientacion> instructionResult2 = new Dictionary<string, Orientacion>() {
            {"ND",Orientacion.E },
            {"NI",Orientacion.W },
            {"WD",Orientacion.N },
            {"WI",Orientacion.S },
            {"ED",Orientacion.S },
            {"EI",Orientacion.N },
            {"SD",Orientacion.W },
            {"SI",Orientacion.E }
        };

    }
}
