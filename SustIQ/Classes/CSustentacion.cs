using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustIQ
{
    class CSustentacion
    {
        /// <summary>
        /// Lista de salones asignados para el dia de sustentaciones
        /// </summary>
        public List<CSalon> salones = null;

        /// <summary>
        /// Lista de proyectos a organizar
        /// </summary>
        public List<CProyecto> proyectos=null;

        /// <summary>
        /// Fecha de la sustentacion
        /// </summary>
        public DateTime fecha;

        /// <summary>
        /// Hora de inicio de la jornada de la mañana
        /// </summary>
        public DateTime horaIniMañana;

        /// <summary>
        /// Hora de fin de la jornada de la mañana
        /// </summary>
        public DateTime horaFinMañana;

        /// <summary>
        /// Hora de inicio de la jornada de la tarde
        /// </summary>
        public DateTime horaIniTarde;

        /// <summary>
        /// Hora de fin de la jornada de la tarde
        /// </summary>
        public DateTime horaFinTarde;

        /// <summary>
        /// Ruta en el disco duro del archivo de sustentacion
        /// </summary>
        public string ruta;

        /// <summary>
        /// Constructor vacío
        /// </summary>
        public CSustentacion()
        {
            this.salones = null;
            this.proyectos = null;
            this.fecha = DateTime.Today;
            this.horaFinMañana = DateTime.Now;
            this.horaFinTarde = DateTime.Now;
            this.horaIniMañana = DateTime.Now;
            this.horaIniTarde = DateTime.Now;
            this.ruta = "";
        }

        /// <summary>
        /// Constructor con asignación
        /// </summary>
        /// <param name="_fecha"></param>
        /// <param name="_iniMañana"></param>
        /// <param name="_finMañana"></param>
        /// <param name="_iniTarde"></param>
        /// <param name="_finTarde"></param>
        /// <param name="_proyectos"></param>
        /// <param name="_salones"></param>
        public CSustentacion(string path, DateTime _fecha, DateTime _iniMañana, DateTime _finMañana, DateTime _iniTarde, DateTime _finTarde, List<CProyecto> _proyectos, List<CSalon> _salones)
        {
            ruta = path;
            fecha = _fecha;
            horaIniMañana = _iniMañana;
            horaFinMañana = _finMañana;
            horaIniTarde = _iniTarde;
            horaFinTarde = _finTarde;

            proyectos = new List<CProyecto>();
            for (int i = 0; i < _proyectos.Count; i++)
            {
                proyectos.Add(new CProyecto(_proyectos[i]));
            }

            salones = new List<CSalon>();
            for (int i = 0; i < _salones.Count; i++)
            {
                salones.Add(new CSalon(_salones[i]));
            }
        }
    }
}
