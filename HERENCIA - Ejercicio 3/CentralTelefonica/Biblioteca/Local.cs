using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Local : Llamada
    {
        protected float costo;

        public float CostoLlamada
        {
            get { return this.CalcularCosto(); }
        }

        private float CalcularCosto()
        {
            return this.duracion * this.costo;
        }
        public Local(Llamada llamada, float costo)
         : this(llamada.NroOrigen, llamada.Duracion, llamada.NroOrigen, costo)
        {

        }
        public Local(string origen, float duracion, string destino, float costo)
            : base(duracion, destino, origen)
        {
            this.costo = costo;
        }
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- LOCAL");
            sb.Append($"{base.Mostrar()}");
            sb.AppendLine($"Costo de llamada: {this.CostoLlamada}");
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
