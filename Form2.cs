using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ToolsRental;

namespace ToolRental
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            balanceLabel.Text = "0";
            discountLabel.Text = "0";
        }

        private void Save1_Click(object sender, EventArgs e)
        {
            var name = nameLabel.Text;
            var surname = surnameLabel.Text;
            var patronymic = patronymicLabel.Text;
            var city = cityLabel.Text;
            var passportStr = passportLabel.Text;

            
            if (!CheckInput(name, surname, patronymic, city, passportStr))
            {
                return;
            }

            var day = issueDateLabel1.Text;
            var month = issueDateLabel2.Text;
            var year = issueDateLabel3.Text;

            if (!CheckIssueDate(day, month, year))
            {
                return;
            }

            var passport = long.Parse(passportStr);

            var street = streetLabel.Text;
            var building = buildingLabel.Text;
            var apartment = apartmentLabel.Text;

            var homePhone = homePhoneLabel.Text;
            var officePhone = officePhoneLabel.Text;
            var cellPhone = cellPhoneLabel.Text;
            var email = emailLabel.Text;


            var balance = int.Parse(balanceLabel.Text);
            var discount = int.Parse(discountLabel.Text);

            var deposit = checkBox1.Checked;
            var note = noteTextBox1.Text;
            var issueDate = day + "-" + month + "-" + year;
            var whoIssuedPassport = whoIssuedPassportLabel.Text;
            var residenceAddress = residenceAddressLabel.Text;

            if (!CheckSex(out var sex))
            {
                return;
            }

            var client = new Client(name, surname, patronymic, city, street, building, 
                apartment, sex, passport, issueDate, whoIssuedPassport, residenceAddress, 
                note, discount, balance, deposit, cellPhone, email, officePhone, homePhone);

            var db = new SQLiteClient();
            db.Clients.Add(client);
            db.SaveChanges();

            this.Hide();
        }

        private bool CheckIssueDate(string _day, string _month, string _year)
        {
            if (!int.TryParse(_day, out var day) || day <= 0 || day > 31)
            {
                issueDateLabel1.BackColor = Color.IndianRed;
                return false;
            }

            if (!int.TryParse(_month, out var month) || month <= 0 || month > 12)
            {
                issueDateLabel2.BackColor = Color.IndianRed;
                return false;
            }

            if (!int.TryParse(_year, out var year))
            {
                issueDateLabel3.BackColor = Color.IndianRed;
                return false;
            }

            return true;
        }

        private bool CheckSex(out string sex)
        {
            sex = "";
            if (menButton.Checked)
            {
                sex = menButton.Text;
                return true;
            }

            if (womanButton.Checked)
            {
                sex = womanButton.Text;
                return true;
            }

            return false;
        }

        private bool CheckInput(string name, string surname, string patronymic, string city, string passportStr)
        {
            if (string.IsNullOrEmpty(name))
            {
                nameLabel.BackColor = Color.IndianRed;
                return false;
            }

            if (string.IsNullOrEmpty(surname))
            {
                surnameLabel.BackColor = Color.IndianRed;
                return false;
            }

            if (string.IsNullOrEmpty(patronymic))
            {
                patronymicLabel.BackColor = Color.IndianRed;
                return false;
            }

            if (string.IsNullOrEmpty(city))
            {
                cityLabel.BackColor = Color.IndianRed;
                return false;
            }

            if (int.TryParse(passportStr, out var result))
            {
                passportLabel.BackColor = Color.IndianRed;
                return false;
            }

            return true;
        }

        private void Cancel1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void FillFields(Client client)
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

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
