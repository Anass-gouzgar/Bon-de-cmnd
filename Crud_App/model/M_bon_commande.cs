using Crud_App.controller;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Crud_App.model
{
    public class M_bon_commande
    {

        public C_bon_commande cntrl;

        private SqlDataAdapter da = new SqlDataAdapter();

        public SqlCommand cmd = new SqlCommand();
        private string cont;



        public bool IsNumCmdUnique_M(string numCmd)
        {

            cmd.CommandText = "SELECT COUNT(*) FROM bon_cmd WHERE num_cmd = @numm";
            cmd.Connection = Mdl_com.verif_connect();
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@numm", numCmd);
            int count = (int)cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();
            return count == 0;

        }


        public void supp_bon_cmd_M(string code)
        {
            using (var conn = Mdl_com.verif_connect())
            {
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        cmd.CommandText = "DELETE FROM d_bon_cmd WHERE num_cmd = @code";
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "DELETE FROM bon_cmd WHERE num_cmd = @code";
                        cmd.ExecuteNonQuery();

                        //MessageBox.Show("L'élément a été supprimé avec succès des deux tables.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur de suppression : " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        public void supp_bon_cmd_M_u(string code)
        {
            using (var conn = Mdl_com.verif_connect())
            {
                //using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        
                        // First, delete from d_bon_cmd
                        cmd.CommandText = "DELETE FROM d_bon_cmd WHERE num_cmd = @code";
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.ExecuteNonQuery();

                        // Then, delete from bon_cmd
                        cmd.CommandText = "DELETE FROM bon_cmd WHERE num_cmd = @code";
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur de suppression : " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }




        public void GetDBonRecords(string code)
        {



            SqlConnection conn = new SqlConnection("Data Source=easysolutions7;Initial Catalog=bon_de_commande_db;Integrated Security=True");

            string query = "SELECT * FROM d_bon_cmd WHERE num_cmd = @num_cmdd";

            using (SqlDataAdapter sda = new SqlDataAdapter(query, conn))
            {
                cmd.Parameters.Clear();

                sda.SelectCommand.Parameters.AddWithValue("@num_cmdd", code);

                DataTable dt = new DataTable();

                conn.Open();

                sda.Fill(dt);

                conn.Close();



            }

        }
        public void ajouter_tout(string num_cmd, string nom_cmd, string remarque, DateTime date, string num_cmdd, DataGridView dgv)
        {
            var trans = Mdl_com.verif_connect().BeginTransaction(IsolationLevel.ReadCommitted);
            cmd.Transaction = trans;
            cont = "";

            try
            {
                cmd.Connection = Mdl_com.verif_connect();

                // Insert into bon_cmd table using parameters
                cmd.CommandText = "INSERT INTO bon_cmd (num_cmd, nom_cmd, description_cmd, date_cmd) VALUES (@num_cmd, @nom_cmd, @description, @date)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@num_cmd", num_cmd);
                cmd.Parameters.AddWithValue("@nom_cmd", nom_cmd);
                cmd.Parameters.AddWithValue("@description", remarque);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO d_bon_cmd (num_cmd, article, quantity, prix_unitaire) VALUES (@num_cmd, @article, @quantity, @prix_unitaire)";


                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    string article = dgv.Rows[i].Cells["article"].Value.ToString();
                    int quantity = Convert.ToInt32(dgv.Rows[i].Cells["quantity"].Value); 
                    decimal prix_unitaire = Convert.ToDecimal(dgv.Rows[i].Cells["prix_unitaire"].Value); 

                    // Insert data into d_bon_cmd table using parameters
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@num_cmd", num_cmd);
                    cmd.Parameters.AddWithValue("@article", article);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@prix_unitaire", prix_unitaire);
                    cmd.Transaction = trans;
                    cmd.ExecuteNonQuery();
                }




                trans.Commit();
                MessageBox.Show("Insertion successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Erreur d'insertion : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //public void ajouter(string num_cmd, string nom_cmd, string remarque, DateTime date, string num_cmdd, string article, int quantity, int prix)
        //{
        //    var trans = Mdl_com.verif_connect().BeginTransaction(IsolationLevel.ReadCommitted);
        //    cmd.Transaction = trans;

        //    try
        //    {
        //        cmd.Connection = Mdl_com.verif_connect();

        //        // Insert into bon_cmd table using parameters
        //        cmd.CommandText = "INSERT INTO bon_cmd (num_cmd, nom_cmd, description_cmd, date_cmd) VALUES (@num_cmd, @nom_cmd, @description, @date)";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@num_cmd", num_cmd);
        //        cmd.Parameters.AddWithValue("@nom_cmd", nom_cmd);
        //        cmd.Parameters.AddWithValue("@description", remarque);
        //        cmd.Parameters.AddWithValue("@date", date);
        //        cmd.Transaction = trans;
        //        cmd.ExecuteNonQuery();

        //        // Insert into d_bon_cmd table using parameters
        //        cmd.CommandText = "INSERT INTO d_bon_cmd (num_cmd, article, quantity, prix_unitaire) VALUES (@num_cmd, @article, @quantity, @prix)";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@num_cmd", num_cmd);
        //        cmd.Parameters.AddWithValue("@article", article);
        //        cmd.Parameters.AddWithValue("@quantity", quantity);
        //        cmd.Parameters.AddWithValue("@prix", prix);
        //        cmd.Transaction = trans;
        //        cmd.ExecuteNonQuery();

        //        trans.Commit();
        //        MessageBox.Show("Insertion successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    catch (Exception ex)
        //    {
        //        trans.Rollback();
        //        MessageBox.Show("Erreur d'insertion : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    }
        //}

        public void update(string num_cmd, string nom_cmd, string remarque, DateTime date, string num_cmdd, string article, int quantity, int prix)
        {
            var trans = Mdl_com.verif_connect().BeginTransaction(IsolationLevel.ReadCommitted);
            cmd.Transaction = trans;

            try
            {
                cmd.Connection = Mdl_com.verif_connect();
                cmd.CommandText = "insert into bon_cmd values( '" + num_cmd + "','" + nom_cmd + "','" + remarque + "','" + date + "')";
                cmd.Transaction = trans;
                cont = cmd.CommandText;
                cmd.Connection = Mdl_com.verif_connect();
                cmd.ExecuteScalar();

                cmd.CommandText = "INSERT INTO d_bon_cmd VALUES ('" + num_cmdd + "','" + article + "','"+ quantity + "','" + prix + "')";
                cmd.Transaction = trans;
                cmd.Connection = Mdl_com.verif_connect();
                cmd.ExecuteScalar();


                trans.Commit();
                //MessageBox.Show("Votre modification a été enregistrée avec succés", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Erreur d'insertion : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        public DataSet load_dgv_d_bon(string num_de_bon)
        {
            try
            {
                DataSet ds = new DataSet();
                cmd.CommandText = "select * , prix_unitaire * quantity as Total from d_bon_cmd where num_cmd = @codd ";
                cmd.Connection = Mdl_com.verif_connect();
                da.SelectCommand = cmd;
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@Codd", num_de_bon);

                da.Fill(ds, "details");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return default;
        }
    }




    //public void update(string num_cmd, string nom_cmd, string remarque, DateTime date, string num_cmdd, string article, int quantity, int prix)
    //{
    //    var trans = Mdl_com.verif_connect().BeginTransaction(IsolationLevel.ReadCommitted);
    //    cmd.Transaction = trans;

    //    try
    //    {
    //        cmd.Connection = Mdl_com.verif_connect();

    //        cmd.CommandText = "INSERT INTO bon_cmd (num_cmd, nom_cmd, description_cmd, date_cmd) VALUES (@num_cmd, @nom_cmd, @description, @date)";
    //        cmd.Parameters.Clear();
    //        cmd.Parameters.AddWithValue("@num_cmd", num_cmd);
    //        cmd.Parameters.AddWithValue("@nom_cmd", nom_cmd);
    //        cmd.Parameters.AddWithValue("@description", remarque);
    //        cmd.Parameters.AddWithValue("@date", date);
    //        cmd.Transaction = trans;
    //        cmd.ExecuteNonQuery();

    //        cmd.CommandText = "INSERT INTO d_bon_cmd (num_cmd, article, quantity, prix_unitaire) VALUES (@num_cmd, @article, @quantity, @prix)";
    //        cmd.Parameters.Clear();
    //        cmd.Parameters.AddWithValue("@num_cmd", num_cmd);
    //        cmd.Parameters.AddWithValue("@article", article);
    //        cmd.Parameters.AddWithValue("@quantity", quantity);
    //        cmd.Parameters.AddWithValue("@prix", prix);
    //        cmd.Transaction = trans;
    //        cmd.ExecuteNonQuery();

    //        trans.Commit();
    //        //MessageBox.Show("Votre modification a été enregistrée avec succés", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

    //    }
    //    catch (Exception ex)
    //    {
    //        trans.Rollback();
    //        MessageBox.Show("Erreur d'insertion : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
    //    }
    //}











    //public void ajouter(string num_cmd, string nom_cmd, string remarque, DateTime date, string num_cmdd, string article, int quantity, int prix)
    //{
    //    var trans = Mdl_com.verif_connect().BeginTransaction(IsolationLevel.ReadCommitted);
    //    cmd.Transaction = trans;
    //    try
    //    {
    //        cmd.CommandText = "insert into bon_cmd values( '" + num_cmd + "','" + nom_cmd + "','" + remarque + "','" + date + "')";
    //        cmd.Transaction = trans;
    //        cont = cmd.CommandText;
    //        cmd.Connection = Mdl_com.verif_connect();
    //        cmd.ExecuteScalar();

    //                cmd.CommandText = "insert into d_bon_cmd values('" + num_cmdd + article + "'," + quantity + "'"+ prix+ "')";
    //                cmd.Transaction = trans;
    //                cmd.Connection = Mdl_com.verif_connect();
    //                cmd.ExecuteScalar();


    //        trans.Commit();
    //    }
    //    catch (Exception ex)
    //    {
    //        trans.Rollback();
    //        MessageBox.Show("Erreur d'insertion : " + ex.Message,"Error", MessageBoxButtons.OK , MessageBoxIcon.Stop );
    //    }
    //}




    //    public void LoadDataGridView()
    //{

    //    vue.dg_cmd_d.Columns.Clear(); // Clear the columns instead of TableStyles

    //    DataGridViewColumn column = new DataGridViewTextBoxColumn();
    //    column.DataPropertyName = "num_cmd";
    //    column.HeaderText = "N° de commande";
    //    column.DefaultCellStyle.NullValue = ""; 
    //    column.Width = 92;
    //    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
    //    column.ReadOnly = false;

    //    // Add the column to the DataGridView
    //    vue.dg_cmd_d.Columns.Add(column);
    //}




    //public void ajouter(string num_cmd, string nom_cmd, string remarque, string date, string article, string quantity, string prix)
    //{
    //    try
    //    {
    //        using (SqlConnection connection = Mdl_com.verif_connect())
    //        {
    //            connection.Open();
    //            using (SqlTransaction trans = connection.BeginTransaction(IsolationLevel.ReadCommitted))
    //            using (SqlCommand cmd = connection.CreateCommand())
    //            {
    //                cmd.Transaction = trans;

    //                // Insert data into the 'bon_cmd' table using parameterized query
    //                cmd.CommandText = "INSERT INTO bon_cmd VALUES (@num_cmd, @nom_cmd, @remarque, @date)";
    //                cmd.Parameters.AddWithValue("@num_cmd", num_cmd);
    //                cmd.Parameters.AddWithValue("@nom_cmd", nom_cmd);
    //                cmd.Parameters.AddWithValue("@remarque", remarque);
    //                cmd.Parameters.AddWithValue("@date", date);
    //                cmd.ExecuteNonQuery();

    //                // Insert data into the 'd_bon_cmd' table using parameterized query
    //                cmd.CommandText = "INSERT INTO d_bon_cmd VALUES (@num_cmd, @article, @quantity, @prix)";
    //                cmd.Parameters.Clear(); // Clear previous parameters
    //                cmd.Parameters.AddWithValue("@num_cmd", num_cmd);
    //                cmd.Parameters.AddWithValue("@article", article);
    //                cmd.Parameters.AddWithValue("@quantity", quantity);
    //                cmd.Parameters.AddWithValue("@prix", prix);
    //                cmd.ExecuteNonQuery();

    //                trans.Commit();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show("bon de commande erreur insertion : " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
    //    }
    //}



    //public void btn_add_Click_1(string num, string nom, string description, DateTime selectedDate)
    //{
    //    using (var conn = Mdl_com.verif_connect())
    //    {
    //        using (var cmd = new SqlCommand())
    //        {
    //            cmd.Connection = conn;
    //            cmd.CommandType = CommandType.Text;

    //            try
    //            {
    //                cmd.CommandText = "INSERT INTO bon_cmd (num_cmd, nom_cmd, description_cmd, date_cmd) VALUES (@num, @nom, @description, @date)";
    //                cmd.Parameters.AddWithValue("@num", num);
    //                cmd.Parameters.AddWithValue("@nom", nom);
    //                cmd.Parameters.AddWithValue("@description", description);
    //                cmd.Parameters.AddWithValue("@date", selectedDate);

    //                cmd.ExecuteNonQuery();


    //                MessageBox.Show("Votre bon de commande a été ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //            }
    //            catch (Exception ex)
    //            {
    //                MessageBox.Show("Erreur lors de l'ajout du bon de commande : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            }
    //        }
    //    }
    //}
}



