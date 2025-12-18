using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEquips.MODEL;

namespace WpfEquips.DATA_ACCES
{
    public class DAOFactory
    {
        public static IDAO<Equips> CreateDAOInstance(DataSource source)
        {
            IDAO<Equips> dao = null;

            switch (source)
            {
                case DataSource.MySQL:
                    dao = new DAOImpMySQL(new MySQLConnection());
                    break;

                case DataSource.XML:
                    dao = new DAOImpXML("EQUIPS.XML");
                    break;

                case DataSource.CSV:
                    dao = new DAOImpCSV("clubs.csv");
                    break;

                default:
                    throw new ArgumentException("Invalid data source");
            }

            return dao;
        }
    }
    public enum DataSource
    {
        MySQL,
        XML,
        CSV
    }
}
