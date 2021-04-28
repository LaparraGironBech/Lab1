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
        private Singleton()
        {
            JugadoresList = new List<Jugadores>();
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
