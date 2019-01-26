using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustIQ
{
    public class CProfesor
    {
        /// <summary>
        /// Nombres del profesor
        /// </summary>
        public string nombres;

        /// <summary>
        /// Apellidos del profesor
        /// </summary>
        public string apellidos;

        /// <summary>
        /// Direccion de correo del profesor
        /// </summary>
        public string correo;

        public bool[,] dispMañana = null;

        public bool[,] dispTarde = null;

        public bool planta = false;

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public CProfesor()
        {
            nombres = "N";
            apellidos = "N";
            correo = null;

            dispMañana = new bool[10,2];
            for (int i = 0; i < 10; i++)
            {
                dispMañana[i,0] = true;
                dispMañana[i, 1] = true;
            }

            dispTarde = new bool[9,2];
            for (int i = 0; i < 9; i++)
            {
                dispTarde[i,0] = true;
                dispTarde[i, 1] = true;
            }
        }

        /// <summary>
        /// Constructor con asignacion
        /// </summary>
        /// <param name="name">nombres del profesor</param>
        /// <param name="lastname">apellidos del profesor</param>
        public CProfesor(string name, string lastname, string mail)
        {
            nombres = name;
            apellidos = lastname;
            correo = mail;

            dispMañana = new bool[10, 2];
            for (int i = 0; i < 10; i++)
            {
                dispMañana[i, 0] = true;
                dispMañana[i, 1] = true;
            }

            dispTarde = new bool[9, 2];
            for (int i = 0; i < 9; i++)
            {
                dispTarde[i, 0] = true;
                dispTarde[i, 1] = true;
            }
        }

        /// <summary>
        /// Constructor con replica
        /// </summary>
        /// <param name="est">profesor a replicar</param>
        public CProfesor(CProfesor prof)
        {
            nombres = prof.nombres;
            apellidos = prof.apellidos;
            correo = prof.correo;

            for (int i = 0; i < 10; i++)
            {
                dispMañana[i,0] = prof.dispMañana[i,0];
                dispMañana[i, 1] = prof.dispMañana[i, 1];
            }

            for (int i = 0; i < 9; i++)
            {
                dispTarde[i,0] = prof.dispTarde[i,0];
                dispTarde[i, 1] = prof.dispTarde[i, 1];
            }

            planta = prof.planta;
        }

        public static bool operator ==(CProfesor pr1, CProfesor pr2)
        {
            return ((pr1.nombres == pr2.nombres) && (pr1.apellidos == pr2.apellidos) && (pr1.correo == pr2.correo));
        }

        public static bool operator !=(CProfesor pr1, CProfesor pr2)
        {
            return ((pr1.nombres != pr2.nombres) || (pr1.apellidos != pr2.apellidos) || (pr1.correo != pr2.correo));
        }
    }
}
