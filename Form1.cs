using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO1_OLC1
{
    public partial class Form1 : Form
    {
        public static string contenido = "";
        public static string expresionesCap = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            AnalisisLexico analizador = new AnalisisLexico();
            AnalizarExpresion analizarEx = new AnalizarExpresion();
            contenido = txaEntrada.Text; //Capturo lo que hay en el textArea
            analizador.analizarTexto(contenido); //Analizo el contenido
            analizador.mostrar(); //Metodo para mostrar lexemas,tokens
            txaSalida.Text = analizador.getTokensLexemas(); //Muestra todo el analisis realizado
            for (int i = 0; i < analizador.listaExRe.Count; i++)
            {
                analizarEx.analizarExpresion(analizador.listaExRe[i]);
                //System.Console.Write("\n");
                //System.Console.Write(analizarEx.getExpresionFinal());
                expresionesCap += analizarEx.getExpresionFinal() + "\r\n";
                analizarEx.limpiar();
            }
            txaExpresiones.Text = expresionesCap;
            //MessageBox.Show("","",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnAFN_Click(object sender, EventArgs e)
        {
            Automata automata = new Automata(txtExpresionReg.Text);
            automata.graficar();
        }

        private void btnAFD_Click(object sender, EventArgs e)
        {
            Automata automata = new Automata(txtExpresionReg.Text);
            automata.graficar();
        }

        private void btnTransiciones_Click(object sender, EventArgs e)
        {
            Transiciones transiciones = new Transiciones(txaExpresiones.Text);

        }
    }
    }
}
