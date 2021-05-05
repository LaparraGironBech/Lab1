using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models.Data
{
    public sealed class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
        public List<Jugadores> JugadoresList;
        public List<Jugadores> JugadoresBuscados;
        public ListaGenerics<Jugadores> JugadoresGeneric;
        public int L;
        public int id;
        public string ejecuciones;
        private Singleton()
        {
            JugadoresList = new List<Jugadores>();
            JugadoresBuscados = new List<Jugadores>();
            JugadoresGeneric = new ListaGenerics<Jugadores>();
            ejecuciones = "";
            id = 1;
        }

        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
