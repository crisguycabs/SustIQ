using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustIQ
{
    public class CEstudiante
    {
        /// <summary>
        /// Nombres del estudiante
        /// </summary>
        public string nombre;

        /// <summary>
        /// Direccion de correo del estudiante
        /// </summary>
        public string correo;

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public CEstudiante()
        {
            nombre = null;            
            correo = null;
        }

        /// <summary>
        /// Constructor con asignacion
        /// </summary>
        /// <param name="cod">codigo del estudiante</param>
        /// <param name="name">nombres del estudiante</param>
        /// <param name="lastname">apellidos del estudiante</param>
        public CEstudiante(string name, string mail)
        {            
            nombre = name;
            correo = mail;
        }

        /// <summary>
        /// Constructor con replica
        /// </summary>
        /// <param name="est">estudiante a replicar</param>
        public CEstudiante(CEstudiante est)
        {
            nombre = est.nombre;
            correo = est.correo;
        }
    }
}
