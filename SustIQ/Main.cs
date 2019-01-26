using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SustIQ
{
    public partial class Main : Form
    {
        #region variables de la aplicacion

        /// <summary>
        /// Brocha con el color de IQ
        /// </summary>
        public static System.Drawing.SolidBrush brushRojoIQ;

        /// <summary>
        /// Color rojo IQ
        /// </summary>
        public static System.Drawing.Color colorRojoIQ;

        /// <summary>
        /// Instancia de la forma Profesores
        /// </summary>
        public FormProfesores profesoresForm = null;

        /// <summary>
        /// Esta abierta o no la forma profesores
        /// </summary>
        public bool abiertoProfesoresForm = false;

        /// <summary>
        /// lista de profesores que se lee desde archivo y se escribe en archivo
        /// </summary>
        public List<CProfesor> profesores = null;

        /// <summary>
        /// Lista de proyectos de grado
        /// </summary>
        public List<CProyecto> proyectos = null;

        /// <summary>
        /// lista de salones que se lee desde archivo y se escribe en archivo
        /// </summary>
        public List<CSalon> salones = null;

        /// <summary>
        /// Instancia de la forma About
        /// </summary>
        public AboutForm aboutForm = null;

        /// <summary>
        /// Path de la aplicacion
        /// </summary>
        public static string thisPath = "";

        /// <summary>
        /// Instancia de la forma para agregar profesores
        /// </summary>
        public AddProfesoresForm agregarProfesorForm = null;

        /// <summary>
        /// Indica si la forma esta abierta o no
        /// </summary>
        public bool abiertoAddProfesorForm = false;

        /// <summary>
        /// Instancia de la forma inicio
        /// </summary>
        public InicioForm inicio = null;

        /// <summary>
        /// Indica si la forma esta abierta o no
        /// </summary>
        public bool abiertoInicio = false;

        /// <summary>
        /// Instancia de la forma para agregar salones
        /// </summary>
        public AddSalon agregarSalonForm = null;

        /// <summary>
        /// Indica si la forma esta abierta o no
        /// </summary>
        public bool abiertoAddSalonForm = false;

        /// <summary>
        /// Instancia de la forma de Salones
        /// </summary>
        public SalonesForm salonesForm = null;

        /// <summary>
        /// Indica si la forma esta abierta o no
        /// </summary>
        public bool abiertoSalonesForm = false;

        /// <summary>
        /// Instancia de la forma
        /// </summary>
        public SustentacionForm sustentacionForm = null;

        /// <summary>
        /// Indica si la forma esta abierta o no
        /// </summary>
        public bool abiertoSustentacionForm = false;

        public ProyectosForm proyectosForm = null;

        public bool abiertoProyectosForm = false;

        #endregion

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // color rojo IQ
            brushRojoIQ = new SolidBrush(Color.FromArgb(217, 39, 29));
            colorRojoIQ = Color.FromArgb(217, 39, 29);

            // path de la aplicacion
            thisPath=Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            // se leen los profesores que existen en archivo
            LeerProfesores();

            // se leen los salones que existen en archivo
            LeerSalones();

            proyectos = new List<CProyecto>();

            AbrirInicioForm();
        }

        public void EscribirProfesores()
        {
            profesores.Sort((x, y) => x.apellidos.CompareTo(y.apellidos));

            if (!File.Exists(thisPath + "\\Resources\\Profesores.siq"))
            {
                File.Create(thisPath + "\\Resources\\Profesores.siq");
            }

            StreamWriter sw = new StreamWriter(thisPath + "\\Resources\\Profesores.siq", false, System.Text.Encoding.UTF8);

            sw.WriteLine("SUSTIQ: Sustentaciones Escuela de Ingenieria Quimica - UIS");
            sw.WriteLine("M.Sc. C. Barajas-Solano, Ph.D. Paola Maradei");
            sw.WriteLine("2018");
            sw.WriteLine("");
            sw.WriteLine("Nombres\tApellidos\tCorreo");

            for (int i = 0; i < profesores.Count; i++)
            {
                sw.WriteLine(profesores[i].nombres + '\t' + profesores[i].apellidos + '\t' + profesores[i].correo);
            }

            sw.Close();
        }

        public void EscribirSalones()
        {
            if (!File.Exists(thisPath + "\\Resources\\Salones.siq"))
            {
                File.Create(thisPath + "\\Resources\\Salones.siq");
            }

            StreamWriter sw = new StreamWriter(thisPath + "\\Resources\\Salones.siq", false, System.Text.Encoding.UTF8);

            sw.WriteLine("SUSTIQ: Sustentaciones Escuela de Ingenieria Quimica - UIS");
            sw.WriteLine("M.Sc. C. Barajas-Solano, Ph.D. Paola Maradei");
            sw.WriteLine("2018");
            sw.WriteLine("");
            sw.WriteLine("Nombre\tEdificio");

            for (int i = 0; i < salones.Count; i++)
            {
                sw.WriteLine(salones[i].nombre + '\t' + salones[i].edificio);
            }

            sw.Close();
        }
        
        /// <summary>
        /// Lee la lista de profesores en archivo. Si existe un error al leer el archivo cancela la operacion. Si no encuentra el archivo crea uno nuevo
        /// </summary>
        /// <returns></returns>
        public void LeerProfesores()
        {
            profesores = new List<CProfesor>();

            if (File.Exists(thisPath + "\\Resources\\Profesores.siq"))
            {
                StreamReader sr = new StreamReader(thisPath + "\\Resources\\Profesores.siq", System.Text.Encoding.Default, true);
                
                string line;
                string[] line2;

                // se leen las primeras cinco lineas
                for (int i = 0; i < 5; i++) line = sr.ReadLine();

                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        line2 = line.Split('\t');
                        profesores.Add(new CProfesor(line2[0], line2[1], line2[2]));
                    }
                    catch { }
                }

                sr.Close();

                profesores.Sort((x, y) => x.apellidos.CompareTo(y.apellidos));
            }
            else
            {
                // no existe el archivo, se pregunta si se quiere crear un archivo nuevo, o se termina la aplicación
                if(MessageBox.Show("No se encuentra el listado de profesores. \r\n\r\nDesea generar un nuevo listado vacío y continuar?","Error al leer el listado de profesores",MessageBoxButtons.YesNo,MessageBoxIcon.Error)==DialogResult.Yes)
                {
                    if (!Directory.Exists(thisPath + "\\Resources")) Directory.CreateDirectory(thisPath + "\\Resources");

                    File.Create(thisPath + "\\Resources\\Profesores.siq");
                }
                else
                {
                    Application.Exit();
                }
            }

        }

        public static bool ValidarEmail(string cadena)
        {
            return ((cadena.IndexOf("@") != -1) && (cadena.IndexOf(".") != -1));            
        }

        public void AbrirAddSalonesForm(bool mode, int index)
        {
            if (!abiertoAddSalonForm)
            {
                agregarSalonForm = new AddSalon();
                agregarSalonForm.padre = this;
                abiertoAddSalonForm = true;
                agregarSalonForm.iSalonMod = index;
                agregarSalonForm.modo = mode;
                agregarSalonForm.ShowDialog();
            }
            else agregarSalonForm.Select();
        }

        public void AbrirSustentacionesForm()
        {
            if (!abiertoSustentacionForm)
            {
                sustentacionForm = new SustentacionForm();
                sustentacionForm.padre = this;
                sustentacionForm.MdiParent = this;
                abiertoSustentacionForm = true;
                sustentacionForm.Show();
            }
            else sustentacionForm.Select();
        }

        public void CerrarAddSalonesForm()
        {
            abiertoAddSalonForm = false;
            agregarSalonForm = null;
        }

        public void CerrarSustentacionForm()
        {
            abiertoSustentacionForm = false;
            sustentacionForm = null;

            AbrirInicioForm();
        }

        /// <summary>
        /// Lee la lista de salones en archivo. Si existe un error al leer el archivo cancela la operacion. Si no encuentra el archivo crea uno nuevo
        /// </summary>
        /// <returns></returns>
        public void LeerSalones()
        {
            salones = new List<CSalon>();

            if (File.Exists(thisPath + "\\Resources\\Salones.siq"))
            {
                StreamReader sr = new StreamReader(thisPath + "\\Resources\\Salones.siq", System.Text.Encoding.Default, true);

                string line;
                string[] line2;

                // se leen las primeras cinco lineas
                for (int i = 0; i < 5; i++) line = sr.ReadLine();

                int count = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        line2 = line.Split('\t');
                        salones.Add(new CSalon(line2[0],line2[1]));
                        count++;
                    }
                    catch { }
                }

                sr.Close();

                salones.Sort((x, y) => x.edificio.CompareTo(y.edificio));
            }
            else
            {
                // no existe el archivo, se pregunta si se quiere crear un archivo nuevo, o se termina la aplicación
                if (MessageBox.Show("No se encuentra el listado de salones. \r\n\r\nDesea generar un nuevo listado vacío y continuar?", "Error al leer el listado de profesores", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    if (!Directory.Exists(thisPath + "\\Resources")) Directory.CreateDirectory(thisPath + "\\Resources");

                    File.Create(thisPath + "\\Resources\\Salones.siq");
                }
                else
                {
                    Application.Exit();
                }
            }

        }

        public void AbrirFormProfesores()
        {
            if (!abiertoProfesoresForm)
            {
                profesoresForm = new FormProfesores();
                profesoresForm.padre = this;
                profesoresForm.MdiParent = this;
                abiertoProfesoresForm = true;
                profesoresForm.Show();
            }
            else profesoresForm.Select();            
        }

        public void AbrirProyectosForm()
        {
            if (!abiertoProyectosForm)
            {
                proyectosForm = new ProyectosForm();
                proyectosForm.padre = this;
                abiertoProyectosForm = true;
                proyectosForm.ShowDialog();
            }
            else proyectosForm.Select();
        }

        public void AbrirSalonesForm()
        {
            if (!abiertoSalonesForm)
            {
                salonesForm = new SalonesForm();
                salonesForm.padre = this;
                salonesForm.MdiParent = this;
                abiertoSalonesForm = true;
                salonesForm.Show();
            }
            else salonesForm.Select();
        }

        public void CerrarSalonesForm()
        {
            abiertoSalonesForm = false;
            salonesForm = null;
        }

        public void AbrirAddProfesoresForm(bool mode, int index)
        {
            if (!this.abiertoAddProfesorForm)
            {
                this.agregarProfesorForm = new AddProfesoresForm();
                agregarProfesorForm.padre = this;
                abiertoAddProfesorForm = true;
                agregarProfesorForm.iProfeMod = index;
                agregarProfesorForm.modo = mode;
                agregarProfesorForm.ShowDialog();
            }
            else agregarProfesorForm.Select();
        }

        public void AbrirInicioForm()
        {
            if (!this.abiertoInicio)
            {
                this.inicio = new InicioForm();
                inicio.padre = this;
                inicio.MdiParent = this;
                abiertoInicio = true;
                inicio.Show();
            }
            else inicio.Select();
        }

        public void CerrarInicio()
        {
            inicio = null;
            abiertoInicio = false;
        }

        public void CerrarFormProfesores()
        {
            profesoresForm = null;
            abiertoProfesoresForm = false;
        }

        public void CerrarAddProfesoresForm()
        {
            agregarProfesorForm = null;
            abiertoAddProfesorForm = false;
        }

        public void CerrarProyectosForm()
        {
            proyectosForm = null;
            abiertoProyectosForm = false;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void verProfesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormProfesores();
        }

        private void verSalonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirSalonesForm();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.EscribirProfesores();
            this.EscribirSalones();
        }
    }
}
