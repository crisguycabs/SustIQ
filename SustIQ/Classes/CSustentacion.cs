using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustIQ
{
    public class CSustentacion
    {
        /// <summary>
        /// fecha de la sustentacion
        /// </summary>
        public DateTime fecha;

        /// <summary>
        /// indice de la hora de inicio de la mañana
        /// </summary>
        public int iniMañana = 0;

        /// <summary>
        /// indice de la hora de fin de la mañana
        /// </summary>
        public int finMañana = 10;

        /// <summary>
        /// indice de la hora de inicio de la tarde
        /// </summary>
        public int iniTarde = 0;

        /// <summary>
        /// indice de la hora de fin de la tarde
        /// </summary>
        public int finTarde = 9;

        /// <summary>
        /// indica si se selecciono o no la jornada de la mañana
        /// </summary>
        public bool jornadaMañana = true;

        /// <summary>
        /// indica si se seleccion o no la jornada de la tarde
        /// </summary>
        public bool jornadaTarde = true;

        /// <summary>
        /// indica si el salon, en cada indice, fue seleccionado o no
        /// </summary>
        public List<bool> salones = new List<bool>();

        /// <summary>
        /// lista que contiene todos los proyectos para esta sustentacion
        /// </summary>
        public List<CProyecto> proyectos = new List<CProyecto>();

        /// <summary>
        /// ruta donde se guarda el proyecto de sustentacion
        /// </summary>
        public string path = "";

        /// <summary>
        /// Organizacion de la mañana
        /// </summary>
        public int[,] matrizMañana;

        /// <summary>
        /// Organizacion de la tarde
        /// </summary>
        public int[,] matrizTarde;

        /// <summary>
        /// Indica si ya se genero una organizacion de proyectos para esta sustentacion
        /// </summary>
        public bool listoOrden=false;

        public List<string> horasMañana = null;

        public List<string> horasTarde = null;

        public List<string> nombresSalones = null;

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public CSustentacion()
        {
            fecha = DateTime.Today;
        }
    }
}
