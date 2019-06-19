using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolsRental;

namespace ToolRental
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.Show();
            var db = new DBSQLClient();
            dataGridView1.DataSource = db.GetDatabase("Clients");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void КлиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var db = new DBSQLClient();
            dataGridView1.DataSource = db.GetDatabase("Clients");
            panel1.Show();
        }

        private void ИнструментToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var db = new DBSQLClient();
            dataGridView1.DataSource = db.GetDatabase("Tools");
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
            var ids = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var a = dataGridView1.Rows[row.Index];
                var id = a.Cells[0];
                ids.Add((int)id.Value);
            }

            var db = new DBSQLClient();
            List<NaturalPerson> clients = db.FindNaturalPersons(ids).ToList();

            foreach (var client in clients)
            {
                var form = new Form2();
                form.FillFields(client);
                form.Show();
            }
        }
    }
}
