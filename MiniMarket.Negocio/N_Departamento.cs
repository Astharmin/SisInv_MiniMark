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
    public class N_Departamento
    {
        public static DataTable Listado_dp(string cTexto)
        {
            D_Departamento Datos = new D_Departamento();
            return Datos.Listado_dp(cTexto);
        }

        public static string Guardar_dp(int nOpciones, E_Departamento oDp)
        {
            D_Departamento Datos = new D_Departamento();
            return Datos.Guardar_dp(nOpciones, oDp);
        }
        public static string Eliminar_dp(int Codigo_dp)
        {
            D_Departamento Datos = new D_Departamento();
            return Datos.Eliminar_dp(Codigo_dp);
        }
    }
}
