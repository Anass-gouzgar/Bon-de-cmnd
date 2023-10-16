namespace Crud_App
{
    partial class v_bonCommande
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(v_bonCommande));
            dg_cmd_d = new DataGridView();
            btn_add = new PictureBox();
            btn_reset = new PictureBox();
            btn_print = new PictureBox();
            btn_search = new PictureBox();
            btn_update = new PictureBox();
            btn_delete = new PictureBox();
            txt_num_bon = new TextBox();
            tb_nom_bon = new TextBox();
            tb_remarque = new TextBox();
            btn_exit = new PictureBox();
            label1 = new Label();
            label5 = new Label();
            label2 = new Label();
            dt_bon_cmd = new DateTimePicker();
            label3 = new Label();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dg_cmd_d).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_add).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_reset).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_print).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_search).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_update).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_delete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).BeginInit();
            SuspendLayout();
            // 
            // dg_cmd_d
            // 
            dg_cmd_d.AllowUserToDeleteRows = false;
            dg_cmd_d.AllowUserToResizeColumns = false;
            dg_cmd_d.AllowUserToResizeRows = false;
            dg_cmd_d.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg_cmd_d.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dg_cmd_d, "dg_cmd_d");
            dg_cmd_d.Name = "dg_cmd_d";
            dg_cmd_d.RowHeadersVisible = false;
            dg_cmd_d.RowTemplate.Height = 25;
            dg_cmd_d.CellContentClick += dg_cmd_d_CellContentClick;
            // 
            // btn_add
            // 
            btn_add.BackColor = SystemColors.ActiveCaption;
            btn_add.Cursor = Cursors.Hand;
            resources.ApplyResources(btn_add, "btn_add");
            btn_add.Name = "btn_add";
            btn_add.TabStop = false;
            btn_add.Click += btn_add_Click;
            // 
            // btn_reset
            // 
            btn_reset.Cursor = Cursors.Hand;
            resources.ApplyResources(btn_reset, "btn_reset");
            btn_reset.Name = "btn_reset";
            btn_reset.TabStop = false;
            btn_reset.Click += pictureBox2_Click;
            // 
            // btn_print
            // 
            btn_print.Cursor = Cursors.Hand;
            resources.ApplyResources(btn_print, "btn_print");
            btn_print.Name = "btn_print";
            btn_print.TabStop = false;
            btn_print.Click += btn_print_Click;
            // 
            // btn_search
            // 
            btn_search.Cursor = Cursors.Hand;
            resources.ApplyResources(btn_search, "btn_search");
            btn_search.Name = "btn_search";
            btn_search.TabStop = false;
            btn_search.Click += btn_search_Click;
            // 
            // btn_update
            // 
            btn_update.Cursor = Cursors.Hand;
            resources.ApplyResources(btn_update, "btn_update");
            btn_update.Name = "btn_update";
            btn_update.TabStop = false;
            btn_update.Click += btn_update_Click;
            // 
            // btn_delete
            // 
            btn_delete.Cursor = Cursors.Hand;
            resources.ApplyResources(btn_delete, "btn_delete");
            btn_delete.Name = "btn_delete";
            btn_delete.TabStop = false;
            btn_delete.Click += btn_delete_Click;
            // 
            // txt_num_bon
            // 
            resources.ApplyResources(txt_num_bon, "txt_num_bon");
            txt_num_bon.Name = "txt_num_bon";
            // 
            // tb_nom_bon
            // 
            resources.ApplyResources(tb_nom_bon, "tb_nom_bon");
            tb_nom_bon.Name = "tb_nom_bon";
            // 
            // tb_remarque
            // 
            resources.ApplyResources(tb_remarque, "tb_remarque");
            tb_remarque.Name = "tb_remarque";
            tb_remarque.TextChanged += tb_remarque_TextChanged;
            // 
            // btn_exit
            // 
            btn_exit.Cursor = Cursors.Hand;
            resources.ApplyResources(btn_exit, "btn_exit");
            btn_exit.Name = "btn_exit";
            btn_exit.TabStop = false;
            btn_exit.Click += pictureBox8_Click;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.GrayText;
            label1.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            label1.Click += label1_Click;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.GrayText;
            label5.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            label5.Click += label1_Click;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.GrayText;
            label2.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            label2.Click += label1_Click;
            // 
            // dt_bon_cmd
            // 
            resources.ApplyResources(dt_bon_cmd, "dt_bon_cmd");
            dt_bon_cmd.Format = DateTimePickerFormat.Short;
            dt_bon_cmd.MinDate = new DateTime(2020, 1, 1, 0, 0, 0, 0);
            dt_bon_cmd.Name = "dt_bon_cmd";
            dt_bon_cmd.ValueChanged += dt_bon_cmd_ValueChanged;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.GrayText;
            label3.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            label3.Click += label1_Click;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewDialog1
            // 
            resources.ApplyResources(printPreviewDialog1, "printPreviewDialog1");
            printPreviewDialog1.Name = "printPreviewDialog1";
            // 
            // label4
            // 
            label4.BackColor = Color.BurlyWood;
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // v_bonCommande
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(label4);
            Controls.Add(dt_bon_cmd);
            Controls.Add(tb_remarque);
            Controls.Add(tb_nom_bon);
            Controls.Add(txt_num_bon);
            Controls.Add(btn_delete);
            Controls.Add(btn_search);
            Controls.Add(btn_print);
            Controls.Add(btn_update);
            Controls.Add(btn_exit);
            Controls.Add(btn_reset);
            Controls.Add(btn_add);
            Controls.Add(dg_cmd_d);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "v_bonCommande";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dg_cmd_d).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_add).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_reset).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_print).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_search).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_update).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_delete).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_exit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox btn_add;
        private PictureBox btn_reset;
        private PictureBox btn_print;
        private PictureBox btn_search;
        private PictureBox btn_update;
        private PictureBox btn_delete;
        private PictureBox btn_exit;
        private Label label1;
        private Label label5;
        private Label label2;
        private Label label3;
        public TextBox txt_num_bon;
        public TextBox tb_nom_bon;
        public TextBox tb_remarque;
        public DateTimePicker dt_bon_cmd;
        public DataGridView dg_cmd_d;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private Label label4;
    }
}