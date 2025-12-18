using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEquips.MODEL;

namespace WpfEquips.DATA_ACCES
{
    using System.Xml;
    using System.Xml.Linq;

    using System.Xml.Linq;

    public class DAOImpXML : IDAO<Equips>
    {
        private string fileName;

        public DAOImpXML(string xmlFile)
        {
            fileName = xmlFile;
        }

        public bool Add(Equips ObjCreate)
        {
            bool fet = false;

            XDocument doc = XDocument.Load(fileName);

            XElement nouEquip = new XElement("EQUIP",
                new XElement("ABREVIACIO", ObjCreate.Abv),
                new XElement("NOM", ObjCreate.Nom),
                new XElement("PRESSUPOST", ObjCreate.HexPress),
                new XElement("LOGO", ObjCreate.ImgClub)
            );

            doc.Root.Add(nouEquip);
            doc.Save(fileName);

            fet = true;
            return fet;
        }

        public bool Delete(string abreviatura)
        {
            bool fet = false;

            XDocument doc = XDocument.Load(fileName);

            XElement equip = doc.Descendants("EQUIP").FirstOrDefault(e => e.Element("ABREVIACIO") != null && e.Element("ABREVIACIO").Value == abreviatura);

            if (equip != null)
            {
                equip.Remove();
                doc.Save(fileName);
                fet = true;
            }

            return fet;
        }

        public List<Equips> GetAll()
        {
            List<Equips> llista = new List<Equips>();

            XDocument doc = XDocument.Load(fileName);

            IEnumerable<XElement> equips = doc.Descendants("EQUIP");

            foreach (XElement e in equips)
            {
                string abv = e.Element("ABREVIACIO") != null ? e.Element("ABREVIACIO").Value : "";
                string nom = e.Element("NOM") != null ? e.Element("NOM").Value : "";
                string press = e.Element("PRESSUPOST") != null ? e.Element("PRESSUPOST").Value : "";
                string logo = e.Element("LOGO") != null ? e.Element("LOGO").Value : "";

                llista.Add(new Equips(nom, abv, press, logo));
            }

            return llista;
        }

        public Equips GetTeam(string abreviatura)
        {
            Equips equipTrobat = null;

            XDocument doc = XDocument.Load(fileName);

            XElement e = doc.Descendants("EQUIP").FirstOrDefault(x => x.Element("ABREVIACIO") != null && x.Element("ABREVIACIO").Value == abreviatura);

            if (e != null)
            {
                string nom = e.Element("NOM") != null ? e.Element("NOM").Value : "";
                string press = e.Element("PRESSUPOST") != null ? e.Element("PRESSUPOST").Value : "";
                string logo = e.Element("LOGO") != null ? e.Element("LOGO").Value : "";

                equipTrobat = new Equips(nom, abreviatura, press, logo);
            }

            return equipTrobat;
        }

        public bool Update(string abAntic, Equips equipNou)
        {
            bool fet = false;

            XDocument doc = XDocument.Load(fileName);

            XElement equip = doc.Descendants("EQUIP").FirstOrDefault(e => e.Element("ABREVIACIO") != null && e.Element("ABREVIACIO").Value == abAntic);

            if (equip != null)
            {
                equip.Element("ABREVIACIO")?.SetValue(equipNou.Abv);
                equip.Element("NOM")?.SetValue(equipNou.Nom);
                equip.Element("PRESSUPOST")?.SetValue(equipNou.HexPress);
                equip.Element("LOGO")?.SetValue(equipNou.ImgClub);

                doc.Save(fileName);
                fet = true;
            }

            return fet;
        }

    }



}
