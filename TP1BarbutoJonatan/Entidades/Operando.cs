using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Constructor de clase, no recibe parametros
        /// </summary>
        public Operando()
            :this(0)
        {

        }
        
        /// <summary>
        /// Constructor de clase
        /// </summary>
        /// <param name="numero"> Numero recibido para asignar</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor de clase que pasa el numero a la propiedad
        /// </summary>
        /// <param name="strNumero"> Numero recibido en formato string</param>
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }

        /// <summary>
        /// Propiedad Numero para setear el atributo
        /// </summary>
        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Validador de numeros binarios
        /// </summary>
        /// <param name="binario"> String a verificar </param>
        /// <returns> Retorna true en caso valido o false </returns>
        private bool EsBinario(string binario)
        {
            bool auxReturn = true;

            foreach (char caracter in binario)
            {
                if(caracter != '1' && caracter != '0')
                {
                    auxReturn = false;
                }
            }
            return auxReturn;
        }


        /// <summary>
        /// Convertidor de decimal a binario
        /// </summary>
        /// <param name="numero"> Atributo a convertir </param>
        /// <returns> Retorna el valor convertido a binario </returns>
        public string DecimalBinario(double numero)
        {
            string valorBinario = string.Empty;
            int resultDiv = (int)numero;
            int restoDiv;

            if (resultDiv >= 0)
            {
                do
                {
                    restoDiv = resultDiv % 2;
                    resultDiv /= 2;
                    valorBinario = restoDiv.ToString() + valorBinario;
                } while (resultDiv > 0);
            }

            return valorBinario;
        }

        /// <summary>
        /// Convertidor de decimal a binario
        /// </summary>
        /// <param name="numero"> Atributo a convertir </param>
        /// <returns> Retorna el valor convertido a binario </returns>
        public string DecimalBinario(string numero)
        {
            int auxNum;
            int.TryParse(numero, out auxNum);

            auxNum = (int)Math.Abs(auxNum);

            return DecimalBinario(auxNum);

        }

        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="valorRecibido"> Numero binario </param>
        /// <returns> Retorna el valor convertido a decimal </returns>
        public string BinarioDecimal(string valorRecibido)
        {
            int resultado = 0;
            int cantidadCaracteres = valorRecibido.Length;

            if(EsBinario(valorRecibido))
            {
                foreach (char caracter in valorRecibido)
                {
                    cantidadCaracteres--;
                    if (caracter == '1')
                    {
                        resultado += (int)Math.Pow(2, cantidadCaracteres);
                    }
                }
                return resultado.ToString();
            }
            else
            {
                return "Valor Invalido";
            }
            
        }

        /// <summary>
        /// Sobrecarga operador +
        /// </summary>
        /// <param name="num1"> Primer numero </param>
        /// <param name="num2"> Segundo numero</param>
        /// <returns> Retorna la suma </returns>
        public static double operator + (Operando num1, Operando num2)
        {
            return (num1.numero + num2.numero);
        }

        /// <summary>
        /// Sobrecarga operador - 
        /// </summary>
        /// <param name="num1"> Primer numero </param>
        /// <param name="num2"> Segundo numero </param>
        /// <returns> Retorna la resta </returns>
        public static double operator - (Operando num1, Operando num2)
        {
            return (num1.numero - num2.numero);
        }

        /// <summary>
        /// Sobrecarga operador *
        /// </summary>
        /// <param name="num1"> Primer numero </param>
        /// <param name="num2"> Segundo numero </param>
        /// <returns> Retorna la multiplicacion </returns>
        public static double operator * (Operando num1, Operando num2)
        {
            return (num1.numero * num2.numero);
        }


        /// <summary>
        /// Sobrecarga operador /
        /// </summary>
        /// <param name="num1"> Primer numero</param>
        /// <param name="num2"> Segundo numero</param>
        /// <returns> Retorna la division</returns>
        public static double operator / (Operando num1, Operando num2)
        {
            if(num2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return (num1.numero / num2.numero);
            }
            
        }

        // Validador
        /// <summary>
        /// Validador de numero
        /// </summary>
        /// <param name="strNumero"> Numero recibido</param>
        /// <returns> retorna el nuevo validado </returns>
        private double ValidarOperando(string strNumero)
        {
            double auxNum = 0;

            double.TryParse(strNumero, out auxNum);

            return auxNum;
        }

    }
}
