using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEquips.MODEL
{
    public class Equips
    {
        private string nom;
        private string abv;
        private string hexPress;
        private string imgClub;


        public Equips(string nom, string abv, string hexPress, string imgClub)
        {
            this.nom = nom;
            this.abv = abv;
            this.hexPress = hexPress;
            this.imgClub = imgClub;
        }

        public string Nom
        {
            get { return nom; }
        }

        public string Abv
        {
            get { return abv; }
        }

        public string HexPress
        {
            get { return hexPress; }
        }

        public string ImgClub
        {
            get { return imgClub; }
        }




    }
}
