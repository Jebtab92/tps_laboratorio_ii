using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor de la clase FormCalculadora sin parametros
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Limpia TextBox, ComboBox y Label de la pantalla
        /// Activa ambos botones conversores
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedItem = null;
            lblResultado.Text = "";
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = true;
        }

        /// <summary>
        /// Llama al metodo limpiar para que vuelva a poner los valores en blanco
        /// </summary>
        /// <param name="sender"> Objeto </param>
        /// <param name="e"> Evento Click </param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Metodo operar que toma los numeros ingresados y llama al metodo operar de la clase calculadora
        /// </summary>
        /// <param name="numero1"> Numero recibido de txt1 </param>
        /// <param name="numero2"> Numero recibo de txt2 </param>
        /// <param name="operador"> Operador recibido del combobox</param>
        /// <returns> Retorna el resultado de la operacion </returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);
            char.TryParse(operador, out char operacion);
            return Calculadora.Operar(num1, num2, operacion);
        }

        /// <summary>
        /// Realiza el llamado al metodo operar de FormCalculadora
        /// luego asigna el retorn al label de resultado e inserta este a la lista de operacion
        /// </summary>
        /// <param name="sender"> Objeto </param>
        /// <param name="e"> Evento </param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            StringBuilder operacion = new StringBuilder();
            double resultado;
            
            resultado = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            operacion.AppendLine(txtNumero1.Text + " " + cmbOperador.Text + " " + txtNumero2.Text + " = " + resultado.ToString());

            lblResultado.Text = resultado.ToString();
            lstOperaciones.Items.Insert(0, operacion);
        }

        /// <summary>
        /// En la carga del programa llama al metodo Limpiar()
        /// </summary>
        /// <param name="sender"> Objeto </param>
        /// <param name="e"> Evento </param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }


        /// <summary>
        /// Cierra el programa
        /// </summary>
        /// <param name="sender"> Objeto </param>
        /// <param name="e"> Evento </param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Arroja un mensaje si desea cerrar
        /// </summary>
        /// <param name="sender"> Objeto </param>
        /// <param name="e"> Evento </param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show("¿Está seguro de querer salir?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Txt1 para validar que ingrese solo numeros
        /// </summary>
        /// <param name="sender"> Objeto </param>
        /// <param name="e"> Evento </param>
        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo puede ingresar valores numericos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Txt2 para validar que ingrese solo numeros
        /// </summary>
        /// <param name="sender"> Objeto </param>
        /// <param name="e"> Evento </param>
        private void txtNumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo puede ingresar valores numericos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Llama a la funcion BinarioDecimal y para que pase resultado a decimal y pone el btn disable
        /// </summary>
        /// <param name="sender"> Objeto </param>
        /// <param name="e"> Evento click </param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando auxNumero = new Operando();
            lblResultado.Text = auxNumero.BinarioDecimal(lblResultado.Text);
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }

        /// <summary>
        /// Llama a la funcion DecimalBinario y para que pase resultado a binario y pone el btn disable
        /// </summary>
        /// <param name="sender"> Objeto </param>
        /// <param name="e"> Evento click </param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando auxNumero = new Operando();
            lblResultado.Text = auxNumero.DecimalBinario(lblResultado.Text);
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = false;
        }
    }
}
