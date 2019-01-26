using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustIQ
{
    public class CProyecto
    {
        /// <summary>
        /// Codigo del proyecto
        /// </summary>
        public int codigo;

        /// <summary>
        /// Nombre del proyecto
        /// </summary>
        public string nombre;

        /// <summary>
        /// Estudiante 1
        /// </summary>
        public CEstudiante estudiante1;

        /// <summary>
        /// Estudiante 2
        /// </summary>
        public CEstudiante estudiante2;

        /// <summary>
        /// Director
        /// </summary>
        public CProfesor director;

        /// <summary>
        /// Evaluador 1
        /// </summary>
        public CProfesor evaluador1;

        /// <summary>
        /// Evaluador 2
        /// </summary>
        public CProfesor evaluador2;

        /// <summary>
        /// Ruta del pdf con el soporte
        /// </summary>
        public string soporte;

        /// <summary>
        /// Indica si el proyecto se incluye en la organizacion
        /// </summary>
        public bool incluir;

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public CProyecto()
        {
            codigo = 0;
            nombre = "";
            this.estudiante1 = null;
            this.estudiante2 = null;
            this.director = null;
            this.evaluador1 = null;
            this.evaluador2 = null;
            soporte = "";
            incluir = true;
        }

        /// <summary>
        /// Constructor con asignacion
        /// </summary>
        /// <param name="cod"></param>
        /// <param name="name"></param>
        /// <param name="est1"></param>
        /// <param name="est2"></param>
        /// <param name="est3"></param>
        /// <param name="dire"></param>
        /// <param name="codire1"></param>
        /// <param name="codire2"></param>
        /// <param name="eva1"></param>
        /// <param name="eva2"></param>
        public CProyecto(int cod, string name, CEstudiante est1, CEstudiante est2, CProfesor dire, CProfesor eva1, CProfesor eva2, string pdf)
        {
            codigo = cod;
            nombre = name;
            estudiante1 = new CEstudiante(est1);
            estudiante2 = new CEstudiante(est2);
            director = new CProfesor(dire);
            evaluador1 = new CProfesor(eva1);
            evaluador2 = new CProfesor(eva2);
            soporte = pdf;
            incluir = true;
        }

        /// <summary>
        /// Asignacion con replica
        /// </summary>
        /// <param name="proy"></param>
        public CProyecto(CProyecto proy)
        {
            codigo = proy.codigo;
            nombre = proy.nombre;
            estudiante1 = new CEstudiante(proy.estudiante1);
            estudiante2 = new CEstudiante(proy.estudiante2);
            director = new CProfesor(proy.director);
            evaluador1 = new CProfesor(proy.evaluador1);
            evaluador2 = new CProfesor(proy.evaluador2);
            soporte = proy.soporte;
            incluir = proy.incluir;
        }

        public static bool operator ==(CProyecto pr1, CProyecto pr2)
        {
            return ((pr1.director == pr2.director) && (pr1.evaluador1 == pr2.evaluador1) && (pr1.evaluador2 == pr2.evaluador2));
        }

        public static bool operator !=(CProyecto pr1, CProyecto pr2)
        {
            return ((pr1.director != pr2.director) || (pr1.evaluador1 != pr2.evaluador1) || (pr1.evaluador2 != pr2.evaluador2));
        }
    }
}
