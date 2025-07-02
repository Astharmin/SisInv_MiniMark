using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MiniMarket.Entidades;
using MiniMarket.Datos;


namespace MiniMarket.Negocio
{
    public class N_Unidades
    {
        public static DataTable Listado_um(string cTexto)
        {
            D_Unidades Datos = new D_Unidades();
            return Datos.Listado_um(cTexto);
        }

        public static string Guardar_um(int nOpciones, E_Unidades oUm)
        {
            D_Unidades Datos = new D_Unidades();
            return Datos.Guardar_um(nOpciones, oUm);
        }
        public static string Eliminar_um(int Codigo_um)
        {
            D_Unidades Datos = new D_Unidades();
            return Datos.Eliminar_um(Codigo_um);
        }
    }
}
