using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
  public class Centralita
    {
        private List<Llamada> listaDeLlamadas;
        protected string razonSocial;

        public float GananciaPorLocal
        {
            get { return this.CalcularGanancia(TipoLlamada.Local); }
        }
        public float GananciaPorProvincial
        {
            get { return this.CalcularGanancia(TipoLlamada.Provincial); }
        }
        public float GananciaPorTotal
        {
            get { return this.CalcularGanancia(TipoLlamada.Todas); }
        }
        public List<Llamada> Llamadas
        {
            get { return listaDeLlamadas; }
        }
        private float CalcularGanancia(TipoLlamada tipo)
        {
            float resultado = 0;    
            foreach (Llamada llamada in this.listaDeLlamadas)
            {
                switch (tipo)
                {
                    case TipoLlamada.Local:
                        if(llamada is Local)
                        {
                            resultado = resultado + ((Local)llamada).CostoLlamada;
                        }
                        break;
                    case TipoLlamada.Provincial:
                        if(llamada is Provincial)
                        {
                            resultado = resultado + ((Provincial)llamada).CostoLlamada;
                        }
                        break;
                    case TipoLlamada.Todas:
                        if(llamada is Local)
                        {
                            resultado = resultado + ((Local)llamada).CostoLlamada;
                        }
                        else
                        {
                            resultado = resultado + ((Provincial)llamada).CostoLlamada;
                        }
                        break;
                }
            }
            return resultado;
        }
        public Centralita()
        {
            this.listaDeLlamadas = new List<Llamada>();
        }
        public Centralita(string nombreEmpresa)
            :this()
        {
            this.razonSocial = nombreEmpresa;
        }
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"---------------------------------------------------------------");
            sb.AppendLine($"Razon Social: {this.razonSocial}");
            sb.AppendLine($"Ganancia Total: {this.GananciaPorTotal}");
            sb.AppendLine($"Ganancia por llamados Locales: {this.GananciaPorLocal}");
            sb.AppendLine($"Ganancia por llamados provinciales: {this.GananciaPorProvincial}");

            foreach (Llamada llamada in listaDeLlamadas)
            {
                sb.AppendLine($"{llamada.ToString()}");
            }
            sb.AppendLine($"---------------------------------------------------------------");
            return sb.ToString();
        }
        public void OrdenarLlamadas()
        {
            this.listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion); //INVESTIGAR PORQUE LE PASA LA DIRECCION DE MEMORIA DEL METODO
        }

    }
}
