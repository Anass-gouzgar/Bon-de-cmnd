using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Crud_App.shared
{
    public class Connect
    {
        public static SqlConnection cnx = new SqlConnection("Data Source=easysolutions7;Initial Catalog=bon_de_commande_db;Integrated Security=True");

        public static void Ouvrir()
        {
            try
            {
                cnx.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème de connexion ! " + ex.Message, "Error", MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }

        public static void Fermer()
        {
            if (cnx.State == System.Data.ConnectionState.Open)
            {
                cnx.Close();
            }
        }
    }
}
