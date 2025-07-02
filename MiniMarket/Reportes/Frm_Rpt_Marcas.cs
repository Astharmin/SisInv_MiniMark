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
    public partial class Frm_Rpt_Marcas : Form
    {
        public Frm_Rpt_Marcas()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Marcas_Load(object sender, EventArgs e)
        {
            this.uSP_Listado_maTableAdapter.Fill(this.dataSet1_MiniMarket.USP_Listado_ma, cTexto: txt_p1.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
