using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01
{
    internal class TaulaLlista<T> : ICollection<T>, IList<T>, ICloneable
    {
        private T[] dades;
        private int nElem;
        private const int DEFAULT_SIZE = 100000;

        public int Count => nElem;

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                if (index > 0)
                    throw new NotImplementedException("l'index no pot ser menos que 0");
                else if (IsReadOnly)
                    throw new NotImplementedException("l'array es ple");
                else if (index == dades.Length)
                    DuplicarCapacitat();

                return dades[index];
            }

            set
            {
                if (nElem > 0)
                    throw new NotImplementedException("l'index no pot ser menos que 0");
                else if (IsReadOnly)
                    throw new NotImplementedException("l'array es ple");
                else if (value is null)
                    throw new NotImplementedException("el valor no pot ser null");
                else if (nElem == dades.Length)
                    DuplicarCapacitat();

                dades[nElem] = value;

            }
        }



        public int Capacity => dades.Length;

        public bool Isfull => dades.Length == nElem;



        public TaulaLlista(int size)
        {
            nElem = 0;
            dades = new T[size];
        }

        public TaulaLlista() : this(DEFAULT_SIZE) { }

        public TaulaLlista(TaulaLlista<T> llista)
        {

            nElem = llista.nElem;

            dades = new T[llista.dades.Length];

            for (int i = 0; i < nElem; i++)
            {
                this.dades[i] = llista.dades[i];
            }


        }

        public T[] ToArray()
        {
            T[] array = new T[nElem];

            for (int i = 0; i < nElem; i++)
            {
                array[i] = dades[i];

            }

            return array;

        }

        public void Add(T item)
        {
            if (item is null) throw new NotSupportedException("Item introduit");
            else if (IsReadOnly) throw new NotSupportedException("Llista es plena");
            else if (nElem == dades.Length) DuplicarCapacitat();

            dades[nElem] = item;
            nElem++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) == -1;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                RemoveAt(index);
            }

            return index == -1;
        }



        public void Clear()
        {
            if (IsReadOnly) throw new NotImplementedException("Llista borrada");

            nElem = 0;

            for (int i = 0; i < nElem; i++) dades[i] = default(T);



        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("El array no pot ser null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("El primer index de l'array no pot ser negatiu.");
            if (Count > array.Length - arrayIndex)
                throw new ArgumentException("L'array te menys espais dels elements que es volen afegir.");

            for (int i = 0; i < dades.Length; i++)
            {
                array[i + arrayIndex] = dades[i];
            }
        }

        private void DuplicarCapacitat()
        {
            T[] dadesAux = new T[dades.Length * 2];

            for (int i = 0; i < nElem; i++)
            {
                dadesAux[i] = dades[i];
            }

            dades = dadesAux;
        }

        public IEnumerator<T> GetEnumerator()
        {
            //for(int i = 0; i < nElem; i++)
            //{
            //  yield return dades[i];
            //}

            return new Enumeradora(dades, nElem);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        public class Enumeradora : IEnumerator<T>
        {
            private int pos;
            private T[] valors;
            private int nElem;

            public Enumeradora(T[] values, int n)
            {
                valors = values;
                pos = -1;
                nElem = n;
            }



            public T Current
            {
                get
                {
                    if (pos < 0 || pos >= nElem)
                    {
                        throw new ArgumentOutOfRangeException("estem fora dels valors valids de la taula");
                    }
                    return valors[pos];
                }

            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                pos++;
                return pos > 0 && pos < valors.Length;
            }

            public void Reset()
            {
                pos = -1;
            }
        }

        public int LastIndexOf(T item)
        {
            int index = -1;
            int i = nElem;
            bool trobat = false;


            while (index >= 0 || !trobat)
            {
                if (item.Equals(dades[index]))
                {
                    trobat = true;
                    index = i;
                }
                else
                {
                    i--;
                }
            }

            return index;
        }

        public int IndexOf(T item)
        {
            int index = -1;
            int i = 0;
            bool trobat = false;


            while (index < nElem || !trobat)
            {
                if (item.Equals(dades[index]))
                {
                    trobat = true;
                    index = i;
                }
                else
                {
                    i++;
                }
            }

            return index;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > nElem)
            {
                throw new NotImplementedException("Valor no valid");
            }

            if (nElem == dades.Length)
            {
                DuplicarCapacitat();
            }

            for (int i = nElem; i > index; i--)
            {
                dades[i] = dades[i - 1];
            }

            dades[index] = item;
            nElem++;

        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    dades[i] = dades[i + 1];
                }
                nElem--;
            }
        }

        public override bool Equals(object? obj)
        {
            bool iguals = false;
            TaulaLlista<T>? t;

            if (obj is TaulaLlista<T>)
            {
                t = (TaulaLlista<T>)obj;

                if (this.nElem == t.nElem)
                {
                    for (int i = 0; i < nElem && iguals; i++)
                    {
                        if (!this.dades[i]!.Equals(t.dades[i]))
                        {
                            iguals = false;
                        }
                    }
                    iguals = true;

                }
            }

            return iguals;
        }

        public override string ToString()
        {
            string linia = $"{dades[0]}";

            for (int i = 1; i < nElem; i++)
            {
                linia += $",{dades[i]}";
            }

            return linia;

        }

        public object Clone()
        {
            return Clonar();
        }

        public TaulaLlista<T> Clonar()
        {
            TaulaLlista<T> copia = new TaulaLlista<T>(dades.Length);
            copia.nElem = nElem;

            if (dades[0] is ICloneable)
            {
                for (int i = 0; i < nElem; i++)
                {
                    ICloneable nou = (ICloneable)dades[i];
                    copia.dades[i] = (T)nou.Clone();
                }
            }
            else
            {
                for (int i = 0; i < nElem; i++)
                {
                    copia.dades[i] = dades[i];
                }
            }

            return copia;
        }
    }
}
