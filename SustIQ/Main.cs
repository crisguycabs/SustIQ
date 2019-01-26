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
using System.Net.Mail;

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

        public SustentacionForm sustentacionForm = null;

        public bool abiertoSustentacion = false;

        /// <summary>
        /// Sustentacion actual que se esta trabajando
        /// </summary>
        public CSustentacion actual = null;

        public s proyectosForm = null;

        public bool abiertoProyectos = false;

        public OrganizacionForm organizacionForm = null;

        public bool abiertoOrganizacion = false;

        public string correo = "";

        public string password = "";

        public ConfiguracionForm configuracionForm = null;

        public bool abiertoConfiguracion = false;

        #endregion

        public Main()
        {
            InitializeComponent();
        }

        public static bool EnviarMailProyecto(CProyecto pa,string correo, string pass, DateTime fecha, string hora, string salon)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(correo,pass);
            client.EnableSsl = true;
            client.Credentials = credentials;

            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(correo);
                mail.To.Add(pa.estudiante1.correo);
                mail.To.Add(pa.estudiante2.correo);
                mail.Subject = "Horario de sustentacion de proyecto de grado";
                mail.Body = "Cordial saludo\r\n\r\n";
                mail.Body = mail.Body + "Codigo: " + pa.codigo + "\r\n";
                mail.Body = mail.Body + "Nombre: " + pa.nombre.ToUpper() + "\r\n\r\n";
                mail.Body = mail.Body + fecha.Day + " de " + fecha.Month + ", " + hora + ", " + " salon " + salon + "\r\n\r\n";
                mail.Body = mail.Body + "Director: " + pa.director.nombres.ToUpper() + " " + pa.director.apellidos.ToUpper() + "\r\n";
                mail.Body = mail.Body + "Evaluadores: " + pa.evaluador1.nombres.ToUpper() + " " + pa.evaluador1.apellidos.ToUpper() + " | " + pa.evaluador2.nombres.ToUpper() + " " + pa.evaluador2.apellidos.ToUpper() + "\r\n\r\n";
                mail.Attachments.Add(new Attachment(pa.soporte));
                client.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Calcula la distancia entre dos proyectos, basandose en si tienen o no los mismos profesores
        /// </summary>
        /// <param name="pA"></param>
        /// <param name="pB"></param>
        /// <returns>min 0: ambos proyectos tienen los mismos profesores; max 3: los proyectos no tienen profesores en comun</returns>
        public static int Distancia(CProyecto pA, CProyecto pB)
        {
            int distancia = 3;

            if ((pA.director == pB.director) || (pA.director == pB.evaluador1) || (pA.director == pB.evaluador2)) distancia--;
            if ((pA.evaluador1 == pB.director) || (pA.evaluador1 == pB.evaluador1) || (pA.evaluador1 == pB.evaluador2)) distancia--;
            if ((pA.evaluador2 == pB.director) || (pA.evaluador2 == pB.evaluador1) || (pA.evaluador2 == pB.evaluador2)) distancia--;

            return distancia;
        }

        /// <summary>
        /// Indica si dos proyectos tienen conflicto. Es decir, comparten algun profesor en algun papel
        /// </summary>
        /// <param name="pA"></param>
        /// <param name="pB"></param>
        /// <returns></returns>
        public static bool Conflicto(CProyecto pA, CProyecto pB)
        {
            if ((pA.director == pB.director) || (pA.director == pB.evaluador1) || (pA.director == pB.evaluador2)) return true;
            if ((pA.evaluador1 == pB.director) || (pA.evaluador1 == pB.evaluador1) || (pA.evaluador1 == pB.evaluador2)) return true;
            if ((pA.evaluador2 == pB.director) || (pA.evaluador2 == pB.evaluador1) || (pA.evaluador2 == pB.evaluador2)) return true;

            return false;
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

            // se lee la configuracion
            CargarConfiguracion();

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
            sw.WriteLine(profesores.Count.ToString());
            sw.WriteLine("--------------------------");
            
            string line;
            for (int i = 0; i < profesores.Count; i++)
            {
                // se escriben los datos personales
                line = profesores[i].nombres + '\t' + profesores[i].apellidos + '\t' + profesores[i].correo;
                if (profesores[i].planta) line = line + "\t1";
                else line = line + "\t0";
                sw.WriteLine(line);

                // se escribe la disponibilidad para el dia lunes en la mañana, pero en forma horizontal
                line = "";
                for (int j = 0; j < profesores[i].dispMañana.GetLength(0); j++)
                {
                    if(profesores[i].dispMañana[j,0]) line += "1\t";
                    else line += "0\t";
                }
                sw.WriteLine(line);

                // se escribe la disponibilidad para el dia lunes en la tarde, pero en forma horizontal
                line = "";
                for (int j = 0; j < profesores[i].dispTarde.GetLength(0); j++)
                {
                    if (profesores[i].dispTarde[j, 0]) line += "1\t";
                    else line += "0\t";
                }
                sw.WriteLine(line);

                // se escribe la disponibilidad para el dia viernes en la mañana, pero en forma horizontal
                line = "";
                for (int j = 0; j < profesores[i].dispMañana.GetLength(0); j++)
                {
                    if (profesores[i].dispMañana[j, 1]) line += "1\t";
                    else line += "0\t";
                }
                sw.WriteLine(line);

                // se escribe la disponibilidad para el dia viernes en la tarde, pero en forma horizontal
                line = "";
                for (int j = 0; j < profesores[i].dispTarde.GetLength(0); j++)
                {
                    if (profesores[i].dispTarde[j, 1]) line += "1\t";
                    else line += "0\t";
                }
                sw.WriteLine(line);

                sw.WriteLine("--------------------------");
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

                // se leen las primeras cuatro lineas
                for (int i = 0; i < 4; i++) line = sr.ReadLine();

                // se lee el numero de profesores
                int nprof = Convert.ToInt32(sr.ReadLine());

                for (int i = 0; i < nprof; i++)
                {
                    line = sr.ReadLine();

                    line = sr.ReadLine();
                    line2 = line.Split('\t');
                    profesores.Add(new CProfesor());
                    profesores[i].nombres = line2[0];
                    profesores[i].apellidos = line2[1];
                    profesores[i].correo = line2[2];
                    profesores[i].planta = (line2[3] == "1");

                    // disponibilidad lunes en la mañana
                    line = sr.ReadLine();
                    line2 = line.Split('\t');
                    for (int j = 0; j < profesores[i].dispMañana.GetLength(0); j++) profesores[i].dispMañana[j, 0] = (line2[j] == "1");

                    // disponibilidad lunes en la tarde
                    line = sr.ReadLine();
                    line2 = line.Split('\t');
                    for (int j = 0; j < profesores[i].dispTarde.GetLength(0); j++) profesores[i].dispTarde[j, 0] = (line2[j] == "1");

                    // disponibilidad viernes en la mañana
                    line = sr.ReadLine();
                    line2 = line.Split('\t');
                    for (int j = 0; j < profesores[i].dispMañana.GetLength(0); j++) profesores[i].dispMañana[j, 1] = (line2[j] == "1");

                    // disponibilidad viernes en la tarde
                    line = sr.ReadLine();
                    line2 = line.Split('\t');
                    for (int j = 0; j < profesores[i].dispTarde.GetLength(0); j++) profesores[i].dispTarde[j, 1] = (line2[j] == "1");
                    
                }

                sr.Close();

                profesores.Sort((x, y) => x.apellidos.CompareTo(y.apellidos));
            }
            else
            {
                // no existe el archivo, se pregunta si se quiere crear un archivo nuevo, o se termina la aplicación
                if (MessageBox.Show("No se encuentra el listado de profesores. \r\n\r\nDesea generar un nuevo listado vacío y continuar?", "Error al leer el listado de profesores", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
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

        public void CerrarAddSalonesForm()
        {
            abiertoAddSalonForm = false;
            agregarSalonForm = null;
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
                abiertoProfesoresForm = true;
                profesoresForm.ShowDialog();
            }
            else profesoresForm.Select();            
        }

        public void AbrirConfiguracion()
        {
            if (!abiertoConfiguracion)
            {
                configuracionForm = new ConfiguracionForm();
                configuracionForm.padre = this;
                abiertoConfiguracion= true;
                configuracionForm.ShowDialog();
            }
        }

        public void CerrarConfiguracion()
        {
            abiertoConfiguracion = false;
            configuracionForm = null;
        }

        public void AbrirSustentacion()
        {
            if (!abiertoSustentacion)
            {
                sustentacionForm = new SustentacionForm();
                sustentacionForm.padre = this;
                sustentacionForm.MdiParent = this;
                abiertoSustentacion = true;
                sustentacionForm.Show();
            }
            else sustentacionForm.Select();
        }

        public void CerrarSustentacionForm()
        {
            abiertoSustentacion = false;
            sustentacionForm = null;
            AbrirInicioForm();
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

        public void AbrirProyectosForm()
        {
            if (!abiertoProyectos)
            {
                proyectosForm = new s();
                proyectosForm.padre = this;
                abiertoProyectos = true;
                proyectosForm.ShowDialog();
            }
            else proyectosForm.Select();
        }

        public void CerrarProyectosForm()
        {
            proyectosForm = null;
            abiertoProyectos = false;
        }

        public void NuevaSustentacion()
        {
            SaveFileDialog salvar = new SaveFileDialog();
            salvar.Title = "Escoga el nombre y carpeta para crear la nueva sustentacion...";
            salvar.Filter = "Archivo de sustentacion (*.sust)|*.sust";
            salvar.DefaultExt = "sust";
            if (salvar.ShowDialog() == DialogResult.OK)
            {
                string folder = Path.GetDirectoryName(salvar.FileName) + "\\" + Path.GetFileNameWithoutExtension(salvar.FileName);
                if(!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                actual = new CSustentacion();
                actual.path = folder + "\\" + Path.GetFileName(salvar.FileName);
                
                AbrirSustentacion();
                inicio.Close();
                CerrarInicio();
            }
        }

        public void CargarConfiguracion()
        {
            if (File.Exists(thisPath + "\\Resources\\Configuracion.siq"))
            {
                StreamReader sr = new StreamReader(thisPath + "\\Resources\\Configuracion.siq", System.Text.Encoding.Default, true);

                string line;
                
                // se leen las primeras cuatro lineas
                for (int i = 0; i < 4; i++) line = sr.ReadLine();

                correo = sr.ReadLine();
                password = sr.ReadLine();

                sr.Close();
            }
            else
            {
                // no existe el archivo de configuracion
                MessageBox.Show("No se encuentra el archivo de configuracion.\r\n\r\nLa aplicacion se cerrara", "Error al cargar la configuracion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void GuardarConfiguracion()
        {
            if (!File.Exists(thisPath + "\\Resources\\Configuracion.siq"))
            {
                File.Create(thisPath + "\\Resources\\Configuracion.siq");
            }

            StreamWriter sw = new StreamWriter(thisPath + "\\Resources\\Configuracion.siq", false, System.Text.Encoding.UTF8);

            sw.WriteLine("SUSTIQ: Sustentaciones Escuela de Ingenieria Quimica - UIS");
            sw.WriteLine("M.Sc. C. Barajas-Solano, Ph.D. Paola Maradei");
            sw.WriteLine("2018");
            sw.WriteLine("");
            sw.WriteLine(correo);
            sw.WriteLine(password);

            sw.Close();
        }

        /// <summary>
        /// Se guarda en disco toda la informacion de la sustentacion
        /// </summary>
        public void GuardarSustentacion()
        {
            //if (!File.Exists(actual.path)) File.Create(actual.path);
            StreamWriter sw = new StreamWriter(actual.path, false, System.Text.Encoding.UTF8);
            
            // cabecera
            sw.WriteLine("SUSTIQ: Sustentaciones Escuela de Ingenieria Quimica - UIS");
            sw.WriteLine("M.Sc. C. Barajas-Solano, Ph.D. Paola Maradei");
            sw.WriteLine("2018");
            sw.WriteLine("");

            sw.WriteLine("FECHA");
            sw.WriteLine(actual.fecha.Day.ToString() + "\t" + actual.fecha.Month.ToString() + "\t" + actual.fecha.Year.ToString());

            sw.WriteLine("MAÑANA");
            if (actual.jornadaMañana) sw.WriteLine("true");
            else sw.WriteLine("false");

            sw.WriteLine("TARDE");
            if (actual.jornadaTarde) sw.WriteLine("true");
            else sw.WriteLine("false");

            sw.WriteLine("INICIO MAÑANA");
            sw.WriteLine(actual.iniMañana);
            sw.WriteLine("FIN MAÑANA");
            sw.WriteLine(actual.finMañana);

            sw.WriteLine("INICIO TARDE");
            sw.WriteLine(actual.iniTarde);
            sw.WriteLine("FIN MAÑANA");
            sw.WriteLine(actual.finTarde);

            sw.WriteLine("COUNT");
            sw.WriteLine(actual.proyectos.Count.ToString());
            sw.WriteLine("--------------");
            for (int i = 0; i < actual.proyectos.Count; i++)
            {
                sw.WriteLine(actual.proyectos[i].codigo.ToString());
                sw.WriteLine(actual.proyectos[i].nombre);
                sw.WriteLine(actual.proyectos[i].soporte);
                sw.WriteLine(actual.proyectos[i].estudiante1.nombre + "\t" + actual.proyectos[i].estudiante1.correo);
                if(actual.proyectos[i].estudiante2.correo==null)
                { // no existe el estudiante 2, se guarda una cadena que signifique vacio   
                    sw.WriteLine("--\t--");
                }
                else
                {
                    sw.WriteLine(actual.proyectos[i].estudiante2.nombre + "\t" + actual.proyectos[i].estudiante2.correo);
                }
                if (actual.proyectos[i].incluir) sw.WriteLine("1");
                else sw.WriteLine("0");
                sw.WriteLine(actual.proyectos[i].director.nombres + "\t" + actual.proyectos[i].director.apellidos + "\t" + actual.proyectos[i].director.correo);
                sw.WriteLine(actual.proyectos[i].evaluador1.nombres + "\t" + actual.proyectos[i].evaluador1.apellidos + "\t" + actual.proyectos[i].evaluador1.correo);
                sw.WriteLine(actual.proyectos[i].evaluador2.nombres + "\t" + actual.proyectos[i].evaluador2.apellidos + "\t" + actual.proyectos[i].evaluador2.correo);
                sw.WriteLine("--------------");
            }
            sw.WriteLine("LISTO ORDEN");
            if (actual.listoOrden)
            {
                sw.WriteLine("true");
                
                sw.WriteLine("N SALONES");
                sw.WriteLine(actual.nombresSalones.Count.ToString());
                string linea="";
                for (int i = 0; i < (actual.nombresSalones.Count); i++) linea = linea + actual.nombresSalones[i] + "\t";                
                sw.WriteLine(linea);

                if (actual.jornadaMañana)
                {
                    sw.WriteLine("N HORAS MAÑANA");
                    sw.WriteLine(actual.horasMañana.Count.ToString());
                    linea = "";
                    for (int i = 0; i < (actual.horasMañana.Count); i++) linea = linea + actual.horasMañana[i] + "\t";
                    sw.WriteLine(linea);
                }

                if (actual.jornadaTarde)
                {
                    sw.WriteLine("N HORAS TARDE");
                    sw.WriteLine(actual.horasTarde.Count.ToString());
                    linea = "";
                    for (int i = 0; i < (actual.horasTarde.Count); i++) linea = linea + actual.horasTarde[i] + "\t";
                    sw.WriteLine(linea);
                }

                sw.WriteLine("ORGANIZACION MAÑANA");
                for (int i = 0; i < actual.horasMañana.Count; i++)
                {
                    linea = "";
                    for (int j = 0; j < actual.nombresSalones.Count; j++) linea = linea + actual.matrizMañana[i, j].ToString() + "\t";
                    sw.WriteLine(linea);                    
                }
                sw.WriteLine("ORGANIZACION TARDE");
                for (int i = 0; i < actual.horasTarde.Count; i++)
                {
                    linea = "";
                    for (int j = 0; j < actual.nombresSalones.Count; j++) linea = linea + actual.matrizTarde[i, j].ToString() + "\t";
                    sw.WriteLine(linea);
                }

            }
            else sw.WriteLine("false");
            sw.Close();

            MessageBox.Show("Sustentacion guardada exitosamente en " + actual.path, "Guardado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CargarSustentacion(string path)
        {
            string line = "";
            string[] line2=null;

            actual = new CSustentacion();
            actual.path = path;

            StreamReader sr = new StreamReader(path, System.Text.Encoding.Default, true);

            // se leen las primeras 4 lineas de la cabecera y FECHA
            for (int i = 0; i < 5; i++) sr.ReadLine();

            // fecha
            line=sr.ReadLine();
            line2=line.Split('\t');
            actual.fecha = new DateTime(Convert.ToInt32(line2[2]), Convert.ToInt32(line2[1]), Convert.ToInt32(line2[0]));

            // jornada mañana
            line = sr.ReadLine();
            actual.jornadaMañana=(sr.ReadLine()=="true");

            // jornada tarde
            line = sr.ReadLine();
            actual.jornadaTarde = (sr.ReadLine() == "true");

            // inicio mañana
            line = sr.ReadLine();
            actual.iniMañana = Convert.ToInt32(sr.ReadLine());

            // fin mañana
            line = sr.ReadLine();
            actual.finMañana = Convert.ToInt32(sr.ReadLine());

            // inicio tarde
            line = sr.ReadLine();
            actual.iniTarde = Convert.ToInt32(sr.ReadLine());

            // fin tarde
            line = sr.ReadLine();
            actual.finTarde = Convert.ToInt32(sr.ReadLine());

            // numero de proyectos
            line = sr.ReadLine();
            int nproyectos = Convert.ToInt32(sr.ReadLine());
            line = sr.ReadLine();

            actual.proyectos=new List<CProyecto>();
            for (int i = 0; i < nproyectos; i++)
            {
                actual.proyectos.Add(new CProyecto());

                actual.proyectos[i].codigo = Convert.ToInt32(sr.ReadLine());
                actual.proyectos[i].nombre = sr.ReadLine();
                actual.proyectos[i].soporte = sr.ReadLine();
                line = sr.ReadLine();
                line2 = line.Split('\t');
                actual.proyectos[i].estudiante1 = new CEstudiante(line2[0], line2[1]);
                line = sr.ReadLine();
                line2 = line.Split('\t');
                if (line2[0] == "--"){
                    actual.proyectos[i].estudiante2 = new CEstudiante();
                }
                else{
                    actual.proyectos[i].estudiante2 = new CEstudiante(line2[0], line2[1]);
                }
                line = sr.ReadLine();
                if (line == "1") actual.proyectos[i].incluir = true;
                else actual.proyectos[i].incluir = false;
                line = sr.ReadLine();
                line2 = line.Split('\t');
                actual.proyectos[i].director = new CProfesor(line2[0], line2[1], line2[2]);
                line = sr.ReadLine();
                line2 = line.Split('\t');
                actual.proyectos[i].evaluador1 = new CProfesor(line2[0], line2[1], line2[2]);
                line = sr.ReadLine();
                line2 = line.Split('\t');
                actual.proyectos[i].evaluador2 = new CProfesor(line2[0], line2[1], line2[2]);               

                sr.ReadLine();
            }
            line = sr.ReadLine();
            line = sr.ReadLine();
            if (line == "true")
            {
                // existe una organizacion a cargar
                actual.listoOrden = true;
                
                line = sr.ReadLine();
                int nsalones = Convert.ToInt32(sr.ReadLine());
                actual.nombresSalones = new List<string>();
                line = sr.ReadLine();
                line2 = line.Split('\t');
                for (int i = 0; i < nsalones; i++) actual.nombresSalones.Add(line2[i]);

                int nhorasmañana=0;
                if (actual.jornadaMañana)
                {
                    line = sr.ReadLine();
                    nhorasmañana = Convert.ToInt32(sr.ReadLine());
                    actual.horasMañana = new List<string>();
                    line = sr.ReadLine();
                    line2 = line.Split('\t');
                    for (int i = 0; i < nhorasmañana; i++) actual.horasMañana.Add(line2[i]);
                }

                int nhorastarde = 0;
                if (actual.jornadaTarde)
                {
                    line = sr.ReadLine();
                    nhorastarde = Convert.ToInt32(sr.ReadLine());
                    actual.horasTarde = new List<string>();
                    line = sr.ReadLine();
                    line2 = line.Split('\t');
                    for (int i = 0; i < nhorastarde; i++) actual.horasTarde.Add(line2[i]);
                }

                if (actual.jornadaMañana)
                {
                    actual.matrizMañana = new int[nhorasmañana, nsalones];
                    line = sr.ReadLine();
                    for (int i = 0; i < nhorasmañana; i++)
                    {
                        line = sr.ReadLine();
                        line2 = line.Split('\t');
                        for (int j = 0; j < nsalones; j++) actual.matrizMañana[i, j] = Convert.ToInt32(line2[j]);
                    }
                }

                if (actual.jornadaTarde)
                {
                    actual.matrizTarde = new int[nhorastarde, nsalones];
                    line = sr.ReadLine();
                    for (int i = 0; i < nhorastarde; i++)
                    {
                        line = sr.ReadLine();
                        line2 = line.Split('\t');
                        for (int j = 0; j < nsalones; j++) actual.matrizTarde[i, j] = Convert.ToInt32(line2[j]);
                    }
                }
            }
            else actual.listoOrden = false;
            sr.Close();

            inicio.Close();
            CerrarInicio();
            AbrirSustentacion();
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

        public void AbrirOrganizacionForm()
        {
            if (!this.abiertoOrganizacion)
            {
                organizacionForm = new OrganizacionForm();
                organizacionForm.padre = this;
                abiertoOrganizacion = true;
                organizacionForm.ShowDialog();
            }
            else
            {
                organizacionForm.Select();
                organizacionForm.CargarOrganizacion();
            }
        }

        public void CerrarOrganizacionForm()
        {
            abiertoOrganizacion = false;
            organizacionForm = null;
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

        private void nuevoProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevaSustentacion();
        }

        private void verConfiguracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirConfiguracion();
        }
    }
}
