using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolsRental;

namespace ToolRental
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var name = nameTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
                nameTextBox.BackColor = Color.IndianRed;

            if (!int.TryParse(priceTextBox.Text, out var price))
                priceTextBox.BackColor = Color.IndianRed;

            if (!int.TryParse(idTextBox.Text, out var id))
                idTextBox.BackColor = Color.IndianRed;

            var note = noteTextBox.Text;
            var path = pictureBox1.ImageLocation;

            var tool = new Tool(name, price, id, note, path);

            var db = new SQLiteClient();
            db.Tools.Add(tool);
            db.SaveChanges();

            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void EditPictureButton_Click(object sender, EventArgs e)
        {
            var path = openFileDialog1.SafeFileName;

            if (path == null || !File.Exists(path)) return;

            pictureBox1.Image = Image.FromFile(path);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void FillFields(Tool tool)
        {
            nameTextBox.Text = tool.Name;
            priceTextBox.Text = tool.Price.ToString();
            noteTextBox.Text = tool.Note;
            idTextBox.Text = tool.Id.ToString();

            if (File.Exists(tool.PathToPicture))
                pictureBox1.ImageLocation = tool.PathToPicture;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
