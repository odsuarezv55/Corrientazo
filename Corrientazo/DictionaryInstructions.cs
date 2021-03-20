using System;
using System.Collections.Generic;
using System.Text;
using static Corrientazo.Model.Dron;

namespace Corrientazo
{
    public class DictionaryInstructions
    {
        

        public IDictionary<string, Orientacion> instructionResult = new Dictionary<string, Orientacion>() {
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
