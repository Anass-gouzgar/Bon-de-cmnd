using Crud_App.model;
using System.Data;

namespace Crud_App.controller
{
    public class C_bon_commande
    {
        private DataSet ds = new DataSet();

        public v_bonCommande vue;
        M_bon_commande model = new M_bon_commande();
        //private SqlDataAdapter sda;

        public void load(v_bonCommande _vue)
        {
            this.vue = _vue;
        }


        private bool convert()
        {
            DataGridViewRow selectedRow = vue.dg_cmd_d.SelectedRows[0];
            object prix_unitaire = selectedRow.Cells["prix_unitaire"].Value;
            object quantity = selectedRow.Cells["quantity"].Value;

            if (int.TryParse(prix_unitaire?.ToString(), out int parsedPrixUnitaire) && int.TryParse(quantity?.ToString(), out int parsedQuantity))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void btn_add_Click_1()
        {
            DateTime selectedDate = vue.dt_bon_cmd.Value;

            if (!model.IsNumCmdUnique_M(vue.txt_num_bon.Text))
            {
                MessageBox.Show("Le numéro de commande existe déjà dans la base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (vue.dg_cmd_d.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = vue.dg_cmd_d.SelectedRows[0];

                    string numBon = vue.txt_num_bon.Text;
                    //object article = selectedRow.Cells["article"].Value;


                    if (convert())
                    {
                        model.ajouter_tout(numBon, vue.tb_nom_bon.Text, vue.tb_remarque.Text, selectedDate, vue.txt_num_bon.Text, vue.dg_cmd_d);
                    }
                    else
                    {
                        MessageBox.Show("Invalid price or quantity. Please enter valid numeric values.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row in the DataGridView.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //public void btn_add_Click_1()
        //{
        //    DateTime selectedDate = vue.dt_bon_cmd.Value;

        //    if (!model.IsNumCmdUnique_M(vue.txt_num_bon.Text))
        //    {
        //        MessageBox.Show("Le numéro de commande existe déjà dans la base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else
        //    {
        //        if (vue.dg_cmd_d.SelectedRows.Count > 0)
        //        {
        //            // Get the selected row
        //            DataGridViewRow selectedRow = vue.dg_cmd_d.SelectedRows[0];

        //            string numBon = vue.txt_num_bon.Text;
        //            object article = selectedRow.Cells["article"].Value;
        //            object prix_unitaire = selectedRow.Cells["prix_unitaire"].Value;
        //            object quantity = selectedRow.Cells["quantity"].Value;

        //            if (int.TryParse(prix_unitaire?.ToString(), out int parsedPrixUnitaire) && int.TryParse(quantity?.ToString(), out int parsedQuantity))
        //            {
        //                model.ajouter(numBon, vue.tb_nom_bon.Text, vue.tb_remarque.Text, selectedDate, vue.txt_num_bon.Text, (string)article, parsedQuantity, parsedPrixUnitaire);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Invalid price or quantity. Please enter valid numeric values.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please select a row in the DataGridView.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //}


        public void load_DGV()
        {

            var dgv = vue.dg_cmd_d;

            {

                ds = new DataSet();
                ds = model.load_dgv_d_bon(vue.txt_num_bon.Text);


                vue.dg_cmd_d.DataSource = null;
                vue.dg_cmd_d.ColumnCount = 5;

                vue.dg_cmd_d.AutoGenerateColumns = false;

                vue.dg_cmd_d.Columns[0].DisplayIndex = 0;
                vue.dg_cmd_d.Columns[0].Name = "num_bon";
                vue.dg_cmd_d.Columns[0].DataPropertyName = "num_cmd";
                vue.dg_cmd_d.Columns[0].HeaderText = "N° de bon";
                vue.dg_cmd_d.Columns[0].Visible = false;
                vue.dg_cmd_d.Columns[0].ReadOnly = true;
                vue.dg_cmd_d.Columns[0].Width = 80;
                vue.dg_cmd_d.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                vue.dg_cmd_d.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                vue.dg_cmd_d.Columns[1].DisplayIndex = 1;
                vue.dg_cmd_d.Columns[1].Name = "article";
                vue.dg_cmd_d.Columns[1].DataPropertyName = "article";
                vue.dg_cmd_d.Columns[1].HeaderText = "Article";
                vue.dg_cmd_d.Columns[1].Visible = true;
                vue.dg_cmd_d.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                vue.dg_cmd_d.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                vue.dg_cmd_d.Columns[2].DisplayIndex = 2;
                vue.dg_cmd_d.Columns[2].Name = "prix_unitaire";
                vue.dg_cmd_d.Columns[2].DataPropertyName = "prix_unitaire";
                vue.dg_cmd_d.Columns[2].HeaderText = "Prix unitaire";
                vue.dg_cmd_d.Columns[2].Visible = true;
                vue.dg_cmd_d.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                vue.dg_cmd_d.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                vue.dg_cmd_d.Columns[3].DisplayIndex = 3;
                vue.dg_cmd_d.Columns[3].Name = "quantity";
                vue.dg_cmd_d.Columns[3].DataPropertyName = "quantity";
                vue.dg_cmd_d.Columns[3].HeaderText = "Quantity";
                vue.dg_cmd_d.Columns[3].Visible = true;
                vue.dg_cmd_d.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                vue.dg_cmd_d.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                vue.dg_cmd_d.Columns[4].DisplayIndex = 4;
                vue.dg_cmd_d.Columns[4].Name = "total";
                vue.dg_cmd_d.Columns[4].DataPropertyName = "total";
                vue.dg_cmd_d.Columns[4].HeaderText = "Total";
                vue.dg_cmd_d.Columns[4].Visible = true;
                vue.dg_cmd_d.Columns[4].ReadOnly = true;
                vue.dg_cmd_d.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                vue.dg_cmd_d.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



                dgv.DataSource = ds.Tables[0];

            }
        }



        public void supp_bon_cmd_M()
        {
            if (vue.txt_num_bon.Text == string.Empty)
            {
                MessageBox.Show("Le numéro De Commande est obligatoire !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var reponse = MessageBox.Show("Voulez-vous vraiment le supprimer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                if (reponse == DialogResult.Yes)
                {
                    model.supp_bon_cmd_M(vue.txt_num_bon.Text);
                    ResetFormControls();
                }
            }
        }

        public void supp_bon_cmd_M_u()
        {
            if (vue.txt_num_bon.Text == string.Empty)
            {
                MessageBox.Show("Le numéro De Commande est obligatoire !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                model.supp_bon_cmd_M(vue.txt_num_bon.Text);
            }
        }

        public void ResetFormControls()
        {
            vue.tb_nom_bon.Clear();
            vue.txt_num_bon.Clear();
            vue.dt_bon_cmd.Value = vue.dt_bon_cmd.MinDate;
            vue.tb_remarque.Clear();
            vue.txt_num_bon.Focus();
            vue.dg_cmd_d.DataSource = null;
            vue.dg_cmd_d.ClearSelection();

        }

          

        public void btn_update_Click()
        {

            if (vue.dg_cmd_d.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = vue.dg_cmd_d.SelectedRows[0];
                DateTime selectedDate = vue.dt_bon_cmd.Value;

                string numBon = vue.txt_num_bon.Text;
                object article = selectedRow.Cells["article"].Value;
                object prix_unitaire = selectedRow.Cells["prix_unitaire"].Value;
                object quantity = selectedRow.Cells["quantity"].Value;

                if (int.TryParse(prix_unitaire?.ToString(), out int parsedPrixUnitaire) && int.TryParse(quantity?.ToString(), out int parsedQuantity))
                {
                    model.supp_bon_cmd_M_u(vue.txt_num_bon.Text);
                    model.update(numBon, vue.tb_nom_bon.Text, vue.tb_remarque.Text, selectedDate, vue.txt_num_bon.Text, (string)article, parsedQuantity, parsedPrixUnitaire);

                }
                else
                {
                    MessageBox.Show("Prix ou quantité non valide. Veuillez entrer des valeurs numériques valides.", "Saisie invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }




                //public void btn_update_Click()
                //{
                //    if (vue.dg_cmd_d.SelectedRows.Count > 0)
                //    {
                //        // Get the selected row
                //        DataGridViewRow selectedRow = vue.dg_cmd_d.SelectedRows[0];
                //        DateTime selectedDate = vue.dt_bon_cmd.Value;

                //        // Extract data from the selected row
                //        string numBon = vue.txt_num_bon.Text;
                //        object article = selectedRow.Cells["article"].Value;
                //        object prix_unitaire = selectedRow.Cells["prix_unitaire"].Value;
                //        object quantity = selectedRow.Cells["quantity"].Value;

                //        // Check if the conversion to integers succeeds for prix_unitaire and quantity
                //        if (int.TryParse(prix_unitaire?.ToString(), out int parsedPrixUnitaire) &&
                //            int.TryParse(quantity?.ToString(), out int parsedQuantity))
                //        {
                //            // Call the controller function to update the data
                //            model.UpdateData(numBon, (string)article, parsedQuantity, parsedPrixUnitaire, selectedDate);

                //            // Optionally, you can display a success message
                //            MessageBox.Show("Data updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }
                //        else
                //        {
                //            // Handle the case where conversion to integers fails
                //            MessageBox.Show("Invalid price or quantity. Please enter valid numeric values.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("Please select a row to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}


                //_______________________________________________________________________________
                //public void GetDBonRecords()

                //{

                //    string input = vue.txt_num_bon.Text;

                //    if (int.TryParse(input, out int num_cmd) && vue.txt_num_bon.Text != string.Empty)
                //    {
                //         DataTable dtt = new DataTable();
                //        SqlConnection conn = new SqlConnection("Data Source=easysolutions7;Initial Catalog=bon_de_commande_db;Integrated Security=True");

                //        string query = "SELECT distinct num_cmd, article, quantity, prix_unitaire, prix_unitaire * quantity as 'Total' FROM d_bon_cmd where num_cmd = @num_cmd ";

                //        SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                //        {
                //            sda.SelectCommand.Parameters.AddWithValue("@num_cmd", input);

                //            //DataTable dt = new DataTable();

                //            conn.Open();

                //            sda.Fill(dt);

                //            conn.Close();

                //            vue.dg_cmd_d.DataSource = dt;
                //            //model.GetDBonRecords();
                //        }
                //        model.GetDBonRecords(input);
                //        dtt= vue.dg_cmd_d;
                //    }
                //    else
                //    {
                //        MessageBox.Show("Veuillez saisir un n° de bon valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}













            }
        }
    }
}