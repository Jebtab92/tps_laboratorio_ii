using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        public enum ETipo 
        { 
            CuatroPuertas, CincoPuertas 
        }
        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"> Parametro marca </param>
        /// <param name="chasis"> Parametro chasis </param>
        /// <param name="color"> Parametro color </param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.CincoPuertas)
        {
        }

        /// <summary>
        /// Constructor de clase que llama al constructor de la clase base
        /// </summary>
        /// <param name="marca"> Parametro marca </param>
        /// <param name="chasis"> Parametro chasis </param>
        /// <param name="color"> Parametro color </param>
        /// <param name="tipo"> Parametro tipo </param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            :base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Genera un Stringbuilder y lo completa (Titulo, informacion de la clase base y el tamanio)
        /// </summary>
        /// <returns> El objeto StringBuilder convertido a String </returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.Append(base.Mostrar());
            sb.AppendLine($"TIPO : {this.tipo}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
