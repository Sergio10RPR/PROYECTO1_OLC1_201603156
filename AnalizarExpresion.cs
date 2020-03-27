using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1_OLC1
{
    class AnalizarExpresion
    {
        ArrayList arrayLexemas = new ArrayList();
        ArrayList arrayTokens = new ArrayList();
        ArrayList arrayErrores = new ArrayList();
        public ArrayList enumeradores = new ArrayList();
        public List<int> tokens = new List<int>();
        List<String>.Enumerator conteo;
        public static String lexemasAlmacenados = "";
        public static String token = "";
        public static String dot = "";
        public static int contador = 0;
        public static int final = 0;
        public static int finalOr = 0;
        public static String dotAsterisco;
        public static int finalAsterisco = 0;
        public static int inicioAsterisco = 0;
        public string expresionFinal = "";  //Expresion Final
        public enum Operadores
        {
            APERTURA = 1, OR = 2, MAS = 3, INTERROGACION = 4, ASTERISCO = 5, ID = 6, OTRO = 7, CERRADURA = 8
        }
        public void analizarExpresion(String entrada)
        {

            String texto = entrada + " ";
            int tamanio = texto.Length;
            int pos = -1;
            int estado = 0;
            String lexema = "";
            int numerador = 0;
            while (pos < tamanio - 1)
            {
                pos++;
                char caracter = texto.ElementAt(pos);


                switch (estado)
                {
                    case 0:
                        if (caracter == '(')
                        {
                            lexema += "(";
                            token = "APERTURA";
                            arrayLexemas.Add(lexema);
                            arrayTokens.Add(token);
                            lexema = "";
                            numerador = (int)Operadores.APERTURA;
                            enumeradores.Add(numerador);
                            //tokens.Add(numerador);
                            tokens.Insert(0, numerador);
                            expresionFinal = expresionFinal + "(";
                        }

                        else if (caracter == '|')
                        {
                            lexema += "|";
                            token = "OR";
                            arrayLexemas.Add(lexema);
                            arrayTokens.Add(token);
                            lexema = "";
                            numerador = (int)Operadores.OR;
                            enumeradores.Add(numerador);
                            tokens.Insert(0, numerador);
                            expresionFinal = expresionFinal + "|";
                        }
                        else if (caracter == '+')
                        {
                            lexema += "+";
                            token = "MAS";
                            arrayLexemas.Add(lexema);
                            arrayTokens.Add(token);
                            lexema = "";
                            numerador = (int)Operadores.MAS;
                            enumeradores.Add(numerador);
                            //tokens.Add(numerador);
                            tokens.Insert(0, numerador);
                            expresionFinal = expresionFinal + "+";
                        }
                        else if (caracter == '*')
                        {
                            lexema += "*";
                            token = "ASTERISCO";
                            arrayLexemas.Add(lexema);
                            arrayTokens.Add(token);
                            lexema = "";
                            numerador = (int)Operadores.ASTERISCO;
                            enumeradores.Add(numerador);
                            //tokens.Add(numerador);
                            tokens.Insert(0, numerador);
                            expresionFinal = expresionFinal + "*";
                        }
                        else if (caracter == '?')
                        {
                            lexema += "?";
                            token = "INTERROGACION";
                            arrayLexemas.Add(lexema);
                            arrayTokens.Add(token);
                            lexema = "";
                            numerador = (int)Operadores.INTERROGACION;
                            enumeradores.Add(numerador);
                            //tokens.Add(numerador);
                            tokens.Insert(0, numerador);
                            expresionFinal = expresionFinal + "?";

                        }
                        if (caracter == ')')
                        {
                            lexema += ")";
                            token = "CERRADURA";
                            arrayLexemas.Add(lexema);
                            arrayTokens.Add(token);
                            lexema = "";
                            numerador = (int)Operadores.CERRADURA;
                            enumeradores.Add(numerador);
                            //tokens.Add(numerador);
                            tokens.Insert(0, numerador);
                            expresionFinal = expresionFinal + ")";
                        }
                        else if (caracter == '\"')
                        {
                            estado = 1;
                            lexema += caracter;

                        }
                        else if ((caracter >= 65 && caracter <= 90) || (caracter >= 97 && caracter <= 122)) //Letras
                        {
                            estado = 2;
                            lexema += caracter;
                        }
                        else if (caracter == ' ')
                        {

                        }
                        break;
                    case 1:
                        if (caracter == '\"') //Si los id´s vienen con comillas
                        {
                            estado = 1;
                            lexema += caracter;
                        }
                        else if ((caracter >= 35 && caracter <= 57) || (caracter >= 64 && caracter <= 123) || caracter == 125)
                        {
                            estado = 1;
                            lexema += caracter;
                            //System.Console.Write("LEXEMAS:"+lexema+"\n");


                        }
                        else
                        {
                            //lexema = "OTRO";
                            token = "OTRO";
                            arrayLexemas.Add(lexema);
                            arrayTokens.Add(token);
                            //lexema = " ";
                            numerador = (int)Operadores.OTRO;
                            enumeradores.Add(numerador);
                            //tokens.Add(numerador);
                            tokens.Insert(0, numerador);
                            //System.Console.Write("Caracter->"+caracter+"\n"); //;
                            expresionFinal = expresionFinal + "S";
                            estado = 0;

                            pos--;

                        }

                        break;
                    //Caso en que venga un identificador de solo letras
                    case 2:
                        if ((caracter >= 65 && caracter <= 90) || (caracter >= 97 && caracter <= 122)) //Id's sin comillas "" ,solo letras
                        {
                            estado = 2;
                            lexema += caracter;
                        }
                        else if ((caracter >= 48 && caracter <= 57) || (caracter >= 64 && caracter <= 123) || caracter == 125) //Numeros y letras,algunos simbolos
                        {
                            estado = 2;
                            lexema += caracter;


                        }
                        else
                        {
                            //lexema = "ID";
                            token = "ID";
                            arrayLexemas.Add(lexema);
                            arrayTokens.Add(token);
                            lexema = "";
                            numerador = (int)Operadores.ID;
                            enumeradores.Add(numerador);
                            //tokens.Add(numerador);
                            tokens.Insert(0, numerador);
                            expresionFinal = expresionFinal + "C";
                            estado = 0;
                            pos--;

                        }
                        break;

                    default:
                        enumeradores.Add(0);
                        tokens.Add(0);
                        break;


                }

            }


        }
        void verificar()
        {

        }
        //Concatenacion .
        int concatenacion(ref List<int>.Enumerator tipo)
        {
            // int inicio = AFN(tipo); 
            AFN(ref tipo);
            contador++;
            //System.Console.Write("INICIO: "+ final+" ");//
            System.Console.Write("Punto");
            System.Console.Write(contador + "\n");
            String expresion1 = "";

            return contador;
        }
        ///////////////////////////////////////////////////////////////////Si viene un ID//////////////////////////////////////////////////////////////////////////
        int id(ref List<int>.Enumerator tipo)
        {

            finalAsterisco = AFN(ref tipo);
            contador++;
            final = contador + 1;
            System.Console.Write("ID");
            System.Console.Write(contador + "\n");
            //finalAsterisco = contador + 1;
            dot = dot + contador.ToString() + "->" + final.ToString() + "\n";//O->O id ,Regla 1
                                                                             //System.Console.Write("\nDOT GENERADO"+dot+"\n");
                                                                             //System.Console.Write("ID " + contador + "\n");
                                                                             //System.Console.Write("2.FINAL->ID " + final + "\n");
            return final;

        }
        /////////////////////////////////////////////////////////////////////////////Si viene ASTERISCO */////////////////////////////////////////////////////////////////
        int asterisco(ref List<int>.Enumerator tipo)
        {
            finalAsterisco = AFN(ref tipo);
            System.Console.Write("QUE CARAJOS" + finalAsterisco + "\n");
            contador++;
            //Inicio porque no se en que valor de nodo tendra el inicio
            //int inicioA = contador;
            //int finalA = final + 1;
            inicioAsterisco = contador;
            System.Console.Write("ASTERISCO");
            System.Console.Write(contador + "\n");
            //dot = dot + inicioAsterisco + "->" + finalAsterisco + "\n";
            //dot =dot+inicioA.ToString() + "->" + finalA.ToString()+"\n";
            //System.Console.Write("ASTERISCO DOT "+ dot+"\n");
            //sSystem.Console.Write("ASTERISCO INICIO "+inicioA+"\n");
            //System.Console.Write("1.ASTERISCO " + finalA +"\n");
            //System.Console.Write(contador + "\n");

            return finalAsterisco;
        }
        /////////////////////////////////////////////////////////////////////////////////Si viene un OR//////////////////////////////////////////////////////////////////////
        int or(ref List<int>.Enumerator tipo)
        {
            AFN(ref tipo);
            contador++; //Inicio del or
            finalOr = final + 2;
            System.Console.Write("OR(|)");
            System.Console.Write(contador + "\n");
            /*int inicioOr = AFN(tipo);
            int finalOr_ = AFN(tipo);
            System.Console.Write("INICIOOR " + inicioOr + " FINAL" + finalOr_ + "\n");*/
            //System.Console.Write("FINAL OR:"+finalOr);
            return contador;

        }
        //Si viene una suma +
        int suma(ref List<int>.Enumerator tipo)
        {
            AFN(ref tipo);
            contador++;
            System.Console.Write("SUMA(+) ");
            System.Console.Write(contador + "\n");
            return contador;

        }
        //Si viene un signo de interrogacion ?
        int interrogacion(ref List<int>.Enumerator tipo)
        {
            AFN(ref tipo);
            contador++;
            System.Console.Write("INTERROGACION(?) ");
            System.Console.Write(contador + "\n");
            return contador;

        }
        //Si viene un signo algo con comiilas ?
        int otro(ref List<int>.Enumerator tipo)
        {

            AFN(ref tipo);
            contador++;
            System.Console.Write("OTRO ");
            System.Console.Write(contador + "\n");
            return contador;

        }


        int AFN(ref List<int>.Enumerator tipo)
        {
            if (tipo.MoveNext())
            {
                switch (tipo.Current)
                {
                    case 1: //Punto .
                        return concatenacion(ref tipo);
                    case 2: //Or |
                        return or(ref tipo);
                    case 3: //Suma + 
                        return suma(ref tipo);

                    case 4: //Interrogacion ?
                        return interrogacion(ref tipo);

                    case 5: //Asterisco *
                        return asterisco(ref tipo);

                    case 6: //ID
                        return id(ref tipo);

                    case 7: //Otro
                        return otro(ref tipo);

                    default:
                        return -1;

                }
            }
            else
            {
                return 0;
            }

        }
        public void mostrar()
        {
            for (int i = 0; i < enumeradores.Count; i++)
            {
                System.Console.Write(enumeradores[i] + "\n");


            }
            System.Console.Write("\n");
            for (int i = 0; i < arrayTokens.Count; i++)
            {
                System.Console.Write(arrayTokens[i] + "\n");
            }
            System.Console.Write("\n");
            for (int i = 0; i < arrayLexemas.Count; i++)
            {
                System.Console.Write(arrayLexemas[i] + "\n");
            }
            System.Console.Write("\n");
            for (int i = 0; i < tokens.Count; i++)
            {
                System.Console.Write(tokens[i] + ",");
            }

        }
        public string getExpresionFinal()
        {
            return expresionFinal;
        }
        public void limpiar()
        {
            expresionFinal = "";
        }
        /*static void Main(string[] args)
        {
            AnalizadorExpresion obj = new AnalizadorExpresion();
            //System.Console.Write(obj.analizarTexto("Aab"));
            //obj.analizarTexto(".letra *| letra| digito\"_\"\"+\";");
            //obj.analizarTexto("letra(letra|digito|\"_\" )* ");
            obj.analizarExpresion("({vocales_min})*|?({VOCALES_may} {minusculas} {mayusculas})*|{logicos} \"\" {relacionales}");
            obj.mostrar();
            System.Console.Write("\n");
            System.Console.Write("EXPRESION FINAL " + expresionFinal);
            System.Console.ReadLine();

        }*/
    }
}
