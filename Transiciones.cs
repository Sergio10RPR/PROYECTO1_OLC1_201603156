using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1_OLC1
{
    public class Transiciones
    {
        private Estados estadoInicial; //private State initialState; //estadoInicial
        private Estados estadoFinal;
        private String transicionSimbolo;

        public Transiciones(String transicionSimbolo_)
        {
            this.transicionSimbolo = transicionSimbolo_;
            this.estadoInicial = new Estados(Automata.contadorEstados);
            this.estadoFinal = new Estados(Automata.contadorEstados);

            this.estadoInicial.agregarEstadoSiguiente(this.estadoFinal);
            this.estadoFinal.agregarEstadoPrevio(this.estadoInicial);
        }
        public Transiciones(String transicionSimbolo_, Estados estadoInicial_, Estados estadoFinal_)
        {
            this.transicionSimbolo = transicionSimbolo_;
            this.estadoInicial = estadoInicial_;
            this.estadoFinal = estadoFinal_;

            this.estadoInicial.agregarEstadoSiguiente(this.estadoFinal);
            this.estadoFinal.agregarEstadoPrevio(this.estadoInicial);
        }
        public Estados getEstadoInicial()
        {
            return this.estadoInicial;
        }
        public Estados getEstadoFinal()
        {
            return this.estadoFinal;
        }
        public String toString()
        {
            return estadoInicial.ToString() + "-" + transicionSimbolo + "-" + estadoFinal.ToString();
        }
        public String getTransicionSimbolo()
        {
            return this.transicionSimbolo;
        }
    }
}
