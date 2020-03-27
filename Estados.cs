using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1_OLC1
{
    public class Estados
    {
        private List<Estados> estadosPrevios;
        private List<Estados> estadosSiguientes; 
        private int idEstado;

        private bool inicial;
        private bool final;

        public Estados(int idEstado_)
        {
            this.idEstado = idEstado_;
            this.estadosPrevios = new List<Estados>(); //new LinkedList<State>();
            this.estadosPrevios = new List<Estados>();
            Automata.contadorEstados++;
        }
        public Estados(int idEstado_, List<Estados> estadoPrevio_, List<Estados> estadoSiguiente_)
        {
            this.idEstado = idEstado_;
            this.estadosPrevios = estadoPrevio_; //private List<Estados> estadosPrevios;
            this.estadosSiguientes = estadoSiguiente_;
            Automata.contadorEstados++;
        }
        public Estados(int idEstado_, bool afd)
        {
            this.idEstado = idEstado_;
            this.estadosPrevios = new List<Estados>();
            this.estadosSiguientes = new List<Estados>();
        }
        public void agregarEstadoPrevio(Estados estadoPrevio_)
        {
            this.estadosPrevios.Add(estadoPrevio_);
        }

        public void agregarEstadoSiguiente(Estados estadoSiguiente_)
        {
            this.estadosSiguientes.Add(estadoSiguiente_);
        }

        public List<Estados> getEstadoPrevio()
        {
            return this.estadosPrevios; //Retorno el array
        }

        public List<Estados> getEstadosSiguientes()
        {
            return this.estadosSiguientes;
        }

        public String toString()
        {
            return this.idEstado.ToString();
        }

        public int getIdEstado() { return this.idEstado; }

        public void setInicio(bool inicial) { this.inicial = inicial; }

        public bool getInicio() { return this.inicial; }

        public void setFinal(bool final) { this.final = final; }

        public bool getFinal() { return this.final; }
    }
}
