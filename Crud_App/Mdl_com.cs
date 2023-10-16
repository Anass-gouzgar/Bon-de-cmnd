using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud_App.shared;

namespace Crud_App
{
    internal class Mdl_com
    {
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataAdapter da = new SqlDataAdapter();


        public static SqlConnection verif_connect()
            {
                if (Connect.cnx.State == ConnectionState.Open)
                    return Connect.cnx;
                else
                {
                    Connect.cnx.ConnectionString = "Data Source=easysolutions7;Initial Catalog=bon_de_commande_db;Integrated Security=True";
                    Connect.cnx.Open();
                    return Connect.cnx;
                }
            }
    }

}
