using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Provincial : Llamada
    {
        public enum Franja
        {
            Franja_1,
            Franja_2,
            Franja_3,
        }
        protected Franja franjaHoraria;

        public float CostoLlamada
        {
            get { return this.CalcularCosto(); }
        }
        public Provincial(Franja miFranja, Llamada llamada)
            : this(llamada.NroOrigen, miFranja, llamada.Duracion, llamada.NroDestino)
        {

        }
        public Provincial(string origen, Franja miFranja, float duracion, string destino)
            : base(duracion, destino, origen)
        {
            this.franjaHoraria = miFranja;
        }
        private float CalcularCosto()
        {
            //REVISAR
            float costoTotal = 0;
            if (this.duracion != 0)
            {
                switch (this.franjaHoraria)
                {
                    case Franja.Franja_1:
                        costoTotal = duracion * (float)0.99;
                        break;
                    case Franja.Franja_2:
                        costoTotal = duracion * (float)1.25;
                        break;
                    case Franja.Franja_3:
                        costoTotal = duracion * (float)0.66;
                        break;
                }
            }
            return costoTotal;
        }
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- PROVINCIAL");
            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine($"Costo de llamada: {this.CostoLlamada}");
            sb.AppendLine($"Franja Horaria: {this.franjaHoraria}");
            return sb.ToString();
        }
        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
