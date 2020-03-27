using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1_OLC1
{
    public class Automata
    {
        private PostFijo postFijo_;
        private String expresionRegular;
        private String expresionRegularPostFijo; //postFixRegExp; 
        private List<Char> simbolos;             //symbolList;
        private List<Transiciones> transiciones; // private List<Transition> transitionsList
        private List<Estados> estadosFinales;
        private List<String> estadosIniciales;
        private List<String> estados;
        public static string dotNFA = "";
        public static int contadorEstados;

        private Estados finalSal;
        private Stack<Estados> pilaInicial;
        private Stack<Estados> pilaFinal;

        private Expresion expresion; // private ExpressionSimplifier expressionSimplifier; //expresion

        public Automata(String expresionRegular)
        {
            contadorEstados = 0;
            this.expresionRegular = expresionRegular;
            expresion = new Expresion(this.expresionRegular);
            try
            {
                postFijo_ = new PostFijo();
            }
            catch (Exception e)
            {
                System.Console.Write(e.Message);
                System.Console.ReadLine();


            }

            //new PostFijo();
            expresionRegularPostFijo = PostFijo.infijo(expresion.getExpresionRegular());
            simbolos = new List<Char>();
            transiciones = new List<Transiciones>();
            estadosFinales = new List<Estados>();
            estadosIniciales = new List<String>();
            estados = new List<String>();
            pilaFinal = new Stack<Estados>();
            pilaInicial = new Stack<Estados>();
            //expresionRegularPostFijo = PostFijo.exprApostFijo();
            listaSimbolos();
            ExpresionToAutomata();
            listaEstados();
            estadoInicial();
        }
        private void listaSimbolos() //private void computeSymbolList()
        {
            for (int i = 0; i < expresionRegularPostFijo.Length; i++)
            {
                if (!PostFijo.precedencia.ContainsKey(expresionRegularPostFijo.ElementAt(i)))
                {
                    if (!simbolos.Contains(expresionRegularPostFijo.ElementAt(i)))
                    {
                        simbolos.Add(expresionRegularPostFijo.ElementAt(i));
                        //simbolos.Sort(); //(Collections.sort)(symbolList);
                    }
                }
            }
        }
        public void listaEstados() //public void computeStateList()
        {
            for (int i = 0; i < transiciones.Count; i++)
            {
                if (!estados.Contains(transiciones[i].getEstadoInicial().ToString()))
                {
                    estados.Add(transiciones[i].getEstadoInicial().ToString());
                }
                if (!estados.Contains(transiciones[i].getEstadoFinal().ToString()))
                {
                    estados.Add(transiciones[i].getEstadoFinal().ToString());
                }
            }
        }
        public void estadoInicial() //public void computeInitialState()
        {
            estadosIniciales.Add(pilaInicial.Pop().ToString());
        }
        private void ExpresionToAutomata()  //private void regExpToAFN()
        {
            for (int i = 0; i < expresionRegularPostFijo.Length; i++)
            {
                if (simbolos.Contains(expresionRegularPostFijo.ElementAt(i)))
                {
                    Transiciones tr1 = new Transiciones(Char.ToString(expresionRegularPostFijo.ElementAt(i)));
                    transiciones.Add(tr1);

                    Estados estadoInicio = tr1.getEstadoInicial();
                    Estados estadoFinal = tr1.getEstadoFinal();

                    pilaInicial.Push(estadoInicio);
                    pilaFinal.Push(estadoFinal);
                }
                else if (Char.ToString(expresionRegularPostFijo.ElementAt(i)).Equals("|"))
                {
                    Estados inicioLow = pilaInicial.Pop();
                    Estados finalLow = pilaFinal.Pop();
                    Estados inicioUpp = pilaInicial.Pop();
                    Estados finalUpp = pilaFinal.Pop();
                    or(inicioUpp, finalUpp, inicioLow, finalLow);
                }
                else if (Char.ToString(expresionRegularPostFijo.ElementAt(i)).Equals("*"))
                {
                    Estados estadoInicio = pilaInicial.Pop();
                    Estados estadoFinal = pilaFinal.Pop();
                    asterisco(estadoInicio, estadoFinal);
                }
                else if (Char.ToString(expresionRegularPostFijo.ElementAt(i)).Equals("."))
                {
                    finalSal = pilaFinal.Pop();
                    Estados estadoFinal = pilaFinal.Pop();
                    Estados estadoInicio = pilaInicial.Pop();
                    concatenacion(estadoFinal, estadoInicio);
                }
                if (i == expresionRegularPostFijo.Length - 1)
                {
                    estadosFinales.Add(pilaFinal.Pop());
                    if (simbolos.Contains('ε')) //epsilon
                    {
                        simbolos.Remove('ε'); //symbolList.remove(symbolList.indexOf('ε'));
                    }
                }
            }
        }
        private void or(Estados inicioUpp, Estados finaUpp, Estados inicioLow, Estados finalLow)
        {
            Estados in_ = new Estados(contadorEstados);
            Estados out_ = new Estados(contadorEstados);

            Transiciones tr1 = new Transiciones("ε", in_, inicioUpp);
            Transiciones tr2 = new Transiciones("ε", in_, inicioLow);
            Transiciones tr3 = new Transiciones("ε", finaUpp, out_);
            Transiciones tr4 = new Transiciones("ε", finalLow, out_);

            transiciones.Add(tr1);
            transiciones.Add(tr2);
            transiciones.Add(tr3);
            transiciones.Add(tr4);

            pilaInicial.Push(in_);
            pilaFinal.Push(out_);
        }
        private void concatenacion(Estados estadoInicial, Estados estadoFinal)
        {
            Transiciones tr1 = new Transiciones("ε", estadoInicial, estadoFinal);
            transiciones.Add(tr1);
            pilaFinal.Push(finalSal);
            finalSal = null;
        }
        private void asterisco(Estados estadoInicial, Estados estadoFinal)
        {
            Estados in_ = new Estados(contadorEstados);
            Estados out_ = new Estados(contadorEstados);

            Transiciones tr1 = new Transiciones("ε", estadoFinal, estadoInicial);
            Transiciones tr2 = new Transiciones("ε", in_, out_);
            Transiciones tr3 = new Transiciones("ε", in_, estadoInicial);
            Transiciones tr4 = new Transiciones("ε", estadoFinal, out_);

            transiciones.Add(tr1);
            transiciones.Add(tr2);
            transiciones.Add(tr3);
            transiciones.Add(tr4);

            pilaInicial.Push(in_);
            pilaFinal.Push(out_);

        }
        public List<Char> getListaSimbolos()
        {
            return this.simbolos;
        }
        public List<Transiciones> getTransiciones()
        {
            return this.transiciones;
        }
        public List<Estados> getEstadosFinales()
        {
            return this.estadosFinales;
        }
        public List<String> getEstados()
        {
            return this.estados;
        }
        public List<String> getEstadosIniciales()
        {
            return this.estadosIniciales;
        }
        public String getExpresionPostFija()
        {
            return this.expresionRegularPostFijo;
        }
        public void graficar()
        {
            TextWriter archivo;
            archivo = new StreamWriter("C:\\Users\\SERGIO_RPR\\Desktop\\compi\\Imagenes\\AFN.dot");
            archivo.WriteLine("digraph ListaSimple{\n");
            archivo.WriteLine("rankdir=LR;\n");
            archivo.WriteLine(dotNFA = estados[0]);
            archivo.WriteLine("node[shape=component,fontcolor=brown4,width=1.5,margin=0.2]");
            archivo.WriteLine("}\n");
            archivo.Close();
            ProcessStartInfo cmd = new ProcessStartInfo("dot.exe");
            cmd.Arguments = "dot AFN.dot -o C:\\Users\\SERGIO_RPR\\Desktop\\compi\\Imagenes\\AFN.png -Tpng";
            Process.Start(cmd);
            Process.Start("C:\\Users\\SERGIO_RPR\\Desktop\\compi\\Imagenes\\AFN.png");
        }

    }
}
