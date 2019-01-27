using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace SustIQ
{
    public partial class OrganizacionForm : Form
    {
        public Main padre = null;

        public OrganizacionForm()
        {
            InitializeComponent();
        }

        private void OrganizacionForm_Load(object sender, EventArgs e)
        {
            CargarOrganizacion();
        }

        public void CargarOrganizacion()
        {
            dgvOrden.Rows.Clear();
            dgvOrden.Columns.Clear();

            // se agrega la primera columna, la de la hora
            dgvOrden.Columns.Add("hora", "Hora");

            // se agregan tantas columnas como salones hallan
            for (int i = 0; i < padre.actual.nombresSalones.Count; i++)
            {
                dgvOrden.Columns.Add("salon" + i.ToString(), padre.actual.nombresSalones[i]);
                dgvOrden.Columns[i + 1].Width = 300;
                //dgvOrden.Columns[i + 1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            
            // se llena el dgv con la informacion de la organizacion
            if (padre.actual.jornadaMañana)
            {
                for (int i = 0; i < padre.actual.horasMañana.Count; i++) 
                {
                    var index = dgvOrden.Rows.Add();
                    dgvOrden.Rows[index].Cells[0].Value = padre.actual.horasMañana[i];
                    for(int j=0;j<padre.actual.nombresSalones.Count;j++)
                    {
                        int isus = padre.actual.matrizMañana[i, j];
                        if (isus >= 0)
                        {
                            string sus = "";
                            sus += padre.actual.proyectos[isus].codigo + "\r\n";
                            sus += padre.actual.proyectos[isus].nombre + "\r\n\r\n";
                            sus += padre.actual.proyectos[isus].estudiante1.nombre + "\r\n";
                            sus += padre.actual.proyectos[isus].estudiante2.nombre + "\r\n\r\n";
                            sus += "Director\r\n" + padre.actual.proyectos[isus].director.nombres + " " + padre.actual.proyectos[isus].director.apellidos + "\r\n\r\n";
                            sus += "Evaluador 1\r\n" + padre.actual.proyectos[isus].evaluador1.nombres + " " + padre.actual.proyectos[isus].evaluador1.apellidos + "\r\n\r\n";
                            sus += "Evaluador 2\r\n" + padre.actual.proyectos[isus].evaluador2.nombres + " " + padre.actual.proyectos[isus].evaluador2.apellidos;
                            dgvOrden.Rows[index].Cells[j + 1].Value = sus;
                        }
                    }
                }
            }

            if (padre.actual.jornadaTarde)
            {
                for (int i = 0; i < padre.actual.horasTarde.Count; i++)
                {
                    var index = dgvOrden.Rows.Add();
                    dgvOrden.Rows[index].Cells[0].Value = padre.actual.horasTarde[i];
                    for (int j = 0; j < padre.actual.nombresSalones.Count; j++)
                    {
                        int isus = padre.actual.matrizTarde[i, j];
                        if (isus >= 0)
                        {
                            string sus = "";
                            sus += padre.actual.proyectos[isus].codigo + "\r\n";
                            sus += padre.actual.proyectos[isus].nombre + "\r\n\r\n";
                            sus += padre.actual.proyectos[isus].estudiante1.nombre + "\r\n";
                            sus += padre.actual.proyectos[isus].estudiante2.nombre + "\r\n\r\n";
                            sus += "Director\r\n" + padre.actual.proyectos[isus].director.nombres + " " + padre.actual.proyectos[isus].director.apellidos + "\r\n\r\n";
                            sus += "Evaluador 1\r\n" + padre.actual.proyectos[isus].evaluador1.nombres + " " + padre.actual.proyectos[isus].evaluador1.apellidos + "\r\n\r\n";
                            sus += "Evaluador 2\r\n" + padre.actual.proyectos[isus].evaluador2.nombres + " " + padre.actual.proyectos[isus].evaluador2.apellidos;
                            dgvOrden.Rows[index].Cells[j + 1].Value = sus;
                        }
                    }
                }
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            dgvOrden.SelectAll();
            DataObject dataObj = dgvOrden.GetClipboardContent();
            if (dataObj != null)
            {
                Clipboard.SetDataObject(dataObj);
                dgvOrden.ClearSelection();
                MessageBox.Show("La organizacion de las sustentaciones ha sido copiada al portapapeles", "Copiado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            padre.CerrarOrganizacionForm();
            this.Close();
        }

        private void btnAgain_Click(object sender, EventArgs e)
        {
            padre.sustentacionForm.Organizar();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea enviar esta organización a los estudiantes y profesores involucrados? Recuerde que este proceso puede tardar algunos minutos.", "Confirmación de envío", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No)
            {
                return;
            }

            // se cargan los mensajes
            string mensajeProf = "";
            if (System.IO.File.Exists(Main.thisPath + "\\Resources\\mensajeProf.txt"))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(Main.thisPath + "\\Resources\\mensajeProf.txt", System.Text.Encoding.Default, true);
                mensajeProf = sr.ReadToEnd();
                sr.Close();
            }
            else
            {
                MessageBox.Show("No se encontró el archivo de mensaje a enviar para los profesores. Se enviará un mensaje robot", "Mensaje no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mensajeProf = "Cordial Saludo. Se le invita a la sustentación de los siguientes trabajos de grado.";
            }
            string mensajeEst = "";
            if (System.IO.File.Exists(Main.thisPath + "\\Resources\\mensajeEst.txt"))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(Main.thisPath + "\\Resources\\mensajeEst.txt", System.Text.Encoding.Default, true);
                mensajeEst = sr.ReadToEnd();
                sr.Close();
            }
            else
            {
                MessageBox.Show("No se encontró el archivo de mensaje a enviar para los estudiantes. Se enviará un mensaje robot", "Mensaje no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mensajeEst = "Cordial Saludo. Su trabajo de grado ha sido asignado para sustentación pública.";
            }

            // primero se envian los correos a los estudiantes
            if(padre.actual.jornadaMañana)
            {
                for (int i = 0; i < padre.actual.horasMañana.Count; i++)
                {
                    for (int j = 0; j < padre.actual.nombresSalones.Count; j++)
                    {
                        int ipa = padre.actual.matrizMañana[i, j];
                        if (ipa >= 0) Main.EnviarMailProyecto(padre.actual.proyectos[ipa], padre.director, padre.coordinador, padre.correo, padre.password, mensajeEst, this.chkTest.Checked, padre.actual.fecha, padre.actual.horasMañana[i], padre.actual.nombresSalones[j]);
                    }
                }
            }
            if (padre.actual.jornadaTarde)
            {
                for (int i = 0; i < padre.actual.horasTarde.Count; i++)
                {
                    for (int j = 0; j < padre.actual.nombresSalones.Count; j++)
                    {
                        int ipa = padre.actual.matrizTarde[i, j];
                        if(ipa>=0) Main.EnviarMailProyecto(padre.actual.proyectos[ipa], padre.director, padre.coordinador, padre.correo, padre.password, mensajeEst, this.chkTest.Checked, padre.actual.fecha, padre.actual.horasMañana[i], padre.actual.nombresSalones[j]);
                    }
                }
            }

            // se recorren todos los profesores de la lista, se verifica cuantos proyectos tiene cada profesor, y si hay uno o mas se envian los correos
            for (int iprof = 0; iprof < padre.profesores.Count; iprof++)
            {
                
                try
                {
                    int contador = 0;
                    for (int j = 0; j < padre.actual.proyectos.Count; j++) if ((padre.actual.proyectos[j].director == padre.profesores[iprof]) || (padre.actual.proyectos[j].evaluador1 == padre.profesores[iprof]) || (padre.actual.proyectos[j].evaluador2 == padre.profesores[iprof])) contador++;

                    if (contador > 0)
                    {
                        SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

                        client.Port = 587;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(padre.correo, padre.password);
                        client.EnableSsl = true;
                        client.Credentials = credentials;

                        var mail = new MailMessage(padre.correo, padre.profesores[iprof].correo);

                        mail.Bcc.Add(padre.coordinador);
                        mail.Bcc.Add(padre.director);

                        try
                        {
                            mail.Attachments.Add(new Attachment(Main.thisPath + "\\Resources\\FormatoCalificacion.xlsx"));
                        }
                        catch
                        {
                        }
                        

                        if (chkTest.Checked) mail.Subject = "CORREO DE PRUEBA - HACER CASO OMISO";
                        else mail.Subject = "Horario de sustentaciones de proyectos de grado";

                        mail.Body = mensajeProf + "\r\n\r\n";
                        mail.Body = mail.Body + "A continuación se incluyen las sustentaciones de proyecto de grado a las que usted debe asistir el dia " + padre.actual.fecha.Day + " de " + System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(padre.actual.fecha.Month) + "\r\n\r\n";

                        if (padre.actual.jornadaMañana)
                        {
                            for (int i = 0; i < padre.actual.horasMañana.Count; i++)
                            {
                                for (int j = 0; j < padre.actual.nombresSalones.Count; j++)
                                {
                                    int ipa = padre.actual.matrizMañana[i, j];
                                    if (ipa >= 0)
                                    {
                                        if ((padre.actual.proyectos[ipa].director == padre.profesores[iprof]) || (padre.actual.proyectos[ipa].evaluador1 == padre.profesores[iprof]) || (padre.actual.proyectos[ipa].evaluador2 == padre.profesores[iprof]))
                                        {
                                            mail.Body = mail.Body + "Codigo: " + padre.actual.proyectos[ipa].codigo + "\r\n";
                                            mail.Body = mail.Body + "Nombre: " + padre.actual.proyectos[ipa].nombre + "\r\n";
                                            mail.Body = mail.Body + padre.actual.horasMañana[i] + ", " + " salon " + padre.actual.nombresSalones[j] + "\r\n";
                                            if (padre.actual.proyectos[ipa].director == padre.profesores[iprof]) mail.Body = mail.Body + "Rol: DIRECTOR";
                                            else mail.Body = mail.Body + "Rol: EVALUADOR";
                                            mail.Attachments.Add(new Attachment(padre.actual.proyectos[ipa].soporte));
                                            mail.Body = mail.Body + "\r\n\r\n";
                                        }
                                    }
                                }
                            }
                        }

                        int a = 1;
                        a = a + 1;

                        if (padre.actual.jornadaTarde)
                        {
                            for (int i = 0; i < padre.actual.horasTarde.Count; i++)
                            {
                                for (int j = 0; j < padre.actual.nombresSalones.Count; j++)
                                {
                                    int ipa = padre.actual.matrizTarde[i, j];
                                    if (ipa >= 0)
                                    {
                                        if ((padre.actual.proyectos[ipa].director == padre.profesores[iprof]) || (padre.actual.proyectos[ipa].evaluador1 == padre.profesores[iprof]) || (padre.actual.proyectos[ipa].evaluador2 == padre.profesores[iprof]))
                                        {
                                            mail.Body = mail.Body + "Codigo: " + padre.actual.proyectos[ipa].codigo + "\r\n";
                                            mail.Body = mail.Body + "Nombre: " + padre.actual.proyectos[ipa].nombre + "\r\n";
                                            mail.Body = mail.Body + padre.actual.horasTarde[i] + ", " + " salon " + padre.actual.nombresSalones[j] + "\r\n";
                                            if (padre.actual.proyectos[ipa].director == padre.profesores[iprof]) mail.Body = mail.Body + "Rol: DIRECTOR";
                                            else mail.Body = mail.Body + "Rol: EVALUADOR";
                                            mail.Attachments.Add(new Attachment(padre.actual.proyectos[ipa].soporte));
                                            mail.Body = mail.Body + "\r\n\r\n";
                                        }
                                    }
                                }
                            }
                        }

                        a = a + 1;

                        try
                        {
                            client.Send(mail);
                        }
                        catch
                        { }
                    }                    
                }
                catch
                { }
            }

            MessageBox.Show("Correos enviados exitosamente!", "Correos enviados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(padre.correo, padre.password);
            client.EnableSsl = true;
            client.Credentials = credentials;

            var mail = new MailMessage(padre.correo, "crisguycabs@gmail.com");
            mail.Subject = "correo de prueba";
            mail.Body = "correo de prueba";
            client.Send(mail);
        }
    }
}
