using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEquips.MODEL;

namespace WpfEquips.DATA_ACCES
{
    public interface IDAO<T>
    {
        // CREAR TIPO T
        public bool Add(T ObjCreate);
        
        // ELIMINAR TIPO T
        public bool Delete(string abreviatura);

        // COGER ENTRADAS
        public List<T> GetAll();

        // ACTUALIZAR EL ANTIGUO I NUEVO 
        public bool Update(string abAntic, Equips equipNou);

        // COGER OBJETO MEDIANTE ABREBIACION
        public T GetTeam(string abreviatura);

            

            


    }
}
