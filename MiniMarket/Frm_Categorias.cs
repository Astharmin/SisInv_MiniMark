using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniMarket.Entidades;
using MiniMarket.Negocio;

namespace MiniMarket
{
    public partial class Frm_Categorias : Form
    {
        public Frm_Categorias()
        {
            InitializeComponent();
        }
        #region "Variables"
        int Codigo_ca = 0;
        int EstadGuardar = 0;
        #endregion

        #region "Metodos"
        private void Formato_ca() 
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CODIGO_CA";
            Dgv_principal.Columns[1].Width = 370;
            Dgv_principal.Columns[1].HeaderText = "CATEGORIAS";
        }

        private void Listado_ca(string cTexto) 
        {
            try 
            {
                Dgv_principal.DataSource = N_Categorias.Listado_ca(cTexto);
                this.Formato_ca();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Estado_BotonPrin(bool L_Estado) 
        {
            this.Btn_nuevo.Enabled = L_Estado;
            this.Btn_actualizar.Enabled = L_Estado;
            this.Btn_eliminar.Enabled = L_Estado;
            this.Btn_reportes.Enabled = L_Estado;
            this.Btn_salir.Enabled = L_Estado;
        }

        private void Estado_Procesos(bool L_Estado) 
        {
            this.Btn_cancelar.Visible = L_Estado;
            this.Btn_guardar.Visible = L_Estado;
            this.Btn_retornar.Visible = !L_Estado;
        }

        private void Selec_iten() 
        {
           if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_ca"].Value))) 
            {
                MessageBox.Show("No hay informacion visible", 
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ca = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ca"].Value);
                Txt_descripcion_ca.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_ca"].Value);
            }
        }

        #endregion

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_Categorias_Load(object sender, EventArgs e)
        {
            this.Listado_ca("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_ca.Text == String.Empty) 
            {
                MessageBox.Show("Faltan registrar Datos (*)", 
                    "Aviso del Sistema", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            else 
            {
                E_Categorias oCa = new E_Categorias();
                string Rpta = "";
                oCa.Codigo_ca = this.Codigo_ca;
                oCa.Descripcion_ca =Txt_descripcion_ca.Text.Trim();
                Rpta = N_Categorias.Guardar_ca(EstadGuardar, oCa);
                if (Rpta == "Ok") 
                {
                    this.Listado_ca("%");
                    MessageBox.Show("Datos Guardados correctamente",
                        "Aviso del Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    EstadGuardar = 0;
                    this.Estado_BotonPrin(true);
                    this.Estado_Procesos(false);
                    Txt_descripcion_ca.Text = "";
                    Txt_descripcion_ca.ReadOnly = true;
                    Tbp_principal.SelectedIndex = 0;
                    this.Codigo_ca = 0;
                    
                }
                else 
                {
                    MessageBox.Show(Rpta,"Aviso del Sistema",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            EstadGuardar = 1;
            this.Estado_BotonPrin(false);
            this.Estado_Procesos(true);
            Txt_descripcion_ca.Text = "";
            Txt_descripcion_ca.ReadOnly = false;
            Tbp_principal.SelectedIndex = 1;
            Txt_descripcion_ca.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            EstadGuardar = 2;
            this.Codigo_ca = 0;
            this.Estado_BotonPrin(false);
            this.Estado_Procesos(true);
            this.Selec_iten();
            Tbp_principal.SelectedIndex = 1;
            Txt_descripcion_ca.ReadOnly = false;
            Txt_descripcion_ca.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            EstadGuardar = 0;
            this.Codigo_ca = 0;
            Txt_descripcion_ca.Text = "";
            Txt_descripcion_ca.ReadOnly = true;
            this.Estado_BotonPrin(true);
            this.Estado_Procesos(false);
            Tbp_principal.SelectedIndex = 0;
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.Selec_iten();
            this.Estado_Procesos(false);
            Tbp_principal.SelectedIndex = 1;
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Procesos(false);
            Tbp_principal.SelectedIndex = 0;
            this.Codigo_ca = 0;
        }

        private void Dgv_principal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_ca"].Value)))
            {
                MessageBox.Show("No hay informacion visible",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Eliminar registo seleccionado?",
                    "Aviso del Sistema",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (Opcion == DialogResult.Yes) 
                {
                    string Rpta = "";
                    this.Codigo_ca = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_ca"].Value);
                    Rpta = N_Categorias.Eliminar_ca(this.Codigo_ca);

                    if (Rpta.Equals("Ok")) 
                    {
                        this.Listado_ca("%");
                        MessageBox.Show("Registro Eliminado",
                            "Aviso del Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        this.Codigo_ca = 0;
                    }
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_ca(Txt_buscar.Text.Trim());
        }

        private void Btn_reportes_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Categoria oRpt1 = new Reportes.Frm_Rpt_Categoria();
            oRpt1.txt_p1.Text = Txt_buscar.Text;
            oRpt1.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
