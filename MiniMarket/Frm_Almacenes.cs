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
    public partial class Frm_Almacenes : Form
    {
        public Frm_Almacenes()
        {
            InitializeComponent();
        }
        #region "Variables"
        int Codigo_al = 0;
        int EstadGuardar = 0;
        #endregion

        #region "Metodos"
        private void Formato_al()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CODIGO_AL";
            Dgv_principal.Columns[1].Width = 370;
            Dgv_principal.Columns[1].HeaderText = "ALMACEN";
        }

        private void Listado_al(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Almacenes.Listado_al(cTexto);
                this.Formato_al();
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_al"].Value)))
            {
                MessageBox.Show("No hay informacion visible",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_al = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_al"].Value);
                Txt_descripcion_al.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_al"].Value);
            }
        }

        #endregion

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Almacenes_Load(object sender, EventArgs e)
        {
            this.Listado_al("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_al.Text == String.Empty)
            {
                MessageBox.Show("Faltan registrar Datos (*)",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                E_Almacenes oAl = new E_Almacenes();
                string Rpta = "";
                oAl.Codigo_al = this.Codigo_al;
                oAl.Descripcion_al = Txt_descripcion_al.Text.Trim();
                Rpta = N_Almacenes.Guardar_al(EstadGuardar, oAl);
                if (Rpta == "Ok")
                {
                    this.Listado_al("%");
                    MessageBox.Show("Datos Guardados correctamente",
                        "Aviso del Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    EstadGuardar = 0;
                    this.Estado_BotonPrin(true);
                    this.Estado_Procesos(false);
                    Txt_descripcion_al.Text = "";
                    Txt_descripcion_al.ReadOnly = true;
                    Tbp_principal.SelectedIndex = 0;
                    this.Codigo_al = 0;

                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            EstadGuardar = 1;
            this.Estado_BotonPrin(false);
            this.Estado_Procesos(true);
            Txt_descripcion_al.Text = "";
            Txt_descripcion_al.ReadOnly = false;
            Tbp_principal.SelectedIndex = 1;
            Txt_descripcion_al.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            EstadGuardar = 2;
            this.Codigo_al = 0;
            this.Estado_BotonPrin(false);
            this.Estado_Procesos(true);
            this.Selec_iten();
            Tbp_principal.SelectedIndex = 1;
            Txt_descripcion_al.ReadOnly = false;
            Txt_descripcion_al.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            EstadGuardar = 0;
            this.Codigo_al = 0;
            Txt_descripcion_al.Text = "";
            Txt_descripcion_al.ReadOnly = true;
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
            this.Codigo_al = 0;
        }

        private void Dgv_principal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_al"].Value)))
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
                    this.Codigo_al = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_al"].Value);
                    Rpta = N_Almacenes.Eliminar_al(this.Codigo_al);

                    if (Rpta.Equals("Ok"))
                    {
                        this.Listado_al("%");
                        MessageBox.Show("Registro Eliminado",
                            "Aviso del Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        this.Codigo_al = 0;
                    }
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_al(Txt_buscar.Text.Trim());
        }

        private void Btn_reportes_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Almacenes oRpt3 = new Reportes.Frm_Rpt_Almacenes();
            oRpt3.txt_p1.Text = Txt_buscar.Text;
            oRpt3.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
