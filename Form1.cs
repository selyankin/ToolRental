using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace ToolRental
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            dataGridView1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var db = new SQLiteClient();
            db.Clients.Load();
            this.dataGridView1.DataSource = db.Clients.Local.ToBindingList();

            tool_add.Hide();
            tool_edit.Hide();
            panel1.Show();
        }

        private void КлиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var db = new SQLiteClient();
            db.Clients.Load();
            dataGridView1.DataSource = db.Clients.Local.ToBindingList();
            
            tool_add.Hide();
            tool_edit.Hide();

            addClient.Show();
            editClient.Show();

            panel1.Show();
        }

        private void ИнструментToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var db = new SQLiteClient();
            db.Tools.Load();
            dataGridView1.DataSource = db.Tools.Local.ToBindingList();

            addClient.Hide();
            editClient.Hide();

            tool_add.Show();
            tool_edit.Show();

            panel1.Show();
        }


        /// <summary>
        /// Button for adding client to db.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AddClient(object sender, EventArgs e)
        {
            var form = new Form2();
            form.Show();
        }

        /// <summary>
        /// Button for editing client.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_EditClient(object sender, EventArgs e)
        {
            var ids = FindSelectedRows().ToList();
            var db = new SQLiteClient();

            var clients = db.FindClients(ids);
            var count = db.Clients.Count();

            foreach (var client in clients)
            {
                var form = new Form2();
                form.FillFields(client);
                form.Show();

                if (db.Clients.Count() > count)
                    db.Clients.Remove(client);
            }

            db.SaveChanges();
        }

        private IEnumerable<int> FindSelectedRows()
        {
            var ids = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var a = dataGridView1.Rows[row.Index];
                var id = a.Cells[0];
                ids.Add((int)id.Value);
            }

            return ids;
        }

        /// <summary>
        /// button for adding tool to db.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AddTool(object sender, EventArgs e)
        {
            var form = new Form3();
            form.Show();
        }

        /// <summary>
        /// Button for editing tool.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_EditTool(object sender, EventArgs e)
        {
            var ids = FindSelectedRows().ToList();
            var db = new SQLiteClient();

            var tools = db.FindTools(ids);
            var count = db.Tools.Count();

            foreach (var tool in tools)
            {
                var form = new Form3();
                form.FillFields(tool);
                form.Show();

                if (db.Tools.Count() > count)
                    db.Tools.Remove(tool);
            }

            db.SaveChanges();
        }
    }
}
