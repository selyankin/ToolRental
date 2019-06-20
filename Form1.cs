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
        }

        private void КлиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var db = new SQLiteClient();
            db.Clients.Load();
            dataGridView1.DataSource = db.Clients.Local.ToBindingList();
            panel1.Show();
        }

        private void ИнструментToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var db = new SQLiteClient();
            db.Clients.Load();
            dataGridView1.DataSource = db.Tools.Local.ToBindingList();
        }


        /// <summary>
        /// Button for adding client to db.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.Show();
        }


        private void EditClient_Click(object sender, EventArgs e)
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

                if (db.Clients.Count() >= count)
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
                var id = a.Cells[4];
                ids.Add((int)id.Value);
            }

            return ids;
        }
    }
}
