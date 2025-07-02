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
    public partial class Frm_Productos : Form
    {
        public Frm_Productos()
        {
            InitializeComponent();
        }
        #region "Variables"
        int Codigo_pr = 0;
        int Codigo_ma = 0;
        int Codigo_ca = 0;
        int Codigo_um = 0;
        int EstadGuardar = 0;
        #endregion

        #region "Metodos"
        private void Formato_pr()
        {
            Dgv_principal.Columns[0].Width = 100;
            Dgv_principal.Columns[0].HeaderText = "CODIGO_PR";
            Dgv_principal.Columns[1].Width = 140;
            Dgv_principal.Columns[1].HeaderText = "PRODUCTOS";
            Dgv_principal.Columns[2].Width = 120;
            Dgv_principal.Columns[2].HeaderText = "MARCAS";
            Dgv_principal.Columns[3].Width = 100;
            Dgv_principal.Columns[3].HeaderText = "U.MEDIDAS";
            Dgv_principal.Columns[4].Width = 120;
            Dgv_principal.Columns[4].HeaderText = "CATEGORIAS";
            Dgv_principal.Columns[5].Width = 50;
            Dgv_principal.Columns[5].HeaderText = "STOCK MIN";
            Dgv_principal.Columns[6].Width = 50;
            Dgv_principal.Columns[6].HeaderText = "STOCK MAX";
            Dgv_principal.Columns[7].Visible = false;
            Dgv_principal.Columns[8].Visible = false;
            Dgv_principal.Columns[9].Visible = false;
        }

        private void Listado_pr(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Productos.Listado_pr(cTexto);
                this.Formato_pr();
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_pr"].Value)))
            {
                MessageBox.Show("No hay informacion visible",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_pr = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_pr"].Value);
                Txt_descripcion_pr.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["descripcion_pr"].Value);
            }
        }

        private void Formato_ma_pr()
        {
            Dgv_marcas.Columns[0].Width = 170;
            Dgv_marcas.Columns[0].HeaderText = "MARCA";
            Dgv_marcas.Columns[1].Visible = false;
        }

        private void Listado_ma_pr(string cTexto)
        {
            try
            {
                Dgv_marcas.DataSource = N_Productos.Listado_ma_pr(cTexto);
                this.Formato_ma_pr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selec_iten_ma_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_marcas.CurrentRow.Cells["codigo_ma"].Value)))
            {
                MessageBox.Show("No hay informacion visible",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ma = Convert.ToInt32(Dgv_marcas.CurrentRow.Cells["codigo_ma"].Value);
                Txt_descripcion_ma.Text = Convert.ToString(Dgv_marcas.CurrentRow.Cells["descripcion_ma"].Value);
            }
        }

        private void Formato_um_pr()
        {
            Dgv_medidas.Columns[0].Width = 170;
            Dgv_medidas.Columns[0].HeaderText = "UNIDADES";
            Dgv_medidas.Columns[1].Visible = false;
        }

        private void Listado_um_pr(string cTexto)
        {
            try
            {
                Dgv_medidas.DataSource = N_Productos.Listado_um_pr(cTexto);
                this.Formato_um_pr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selec_iten_um_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_medidas.CurrentRow.Cells["codigo_um"].Value)))
            {
                MessageBox.Show("No hay informacion visible",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ma = Convert.ToInt32(Dgv_medidas.CurrentRow.Cells["codigo_um"].Value);
                Txt_descripcion_um.Text = Convert.ToString(Dgv_medidas.CurrentRow.Cells["descripcion_um"].Value);
            }
        }

        private void Formato_ca_pr()
        {
            Dgv_categorias.Columns[0].Width = 170;
            Dgv_categorias.Columns[0].HeaderText = "CATEGORIA";
            Dgv_categorias.Columns[1].Visible = false;
        }

        private void Listado_ca_pr(string cTexto)
        {
            try
            {
                Dgv_categorias.DataSource = N_Productos.Listado_ca_pr(cTexto);
                this.Formato_ca_pr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selec_iten_ca_pr()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_categorias.CurrentRow.Cells["codigo_ca"].Value)))
            {
                MessageBox.Show("No hay informacion visible",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_ca = Convert.ToInt32(Dgv_categorias.CurrentRow.Cells["codigo_ca"].Value);
                Txt_descripcion_ca.Text = Convert.ToString(Dgv_categorias.CurrentRow.Cells["descripcion_ca"].Value);
            }
        }

        #endregion



        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            this.Listado_pr("%");
            this.Listado_ma_pr("%");
            this.Listado_um_pr("%");
            this.Listado_ca_pr("%");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_descripcion_pr.Text == String.Empty ||
                Txt_descripcion_ma.Text == String.Empty ||
                Txt_descripcion_um.Text == String.Empty ||
                Txt_descripcion_ca.Text == String.Empty)
            {
                MessageBox.Show("Faltan registrar Datos (*)",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                E_Productos oPr = new E_Productos();
                string Rpta = "";
                oPr.Codigo_pr = this.Codigo_pr;
                oPr.Descripcion_pr = Txt_descripcion_pr.Text.Trim();
                oPr.Codigo_ma = this.Codigo_ma;
                oPr.Codigo_um = this.Codigo_um;
                oPr.Codigo_ca = this.Codigo_ca;
                oPr.Stock_min = Convert.ToDecimal (Txt_stock_min.Text);
                oPr.Stock_max = Convert.ToDecimal (Txt_stock_max.Text);
                
                Rpta = N_Productos.Guardar_pr(EstadGuardar, oPr);
                if (Rpta == "Ok")
                {
                    this.Listado_pr("%");
                    MessageBox.Show("Datos Guardados correctamente",
                        "Aviso del Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    EstadGuardar = 0;
                    this.Estado_BotonPrin(true);
                    this.Estado_Procesos(false);
                    Txt_descripcion_pr.Text = "";
                    Txt_stock_min.Text = "0";
                    Txt_stock_max.Text = "0";
                    Txt_descripcion_pr.ReadOnly = true;
                    Txt_stock_min.ReadOnly = true;
                    Txt_stock_max.ReadOnly = true;
                    Tbp_principal.SelectedIndex = 0;
                    this.Codigo_ma = 0;

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
            Txt_descripcion_pr.Text = "";
            Txt_stock_min.Text = "0";
            Txt_stock_max.Text = "0";
            Txt_descripcion_pr.ReadOnly = false;
            Txt_stock_min.ReadOnly = false;
            Txt_stock_max.ReadOnly = false;
            Tbp_principal.SelectedIndex = 1;
            Txt_descripcion_pr.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            EstadGuardar = 2;
            this.Codigo_pr = 0;
            this.Estado_BotonPrin(false);
            this.Estado_Procesos(true);
            this.Selec_iten();
            Tbp_principal.SelectedIndex = 1;
            Txt_descripcion_pr.ReadOnly = false;
            Txt_descripcion_pr.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            EstadGuardar = 0;
            this.Codigo_pr = 0;
            Txt_descripcion_pr.Text = "";
            Txt_stock_min.Text = "0";
            Txt_stock_max.Text = "0";
            Txt_descripcion_pr.ReadOnly = true;
            Txt_stock_min.ReadOnly = true;
            Txt_stock_max.ReadOnly = true;
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
            this.Codigo_pr = 0;
        }

        private void Dgv_principal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["codigo_pr"].Value)))
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
                    this.Codigo_pr = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["codigo_pr"].Value);
                    Rpta = N_Productos.Eliminar_pr(this.Codigo_pr);

                    if (Rpta.Equals("Ok"))
                    {
                        this.Listado_pr("%");
                        MessageBox.Show("Registro Eliminado",
                            "Aviso del Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        this.Codigo_pr = 0;
                    }
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_pr(Txt_buscar.Text.Trim());
        }

        private void Btn_reportes_Click(object sender, EventArgs e)
        {
            Reportes.Frm_Rpt_Marcas oRpt2 = new Reportes.Frm_Rpt_Marcas();
            oRpt2.txt_p1.Text = Txt_buscar.Text;
            oRpt2.ShowDialog();
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_buscar1_Click(object sender, EventArgs e)
        {
            this.Listado_ma_pr(Txt_buscar1.Text);
        }

        private void Btn_retornar1_Click(object sender, EventArgs e)
        {
            Pnl_Listado_ma.Visible = false;
        }

        private void Btn_lupa1_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_ma.Location = Btn_lupa1.Location;
            this.Pnl_Listado_ma.Visible = true;
        }

        private void Dgv_marcas_DoubleClick(object sender, EventArgs e)
        {
            this.Selec_iten_ma_pr();
            Pnl_Listado_ma.Visible = false;
        }

        private void Btn_lupa2_Click(object sender, EventArgs e)
        {
            this.Pnl_Listado_um.Location = Btn_lupa1.Location;
            this.Pnl_Listado_um.Visible = true;
        }

        private void Btn_buscar2_Click(object sender, EventArgs e)
        {
            this.Listado_um_pr(Txt_buscar2.Text);
        }

        private void Btn_retornar2_Click(object sender, EventArgs e)
        {
            Pnl_Listado_um.Visible = false;
        }

        private void Dgv_medidas_DoubleClick(object sender, EventArgs e)
        {
            this.Selec_iten_um_pr();
            Pnl_Listado_um.Visible = false;
        }

        private void Dgv_categorias_DoubleClick(object sender, EventArgs e)
        {
            this.Selec_iten_ca_pr();
            Pnl_Listado_ca.Visible = false;

        }  

        private void Btn_lupa3_Click_1(object sender, EventArgs e)
        {
            this.Pnl_Listado_ca.Location = Btn_lupa1.Location;
            this.Pnl_Listado_ca.Visible = true;
        }

        private void Btn_buscar3_Click(object sender, EventArgs e)
        {
            this.Listado_ca_pr(Txt_buscar3.Text);
        }

        private void Btn_retornar3_Click(object sender, EventArgs e)
        {
            Pnl_Listado_ca.Visible = false;
        }
    }
}