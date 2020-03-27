using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1_OLC1
{
    public class PostFijo
    {
        //public static readonly Dictionary<Char, int> precedencia;



        //IDictionary<Char, int> map = new Dictionary<Char, int>();
        public static Dictionary<char, int> precedencia;


        static PostFijo()
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            map.Add('(', 1);
            map.Add('|', 2);
            map.Add('.', 3); // explicit concatenation operator
            map.Add('?', 4);
            map.Add('*', 4);
            map.Add('+', 4);
            map.Add('^', 5);
            
            //precedenceMap = Collections.unmodifiableMap(map);
            precedencia = map;
        }




        /*map['('] = 1;
        map['|'] = 2;
        map['.'] = 3; // explicit concatenation operator
        map['?'] = 4;
        map['*'] = 4;
        map['+'] = 4;
        map['^'] = 5;*/



        //precedencia = new Dictionary<char, int>(map.);
        // (...)

        // (...)
        //var read_only = map.ToLookup(kv => kv.Key, kv => kv.Value);

        //precedencia = read_only;




        private static int? getPrecedencia(char? c)
        {
            int precedencia_ = precedencia[(char)c];
            return precedencia_ == null ? 6 : precedencia_;

        }
        private static String expresionRegularFormato(String regular)
        {
            String res = "";  //new String()
            List<Char> operadores = new List<Char>(new[] { '|', '?', '+', '*', '^' });
            List<Char> operadoresBinarios = new List<Char>(new[] { '^', '|' });
            for (int i = 0; i < regular.Length; i++)
            {
                Char c1 = regular.ElementAt(i);
                if (i + 1 < regular.Length)
                {
                    Char c2 = regular.ElementAt(i + 1);
                    res += c1;
                    if (!c1.Equals('(') && !c2.Equals(')') && !operadores.Contains(c2) && !operadoresBinarios.Contains(c1))
                    {
                        res += '.';
                    }
                }
            }
            res += regular.ElementAt(regular.Length - 1);
            return res;

        }
        ///////////////////////////////////////////////////////No se si es util ////////////////////////////
        public static String infijo(String regular)
        {
            String postFijo = ""; //new String
            Stack<Char> pila = new Stack<Char>();
            String formatoExpresion = expresionRegularFormato(regular);
            foreach (Char c in formatoExpresion.ToCharArray()) // for (Character c : formattedRegEx.toCharArray())
            {
                switch (c)
                {
                    case '(':
                        pila.Push(c);
                        break;
                    case ')':
                        while (!pila.Peek().Equals('('))
                        {
                            postFijo += pila.Pop();
                        }
                        pila.Pop();
                        break;
                    default:
                        while (pila.Count > 0)
                        {
                            Char? p = pila.Peek();
                            int? pPrecedencia = getPrecedencia(p); //Integer peekedCharPrecedence = getPrecedence(peekedChar);
                            int? pActual = getPrecedencia(c);      //Integer currentCharPrecedence = getPrecedence(c);

                            if (pPrecedencia >= pActual)
                            {
                                postFijo += pila.Pop();

                            }
                            else
                            {
                                break;
                            }

                        }
                        pila.Push(c);
                        break;
                }
            }
            while (pila.Count > 0)
            {
                postFijo += pila.Pop();
            }
            return postFijo;
        }
    }
}
