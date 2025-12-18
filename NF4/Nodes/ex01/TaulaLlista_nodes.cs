using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01
{
    internal class TaulaLlista_nodes<T> : IList<T>
    {


        #region Class Node
        private class Node
        {
            private T data;
            private Node next;



            public Node(T data)
            {
                this.data = data;
            }

            public T Data
            {
                get { return data; }
                set { data = value; }
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }


        }
        #endregion

        #region Atributs


        private Node head;
        private Node tail;
        private int nElem;
        #endregion

        #region Constructors


        public TaulaLlista_nodes()
        {
            nElem = 0;
            head = null;
            head = null;
        }
        #endregion

        #region Propietats


        public int Count => nElem;

        public bool IsReadOnly => false;

        public T this[int index] 
        { 
            get
            {


                if (index < 0 || index >= nElem )
                {
                    throw new ArgumentOutOfRangeException("l'index no pot ser menos que 0");
                }

                Node aux = head;

                for(int i = 0; i < index; i++)
                {
                    aux = aux.Next;
                }

                return aux.Data;

            }

            set
            {

                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException("l'index no pot ser menos que 0");
                else if (IsReadOnly)
                    throw new NotSupportedException("la taula es ReadOnly");
                else if (value is null)
                    throw new ArgumentNullException("el valor no pot ser null");

                Node aux = head;

                for (int i = 0; i < index; i++)
                {
                    aux = aux.Next;
                }

                aux.Data = value;

            }

        }

        #endregion

        #region IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }



        public class enumeradorNode : IEnumerator<T>
        {
            private Node head;
            private Node aux;
            private bool iniciat = false;

            public T Current
            {
                get
                {
                    if(aux == null)
                    {
                        throw new IndexOutOfRangeException("No hi ha cap valor");
                    }
                    else
                    {
                        return aux.Data;
                    }
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                head = null;
            }

            public bool MoveNext()
            {
                if(iniciat)
                {
                    aux = aux.Next;
                }
                else
                {
                    aux = head;
                    iniciat = true;
                }

                return (aux != null);
            }

            public void Reset()
            {
                aux = null;
                iniciat = false;
            }
        }





        #endregion

        #region ICollection
        public void Add(T data)
        {
            if (IsReadOnly) throw new NotSupportedException("Taula llista node es ReadOnly");

            Node nouNode = new Node(data);
            
            if(nElem == 0)
            {
                head = nouNode;
                tail = nouNode;
            }
            else
            {
                tail.Next = nouNode;
                tail = nouNode;
            }

            nElem++;
            

        }

        public void Clear()
        {
            if (IsReadOnly) throw new NotSupportedException("Taula llista node es ReadOnly");
            nElem = 0;
            head = null;
            tail = null;
        }

        public bool Contains(T item)
        {
            bool trobat = false;
            Node aux = head;
            

            while(aux != null && !trobat )
            {

                if(aux.Equals(item))
                {
                    trobat = true;
                }
                else
                {
                    aux = aux.Next;
                }

                
            }

            return trobat;

        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException();
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException();
            if (array.Length - arrayIndex < nElem) throw new ArgumentException();

            Node aux = head;
            for (int i = 0; i < nElem; i++)
            {
                if (aux.Data is ICloneable clon)
                {
                    //ICloneable clon = (ICloneable)aux.Data;
                    array[i + arrayIndex] = (T)clon.Clone();
                }
                else
                    array[i + arrayIndex] = aux.Data;

                aux = aux.Next;
            }
        }


        public bool Remove(T item)
        {
            if (item == null) throw new ArgumentNullException("Item null.");
            if (IsReadOnly) throw new NotSupportedException("TaulaLlista Node és ReadOnly.");
            bool trobat = false;
            Node anterior = head;
            Node actual = head.Next;

            if (head == null) trobat = false;
            else if (head.Data.Equals(item))
            {
                trobat = true;
                if (head == tail) //if(nElem = 1)
                {
                    head = null;
                    tail = null;
                }
                else
                    head = head.Next;
            }
            else
            {
                while (actual != null && !trobat)
                {
                    if (actual.Data.Equals(item))
                    {
                        trobat = true;
                        anterior.Next = actual.Next;
                        if (tail == actual)
                            tail = anterior;
                    }
                    else
                    {
                        anterior = actual;
                        actual = actual.Next;
                    }
                }
            }

            if (trobat) nElem--;

            return trobat;
        }

        #endregion

        #region Ilist
        public int IndexOf(T item)
        {
            Node aux = head;
            bool trobat = false;
            int index = 0;

            while (!trobat && aux != null)
            {
                if (aux.Data.Equals(item))
                    trobat = true;
                else
                {
                    index++;
                    aux = aux.Next;
                }
            }

            if (!trobat)
                index = -1;

            return index;
        }

        public void Insert(int index, T item)
        {
            if (IsReadOnly) throw new NotSupportedException("TaulaLlista Node és ReadOnly.");
            if (index < 0) throw new ArgumentOutOfRangeException("Índex no vàlid.");
            Node nou = new Node(item);
            Node aux = head;

            if (nElem == 0)
            {
                head = nou;
                tail = nou;
            }
            else
            {
                if (index == nElem - 1)
                {
                    tail.Next = nou;
                    tail = nou;
                }
                else
                {
                    for (int i = 0; i < index; i++)
                    {
                        aux.Next = aux;
                    }
                    nou.Next = aux.Next;
                    aux.Next = nou;
                }
            }
            nElem++;
        }

        

        public void RemoveAt(int index)
        {
            T valor = this[index];
            Remove(valor);
        }

        #endregion

        public override string ToString()
        {


            for(int i = 0; i < nElem; i++)
            {

            }
        }

        public override bool Equals(object? obj)
        {
            bool iguals = false;
            TaulaLlista_nodes<T> t;




            if (obj is TaulaLlista_nodes<T>)
            {
                t = (TaulaLlista_nodes<T>)obj;

                if (this.nElem == t.nElem)
                {
                    for (int i = 0; i < nElem && iguals; i++)
                    {
                        if (!this.!.Equals(t.head))
                        {
                            iguals = false;
                        }
                        else
                        {
                            iguals = true;
                        }
                    }


                }
            }

            return iguals;
        }

    }
}

