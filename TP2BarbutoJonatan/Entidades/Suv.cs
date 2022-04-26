using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        /// <summary>
        /// Constructor de clase que llama al constructor de la clase base
        /// </summary>
        /// <param name="marca"> Atributo marca </param>
        /// <param name="chasis"> Atributo chasis </param>
        /// <param name="color"> Atributo color </param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Genera un Stringbuilder y lo completa (Titulo, informacion de la clase base y el tamanio)
        /// </summary>
        /// <returns> El objeto StringBuilder convertido a String </returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
