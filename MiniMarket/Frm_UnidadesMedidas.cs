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
    public partial class Frm_UnidadesMedidas : Form
    {
        public Frm_UnidadesMedidas()
        {
            InitializeComponent();
        }
        #region "Variables"
        int Codigo_um = 0;
        int EstadGuardar = 0;
        #endregion

        #region "Metodos"
        private void Formato_um() 
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CODIGO_UM";
            Dgv_principal.Columns[1].Width = 230;
            Dgv_principal.Columns[1].HeaderText = "MEDIDAS";
            Dgv_principal.Columns[2].Width = 120;
            Dgv_principal.Columns[2].HeaderText = "ABREVIATURAS";
        }

        private void Listado_um(string cTexto) 
        {
            try
            {
                Dgv_principal.DataSource = N_Unidades.Listado_um(cTexto);
                this.Formato_um();
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
           if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_um"].Value))) 
            {
                MessageBox.Show("No hay informacion visible", 
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_um = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_um"].Value);
                Txt_abreviatura_um.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["abreviatura_um"].Value);
                Txt_descripcion_um.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_um"].Value);
            }
        }

        #endregion

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_UnidadesMedidas_Load(object sender, EventArgs e)
        {
            this.Listado_um("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_abreviatura_um.Text == String.Empty || Txt_descripcion_um.Text == String.Empty) 
            {
                MessageBox.Show("Faltan registrar Datos (*)", 
                    "Aviso del Sistema", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            else 
            {
                E_Unidades oUm = new E_Unidades();
                string Rpta = "";
                oUm.Codigo_um = this.Codigo_um;
                oUm.Abreviatura_um = Txt_abreviatura_um.Text.Trim();
                oUm.Descripcion_um =Txt_descripcion_um.Text.Trim();
                Rpta = N_Unidades.Guardar_um(EstadGuardar, oUm);
                if (Rpta == "Ok") 
                {
                    this.Listado_um("%");
                    MessageBox.Show("Datos Guardados correctamente",
                        "Aviso del Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    EstadGuardar = 0;
                    this.Estado_BotonPrin(true);
                    this.Estado_Procesos(false);
                    Txt_abreviatura_um.Text = "";
                    Txt_descripcion_um.Text = "";
                    Txt_descripcion_um.ReadOnly = true;
                    Txt_abreviatura_um.ReadOnly = true;
                    Tbp_principal.SelectedIndex = 0;
                    this.Codigo_um = 0;
                    
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
            Txt_descripcion_um.Text = "";
            Txt_abreviatura_um.Text = "";
            Txt_descripcion_um.ReadOnly = false;
            Txt_abreviatura_um.ReadOnly = false;
            Tbp_principal.SelectedIndex = 1;
            Txt_abreviatura_um.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            EstadGuardar = 2;
            this.Codigo_um = 0;
            this.Estado_BotonPrin(false);
            this.Estado_Procesos(true);
            this.Selec_iten();
            Tbp_principal.SelectedIndex = 1;
            Txt_descripcion_um.ReadOnly = false;
            Txt_abreviatura_um.ReadOnly = false;
            Txt_descripcion_um.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            EstadGuardar = 0;
            this.Codigo_um = 0;
            Txt_abreviatura_um.Text = "";
            Txt_descripcion_um.Text = "";
            Txt_descripcion_um.ReadOnly = true;
            Txt_abreviatura_um.ReadOnly = true;
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
            this.Codigo_um = 0;
        }

        private void Dgv_principal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_um"].Value)))
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
                    this.Codigo_um = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_um"].Value);
                    Rpta = N_Unidades.Eliminar_um(this.Codigo_um);

                    if (Rpta.Equals("Ok")) 
                    {
                        this.Listado_um("%");
                        MessageBox.Show("Registro Eliminado",
                            "Aviso del Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        this.Codigo_um = 0;
                    }
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_um(Txt_buscar.Text.Trim());
        }

        private void Btn_reportes_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Unidades oRpt3 = new Reportes.Frm_Rpt_Unidades();
            oRpt3.txt_p1.Text = Txt_buscar.Text;
            oRpt3.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
