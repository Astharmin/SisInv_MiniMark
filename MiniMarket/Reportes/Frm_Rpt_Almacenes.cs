using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMarket.Reportes
{
    public partial class Frm_Rpt_Almacenes : Form
    {
        public Frm_Rpt_Almacenes()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Almacenes_Load(object sender, EventArgs e)
        {
            this.uSP_Listado_alTableAdapter.Fill(this.dataSet1_MiniMarket.USP_Listado_al, cTexto: txt_p1.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
