using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfEquips.MODEL;

namespace WpfEquips.DATA_ACCES
{
    public class DAOImpCSV : IDAO<Equips>
    {
        private string fileName;

        public DAOImpCSV(string csv)
        {
            fileName = csv;
        }

        public bool Add(Equips ObjCreate)
        {
            bool fet = false;
            string liniaAfegir = $"{ObjCreate.Nom};{ObjCreate.Abv};{ObjCreate.HexPress};{ObjCreate.ImgClub}";

            StreamWriter sw = new StreamWriter(fileName); 
            sw.WriteLine(liniaAfegir);
            sw.Close();

            fet = true;
            return fet;
        }

        public bool Delete(string abreviatura)
        {
            StringBuilder fitxerCsv = new StringBuilder();
            bool fet = false;

            StreamReader sr = new StreamReader(fileName);
            string linia = sr.ReadLine();

            while (linia != null)
            {
                string[] parts = linia.Split(';');
                if (parts.Length == 4 && parts[1] != abreviatura)
                {
                    fitxerCsv.AppendLine(linia);
                }
                linia = sr.ReadLine();
            }
            sr.Close();

            File.WriteAllText(fileName, fitxerCsv.ToString());
            fet = true;
            return fet;
        }

        public List<Equips> GetAll()
        {
            List<Equips> llista = new List<Equips>();
            StreamReader sr = new StreamReader(fileName);

            string linia = sr.ReadLine();
            while (linia != null)
            {
                string[] parts = linia.Split(';');
                if (parts.Length == 4)
                {
                    Equips e = new Equips(parts[0], parts[1], parts[2], parts[3]);
                    llista.Add(e);
                }
                linia = sr.ReadLine();
            }
            sr.Close();

            return llista;
        }

        public Equips GetTeam(string abreviatura)
        {
            Equips equipTrobat = null;
            StreamReader sr = new StreamReader(fileName);

            string linia = sr.ReadLine();
            while (linia != null)
            {
                string[] parts = linia.Split(';');
                if (parts.Length == 4 && parts[1] == abreviatura)
                {
                    equipTrobat = new Equips(parts[0], parts[1], parts[2], parts[3]);
                    break;
                }
                linia = sr.ReadLine();
            }
            sr.Close();

            return equipTrobat;
        }

        public bool Update(string abAntic, Equips equipNou)
        {
            StringBuilder fitxerCsv = new StringBuilder();
            bool fet = false;

            using (StreamReader sr = new StreamReader(fileName))
            {
                string linia = sr.ReadLine();
                while (linia != null)
                {
                    string[] parts = linia.Split(';');
                    if (parts.Length == 4)
                    {
                        if (parts[1] == abAntic)
                        {
                            parts[0] = equipNou.Nom;
                            parts[1] = equipNou.Abv;
                            parts[2] = equipNou.HexPress;
                            parts[3] = equipNou.ImgClub;
                        }
                        fitxerCsv.AppendLine($"{parts[0]};{parts[1]};{parts[2]};{parts[3]}");
                    }
                    linia = sr.ReadLine();
                }
            }

            File.WriteAllText(fileName, fitxerCsv.ToString());
            fet = true;

            return fet;
        }

    }


}
