using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Lab1.Models
{
    public class ListaGenerics<T>
    {

        public class Nodo
        {
            public Nodo(T t)
            {
                Siguiente = null;
                data = t;
            }
            private Nodo Siguiente;

            public Nodo siguiente
            {
                get { return Siguiente; }
                set { Siguiente = value; }
            }

            private T data;
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }
        //Declaraci´´on de los nodos y cantidades
        public int Cantidad;
        public Nodo PrimerNodo;
        public Nodo UltimoNodo;



        //Metodos
        public void AgregarInicio(T t)
        {
            Nodo Nom1 = new Nodo(t);
            if (Cantidad == 0)
            {
                PrimerNodo = Nom1;
                UltimoNodo = Nom1;
            }
            else
            {
                Nodo temp = Nom1;
                temp.siguiente = PrimerNodo;
                PrimerNodo = temp;

            }
            Cantidad++;
        }

        public void AgregarFinal(T t)
        {
            Nodo Nom2 = new Nodo(t);
            if (Cantidad == 0)
            {
                AgregarInicio(t);
            }
            else
            {
                UltimoNodo.siguiente = Nom2;
                UltimoNodo = Nom2;
            }
            Cantidad++;
        }

        public void AgregarPos(int pos, T t)
        {
            Nodo Nom3 = new Nodo(t);
            if (Cantidad == 0 || pos == 0)
            {
                AgregarInicio(t);
            }
            else
            {
                if (Cantidad >= Cantidad)
                {
                    AgregarFinal(t);
                }
                else
                {
                    Nodo pretemp = PrimerNodo;
                    Nodo temp = Nom3;
                    int cont = 0;

                    while (cont < (pos - 1))
                    {
                        pretemp = pretemp.siguiente;
                        cont++;
                    }
                    temp.siguiente = pretemp.siguiente;
                    pretemp.siguiente = temp;
                    Cantidad++;
                }
            }
        }


        public Nodo ObtenerInicio()
        {
            return PrimerNodo;
        }

        public Nodo ObtenerFinal()
        {
            return UltimoNodo;
        }

        public Nodo ObtenerPos(int Pos)
        {
            if (Cantidad == 0 || Pos == 0)
            {
                return ObtenerInicio();
            }
            else
                if (Pos >= Cantidad)
            {
                return ObtenerFinal();
            }
            else
            {
                Nodo temp = PrimerNodo;
                int cont = 0;
                while (cont < Pos)
                {
                    temp = temp.siguiente;
                    cont++;
                }
                return temp;
            }


        }
        //Eliminaciones---------------------------------------------------------------------------------->

        public void EliminarInicio()
        {
            Nodo auxiliar = PrimerNodo.siguiente;
            PrimerNodo = auxiliar;
            Cantidad--;
        }

        public void EliminarFinal()
        {
            if (Cantidad > 0)
            {
                Nodo auxiliar;
                auxiliar = ObtenerPos(Cantidad - 2);
                UltimoNodo = auxiliar;
                UltimoNodo.siguiente = null;
                Cantidad--;
            }
        }


        public void Eliminarpos(int posi)
        {
            int pos = posi;
            if (pos == 0)
            {
                EliminarInicio();
            }
            else
            {
                if (pos == (Cantidad - 1))
                {
                    EliminarFinal();
                }
                else
                {
                    if (pos > 0 && pos < (Cantidad - 1))
                    {
                        Nodo auxiliar1 = ObtenerPos(pos - 1);
                        Nodo auxiliar2 = ObtenerPos(pos);
                        Nodo auxiliar3 = ObtenerPos(pos + 1);

                        auxiliar1.siguiente = auxiliar3;
                        auxiliar2.siguiente = null;
                        Cantidad--;
                    }
                }
            }



        }
        //Insertar-------------------------------------
        public void InsertarInicio(Nodo t)
        {
            PrimerNodo = t;
        }
        public void insertarfinal(Nodo t)
        {
            UltimoNodo = t;
        }
        public void insertarpos(int pos, T t)
        {
            Nodo Nom3 = new Nodo(t);
            if (pos == 0)
            {
                InsertarInicio(Nom3);
            }
            else
            {
                if (pos == (Cantidad - 1))
                {
                    insertarfinal(Nom3);
                }
                else
                {
                    if (pos > 0 && pos < (Cantidad - 1))
                    {
                        Nodo temp = PrimerNodo;
                        int cont = 0;
                        while (cont < pos)
                        {
                            temp = temp.siguiente;
                            cont++;
                        }
                        temp = Nom3;
                    }
                }
            }
        }
    }

}

