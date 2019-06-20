using System.Data.Linq.Mapping;

namespace ToolsRental
{
    /*
     * may be client have to field organization then he can add organization properties
     */
    public sealed class Client
    {
        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Patronymic { get; private set; }

        public string Sex { get; private set; }

        public int Id { get; private set; }

        public string City { get; private set; }

        public string Street { get; private set; }

        public string Building { get; private set; }

        public string Apartment { get; private set; }

        public string HomePhone { get; private set; }

        public string OfficePhone { get; private set; }

        public string CellPhone { get; private set; }

        public string Email { get; private set; }

        public bool Deposit { get; private set; }

        public int Balance { get; private set; }

        public int Discount { get; private set; }

        public string Note { get; private set; }

        public long Passport { get; private set; }

        public string IssueDate { get; private set; }

        public string WhoIssuedPassport { get; private set; }

        public string ResidenceAddress { get; private set; }

        public Client() : this("", "", "", "", "", "", "", "Мужской", 0, "", "", "")
        {
        }

        public Client(string name, string surname, string patronymic, string city, 
            string street, string building, string apartment, string sex, long passport, string issueDate, 
            string whoIssuedPassport, string residenceAddress, string note = null, int discount = 0, int balance = 0, 
            bool deposit = false, string cellPhone = null, string email = null, string officePhone = null, string homePhone = null)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            City = city;
            Street = street;
            Building = building;
            Apartment = apartment;
            Sex = sex;
            Passport = passport;
            IssueDate = issueDate;
            WhoIssuedPassport = whoIssuedPassport;
            ResidenceAddress = residenceAddress;
            Note = note;
            Discount = discount;
            Balance = balance;
            Deposit = deposit;
            CellPhone = cellPhone;
            Email = email;
            OfficePhone = officePhone;
            HomePhone = homePhone;

            Id = GetHashCode();
        }

        public long GetPassportHash()
        {
            unchecked
            {
                return Passport * 1023 + 8087;
            }
        }

        public long ParseHashToPassport(int hash)
        {
            unchecked
            {
                return (hash - 8087) / 1023;
            }
        }

        public sealed override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public sealed override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
