using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SustIQ
{
    public partial class SustentacionForm : Form
    {
        public Main padre = null;
        
        /// <summary>
        /// modo: TRUE, nuevo    FALSE, cargar
        /// </summary>
        public bool modo = true;

        public int proymax = 0;

        /// <summary>
        /// Copia local de los salones a utilizar
        /// </summary>
        public List<CSalon> salones = new List<CSalon>();

        /// <summary>
        /// Copia local de las horas de inicio de la mañana
        /// </summary>
        public List<string> horasMañana = new List<string>();

        /// <summary>
        /// Copia local de las horas de inicio de tarde
        /// </summary>
        public List<string> horasTarde = new List<string>();

        public int[,] matrizMañana;

        public int[,] matrizTarde;

        public SustentacionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obtiene el maximo de sustentaciones disponibles para el dia de sustentaciones
        /// </summary>
        public void GetMax()
        {
            int mañana = 0;
            int tarde = 0;
            if (checkMañana.Checked) mañana = comboFinMañana.SelectedIndex - comboIniMañana.SelectedIndex;
            if(checkTarde.Checked) tarde=comboFinTarde.SelectedIndex - comboIniTarde.SelectedIndex;
            proymax = (mañana + tarde) * checkSalones.CheckedIndices.Count;
            txtMax.Text = "Capacidad maxima: " + proymax.ToString();
        }

        private void checkMañana_CheckedChanged(object sender, EventArgs e)
        {
            groupMañana.Enabled = checkMañana.Checked;
            GetMax();
        }

        private void checkTarde_CheckedChanged(object sender, EventArgs e)
        {
            groupTarde.Enabled = checkTarde.Checked;
            GetMax();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            padre.CerrarSustentacionForm();

            this.Close();
        }

        private void SustentacionForm_Load(object sender, EventArgs e)
        {
            // se carga en pantalla la información de la sustentacion actual
            dateFecha.Value = padre.actual.fecha;

            comboFinMañana.SelectedIndex = padre.actual.finMañana;
            comboIniMañana.SelectedIndex = padre.actual.iniMañana;

            comboFinTarde.SelectedIndex = padre.actual.finTarde;
            comboIniTarde.SelectedIndex = padre.actual.iniTarde;

            checkMañana.Checked = padre.actual.jornadaMañana;
            checkTarde.Checked = padre.actual.jornadaTarde;

            LlenarSalones();

            lblSust.Text = "Proyectos a sustentar: " + padre.actual.proyectos.Count.ToString();            
        }

        /// <summary>
        /// Se vuelve a llenar el CheckListBox de salones despues de agregar un nuevo salon
        /// </summary>
        public void RefillSalones()
        {
            // se guarda el estado de checkeado de los salones
            List<bool> estados=new List<bool>();
            for (int i = 0; i < checkSalones.Items.Count; i++) estados.Add(checkSalones.GetItemChecked(i));

            LlenarSalones();

            // se reestablecen los estados
            for (int i = 0; i < estados.Count; i++) checkSalones.SetItemChecked(i, estados[i]);
        }

        /// <summary>
        /// Se llena la lista de salones
        /// </summary>
        public void LlenarSalones()
        {
            // se limpian los salones
            checkSalones.Items.Clear();

            // se llenan los salones
            for (int i = 0; i < padre.salones.Count; i++) checkSalones.Items.Add(padre.salones[i].nombre + " - " + padre.salones[i].edificio);
        }

        private void comboIniMañana_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboIniMañana.SelectedIndex >= comboFinMañana.SelectedIndex)
            {
                MessageBox.Show("Hora de inicio no válida para la jornada de la mañana", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboIniMañana.SelectedIndex = 0;
            }
            GetMax();
        }

        private void comboFinMañana_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboIniMañana.SelectedIndex >= comboFinMañana.SelectedIndex)
            {
                MessageBox.Show("Hora de finalización no válida para la jornada de la mañana", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboFinMañana.SelectedIndex = comboFinMañana.Items.Count - 1;
            }
            GetMax();
        }

        private void checkSalones_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMax();
        }

        private void comboIniTarde_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboIniTarde.SelectedIndex >= comboFinTarde.SelectedIndex)
            {
                MessageBox.Show("Hora de inicio no válida para la jornada de la tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboIniTarde.SelectedIndex = 0;
            }
            GetMax();
        }

        private void comboFinTarde_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboIniTarde.SelectedIndex >= comboFinTarde.SelectedIndex)
            {
                MessageBox.Show("Hora de finalización no válida para la jornada de la mañana", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboFinTarde.SelectedIndex = comboFinTarde.Items.Count - 1;
            }
            GetMax();
        }

        private void btnAddSalon_Click(object sender, EventArgs e)
        {
            padre.AbrirAddSalonesForm(true, -1);
            RefillSalones();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            padre.AbrirProyectosForm();
            lblSust.Text = "Proyectos a sustentar: " + padre.actual.proyectos.Count.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            padre.actual.fecha = dateFecha.Value;
            padre.actual.jornadaMañana = checkMañana.Checked;
            padre.actual.jornadaTarde = checkTarde.Checked;
            padre.actual.iniMañana = comboIniMañana.SelectedIndex;
            padre.actual.finMañana = comboFinMañana.SelectedIndex;
            padre.actual.iniTarde = comboIniTarde.SelectedIndex;
            padre.actual.finTarde = comboFinTarde.SelectedIndex;

            padre.GuardarSustentacion();
        }

        public void Organizar()
        {
            if (proymax < padre.actual.proyectos.Count)
            {
                MessageBox.Show("El numero de proyectos cargados excede la capacidad maxima.\r\n\r\nSeleccione mas salones, o extienda el horario de sustentaciones, para incrementar la capacidad maxima.", "Capacidad insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (padre.actual.listoOrden)
            {
                if (MessageBox.Show("Existe una organizacion previa. Si continua se perdera la organizacion existente y se reemplazara por una nueva organizacion.\r\n\r\nDesea continuar?", "Advertencia de sobreescritura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }

            padre.actual.fecha = dateFecha.Value;

            switch (MessageBox.Show("La organización de los proyectos de grado tardara unos minutos, agradecemos su paciencia.\r\n\r\nPresione SI si desea organizar las sustentaciones de manera OPTIMIZADA.\r\n\r\nPresione NO si desea organizar las sustentaciones de manera ALEATORIA.", "Tipo de organizacion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    OrganizarOptimizado();
                    break;
                case System.Windows.Forms.DialogResult.No:
                    OrganizarAleatorio();
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                    return;
            }
        }

        public void btnOrganizar_Click(object sender, EventArgs e)
        {
            if ((dateFecha.Value.DayOfWeek != System.DayOfWeek.Monday) && (dateFecha.Value.DayOfWeek != System.DayOfWeek.Friday))
            {
                MessageBox.Show("El dia de la sustentacion solo puede ser un LUNES o VIERNES", "Error al escoger la fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (padre.actual.listoOrden)
            {
                // ya existe un orden previo, solo se abre la ventana de organizacion y se muestra el orden
                padre.AbrirOrganizacionForm();
            }
            else Organizar(); // si no existe una organizacion previa entonces se muestra            
        }

        /// <summary>
        /// Rutina que organiza las sustentaciones de manera aleatoria
        /// </summary>
        public void OrganizarAleatorio()
        {
            padre.actual.listoOrden = false;
            GenerarMatriz();

            int dia=0;
            if(padre.actual.fecha.DayOfWeek==System.DayOfWeek.Monday) dia=0;
            else dia=1;

            int[] iproy = new int[padre.actual.proyectos.Count];
            for (int i = 0; i < padre.actual.proyectos.Count; i++)
            {
                if (padre.actual.proyectos[i].incluir) iproy[i] = i;
            }

            int repeticiones = 10000000;
            List<int[,]> posiblesResultadosMañana = new List<int[,]>();
            List<int[,]> posiblesResultadosTarde = new List<int[,]>();

            for (int i = 0; i < repeticiones; i++)
            {
                // se barajan de manera aleatoria los proyectos
                Shuffle(iproy);

                int ip = 0;

                for (int ij = 0; ij < horasMañana.Count * salones.Count; ij++) matrizMañana[ij % horasMañana.Count, ij / horasMañana.Count] = -1; 

                // se colocan en la matriz de la mañana (si aplica)
                bool aprobadoMañana = true;
                if (checkMañana.Checked)
                {
                    for (int ihora = 0; ihora < horasMañana.Count; ihora++)
                    {
                        for (int isalon = 0; isalon < salones.Count; isalon++)
                        {
                            matrizMañana[ihora, isalon] = iproy[ip];
                            ip++;
                            if (ip >= iproy.Length) break;
                        }
                        if (ip >= iproy.Length) break;
                    }

                    // se verifica si la matriz pasa la prueba de conflicto
                    for (int ihora = 0; ihora < horasMañana.Count; ihora++)
                    {
                        // primero se verifica la disponibilidad de profesores
                        for (int isalon = 0; isalon < salones.Count;isalon++)
                        {
                            if (matrizMañana[ihora, isalon] >= 0)
                            {
                                
                                
                                
                            }
                        }

                        // luego se verifica si hay conflicto de profesores que se cruzan
                        for (int isalon = 0; isalon < (salones.Count-1); isalon++)
                        {
                            for (int jsalon = isalon + 1; jsalon < salones.Count;jsalon++)
                            {
                                if ((matrizMañana[ihora, isalon] >= 0) && (matrizMañana[ihora, jsalon] >= 0))
                                {
                                    // se verifica que no hayan conflictos de profesores
                                    if (Main.Conflicto(padre.actual.proyectos[matrizMañana[ihora, isalon]], padre.actual.proyectos[matrizMañana[ihora, jsalon]]))
                                    {
                                        aprobadoMañana = false;
                                        break;
                                    }
                                }    
                            }
                            if (!aprobadoMañana) break;                     
                        }
                        if (!aprobadoMañana) break;
                    }
                }
                
                // se colocan en la matriz de la tarde (si aplica)
                bool aprobadoTarde = true;
                if (checkTarde.Checked && aprobadoMañana)
                {
                    for (int ij = 0; ij < horasTarde.Count * salones.Count; ij++) matrizTarde[ij % horasTarde.Count, ij / horasTarde.Count] = -1; 

                    for (int ihora = 0; ihora < horasTarde.Count; ihora++)
                    {
                        for (int isalon = 0; isalon < salones.Count; isalon++)
                        {
                            matrizTarde[ihora, isalon] = iproy[ip];
                            ip++;
                            if (ip >= iproy.Length) break;
                        }
                        if (ip >= iproy.Length) break;
                    }

                    // se verifica si la matriz pasa la prueba de conflicto
                    for (int ihora = 0; ihora < horasTarde.Count; ihora++)
                    {
                        // primero se verifica la disponibilidad de profesores
                        for (int isalon = 0; isalon < salones.Count; isalon++)
                        {
                            if (matrizTarde[ihora, isalon] >= 0)
                            {
                                
                                
                                
                            }
                        }

                        // luego se verifica si hay conflicto de profesores que se cruzan
                        for (int isalon = 0; isalon < (salones.Count - 1); isalon++)
                        {
                            for (int jsalon = isalon + 1; jsalon < salones.Count;jsalon++)
                            {
                                if ((matrizTarde[ihora, isalon] >= 0) && (matrizTarde[ihora, jsalon] >= 0))
                                {
                                    if (Main.Conflicto(padre.actual.proyectos[matrizTarde[ihora, isalon]], padre.actual.proyectos[matrizTarde[ihora, jsalon]]))
                                    {
                                        aprobadoTarde = false;
                                        break;
                                    }
                                }
                            }                                
                        }
                        if (!aprobadoTarde) break;
                    }
                }
                
                if (aprobadoMañana && aprobadoTarde)
                {
                    int[,] duplicado;
                    if (checkMañana.Checked)
                    {
                        // se duplica la matriz para evitar problemas despues
                        duplicado = new int[horasMañana.Count, salones.Count];
                        for (int ihoras = 0; ihoras < horasMañana.Count; ihoras++)
                        {
                            for (int isalon = 0; isalon < salones.Count; isalon++) duplicado[ihoras, isalon] = matrizMañana[ihoras, isalon];                            
                        }
                        posiblesResultadosMañana.Add(duplicado);
                    }
                    if (checkTarde.Checked)
                    {
                        // se duplica la matriz para evitar problemas despues
                        duplicado = new int[horasTarde.Count, salones.Count];
                        for (int ihoras = 0; ihoras < horasTarde.Count; ihoras++)
                        {
                            for (int isalon = 0; isalon < salones.Count; isalon++) duplicado[ihoras, isalon] = matrizTarde[ihoras, isalon];
                        }
                        posiblesResultadosTarde.Add(duplicado);
                    }
                }
            }

            if ((posiblesResultadosMañana.Count > 0) || (posiblesResultadosTarde.Count > 0))
            {
                // se evalua cada posible combinacion, se crea una matriz, de dos valores: uno con el indice de la combinacion posible y el otro con el valor de la distancia acumulada total
                double[,] soluciones = new double[posiblesResultadosMañana.Count, 2];
                for (int i = 0; i < posiblesResultadosMañana.Count; i++)
                {
                    soluciones[i, 0] = i;
                    int costo = 0;
                    // se recorren las matrices de la mañana y tarde de la posible solucion, midiendo la distancia por columna
                    if (checkMañana.Checked)
                    {
                        for (int isalon = 0; isalon < (salones.Count); isalon++)
                        {
                            for (int ihora = 0; ihora < (horasMañana.Count - 1); ihora++)
                            {
                                if ((posiblesResultadosMañana[i][ihora, isalon] >= 0) && (posiblesResultadosMañana[i][ihora + 1, isalon] >= 0)) costo += Main.Distancia(padre.actual.proyectos[posiblesResultadosMañana[i][ihora, isalon]], padre.actual.proyectos[posiblesResultadosMañana[i][ihora + 1, isalon]]);
                            }
                        }
                    }
                    if (checkTarde.Checked)
                    {
                        for (int isalon = 0; isalon < (salones.Count); isalon++)
                        {
                            for (int ihora = 0; ihora < (horasTarde.Count - 1); ihora++)
                            {
                                if ((posiblesResultadosTarde[i][ihora, isalon] >= 0) && (posiblesResultadosTarde[i][ihora + 1, isalon] >= 0)) costo += Main.Distancia(padre.actual.proyectos[posiblesResultadosTarde[i][ihora, isalon]], padre.actual.proyectos[posiblesResultadosTarde[i][ihora + 1, isalon]]);
                            }
                        }
                    }
                    soluciones[i, 1] = costo;
                }
                SortDoubleDimension(soluciones, true);

                
                // se guarda la mejor organizacion
                int imejor = Convert.ToInt32(soluciones[0, 0]);
                if (checkMañana.Checked)
                {
                    padre.actual.matrizMañana = new int[horasMañana.Count, salones.Count];
                    for (int ihora = 0; ihora < horasMañana.Count; ihora++)
                    {
                        for (int isalon = 0; isalon < salones.Count; isalon++) padre.actual.matrizMañana[ihora, isalon] = posiblesResultadosMañana[imejor][ihora, isalon];
                    }
                }
                if (checkTarde.Checked)
                {
                    padre.actual.matrizTarde = new int[horasTarde.Count, salones.Count];
                    for (int ihora = 0; ihora < horasTarde.Count; ihora++)
                    {
                        for (int isalon = 0; isalon < salones.Count; isalon++) padre.actual.matrizTarde[ihora, isalon] = posiblesResultadosTarde[imejor][ihora, isalon];
                    }
                }

                padre.actual.horasMañana = new List<string>();
                for (int i = 0; i < horasMañana.Count; i++) padre.actual.horasMañana.Add(horasMañana[i]);

                padre.actual.horasTarde = new List<string>();
                for (int i = 0; i < horasTarde.Count; i++) padre.actual.horasTarde.Add(horasTarde[i]);

                padre.actual.nombresSalones = new List<string>();
                for (int i = 0; i < salones.Count; i++) padre.actual.nombresSalones.Add(salones[i].edificio + " - " + salones[i].nombre);

                padre.actual.jornadaMañana = checkMañana.Checked;
                padre.actual.jornadaTarde = checkTarde.Checked;

                padre.actual.listoOrden = true;

                padre.AbrirOrganizacionForm();
            }
            else MessageBox.Show("La busqueda aleatoria no arrojó ningún resultado viable", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public int GetMinDistance(int ia, List<int> B)
        {
            int minDistancia = 10;
            int distancia = 0;
            int idistancia = 0;

            for (int i = 0; i < B.Count;i++)
            {
                distancia = Main.Distancia(padre.actual.proyectos[ia], padre.actual.proyectos[B[i]]);
                if (distancia < minDistancia)
                {
                    minDistancia = distancia;
                    idistancia = i;
                }
            }

            return idistancia;
        }

        /// <summary>
        /// Rutina que organiza las sustentaciones de manera optimizada
        /// </summary>
        public void OrganizarOptimizado()
        {
            padre.actual.listoOrden = false;
            GenerarMatriz();

            int[] iproy = new int[padre.actual.proyectos.Count];
            List<int> data;

            for (int i = 0; i < padre.actual.proyectos.Count; i++) iproy[i] = i;
            
            int repeticiones = 1000000;
            List<int[,]> posiblesResultadosMañana = new List<int[,]>();
            List<int[,]> posiblesResultadosTarde = new List<int[,]>();

            for (int i = 0; i < repeticiones; i++)
            {
                Shuffle(iproy);

                data = new List<int>();
                for (int id = 0; id < iproy.Length; id++) data.Add(iproy[id]);

                for (int ij = 0; ij < horasMañana.Count * salones.Count; ij++) matrizMañana[ij % horasMañana.Count, ij / horasMañana.Count] = -1;
                for (int ij = 0; ij < horasTarde.Count * salones.Count; ij++) matrizTarde[ij % horasTarde.Count, ij / horasTarde.Count] = -1;

                // se recorre la matriz de la mañana, colocando proyectos y verificando la distancia verticalmente y conflictos horizontalmente
                bool aprobadoMañana = true;
                if (checkMañana.Checked)
                {
                    for (int isalon = 0; isalon < salones.Count; isalon++)
                    {
                        for (int ihoras = 0; ihoras < horasMañana.Count; ihoras++)
                        {
                            // si es la primera hora no se hace verificacion de distancia
                            if (ihoras == 0)
                            {
                                matrizMañana[ihoras, isalon] = data[0];
                                data.RemoveAt(0);
                            }
                            else
                            {
                                // para todas las demas horas se reorganiza el vector de proyectos restantes segun la distancia con el ultimo proyecto agregado a la matriz
                                int iMinDistancia = GetMinDistance(matrizMañana[ihoras - 1, isalon], data);
                                matrizMañana[ihoras, isalon] = data[iMinDistancia];
                                data.RemoveAt(iMinDistancia);
                            }

                            // si es la primera columna no se hace verificacion de conflicto
                            if (isalon > 0)
                            {
                                // para todas las demas columnas se verifica que el ultimo elemento colocado no tenga conflicto con su vecino horizontal
                                if (Main.Conflicto(padre.actual.proyectos[matrizMañana[ihoras, isalon]], padre.actual.proyectos[matrizMañana[ihoras, isalon - 1]]))
                                {
                                    aprobadoMañana = false;
                                    break;
                                }
                            }

                            if (data.Count < 1) break;
                        }
                        if (!aprobadoMañana) break;
                        if (data.Count < 1) break;
                    }
                }

                bool aprobadoTarde = true;
                if (checkTarde.Checked && aprobadoMañana)
                {
                    for (int isalon = 0; isalon < salones.Count; isalon++)
                    {
                        for (int ihoras = 0; ihoras < horasTarde.Count; ihoras++)
                        {
                            // si es la primera hora no se hace verificacion de distancia
                            if (ihoras == 0)
                            {
                                matrizTarde[ihoras, isalon] = data[0];
                                data.RemoveAt(0);
                            }
                            else
                            {
                                // para todas las demas horas se reorganiza el vector de proyectos restantes segun la distancia con el ultimo proyecto agregado a la matriz
                                int iMinDistancia = GetMinDistance(matrizTarde[ihoras - 1, isalon], data);
                                matrizTarde[ihoras, isalon] = data[iMinDistancia];
                                data.RemoveAt(iMinDistancia);
                            }

                            // si es la primera columna no se hace verificacion de conflicto
                            if (isalon > 0)
                            {
                                // para todas las demas columnas se verifica que el ultimo elemento colocado no tenga conflicto con su vecino horizontal
                                if (Main.Conflicto(padre.actual.proyectos[matrizTarde[ihoras, isalon]], padre.actual.proyectos[matrizTarde[ihoras, isalon - 1]]))
                                {
                                    aprobadoTarde = false;
                                    break;
                                }
                            }

                            if (data.Count < 1) break;
                        }
                        if (!aprobadoTarde) break;
                        if (data.Count < 1) break;
                    }
                }

                if (aprobadoMañana && aprobadoTarde)
                {
                    int[,] duplicado;
                    if (checkMañana.Checked)
                    {
                        // se duplica la matriz para evitar problemas despues
                        duplicado = new int[horasMañana.Count, salones.Count];
                        for (int ihoras = 0; ihoras < horasMañana.Count; ihoras++)
                        {
                            for (int isalon = 0; isalon < salones.Count; isalon++) duplicado[ihoras, isalon] = matrizMañana[ihoras, isalon];
                        }
                        posiblesResultadosMañana.Add(duplicado);
                    }
                    if (checkTarde.Checked)
                    {
                        // se duplica la matriz para evitar problemas despues
                        duplicado = new int[horasTarde.Count, salones.Count];
                        for (int ihoras = 0; ihoras < horasTarde.Count; ihoras++)
                        {
                            for (int isalon = 0; isalon < salones.Count; isalon++) duplicado[ihoras, isalon] = matrizTarde[ihoras, isalon];
                        }
                        posiblesResultadosTarde.Add(duplicado);
                    }
                }
            }

            if ((posiblesResultadosMañana.Count > 0) || (posiblesResultadosTarde.Count > 0))
            {
                // se evalua cada posible combinacion, se crea una matriz, de dos valores: uno con el indice de la combinacion posible y el otro con el valor de la distancia acumulada total
                double[,] soluciones = new double[posiblesResultadosMañana.Count, 2];
                for (int i = 0; i < posiblesResultadosMañana.Count; i++)
                {
                    soluciones[i, 0] = i;
                    int costo = 0;
                    // se recorren las matrices de la mañana y tarde de la posible solucion, midiendo la distancia por columna
                    if (checkMañana.Checked)
                    {
                        for (int isalon = 0; isalon < (salones.Count); isalon++)
                        {
                            for (int ihora = 0; ihora < (horasMañana.Count - 1); ihora++)
                            {
                                if ((posiblesResultadosMañana[i][ihora, isalon] >= 0) && (posiblesResultadosMañana[i][ihora + 1, isalon] >= 0)) costo += Main.Distancia(padre.actual.proyectos[posiblesResultadosMañana[i][ihora, isalon]], padre.actual.proyectos[posiblesResultadosMañana[i][ihora + 1, isalon]]);
                            }
                        }
                    }
                    if (checkTarde.Checked)
                    {
                        for (int isalon = 0; isalon < (salones.Count); isalon++)
                        {
                            for (int ihora = 0; ihora < (horasTarde.Count - 1); ihora++)
                            {
                                if ((posiblesResultadosTarde[i][ihora, isalon] >= 0) && (posiblesResultadosTarde[i][ihora + 1, isalon] >= 0)) costo += Main.Distancia(padre.actual.proyectos[posiblesResultadosTarde[i][ihora, isalon]], padre.actual.proyectos[posiblesResultadosTarde[i][ihora + 1, isalon]]);
                            }
                        }
                    }
                    soluciones[i, 1] = costo;
                }
                SortDoubleDimension(soluciones, true);


                // se guarda la mejor organizacion
                int imejor = Convert.ToInt32(soluciones[0, 0]);
                if (checkMañana.Checked)
                {
                    padre.actual.matrizMañana = new int[horasMañana.Count, salones.Count];
                    for (int ihora = 0; ihora < horasMañana.Count; ihora++)
                    {
                        for (int isalon = 0; isalon < salones.Count; isalon++) padre.actual.matrizMañana[ihora, isalon] = posiblesResultadosMañana[imejor][ihora, isalon];
                    }
                }
                if (checkTarde.Checked)
                {
                    padre.actual.matrizTarde = new int[horasTarde.Count, salones.Count];
                    for (int ihora = 0; ihora < horasTarde.Count; ihora++)
                    {
                        for (int isalon = 0; isalon < salones.Count; isalon++) padre.actual.matrizTarde[ihora, isalon] = posiblesResultadosTarde[imejor][ihora, isalon];
                    }
                }

                padre.actual.horasMañana = new List<string>();
                for (int i = 0; i < horasMañana.Count; i++) padre.actual.horasMañana.Add(horasMañana[i]);

                padre.actual.horasTarde = new List<string>();
                for (int i = 0; i < horasTarde.Count; i++) padre.actual.horasTarde.Add(horasTarde[i]);

                padre.actual.nombresSalones = new List<string>();
                for (int i = 0; i < salones.Count; i++) padre.actual.nombresSalones.Add(salones[i].edificio + " - " + salones[i].nombre);

                padre.actual.jornadaMañana = checkMañana.Checked;
                padre.actual.jornadaTarde = checkTarde.Checked;

                padre.actual.listoOrden = true;

                padre.AbrirOrganizacionForm();
            }
            else MessageBox.Show("La busqueda aleatoria no arrojó ningún resultado viable", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        void SortDoubleDimension<T>(T[,] array, bool bySecond = false)
        {
            int length = array.GetLength(0);
            T[] dim1 = new T[length];
            T[] dim2 = new T[length];
            for (int i = 0; i < length; i++)
            {
                dim1[i] = array[i, 0];
                dim2[i] = array[i, 1];
            }
            if (bySecond) Array.Sort(dim2, dim1);
            else Array.Sort(dim1, dim2);
            for (int i = 0; i < length; i++)
            {
                array[i, 0] = dim1[i];
                array[i, 1] = dim2[i];
            }
        }

        /// <summary>
        /// Genera la matriz donde se empezaran a ubicar los proyectos. Tiene tantas filas como horas de sustentacion, y tantas columnas como salones
        /// </summary>
        public void GenerarMatriz()
        {
            // se obtiene una copia local de los salones
            salones = new List<CSalon>();
            for (int i = 0; i < checkSalones.Items.Count; i++)
            {
                if (checkSalones.GetItemChecked(i)) salones.Add(padre.salones[i]);
            }

            // se obtiene una copia local de las horas
            horasMañana = new List<string>();
            if (checkMañana.Checked)
            {
                for (int i = comboIniMañana.SelectedIndex; i < (comboFinMañana.SelectedIndex); i++) horasMañana.Add(comboIniMañana.Items[i].ToString());

                matrizMañana = new int[horasMañana.Count, salones.Count];
            }

            horasTarde = new List<string>();
            if (checkTarde.Checked)
            {
                for (int i = comboIniTarde.SelectedIndex; i < (comboFinTarde.SelectedIndex); i++) horasTarde.Add(comboIniTarde.Items[i].ToString());

                matrizTarde = new int[horasTarde.Count, salones.Count];
            }            
        }

        public void Shuffle(int[] array)
        {
            Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            int n = array.Count();
            while (n > 1)
            {
                n--;
                int i = random.Next(n + 1);
                int temp = array[i];
                array[i] = array[n];
                array[n] = temp;
            }
        }

        public void Shuffle(List<CDupla> array)
        {
            Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            int n = array.Count;
            while (n > 1)
            {
                n--;
                int i = random.Next(n + 1);
                CDupla temp = new CDupla(array[i]);
                array[i].indice = array[n].indice;
                array[i].distancia = array[n].distancia;
                array[n].indice = temp.indice;
                array[n].distancia = temp.distancia;
            }
        }

        private void dateFecha_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
