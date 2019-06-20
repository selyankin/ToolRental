using System;
using System.Windows.Forms;
using ToolsRental;

namespace ToolRental
{
    public partial class Form3 : Form
    {
        private Client client;

        public Form3(Client _client)
        {
            InitializeComponent();
            client = _client;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            nameLabel.Text = client.Name;
            surnameLabel.Text = client.Surname;
            patronymicLabel.Text = client.Patronymic;
            cityLabel.Text = client.City;
            passportLabel.Text = client.Passport.ToString();

            var date = client.IssueDate.Split('-');
            issueDateLabel1.Text = date[0];
            issueDateLabel2.Text = date[1];
            issueDateLabel3.Text = date[2];

            streetLabel.Text = client.Street;
            buildingLabel.Text = client.Building;
            apartmentLabel.Text = client.Apartment;

            homePhoneLabel.Text = client.HomePhone;
            officePhoneLabel.Text = client.OfficePhone;
            cellPhoneLabel.Text = client.CellPhone;
            emailLabel.Text = client.Email;


            balanceLabel.Text = client.Balance.ToString();
            discountLabel.Text = client.Discount.ToString();

            if (client.Sex == "Мужской")
                menButton.Checked = true;
            else if (client.Sex == "Женский")
                womanButton.Checked = true;

            noteTextBox1.Text = client.Note;
            whoIssuedPassportLabel.Text = client.WhoIssuedPassport;
            residenceAddressLabel.Text = client.ResidenceAddress;
        }

        private void Save1_Click(object sender, EventArgs e)
        {
            var db = new SQLiteClient();


        }

        private void Cancel1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
