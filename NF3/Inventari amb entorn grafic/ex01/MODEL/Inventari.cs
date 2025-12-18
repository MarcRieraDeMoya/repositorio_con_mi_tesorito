using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01.MODEL
{
    class Inventari
    {
        private const string FILE_NAME = "Inventari.CSV";
        private const int MAX_PRODUCTES = 100000;
        private Producte[] productes;
        private int nElem;

        public Inventari()
        {
            nElem = 0;
            productes = new Producte[MAX_PRODUCTES];
        }

        /// <summary>
        /// Obtenir la llista de productes del magatzem.
        /// </summary>
        public Producte[] Productes
        {
            get { return productes; }
        }

        /// <summary>
        /// Obtenir la suma del ValorTotal de tots els productes del magatzem.
        /// </summary>
        public double ValorTotal
        {
            get
            {
                double valorTotal = 0;
                for (int i = 0; i < nElem; i++)
                {
                    valorTotal += productes[i].Preu * productes[i].Quantitat;
                }
                return valorTotal;
            }
        }

        /// <summary>
        /// Propietat que retorna la quantitat de productes que hi ha al magatzem.
        /// </summary>
        public int count
        {
            get { return nElem; }
        }

        /// <summary>
        /// Llegeix tots els productes del fitxer INVENTARI.CSV
        /// i els afageix a l'inventari.
        /// </summary>
        public void CarregarInventari()
        {
            StreamReader sr = new StreamReader(FILE_NAME);
            string linia;
            int[] ids = new int[MAX_PRODUCTES];
            string[] noms = new string[MAX_PRODUCTES];
            double[] preus = new double[MAX_PRODUCTES];
            int[] quantitats = new int[MAX_PRODUCTES];
            string[] categories = new string[MAX_PRODUCTES];

            linia = sr.ReadLine();
            linia = sr.ReadLine();
            while (linia != null)
            {
                string[] elements = linia.Split(';');
                ids[nElem] = Convert.ToInt32(elements[0]);
                noms[nElem] = elements[1];
                preus[nElem] = Convert.ToDouble(elements[2]);
                quantitats[nElem] = Convert.ToInt32(elements[3]);
                categories[nElem] = elements[4];

                productes[nElem] = new Producte(ids[nElem], noms[nElem], preus[nElem], quantitats[nElem], categories[nElem]);
                nElem++;

                linia = sr.ReadLine();
            }
        }

        /// <summary>
        /// Obtenir un producte a partir d'un identificador passat per paràmetre (id).
        /// Si el producte no existeix al magatzem llavors el mètode ha de retornar null.
        /// </summary>
        /// <param name="id">Identificador del producte.</param>
        /// <returns>Retorna el producte si aquest està al magatzem, 
        /// o bé retorna un null si el producte no existeix.</returns>
        public Producte GetProducteById(int id)
        {
            bool trobat = false;
            int i = 0;
            Producte prod = null;

            while (!trobat && i < nElem)
            {
                if (productes[i].Id == id)
                {
                    prod = productes[i];
                    trobat = true;
                }
                i++;
            }
            return prod;
        }

        /// <summary>
        /// Retorna cert si un producte existeix al magatzem, altrament retorna fals.
        /// Utilitza el mètode GetProducteById per saber si el producte existeix. 
        /// </summary>
        /// <param name="id">Codi del producte</param>
        /// <returns>Retorna true si existeix un producte al magatzem 
        /// amb el codi de producte passat per paràmetre, altrament
        /// retorna fals</returns>
        public bool ExisteixProducte(int id)
        {
            bool existeix = false;
            if (GetProducteById(id) != null)
            {
                existeix = true;
            }
            return existeix;
        }

        /// <summary>
        /// Afegeix a l'array de productes un nou producte passat per paràmetre.
        /// No s'ha de poder afegir un producte amb un codi que ja existeix en el magatzem.
        /// </summary>
        /// <param name="nouProducte">Producte a afegir al magatzem</param>
        /// <exception cref="Exception">El codi de producte ja existeix al magatzem</exception>
        public void AfegirProducte(Producte nouProducte)
        {
            if (nElem == MAX_PRODUCTES)
            {
                throw new Exception("ERROR: No es poden afegir més productes al magatzem");
            }
            else if (ExisteixProducte(nouProducte.Id))
            {
                throw new Exception("ERROR: El codi de producte ja existeix al magatzem");
            }
            else
            {
                productes[nElem] = nouProducte;
                nElem++;
            }
        }

        /// <summary>
        /// Incrementa o decrementa una quantitat de producte.
        /// </summary>
        /// <param name="id">Codi del producte a incrementar o decrementar.</param>
        /// <param name="increment">Increment (o decrement) de producte.</param>
        /// <exception cref="Exception">Es genera un error si el codi del producte no existeix.</exception>
        public void AfegirQuantitat(int id, int increment)
        {
            if (!ExisteixProducte(id))
            {
                throw new Exception("ERROR: El codi de producte no existeix al magatzem");
            }
            else
            {
                GetProducteById(id).Quantitat = increment;
            }
        }

        /// <summary>
        /// Genera un text en CSV que conté les capçaleres seguit de tots els productes.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //S'ha de treballar amb stringbuilder
            throw new NotImplementedException();
            throw new Exception();

        }

        /// <summary>
        /// Elimina un producte del magatzem. 
        /// </summary>
        /// <param name="id">Codi del producte a eliminar.</param>
        /// <exception cref="Exception">El codi del producte no existeix al magatzem.</exception>
        public void EliminarProducte(int id)
        {
            if (!ExisteixProducte(id))
            {
                throw new ArgumentException("ERROR: El codi de producte no existeix al magatzem");
            }
            else
            {
                for (int i = 0; i < nElem; i++)
                {
                    if (productes[i].Id == id)
                    {
                        for (int j = i; j < nElem - 1; j++)
                        {
                            productes[j] = productes[j + 1];
                        }
                        productes[nElem - 1] = null;
                        nElem--;
                    }
                }
            }
        }

        /// <summary>
        /// Guarda les dades del producte al fitxer FILE_NAME. Primer has d'escriure la capçalera del 
        /// fitxer csv i després escriure tots els productes del magatzem.
        /// </summary>
        public void GuardarInventari()
        {
            StreamWriter sw = new StreamWriter("test.csv");
            sw.WriteLine("ID;Nom;Preu;Quantitat;Categoria");
            for (int i = 0; i < nElem; i++)
            {
                sw.WriteLine(productes[i].ToString());
            }
        }

        public void ModificarProducte(int id, string nouNom, double nouPreu, int novaQuantitat, string novaCategoria)
        {
            for (int i = 0; i < nElem; i++)
            {
                if (productes[i].Id == id)
                {
                    productes[i] = new Producte(id, nouNom, nouPreu, novaQuantitat, novaCategoria);
                    return;
                }
            }
            throw new Exception("ERROR: El codi de producte no existeix al magatzem");
        }



    }
}
