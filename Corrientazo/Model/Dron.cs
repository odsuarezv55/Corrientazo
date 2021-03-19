using System;
using System.Collections.Generic;
using System.Text;

namespace Corrientazo.Model
{
    public partial class Dron
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public Orientacion PuntoCardinal { get; set; }
        public string error { get; set; }
        public Dron(int XPosition, int YPosition, Orientacion PuntoCardinal)
        {
            this.XPosition = XPosition;
            this.YPosition = YPosition;
            this.PuntoCardinal = PuntoCardinal;
        }
    }
}
