using Crud_App.controller;
using System.Data;
using System.Data.SqlClient;

namespace Crud_App
{
    public partial class v_bonCommande : Form
    {
        public v_bonCommande()
        {
            InitializeComponent();
            cntrl.load(this);
            cntrl.load_DGV();
            dg_cmd_d.ClearSelection();

        }
        C_bon_commande cntrl = new C_bon_commande();
        DataSet ds;
        SqlConnection conn = new SqlConnection("Data Source=easysolutions7;Initial Catalog=bon_de_commande_db;Integrated Security=True");
        //SqlDataAdapter adap;
        //SqlCommandBuilder sb;
        DataTable dt = new DataTable();

        public void GetDBonRecords_sans_num()
        {


            string query = "SELECT * FROM d_bon_cmd";

            using (SqlDataAdapter sda = new SqlDataAdapter(query, conn))
            {

                conn.Open();

                sda.Fill(dt);

                conn.Close();

                dg_cmd_d.DataSource = dt;
            }

        }


        public void GetBonRecords()
        {


            SqlConnection conn = new SqlConnection("Data Source=easysolutions7;Initial Catalog=bon_de_commande_db;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("select * from bon_cmd", conn);


            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            dt.Load(sdr);

            conn.Close();

            dg_cmd_d.DataSource = dt;
        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox8_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Voulez-vous vraiment quitter l'application ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {

                this.Close();
            }
        }




        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cntrl.ResetFormControls();
        }

        private bool IsValid()
        {
            if (txt_num_bon.Text == string.Empty && tb_nom_bon.Text == string.Empty)
            {
                MessageBox.Show("Le numéro et Le Nom De Commande est obligatoire !", "Echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        public void btn_add_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {

                cntrl.btn_add_Click_1();

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                //GetDBonRecords_sans_num();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error");
            }
        }


        private void dg_cmd_d_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //cntrl.load_DGV();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

            // Assuming txtInput is the name of your TextBox control.
            string userInput = txt_num_bon.Text.Trim(); // Trim to remove leading/trailing spaces

            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Entrez les informations de vitre bon de commande !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if the input is empty.
            }
            try
            {
                cntrl.btn_update_Click();

                MessageBox.Show("La modification a été effectuée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de modification : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void btn_search_Click(object sender, EventArgs e)
        {
            string input = txt_num_bon.Text;
            cntrl.load_DGV();

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 0.5;
            printPreviewDialog1.ShowDialog();
        }

        private void tb_remarque_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            cntrl.supp_bon_cmd_M();

        }

        private void dt_bon_cmd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap imagebmp = new Bitmap(dg_cmd_d.Width, dg_cmd_d.Height);
            dg_cmd_d.DrawToBitmap(imagebmp, new Rectangle(0, 0, dg_cmd_d.Width, dg_cmd_d.Height));
            e.Graphics.DrawImage(imagebmp, 100, 100);

        }

        /*
private bool IsNumCmdUnique(string numCmd)
{
    using (SqlConnection conn = new SqlConnection("Data Source=easysolutions7;Initial Catalog=bon_de_commande_db;Integrated Security=True"))
    {
        conn.Open();

        string query = "SELECT COUNT(*) FROM bon_cmd WHERE num_cmd = @num_cmd";
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@num_cmd", numCmd);
            int count = (int)cmd.ExecuteScalar();

            // If count is 0, the num_cmd is unique; otherwise, it already exists
            return count == 0;
        }
    }
}
*/

        //public void GetDBonRecords()
        //{
        //    string input = txt_num_bon.Text;

        //    if (int.TryParse(input, out int num_cmd))
        //    {
        //        // The conversion was successful, num_cmd now contains the integer value.
        //        // Proceed with your database query using num_cmd.

        //        SqlConnection conn = new SqlConnection("Data Source=easysolutions7;Initial Catalog=bon_de_commande_db;Integrated Security=True");

        //        string query = "SELECT * FROM d_bon_cmd WHERE num_cmd = @num_cmd";

        //        using (SqlDataAdapter sda = new SqlDataAdapter(query, conn))
        //        {
        //            sda.SelectCommand.Parameters.AddWithValue("@num_cmd", num_cmd);

        //            //DataTable dt = new DataTable();

        //            conn.Open();

        //            sda.Fill(dt);

        //            conn.Close();

        //            dg_cmd_d.DataSource = dt;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Veuillez saisir un n° de bon valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}
