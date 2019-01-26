using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustIQ
{
    public class CSalon
    {
        /// <summary>
        /// Nombre del salon
        /// </summary>
        public string nombre;

        /// <summary>
        /// Edificio del salon
        /// </summary>
        public string edificio;

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public CSalon()
        {
            nombre = "";
            edificio = "";
        }

        /// <summary>
        /// Constructor con asignacion
        /// </summary>
        /// <param name="name"></param>
        /// <param name="edif"></param>
        public CSalon(string name, string edif)
        {
            nombre = name;
            edificio = edif;
        }

        /// <summary>
        /// Constructor con replica
        /// </summary>
        /// <param name="salon"></param>
        public CSalon(CSalon salon)
        {
            nombre = salon.nombre;
            edificio = salon.edificio;
        }
    }
}
