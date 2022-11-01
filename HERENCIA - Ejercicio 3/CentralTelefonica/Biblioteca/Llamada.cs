using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Llamada
    {
        protected float duracion;
        protected string nroDestino;
        protected string nroOrigen;

        public float Duracion
        {
            get { return duracion; }
        }
        public string NroOrigen
        {
            get { return nroOrigen; }
        }
        public string NroDestino
        {
            get { return nroDestino; }
        }
        public Llamada(float duracion, string nroDestino, string nroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = nroDestino;
            this.nroOrigen = nroOrigen;
        }
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"* Duracion de llamada:{this.duracion}");
            sb.AppendLine($"* Numero de Destino: {this.NroDestino}");
            sb.AppendLine($"* Numero de Origen: {this.NroOrigen}");
            return sb.ToString();
        }
        public static int OrdenarPorDuracion(Llamada llamada1, Llamada llamada2)
        {
            int retorno = 0;
            if (llamada1 is not null && llamada2 is not null)
            {
                if (llamada1.duracion > llamada2.duracion)
                {
                    retorno = 1;
                }
                else if (llamada2.duracion > llamada1.duracion)
                {
                    retorno = -1;
                }
            }
            return retorno;
        }
        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
