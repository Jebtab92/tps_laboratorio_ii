using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {

        /// <summary>
        /// Realiza la operacion solicitada, si es valida, entre los numeros ingresados
        /// </summary>
        /// <param name="num1"> Primero numero </param>
        /// <param name="num2"> Segundo numero </param>
        /// <param name="operador"> Operacion a realizar </param>
        /// <returns> Retorna el resultado </returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;

            switch (ValidarOperador(operador))
            {
                case '+':
                    {
                        resultado = (num1 + num2);
                        break;
                    }
                case '-':
                    {
                        resultado = (num1 - num2);
                        break;
                    }
                case '*':
                    {
                        resultado = (num1 * num2);
                        break;
                    }
                case '/':
                    {
                        resultado = (num1 / num2);
                        break;
                    }
            }

            return resultado;

        }

        /// <summary>
        /// Validador de un operador valido para hacer la operacion
        /// </summary>
        /// <param name="operador"> Operador a validar</param>
        /// <returns>El operador en caso de ser valido, en caso contrario retornara + </returns>
        private static char ValidarOperador(char operador)
        {
            if(operador == '/' || operador == '-' || operador == '*')
            {
                return operador;
            }
            else
            {
                return '+';
            }
            
        }

    }
}
