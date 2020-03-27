using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1_OLC1
{
    public class Expresion
    {
        private String expresionRegular;
        //Constructor
        public Expresion(String expresionRegular)
        {
            this.expresionRegular = expresionRegular;
            cerradura2();
            cerradura1(); 
        }
        //////////////
        public String getExpresionRegular()
        {

            return this.expresionRegular;
        }
        public void cerradura1()
        {
            for (int i = 0; i < expresionRegular.Length; i++)
            {
                if (Char.ToString(expresionRegular[i]).Equals("?")) //regExp
                {
                    if (!Char.ToString(expresionRegular[i - 1]).Equals(")"))
                    {
                        String simbolo = Char.ToString(expresionRegular[i - 1]);
                        String subExpresion = "(" + simbolo + "|ε)";

                        String izquierda = expresionRegular.Substring(0, i - 1);
                        String derecha = expresionRegular.Substring(i + 1);
                        expresionRegular = izquierda + subExpresion + derecha;

                    }
                    else
                    {
                        for (int j = (i - 1); j >= 0; j--)
                        {
                            if ((Char.ToString(expresionRegular[j]).Equals("(")))
                            {
                                if (j != 0)
                                {
                                    String secuenciaSimbolos = (String)expresionRegular.Substring(j + 1, (i - 1) - (j + 1));  //subSequence
                                    String secuenciaSimbolosW = (String)expresionRegular.Substring(j, i - j);  //subSequence
                                    String subExpresion = "(" + secuenciaSimbolosW + "|ε)";

                                    String izquierda = expresionRegular.Substring(0, j);
                                    String derecha = expresionRegular.Substring(i + 1);
                                    expresionRegular = izquierda + subExpresion + derecha;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        //////////////////////////////////////////////////////CERRADURA 2////////////////////////////////////////
        public void cerradura2()
        {
            for (int i = 0; i < expresionRegular.Length; i++)
            {
                if (Char.ToString(expresionRegular[i]).Equals("+"))
                {
                    if (!Char.ToString(expresionRegular[i - 1]).Equals(")"))
                    {
                        String simbolo = Char.ToString(expresionRegular[i - 1]);
                        String subExpresion = simbolo + simbolo + "*";

                        String izquierda = expresionRegular.Substring(0, i - 1);
                        String derecha = expresionRegular.Substring(i + 1);
                        expresionRegular = izquierda + subExpresion + derecha;

                    }
                    else
                    {
                        int contador = 0;
                        for (int j = (i - 1); j >= 0; j--)
                        {
                            if (j != (i - 1) && (Char.ToString(expresionRegular[j]).Equals(")")))
                            {
                                contador++;
                            }
                            if ((Char.ToString(expresionRegular[j]).Equals("(")))
                            {
                                if (contador != 0)
                                {
                                    contador--;
                                }
                                else
                                {
                                    String secuenciaSimbolos = (String)expresionRegular.Substring(j + 1, (i - 1) - (j + 1));  //subSequence
                                    String secuenciaSimbolosW = (String)expresionRegular.Substring(j, i - j);  //subSequence
                                    String subExpresion = secuenciaSimbolosW + secuenciaSimbolosW + "*";

                                    String izquierda = expresionRegular.Substring(0, j);
                                    String derecha = expresionRegular.Substring(i + 1);
                                    expresionRegular = izquierda + subExpresion + derecha;
                                }
                                if (j != 0)
                                {

                                }

                            }

                        }
                    }
                }
            }
        }
    }
}
