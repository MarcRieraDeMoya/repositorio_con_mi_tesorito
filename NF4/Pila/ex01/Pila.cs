using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ex01
{
    internal class Pila<T>: IEnumerable<T>, ICollection<T>
    {
        private T[] data;
        private const int DEFAULT_SIZE = 5;
        private int top = -1;

        public T this[int index]
        {
            get
            {
                if (index < 0)
                    throw new NotImplementedException("l'index no pot ser menor que 0");
                else if (index >= data.Length)
                    throw new NotImplementedException("L'index esta fora de la nostra pila");

                return data[index];
                    
            }
        }

        public Pila(int size)
        {
            top = -1;
            data = new T[size];
        }
            

        public Pila() : this(DEFAULT_SIZE) { }


        public Pila(IEnumerable<T> pila )
        {
             
        }

        public bool isFull
        {
            get { return top == data.Length; }
        }

        public bool isEmpty
        {
            get { return top == -1; }
        }

        public int Capacity
        {
            get { return data.Length; }
        }

        public int Count
        {
            get { return top + 1; }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeradorPila<T>(data, top);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public class EnumeradorPila<T> : IEnumerator<T>
        {
            private int top;
            private T[] valors;
            private int pos;

            public EnumeradorPila(T[]values, int t)
            {
                valors = values;
                top = t;
                pos = t + 1;
            }


            public T Current
            {
                get
                {
                    if (pos < 0 || pos > top + 1)
                    {
                        throw new ArgumentOutOfRangeException("estem fora dels valors valids de la taula");
                    }
                    return valors[pos];
                }
            }   

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                valors = null;
            }

            public bool MoveNext()
            {
                pos--;
                return pos >= 0 && pos <= top;
            }

            public void Reset()
            {
                pos = top + 1;
            }

        }

        public void Add(T item)
        {
            Push(item);
        }

        public void Clear()
        {
            if (top == -1)
                throw new NotImplementedException("Pila borrada");

            top = -1;

            for (int i = 0; i < top; i++) data[i] = default(T);

        }

        public bool Contains(T item)
        {
            bool trobat = false;
            int i = 0;

            while(i < data.Length && !trobat)
            {
                if (data[i].Equals(item) )
                {
                    trobat = true;
                }

                i++;
            }

            return trobat;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("El array no pot ser null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("El primer index de l'array no pot ser negatiu.");
            if (Count > array.Length - arrayIndex)
                throw new ArgumentException("L'array te menys espais dels elements que es volen afegir.");

            for (int i = arrayIndex; i >= 0; i--)
            {
                array[i] = data[i];
            }
        }

        public bool Remove(T item)
        {
            bool trobat = false;
            
            
            if(Contains(item))
            {

                

            }

            return trobat;
        }

        public T Pop()
        {
            if (top == -1)
                throw new InvalidOperationException("No hi ha valors per fer Pop");

            top--;

            return data[top + 1];

            

        }

        public void Push(T item)
        {
            if (top == data.Length)
                throw new StackOverflowException("la pila esta llena");

            top++;

            data[top] = item;
        }

        public T Peek()
        {
            if (top == -1)
                throw new InvalidOperationException("No hi ha valors per mostrar res");

            return data[top];
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            int i = 0;

            foreach(T valor in this)
            {
                array[i] = valor;
                i++;
            }
    
            return array;
            
        }

        public int EnsureCapacity(int newCapacity)
        {

            int capacitatAntiga = data.Length;
            
            if(data.Length < newCapacity)
            {
                capacitatAntiga = newCapacity;
            }

            return capacitatAntiga;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            string linia = $"[{data[top]}";

            for (int i = top -1; i >= 1 ; i--)
            {
                linia += $",{data[i]}";
            }

            linia += $",{data[0]}]";

            return linia;
        }

    }
}
