using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1_OLC1
{
    public class AnalisisLexico
    {

        ArrayList arrayLexemas = new ArrayList(); //Array de los lexemas
        ArrayList arrayTokens = new ArrayList(); //Array de Tokens
        ArrayList arrayErrores = new ArrayList(); //Array de Errores
        ArrayList enumeradores = new ArrayList(); //Array Enumeradores
        List<int> tokens = new List<int>();       //Lista de Enumeradores
        public List<string> listaExRe = new List<string>();
        public static string lexemasAlmacenados = "";
        public static string token = "";
        public static string dot = "";
        public static int contador = 0;
        public static string tokensLexemas = "";
        public enum Operadores
        {
            // .,|.+,?,*,letra,"_"
            PUNTO = 1, OR = 2, MAS = 3, INTERROGACION = 4, ASTERISCO = 5, ID = 6, OTRO = 7
        }
        public void analizarTexto(string entrada)
        {
            string texto = entrada;
            int tamanio = texto.Length;
            int pos = -1;
            int estado = 0;
            string lexema = " ";
            int numerador = 0;

            while (pos < tamanio - 1)
            {
                pos++;
                char caracter = texto.ElementAt(pos);

                ////////////////////////////////////////////////////////////ESTADOS////////////////////////////////////////////////////////////////////
                switch (estado)
                {
                    case 0:

                        if (caracter == '<') //Puede que abra un comentario, ir al estado 1
                        {
                            estado = 1;
                            lexema += caracter;
                        }
                        /*else if ((caracter >= 65 && caracter <= 90) || (caracter >= 97 && caracter <= 122)) //Si viene una letra
                        {
                            estado = 2;
                            lexema += caracter;
                        }*/
                        else if (caracter == '/')
                        {
                            estado = 8;
                            lexema += caracter;
                        }
                        else if ((caracter >= 97 && caracter <= 122) || (caracter >= 65 && caracter <= 90)) //Si viene letras puede ser un identificador ya sea de un conjunto o una expresion
                        {
                            if (caracter == 'C')
                            {
                                estado = 7;
                                lexema += caracter;
                            }

                            else
                            {
                                estado = 3;
                            }
                        }


                        break;
                    //////////////////////////////////////////////////COMENTARIOS VARIAS LINEAS///////////////////////////////////////////////////////
                    case 1:  //Viene del estado0 con '<'
                        if (caracter == '!')
                        {
                            estado = 1;
                            lexema += caracter;

                        }
                        else if (caracter == ' ')
                        {
                            estado = 1;
                            lexema += caracter;

                        }
                        else if (caracter == '\n') //Salto de linea, el cual permite determinar que es un comentario de varias lineas
                        {
                            estado = 10; //Se podria ir a otro estado
                            lexema += caracter;
                        }
                        else if ((caracter >= 97 && caracter <= 122) || (caracter >= 65 && caracter <= 90)) //Puede venir cualquier simbolo
                        {
                            estado = 1;
                            lexema += caracter;
                        }

                        else if (caracter == '!')
                        {
                            estado = 1;
                            lexema += caracter;

                        }
                        else if (caracter == '>') //Salto de linea, el cual permite determinar que es un comentario de varias lineas
                        {
                            estado = 1;
                            lexema += caracter;
                        }

                        else
                        {
                            //lexema = "ID";
                            token = "COMENTARIO_VARIAS_LINEAS";
                            arrayLexemas.Add(lexema);
                            arrayTokens.Add(token);
                            lexema = "";
                            //numerador = (int)Operadores.ID;
                            //enumeradores.Add(numerador);
                            //tokens.Add(numerador);
                            //tokens.Insert(0, numerador);
                            estado = 0;
                            pos--;
                        }
                        break;
                    ///////////////////////////////////////////////////////Fin de aceptacion del comentario///////////////////////////////////////////////////////////
                    case 2:
                        ////////////////////////Letras
                        break;
                    //////////////////////////////////////////////////////ACEPTA LAS EXPRESIONES REGULARES////////////////////////////////////////////////////////////
                    case 3:
                        if (caracter == '-')
                        {
                            estado = 3;
                            //lexema += caracter;
                        }
                        else if (caracter == '>')
                        {
                            //lexema += caracter;
                            estado = 4;
                        }
                        else if (caracter == ':')
                        {
                            estado = 9;
                            //lexema += caracter;
                        }
                        break;
                    case 4:
                        if ((caracter >= 97 && caracter <= 122) || (caracter >= 65 && caracter <= 90)) //Letras
                        {
                            lexema += caracter;
                            estado = 4;
                        }
                        else if (caracter == 32) //Espacios en blanco no incluir en las expresiones
                        {
                            estado = 4;
                            lexema += caracter;

                        }
                        else if (caracter == '~')
                        {

                        }
                        else if ((caracter >= 48 && caracter <= 57)) //Numeros
                        {
                            lexema += caracter;
                            estado = 4;
                        }
                        else if (caracter == '{') //Si viene un parentesis
                        {
                            estado = 6;
                            lexema += caracter;
                        }
                        else if (caracter == '\"') //Si vienen comillas
                        {
                            estado = 5;
                            lexema += caracter;
                        }
                        else if (caracter == '*' || caracter == '+' || caracter == '|' || caracter == '?' || caracter == '(' || caracter == ')')  //Operadores
                        {
                            lexema += caracter;
                            estado = 4;
                        }

                        /*else if ((caracter >= 123 && caracter <= 126))
                        {
                            lexema += caracter;
                            estado = 4;
                        }*/
                        else
                        {
                            if (lexema == " " || lexema == "\n" || lexema == "")
                            {

                            }
                            else
                            {
                                listaExRe.Add(lexema);
                            }
                            token = "EXPRESION_REGULAR";
                            arrayLexemas.Add(lexema);
                            arrayTokens.Add(token);
                            lexema = "";
                            estado = 0;
                            pos--;
                        }
                        break;
                    case 5:
                        if (caracter == '\"')
                        {
                            lexema += caracter;
                            estado = 5;
                        }
                        else if ((caracter >= 32 && caracter <= 126))
                        {
                            lexema += caracter;
                            estado = 5;
                        }
                        else if (caracter == '\"')
                        {
                            lexema += caracter;
                            estado = 5;
                        }
                        else
                        {
                            estado = 4;
                            pos--;
                        }
                        break;
                    case 6:
                        if ((caracter >= 97 && caracter <= 122) || (caracter >= 65 && caracter <= 90))
                        {
                            estado = 6;
                            lexema += caracter;
                        }
                        else if (caracter == '_')
                        {
                            estado = 6;
                            lexema += caracter;
                        }
                        else if (caracter == '}')
                        {
                            estado = 6;
                            lexema += caracter;
                        }
                        else
                        {
                            estado = 4;
                            pos--;
                        }
                        break;
                    case 7:
                        if (caracter == 'O')
                        {
                            estado = 7;
                            lexema += caracter;
                        }
                        else if (caracter == 'N')
                        {
                            estado = 7;
                            lexema += caracter;
                        }
                        else if (caracter == 'J')
                        {
                            estado = 7;
                            lexema += caracter;
                        }
                        else if (caracter == ':')
                        {
                            estado = 7;
                            lexema += caracter;
                        }
                        else if (caracter == 32)
                        {
                            estado = 7;

                        }
                        else if (caracter == '-')
                        {
                            estado = 7;
                            lexema += caracter;

                        }
                        else if (caracter == '_')
                        {
                            estado = 7;
                            lexema += caracter;

                        }
                        else if (caracter == '>')
                        {
                            estado = 7;
                            lexema += caracter;

                        }
                        else if ((caracter >= 97 && caracter <= 122) || (caracter >= 65 && caracter <= 90))
                        {
                            estado = 7;
                            lexema += caracter;

                        }
                        else if (caracter == ',')
                        {
                            estado = 7;
                            lexema += caracter;

                        }
                        else if ((caracter >= 48 && caracter <= 57))
                        {
                            estado = 7;
                            lexema += caracter;

                        }
                        else if (caracter == '~')
                        {
                            estado = 7;
                            lexema += caracter;

                        }

                        else
                        {
                            token = "CONJUNTOS";
                            arrayLexemas.Add(lexema);
                            arrayTokens.Add(token);
                            lexema = "";
                            estado = 0;
                            pos--;
                        }
                        break;
                    case 8:
                        if (caracter == '/')
                        {
                            estado = 8;
                            lexema += caracter;
                        }
                        else if ((caracter >= 32 && caracter <= 126))
                        {
                            estado = 8;
                            lexema += caracter;
                        }
                        else
                        {
                            token = "COMENTARIO_DE_UNA_LINEA";
                            arrayLexemas.Add(lexema);
                            arrayTokens.Add(token);
                            lexema = "";
                            estado = 0;
                            pos--;
                        }
                        break;
                    case 9:
                        if (caracter == '\"')
                        {
                            estado = 9;
                            lexema += caracter;
                        }


                        else if ((caracter >= 32 && caracter <= 126))
                        {
                            estado = 9;
                            lexema += caracter;
                        }


                        else
                        {
                            token = "EXPRESION_A_VALIDAR";
                            arrayLexemas.Add(lexema);
                            arrayTokens.Add(token);
                            lexema = "";
                            estado = 0;
                            pos--;

                        }
                        break;
                    case 10:
                        if (caracter == 32)
                        {
                            estado = 10;
                            lexema += caracter;
                        }
                        else if ((caracter >= 32 && caracter <= 126))
                        {
                            estado = 10;
                            lexema += caracter;
                        }
                        else
                        {
                            estado = 1;
                            pos--;
                        }
                        break;

                }
            }
        }
        /// <summary>
        /// ///////////////////////////////////////////////////MUESTRA LEXEMAS,TOKENS,ETC//////////////////////////////////////////////////
        /// </summary>
        public void mostrar()
        {
            /* for (int i = 0; i < enumeradores.Count; i++)
             {
                 System.Console.Write(enumeradores[i] + "\n");


             }*/
            System.Console.Write("\n");
            /*for (int i = 0; i < arrayTokens.Count; i++)
            {
                System.Console.Write(arrayTokens[i] + "\n");
            }
            System.Console.Write("\n");
            for (int i = 0; i < arrayLexemas.Count; i++)
            {
                System.Console.Write(arrayLexemas[i] + "\n");
            }*/
            System.Console.Write("\n");
            /*for (int i = 0; i < tokens.Count; i++)
            {
                System.Console.Write(tokens[i] + ",");
            }*/
            for (int i = 0; i < arrayTokens.Count; i++)
            {
                //System.Console.Write(arrayTokens[i] +"         "+arrayLexemas[i]+ "\n");
                tokensLexemas += i.ToString() + arrayTokens[i] + " ---> " + arrayLexemas[i] + "\r\n";
            }
            System.Console.Write("\n");
            for (int i = 0; i < listaExRe.Count; i++)
            {
                System.Console.Write("EXPRESION--->" + listaExRe[i] + "\n");
            }

        }
        public string getTokensLexemas()
        {
            return tokensLexemas;
        }
    }
}
